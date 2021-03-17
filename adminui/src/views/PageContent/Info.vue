<template>
  <div v-loading="loading">
    <div class="toolbar">
      <h2>{{ contentId === 0 ? "新增内容" : "编辑内容" }}</h2>
      <div>
        <el-button type="primary" @click="saveHandle">保存</el-button>
        <el-button @click="returnHandle">返回</el-button>
      </div>
    </div>

    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-form-item label="标题" prop="title">
        <el-input v-model="form.title" placeholder="标题"></el-input>
      </el-form-item>

      <el-form-item label="所属菜单" prop="navMenuId">
        <select-menu
          v-model="form.navMenuId"
          :filterModel="menuModel"
        ></select-menu>
      </el-form-item>

      <el-form-item
        v-if="menuModel === 2"
        label="文件列表"
        class="form-item-line-height-normal"
      >
        <file-list v-model="form.downloadFiles"></file-list>
      </el-form-item>

      <el-form-item label="缩略图" prop="thumbnail">
        <upload-image v-model="form.thumbnail"></upload-image>
      </el-form-item>

      <el-form-item label="内容" prop="content">
        <quill-editor v-model="form.content"></quill-editor>
      </el-form-item>

      <el-form-item label="是否发布">
        <el-switch v-model="form.isPublished"></el-switch>
      </el-form-item>

      <el-divider>SEO设置</el-divider>

      <el-form-item label="SEO标题" prop="websiteTitle">
        <el-input v-model="form.websiteTitle" placeholder="SEO标题"></el-input>
      </el-form-item>

      <el-form-item label="SEO关键字" prop="websiteKeywords">
        <el-input
          v-model="form.websiteKeywords"
          placeholder="SEO关键字"
        ></el-input>
        <span>多个关键词请用英文逗号（,）隔开，建议3到5个关键词。</span>
      </el-form-item>

      <el-form-item label="SEO描述" prop="websiteDescription">
        <el-input
          v-model="form.websiteDescription"
          type="textarea"
          :rows="3"
          maxlength="200"
          show-word-limit
          placeholder="SEO描述"
        ></el-input>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import {
  ContentDetail,
  ContentCreate,
  ContentEdit,
} from "../../api/pageContent";
import QuillEditor from "../../components/QuillEditor";
import UploadImage from "../../components/UploadImage";
import SelectMenu from "../../components/SelectMenu";
import FileList from "./components/FileList";

export default {
  name: "PageContentInfo",
  components: {
    QuillEditor,
    UploadImage,
    SelectMenu,
    FileList,
  },
  data() {
    return {
      contentId: 0,
      menuModel: 0,
      loading: false,
      form: {
        content: "",
        downloadFiles: [],
        id: 0,
        isPublished: true,
        navMenuId: "",
        thumbnail: "",
        title: "",
        websiteDescription: "",
        websiteKeywords: "",
        websiteTitle: "",
      },
      rules: {
        title: [
          {
            required: true,
            message: "请输入标题",
            trigger: "blur",
          },
        ],
        navMenuId: [
          {
            required: true,
            message: "请选择菜单",
            trigger: "blur",
          },
        ],
      },
    };
  },
  methods: {
    saveHandle() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.loading = true;
          if (this.contentId > 0) {
            ContentEdit(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ path: "/content" });
                }
              })
              .catch(() => {
                this.loading = false;
              });
          } else {
            ContentCreate(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ path: "/content" });
                }
              })
              .catch(() => {
                this.loading = false;
              });
          }
        }
      });
    },
    returnHandle() {
      this.$router.push({
        path: "/content",
        query: { key: this.form.navMenuId },
      });
    },
    loadContent() {
      if (this.contentId > 0) {
        this.loading = true;
        ContentDetail(this.contentId)
          .then((res) => {
            this.loading = false;
            if (res.code === 0) {
              this.form = res.data;
            }
          })
          .catch(() => {
            this.loading = false;
          });
      }
    },
  },
  mounted() {
    this.loadContent();
  },
  created() {
    if (this.$route.query.id) {
      this.contentId = this.$route.query.id;
    }
    if (this.$route.query.menuId) {
      this.form.navMenuId = this.$route.query.menuId;
    }
    if (this.$route.query.model) {
      this.menuModel = parseInt(this.$route.query.model);
    }
  },
};
</script>
