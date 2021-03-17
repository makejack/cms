<template>
  <div>
    <div class="toolbar">
      <h2>模板管理</h2>
      <div class="toolbar-btn-group">
        <el-button
          type="primary"
          @click="$router.push({ name: 'Upload', query: { path } })"
          >上传</el-button
        >
        <el-button type="primary" @click="dialogVisible = true"
          >新建文件夹</el-button
        >
        <el-button type="primary" @click="createFile">新建文件</el-button>
      </div>
    </div>

    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column label="名称" prop="fileName">
        <template slot-scope="scope">
          <el-button
            v-if="scope.row.isFolder"
            type="text"
            icon="el-icon-folder-opened"
            @click="loadFolder(scope.row)"
            >{{ scope.row.fileName }}</el-button
          >
          <div v-else>{{ scope.row.fileName }}</div>
        </template>
      </el-table-column>
      <el-table-column label="大小" prop="fileSize" :formatter="formatFileSize">
      </el-table-column>
      <el-table-column label="操作" width="100px">
        <template slot-scope="scope">
          <el-button
            v-if="!scope.row.isFolder"
            type="text"
            @click="editHandle(scope.row)"
            >编辑</el-button
          >
        </template>
      </el-table-column>
    </el-table>

    <el-dialog
      title="创建文件夹"
      :visible.sync="dialogVisible"
      @closed="dialogClosed"
    >
      <el-form :model="form" ref="form" :rules="rules" label-width="120px">
        <el-form-item label="文件夹名称" prop="name">
          <el-input v-model="form.name" placeholder="文件夹名称"></el-input>
        </el-form-item>
      </el-form>
      <span slot="footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="createFolder">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import { fileSuffixTypeUtil } from "../../utils/file";
import { GetFiles, CreateFolder } from "@/api/media";
import { renderSize } from "@/utils/format";

export default {
  name: "Template",
  data() {
    return {
      loading: false,
      path: "uploads/templates",
      tableData: [],
      dialogVisible: false,
      form: {
        name: "",
      },
      rules: {
        name: [
          { required: true, message: "请输入文件夹名称", trigger: "blur" },
        ],
      },
    };
  },
  methods: {
    formatFileSize(row, col, cellValue) {
      if (!row.isFolder) return renderSize(cellValue);
    },
    editHandle(row) {
      var editList = ["javascript", "css", "html"];
      var fileType = fileSuffixTypeUtil.matchFileSuffixType(row.fileName);
      var index = editList.findIndex((item) => {
        return item == fileType;
      });
      if (index > -1) {
        var lastIndex = row.fileUrl.lastIndexOf("/");
        var fileName = "";
        if (lastIndex > -1) {
          fileName = row.fileUrl.substring(lastIndex + 1, row.fileUrl.length);
        }
        this.$router.push({
          name: "TemplateInfo",
          query: { path: this.path, file: fileName },
        });
      } else {
        this.$message({
          message: "文件不可编辑",
          type: "warning",
        });
      }
    },
    dialogClosed() {
      this.$refs.form.resetFields();
    },
    createFolder() {
      CreateFolder({ path: this.path, name: this.form.name })
        .then((res) => {
          if (res.code === 0) {
            this.dialogVisible = false;

            var params = {
              folder: this.path,
              root: this.path,
            };
            this.loadFiles(params);
          }
        })
        .catch(() => {});
    },
    createFile() {
      this.$router.push({
        name: "TemplateInfo",
        query: { path: this.path },
      });
    },
    loadFolder(row) {
      this.path = row.fileUrl;
      this.loadFiles({ folder: row.fileUrl });
    },
    loadFiles(params) {
      this.loading = true;
      GetFiles(params)
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.tableData = res.data;
          } else {
            this.$message({
              message: res.msg,
              type: "error",
            });
          }
        })
        .catch(() => {
          this.loading = false;
          this.$message({
            message: "请求失败",
            type: "error",
          });
        });
    },
  },
  mounted() {
    var params = {
      folder: this.path,
      root: this.path,
    };

    this.loadFiles(params);
  },
  created() {
    if (this.$route.query.path) {
      this.path = this.$route.query.path;
    }
  },
};
</script>