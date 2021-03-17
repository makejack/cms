<template>
  <div v-loading="loading">
    <div class="toolbar">
      <h2>{{ productId === 0 ? "新增产品" : "编辑产品" }}</h2>
      <div>
        <el-button type="primary" @click="saveHandle">保存</el-button>
        <el-button @click="returnHandle">返回</el-button>
      </div>
    </div>

    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-form-item label="分类" prop="categoryId">
        <category v-model="form.categoryId" :type="0" />
      </el-form-item>
      <el-form-item label="标题" prop="title">
        <el-input v-model="form.title" placeholder="产品标题"></el-input>
      </el-form-item>
      <el-form-item label="描述" prop="content">
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
import QuillEditor from "@/components/QuillEditor";
import UploadImage from "@/components/UploadImage.vue";
import Category from "../../components/Category";
import { ProductGet, ProductCreate, ProductEdit } from "../../api/product";

export default {
  name: "ProductInfo",
  components: {
    QuillEditor,
    UploadImage,
    Category,
  },
  data() {
    return {
      productId: 0,
      loading: false,
      imageVisible: false,
      percentage: 0,
      form: {
        id: 0,
        categoryId: undefined,
        title: "",
        content: "",
        imageUrl: "",
        isPublished: false,
      },
      rules: {
        categoryId: [
          {
            required: true,
            message: "请选择分类",
            trigger: "blur",
          },
        ],
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
          if (this.productId > 0) {
            ProductEdit(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "Product" });
                }
              })
              .catch(() => {
                this.loading = false;
              });
          } else {
            ProductCreate(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "Product" });
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
      this.$router.push({ name: "Product" });
    },
  },
  mounted() {
    if (this.productId > 0) {
      this.loading = true;
      ProductGet(this.productId)
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
      this.productId = this.$route.query.id;
    }
  },
};
</script>
