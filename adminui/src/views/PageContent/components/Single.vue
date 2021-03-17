<template>
  <div>
    <quill-editor v-loading="loading" v-model="form.content"></quill-editor>

    <div class="pagination">
      <el-button type="primary" @click="saveHandle" :disabled="loading"
        >保存</el-button
      >
    </div>
  </div>
</template>

<script>
import QuillEditor from "@/components/QuillEditor";
import {
  SingleContentDetail,
  ContentCreate,
  ContentEdit,
} from "@/api/pageContent";

export default {
  name: "PageContentSingle",
  components: {
    QuillEditor,
  },
  props: {
    value: {
      type: Number,
      required: true,
      default: undefined,
    },
  },
  watch: {
    value(val) {
      this.menuId = val;
      this.loadContent();
    },
  },
  data() {
    return {
      loading: false,
      menuId: this.value,
      form: {
        content: "",
        DownloadFiles: null,
        id: 0,
        isPublished: true,
        navMenuId: 0,
        thumbnail: null,
        title: "",
        websiteDescription: null,
        websiteKeywords: null,
        websiteTitle: null,
      },
    };
  },
  methods: {
    saveHandle() {
      this.loading = true;
      if (this.form.id === 0) {
        ContentCreate(this.form)
          .then((res) => {
            this.loading = false;
            if (res.code === 0) {
              this.$message({
                message: "保存成功",
                type: "success",
              });
            }
          })
          .catch(() => {
            this.loading = false;
          });
      } else {
        ContentEdit(this.form)
          .then((res) => {
            this.loading = false;
            if (res.code === 0) {
              this.$message({
                message: "保存成功",
                type: "success",
              });
            }
          })
          .catch(() => {
            this.loading = false;
          });
      }
    },
    loadContent() {
      this.loading = true;
      SingleContentDetail(this.menuId)
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.form = res.data;
            this.form.navMenuId = this.menuId;
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    this.loadContent();
  },
};
</script>