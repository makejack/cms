<template>
  <div v-loading="loading">
    <div class="toolbar">
      <h2>{{ categoryId === 0 ? "新增分类" : "编辑分类" }}</h2>
      <div>
        <el-button type="primary" @click="saveHandle">保存</el-button>
        <el-button @click="returnHandle">返回</el-button>
      </div>
    </div>

    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-form-item label="标题" prop="title">
        <el-input v-model="form.title" placeholder="标题"></el-input>
      </el-form-item>
      <el-form-item label="类型" prop="type">
        <el-select v-model="form.type" placeholder="请选择">
          <el-option
            v-for="item in CategoryTypes"
            :key="item.key"
            :label="item.title"
            :value="item.key"
          >
          </el-option>
        </el-select>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import { CategoryTypes } from "../../utils/constant";
import {
  CategoryDetail,
  CategoryCreate,
  CategoryEdit,
} from "../../api/category";

export default {
  name: "ProductInfo",
  data() {
    return {
      categoryId: 0,
      loading: false,
      CategoryTypes,
      form: {
        id: 0,
        title: "",
        type: 0,
      },
      rules: {
        title: [
          {
            required: true,
            message: "请输入标题",
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
          if (this.categoryId > 0) {
            CategoryEdit(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "Category" });
                }
              })
              .catch(() => {
                this.loading = false;
              });
          } else {
            CategoryCreate(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "Category" });
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
      this.$router.push({ name: "Category" });
    },
  },
  mounted() {
    if (this.categoryId > 0) {
      this.loading = true;
      CategoryDetail(this.categoryId)
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
      this.categoryId = this.$route.query.id;
    }
  },
};
</script>
