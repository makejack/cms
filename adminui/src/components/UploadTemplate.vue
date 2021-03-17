<template>
  <el-upload
    class="box-inline"
    action="#"
    accept="text/html"
    :show-file-list="false"
    :before-upload="beforetUpload"
    :http-request="uploadTemplate"
  >
    <el-button icon="el-icon-upload">上传模板</el-button>
  </el-upload>
</template>

<script>
import { Upload } from "../api/media";

export default {
  name: "UploadTemplate",
  methods: {
    uploadTemplate(file) {
      var formData = new FormData();
      formData.append("file", file.file);
      formData.append("path", "uploads/templates");
      Upload(formData)
        .then((res) => {
          if (res.code === 0) {
            this.$emit("complete", res.data);
          }
        })
        .catch(() => {
          this.$message.error("请求失败");
        });
    },
    beforetUpload(file) {
      const isLt10M = file.size / 1024 / 1024 < 10;

      if (!isLt10M) {
        this.$message.error("上传文件大小不能超过 10MB!");
      }

      return isLt10M;
    },
  },
};
</script>