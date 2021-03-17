<template>
  <div>
    <div class="toolbar">
      <h2>上传管理</h2>
      <div class="toolbar-btn-group">
        <el-button type="primary" @click="uploadHandle">上传</el-button>
        <el-button @click="tableData = []">清除</el-button>
        <el-button @click="$router.push({ name: 'Template', query: { path } })"
          >返回</el-button
        >
      </div>
    </div>

    <div id="drop_area" class="drop-box">
      <div v-if="tableData.length === 0" class="drop-prompt">
        <i class="el-icon-upload"></i>
        <div class="drop-text">
          将文件拖到此处，或 <el-button type="text">点击上传</el-button>
        </div>
      </div>

      <div v-else class="table-box">
        <el-table :data="tableData" border>
          <el-table-column
            label="文件名"
            prop="file.fullPath"
          ></el-table-column>
          <el-table-column
            label="文件大小"
            width="120px"
            prop="file.size"
            :formatter="formatFileSize"
          ></el-table-column>
          <el-table-column label="上传进度" width="120px" prop="percentage">
            <template slot-scope="scope">
              <el-progress
                :text-inside="true"
                :stroke-width="26"
                :percentage="scope.row.percentage"
                :status="scope.row.status"
              ></el-progress>
            </template>
          </el-table-column>
          <el-table-column label="上传进度" width="100px">
            <template slot-scope="scope">
              <el-button type="text" @click="removeHandle(scope.$index)"
                >删除</el-button
              >
            </template>
          </el-table-column>
        </el-table>
      </div>
    </div>
  </div>
</template>

<script>
import { renderSize } from "@/utils/format";
import { Upload } from "../../api/media";

export default {
  name: "UploadMultipleFile",
  data() {
    return {
      path: "",
      uploadIndex: 0,
      tableData: [],
    };
  },
  methods: {
    formatFileSize(row, col, cellValue) {
      return renderSize(cellValue);
    },
    drop(e) {
      e.stopPropagation();
      e.preventDefault(); //必填字段
      // let fileList = e.dataTransfer.files;

      let items = e.dataTransfer.items;
      if (items && items.length) {
        items.forEach((item) => {
          if (item.webkitGetAsEntry) {
            var entry = item.webkitGetAsEntry();
            if (entry.isFile) {
              entry.file((file) => {
                file.path = "";
                file.fullPath = file.name;
                this.addFile(file);
              });
            } else if (entry.isDirectory) {
              this.addFilesFormDirectory(entry, entry.name);
            }
          }
        });
      }
      console.log(this.tableData);
    },
    addFilesFormDirectory(directory, path) {
      const dirReader = directory.createReader();

      dirReader.readEntries((entries) => {
        entries.forEach((entry) => {
          if (entry.isFile) {
            // 如果是文件
            entry.file((file) => {
              file.path = path;
              file.fullPath = path + "/" + file.name;
              // 那么暴露出去的就是 '文件夹/q.jpg' 这种形式
              this.addFile(file);
            });
          } else if (entry.isDirectory) {
            // 递归处理
            this.addFilesFormDirectory(entry, path + "/" + entry.name);
          }
        });
      });
    },
    uploadHandle() {
      this.tableData.forEach((item, index) => {
        var formData = new FormData();
        formData.append("file", item.file);
        let uploadPath = this.path;
        if (this.path && item.file.path) {
          uploadPath = this.path + "\\" + item.file.path;
        } else if (!this.path && item.file.path) {
          uploadPath = item.file.path;
        }
        formData.append("path", uploadPath);

        Upload(formData, (progressEvent) => {
          let num = ((progressEvent.loaded / progressEvent.total) * 100) | 0;
          this.$set(this.tableData[index], "percentage", num);
        })
          .then((res) => {
            if (res.code !== 0) {
              this.$set(this.tableData[index], "status", "warning");
            }
          })
          .catch(() => {
            this.$set(this.tableData[index], "status", "warning");
          });
      });
    },
    addFile(file) {
      this.tableData.push({
        percentage: 0,
        status: "success",
        file: file,
      });
    },
    removeHandle(index) {
      this.tableData = this.tableData.filter((item, rowIndex) => {
        return rowIndex !== index;
      });
    },
  },
  mounted() {
    let _this = this;
    var dropbox = document.getElementById("drop_area");
    dropbox.addEventListener("drop", this.drop, false);
    dropbox.addEventListener("dragleave", function (e) {
      e.stopPropagation();
      e.preventDefault();
      _this.borderhover = false;
    });
    dropbox.addEventListener("dragenter", function (e) {
      e.stopPropagation();
      e.preventDefault();
      _this.borderhover = true;
    });
    dropbox.addEventListener("dragover", function (e) {
      e.stopPropagation();
      e.preventDefault();
      _this.borderhover = true;
    });
  },
  created() {
    if (this.$route.query.path) {
      this.path = this.$route.query.path;
    }
  },
};
</script>

<style scoped>
.drop-box {
  width: 100%;
}
.drop-prompt {
  text-align: center;
  padding-top: 140px;
  border: 1px dashed #d9d9d9;
  min-height: 400px;
}
.drop-prompt .el-icon-upload {
  font-size: 67px;
  color: #c0c4cc;
  margin: 0 0 16px;
  line-height: 50px;
}

.table-box {
  padding-bottom: 20px;
}
</style>