<template>
  <div v-loading="loading">
    <div class="toolbar">
      <h2>{{ offlineStoreId === 0 ? "新增门店" : "编辑门店" }}</h2>
      <div>
        <el-button type="primary" @click="saveHandle">保存</el-button>
        <el-button @click="returnHandle">返回</el-button>
      </div>
    </div>

    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-form-item label="门店名称" prop="storeName">
        <el-input v-model="form.storeName" placeholder="门店名称"></el-input>
      </el-form-item>
      <el-form-item label="封面" prop="imageUrl">
        <upload-image v-model="form.imageUrl"></upload-image>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import UploadImage from "@/components/UploadImage.vue";
import {
  OfflinestoreDetail,
  OfflinestoreCreate,
  OfflinestoreEdit,
} from "../../api/offlineStore";

export default {
  name: "NewsInfo",
  components: {
    UploadImage,
  },
  data() {
    return {
      offlineStoreId: 0,
      loading: false,
      form: {
        id: 0,
        imageUrl: "",
        storeName: "",
      },
      rules: {
        storeName: [
          {
            required: true,
            message: "请输入标题",
            trigger: "blur",
          },
        ],
        imageUrl: [
          {
            required: true,
            message: "请选择图片",
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
          if (this.offlineStoreId > 0) {
            OfflinestoreEdit(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "OfflineStore" });
                }
              })
              .catch(() => {
                this.loading = false;
              });
          } else {
            OfflinestoreCreate(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "OfflineStore" });
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
      this.$router.push({ name: "OfflineStore" });
    },
  },
  mounted() {
    if (this.offlineStoreId > 0) {
      this.loading = true;
      OfflinestoreDetail(this.offlineStoreId)
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
      this.offlineStoreId = this.$route.query.id;
    }
  },
};
</script>