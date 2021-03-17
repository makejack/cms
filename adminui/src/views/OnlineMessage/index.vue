<template>
  <div>
    <div class="toolbar">
      <h2>在线留言</h2>
    </div>
    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column label="姓名" prop="userName"></el-table-column>
      <el-table-column label="手机号" prop="tel"></el-table-column>
      <el-table-column label="电子邮箱" prop="email"></el-table-column>
      <el-table-column label="留言信息" prop="message"></el-table-column>
      <el-table-column
        label="创建时间"
        prop="createTime"
        :formatter="formatDate"
      ></el-table-column>
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
import { OnlineMessageList } from "../../api/onlineMessage";

export default {
  name: "OnlineMessage",
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
      this.loadOnlineMessage();
    },
    currentChange(val) {
      this.pagination.page = val;
      this.loadOnlineMessage();
    },
    loadOnlineMessage() {
      this.loading = true;
      OnlineMessageList(this.pagination)
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
    this.loadOnlineMessage();
  },
};
</script>
