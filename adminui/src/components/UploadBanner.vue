<template>
  <el-input
    placeholder="上传图片或远程图片地址"
    v-model="bannerImg"
    class="input-with-select"
  >
    <el-popover slot="prepend" placement="top-start" trigger="hover">
      <el-image v-if="bannerImg" :src="bannerImg" fit="contain"></el-image>
      <i class="el-icon-picture" slot="reference"></i>
    </el-popover>

    <el-upload
      slot="append"
      action="#"
      :show-file-list="false"
      :before-upload="beforetImageUpload"
      :http-request="uploadImage"
    >
      <el-button icon="el-icon-upload">上传文件</el-button>
    </el-upload>
  </el-input>
</template>

<script>
import { UploadImg } from "../api/media";
import { fileSuffixTypeUtil } from "../utils/file";

export default {
  name: "UploadBanner",
  props: ["value"],
  watch: {
    value(val) {
      this.bannerImg = val;
    },
    bannerImg(val) {
      this.$emit("input", val);
    },
  },
  data() {
    return {
      bannerImg: this.value,
    };
  },
  methods: {
    uploadImage(file) {
      var formData = new FormData();
      formData.append("file", file.file);
      UploadImg(formData)
        .then((res) => {
          if (res.code === 0) {
            this.bannerImg = res.data.host + res.data.url;
          }
        })
        .catch(() => {
          this.$message.error("请求失败");
        });
    },
    beforetImageUpload(file) {
      // const imgTypes = ["image/jpeg", "image/png", "image/x-icon"];
      var type = fileSuffixTypeUtil.matchFileSuffixType(file.name);
      const isImg = type === "image"; // imgTypes.indexOf(file.type) !== -1;
      const isLt5M = file.size / 1024 / 1024 < 5;

      if (!isImg) {
        this.$message.error("上传图片只能是 JPG PNG GIF ICO ICON 格式!");
      }
      if (!isLt5M) {
        this.$message.error("上传图片大小不能超过 5MB!");
      }

      return isImg && isLt5M;
    },
  },
};
</script>