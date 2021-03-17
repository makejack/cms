<template>
  <div>
    <el-upload
      action="#"
      :show-file-list="false"
      :before-upload="beforetUpload"
      :http-request="uploadFile"
    >
      <el-button slot="trigger" type="primary" icon="el-icon-upload"
        >上传文件</el-button
      >
      <el-button
        style="margin-left: 10px"
        icon="el-icon-folder"
        @click="dialogVisible = true"
        >在线选择文件</el-button
      >
      <div slot="tip" class="el-upload__tip">上传文件不能超过10M</div>
    </el-upload>

    <el-table :data="tableData" border class="file-list">
      <el-table-column label="文件名" prop="fileName">
        <template slot-scope="scope">
          <el-link :href="'/' + scope.row.fileUrl">{{
            scope.row.fileName
          }}</el-link>
        </template>
      </el-table-column>
      <el-table-column label="标题" prop="title">
        <template slot-scope="scope">
          <el-input v-model="scope.row.title"></el-input>
        </template>
      </el-table-column>
      <el-table-column
        label="文件大小"
        prop="fileSize"
        :formatter="formatFileSize"
      ></el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button type="text" @click="removeHandle(scope.row, scope.$index)"
            >移除</el-button
          >
        </template>
      </el-table-column>
    </el-table>

    <file-table v-model="dialogVisible" @selectFile="pushData"></file-table>
  </div>
</template>

<script>
import { UploadFile } from "@/api/media";
import { renderSize } from "@/utils/format";
import FileTable from "@/components/FileTable";

export default {
  name: "FileList",
  components: {
    FileTable,
  },
  props: {
    value: {
      type: Array,
      required: true,
    },
  },
  watch: {
    value(val) {
      this.tableData = val;
    },
    tableData(val) {
      this.$emit("input", val);
    },
  },
  data() {
    return {
      tableData: this.value,
      dialogVisible: false,
    };
  },
  methods: {
    formatFileSize(row, col, cellValue) {
      return renderSize(cellValue);
    },
    uploadFile(file) {
      var formData = new FormData();
      formData.append("file", file.file);
      UploadFile(formData)
        .then((res) => {
          if (res.code === 0) {
            this.pushData(res.data);
          }
        })
        .catch(() => {
          this.$message.error("请求失败");
        });
    },
    pushData(data) {
      this.tableData.push({
        id: 0,
        fileName: data.fileName,
        fileUrl: data.fileUrl,
        title: data.fileName,
        fileSize: data.fileSize,
      });
    },
    beforetUpload(file) {
      const isLt10M = file.size / 1024 / 1024 < 10;

      if (!isLt10M) {
        this.$message.error("上传文件大小不能超过 10MB!");
      }

      return isLt10M;
    },
    removeHandle(row, index) {
      this.tableData = this.tableData.filter((item, rowindex) => {
        return rowindex !== index;
      });
    },
  },
};
</script>

<style scoped>
.file-list {
  margin-top: 10px;
}
</style>