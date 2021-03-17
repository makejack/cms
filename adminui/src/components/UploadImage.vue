<template>
  <div>
    <el-progress
      v-if="imageVisible"
      type="circle"
      :percentage="percentage"
    ></el-progress>
    <el-upload
      v-if="!imageVisible"
      class="avatar-uploader"
      action="#"
      :show-file-list="false"
      :before-upload="beforetImageUpload"
      :http-request="uploadImage"
    >
      <img v-if="imageUrl" :src="imageUrl" class="avatar" />
      <i v-else class="el-icon-plus avatar-uploader-icon"></i>
    </el-upload>
  </div>
</template>

<script>
import { UploadImg } from "../api/media";

export default {
  name: "UploadImage",
  props: {
    value: {
      required: true,
      type: String,
      default: "",
    },
  },
  watch: {
    value(val) {
      this.imageUrl = val;
    },
    imageUrl(val) {
      this.$emit("input", val);
    },
  },
  data() {
    return {
      imageUrl: this.value,
      imageVisible: false,
      percentage: 0,
    };
  },
  methods: {
    uploadImage(file) {
      var formData = new FormData();
      formData.append("file", file.file);
      this.percentage = 0;
      this.imageVisible = true;
      UploadImg(formData, (progressEvent) => {
        let num = ((progressEvent.loaded / progressEvent.total) * 100) | 0;
        this.percentage = num;
      })
        .then((res) => {
          this.imageVisible = false;
          if (res.code === 0) {
            this.imageUrl = res.data.host + res.data.url;
          }
        })
        .catch(() => {
          this.imageVisible = false;
          this.$message.error("请求失败");
        });
    },
    beforetImageUpload(file) {
      const imgTypes = ["image/jpeg", "image/png"];
      const isImg = imgTypes.indexOf(file.type) !== -1;
      const isLt5M = file.size / 1024 / 1024 < 5;

      if (!isImg) {
        this.$message.error("上传图片只能是 JPG PNG 格式!");
      }
      if (!isLt5M) {
        this.$message.error("上传图片大小不能超过 5MB!");
      }

      return isImg && isLt5M;
    },
  },
};
</script>

<style scoped>
.avatar-uploader-icon {
  background-color: #fbfdff;
  font-size: 28px;
  color: #8c939d;
  width: 148px;
  height: 148px;
  line-height: 148px;
  text-align: center;
}
</style>