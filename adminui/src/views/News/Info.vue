<template>
  <div v-loading="loading">
    <div class="toolbar">
      <h2>{{ newsId === 0 ? "新增新闻" : "编辑新闻" }}</h2>
      <div>
        <el-button type="primary" @click="saveHandle">保存</el-button>
        <el-button @click="returnHandle">返回</el-button>
      </div>
    </div>

    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-form-item label="标题" prop="title">
        <el-input v-model="form.title" placeholder="标题"></el-input>
      </el-form-item>
      <el-form-item label="内容" prop="content">
        <quill-editor v-model="form.content" />
      </el-form-item>
      <el-form-item label="封面" prop="imageUrl">
        <upload-image v-model="form.imageUrl"></upload-image>
      </el-form-item>
      <el-form-item label="是否发布">
        <el-switch v-model="form.isPublished"></el-switch>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import QuillEditor from "../../components/QuillEditor";
import UploadImage from "@/components/UploadImage.vue";
import { NewsDetail, NewsCreate, NewsEdit } from "../../api/news";

export default {
  name: "NewsInfo",
  components: {
    QuillEditor,
    UploadImage,
  },
  data() {
    return {
      newsId: 0,
      loading: false,
      imageVisible: false,
      percentage: 0,
      form: {
        id: 0,
        imageUrl: "",
        title: "",
        content: "",
        isPublished: false,
      },
      rules: {
        title: [
          {
            required: true,
            message: "请输入标题",
            trigger: "blur",
          },
        ],
        content: [
          {
            required: true,
            message: "请输入内容",
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
          if (this.newsId > 0) {
            NewsEdit(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "News" });
                }
              })
              .catch(() => {
                this.loading = false;
              });
          } else {
            NewsCreate(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "News" });
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
      this.$router.push({ name: "News" });
    },
  },
  mounted() {
    if (this.newsId > 0) {
      this.loading = true;
      NewsDetail(this.newsId)
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
  created() {
    if (this.$route.query.id) {
      this.newsId = this.$route.query.id;
    }
  },
};
</script>