<template>
  <el-dialog
    title="在线文件选择器"
    :visible.sync="dialogVisible"
    @open="loadFiles({ root: 'uploads/files' })"
  >
    <el-table
      v-loading="loading"
      :data="tableData"
      border
      highlight-current-row
      @current-change="handleCurrentChange"
    >
      <el-table-column label="名称" prop="fileName">
        <template slot-scope="scope">
          <el-link v-if="scope.row.isFolder" type="primary">
            <i class="el-icon-folder-opened"></i>
            {{ scope.row.fileName }}</el-link
          >
          <div v-else>{{ scope.row.fileName }}</div>
        </template>
      </el-table-column>
      <el-table-column label="大小" prop="fileSize" :formatter="formatFileSize">
      </el-table-column>
    </el-table>
    <div slot="footer">
      <el-button @click="dialogVisible = false">取 消</el-button>
      <el-button type="primary" @click="confirmHandle">确 定</el-button>
    </div>
  </el-dialog>
</template>

<script>
import { GetFiles } from "@/api/media";
import { renderSize } from "@/utils/format";

export default {
  name: "FileTable",
  props: {
    value: {
      type: Boolean,
      required: true,
      default: false,
    },
  },
  watch: {
    value(val) {
      this.dialogVisible = val;
    },
    dialogVisible(val) {
      this.$emit("input", val);
    },
  },
  data() {
    return {
      loading: false,
      dialogVisible: this.value,
      currentRow: null,
      tableData: [],
      selectedFile: null,
    };
  },
  methods: {
    formatFileSize(row, col, cellValue) {
      if (!row.isFolder) return renderSize(cellValue);
    },
    confirmHandle() {
      if (this.selectedFile) {
        this.$emit("selectFile", this.selectedFile);
      }
      this.dialogVisible = false;
    },
    handleCurrentChange(val) {
      if (!val) return;
      if (val.isFolder) {
        this.loadFiles({ folder: val.fileUrl });
      } else {
        this.selectedFile = val;
      }
    },
    loadFiles(params) {
      this.selectedFile = null;
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
};
</script>