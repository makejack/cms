<template>
  <div>
    <div class="toolbar">
      <h2>线下门店</h2>
      <div class="toolbar-btn-group">
        <el-button type="primary" @click="$router.push({ name: 'OfflineStoreInfo' })"
          >添加</el-button
        >
      </div>
    </div>
    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column label="门店名称" prop="storeName"></el-table-column>
      <el-table-column
        label="创建时间"
        prop="createTime"
        :formatter="formatDate"
      ></el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button type="text" @click="editHandle(scope.row)">编辑</el-button>
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
  </div>
</template>

<script>
import { OfflinestoreList, OfflinestoreDelete } from "../../api/offlineStore";

export default {
  name: "OfflineStore",
  data() {
    return {
      loading: false,
      tableData: [],
      totalRows: 0,
      pagination: {
        page: 1,
        limit: 10,
      },
    };
  },
  methods: {
    formatDate(row, column, cellValue) {
      return this.$moment(cellValue).format("YYYY-MM-DD");
    },
    sizeChange(val) {
      this.pagination.limit = val;
      this.loadOfflineStore();
    },
    currentChange(val) {
      this.pagination.page = val;
      this.loadOfflineStore();
    },
    editHandle(row) {
      this.$router.push({ name: "OfflineStoreInfo", query: { id: row.id } });
    },
    deleteHandle(row) {
      this.$confirm("确认是否删除门店数据?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          OfflinestoreDelete(row.id).then((res) => {
            if (res.code === 0) {
              this.$message({
                type: "success",
                message: "删除成功",
              });

              this.loadOfflineStore();
            }
          });
        })
        .catch(() => {});
    },
    loadOfflineStore() {
      this.loading = true;
      OfflinestoreList(this.pagination)
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.tableData = res.data.result;
            this.totalRows = res.data.totalRows;
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    this.loadOfflineStore();
  },
};
</script>
