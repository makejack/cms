<template>
  <div>
    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column
        v-for="(item, index) in headers"
        :key="index"
        :label="item.name"
        :prop="'value.' + item.name"
      >
      </el-table-column>
      <el-table-column
        label="创建时间"
        prop="createTime"
        :formatter="formatDate"
      ></el-table-column>
      <el-table-column label="操作" width="100px">
        <template slot-scope="scope">
          <el-button type="text" @click="editHandle(scope.row)">查看</el-button>
          <el-button type="text" @click="deleteHandle(scope.row)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <div class="pagination">
      <el-pagination
        background
        layout="prev, pager, next"
        :total="totalRows"
        :current-page="pagination.page"
        :page-size="pagination.limit"
        @size-change="sizeChange"
        @current-change="currentChange"
      >
      </el-pagination>
    </div>

    <el-dialog title="表单详情" :visible.sync="dialogVisible">
      <div v-for="(item, key) in viewForm" :key="key" class="view-item">
        <span class="view-item-title">{{ key }}:</span>
        <div v-if="isImage(item)">
          <el-popover placement="top-start" trigger="hover">
            <el-image :src="item"></el-image>
            <el-link :href="item" slot="reference" target="_blank"
              >图片链接</el-link
            >
          </el-popover>
        </div>
        <div v-else>{{ item }}</div>
      </div>
      <div class="view-item">
        <span>创建时间:</span>
        {{ $moment(viewForm.createTime).format("YYYY-MM-DD HH:mm:ss") }}
      </div>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="dialogVisible = false"
          >确 定</el-button
        >
      </div>
    </el-dialog>
  </div>
</template>

<script>
import { CustomFormValueTable, CustomFormValueDelete } from "@/api/customForm";
import { fileSuffixTypeUtil } from "@/utils/file";

export default {
  name: "CustomFormTable",
  props: ["value"],
  watch: {
    value(val) {
      this.pagination.menuId = val;
      this.loadTable();
    },
  },
  data() {
    return {
      loading: false,
      dialogVisible: false,
      headers: [],
      tableData: [],
      totalRows: 0,
      pagination: {
        menuId: this.value,
        page: 1,
        limit: 10,
      },
      viewForm: {},
    };
  },
  methods: {
    formatDate(row, column, cellValue) {
      return this.$moment(cellValue).format("YYYY-MM-DD HH:mm:ss");
    },
    isImage(url) {
      var type = fileSuffixTypeUtil.matchFileSuffixType(url);
      return type === "image";
    },
    sizeChange(val) {
      this.pagination.limit = val;
      this.loadTable();
    },
    currentChange(val) {
      this.pagination.page = val;
      this.loadTable();
    },
    deleteHandle(row) {
      this.$confirm("确认是否删除内容数据?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          CustomFormValueDelete(row.id).then((res) => {
            if (res.code === 0) {
              this.$message({
                type: "success",
                message: "删除成功",
              });

              this.loadTable();
            }
          });
        })
        .catch(() => {});
    },
    editHandle(row) {
      this.viewForm = row.value;
      this.dialogVisible = true;
    },
    loadTable() {
      this.loading = true;
      CustomFormValueTable(this.pagination)
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.headers = res.data.headers;
            this.tableData = res.data.table.result;
            this.tableData.forEach((item) => {
              item.value = JSON.parse(item.value);
            });
            this.totalRows = res.data.table.totalRows;
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    this.loadTable();
  },
};
</script>

<style scoped>
.view-item {
  margin-bottom: 10px;
  font-size: 20px;
}
.view-item .view-item-title {
  display: block;
  float: left;
  text-align: right;
  width: 120px;
  margin-right: 10px;
}
</style>