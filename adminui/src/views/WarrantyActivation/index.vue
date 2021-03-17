<template>
  <div>
    <div class="toolbar">
      <h2>保修激活</h2>
    </div>
    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column label="图片" prop="imgUrl">
        <template slot-scope="scope">
          <el-image
            style="width: 100px; height: 100px"
            :src="scope.row.imgUrl"
            :preview-src-list="generatePreviewList"
          >
          </el-image>
        </template>
      </el-table-column>
      <el-table-column label="序列号" prop="serialNumber"></el-table-column>
      <el-table-column label="用户称呼" prop="userName"></el-table-column>
      <el-table-column label="邮箱" prop="email"></el-table-column>
      <el-table-column label="手机号" prop="tel"></el-table-column>
      <el-table-column label="代理商名称" prop="agentName"></el-table-column>
      <el-table-column label="购买日期" prop="purchaseDate"></el-table-column>
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
import { WarrantyActivationList } from "../../api/warrantyactivation";

export default {
  name: "WarrantyActivation",
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
      this.loadWarrantyActivation();
    },
    currentChange(val) {
      this.pagination.page = val;
      this.loadWarrantyActivation();
    },
    generatePreviewList(row) {
      var array = [];
      array.push(row.imgUrl);
      return array;
    },
    loadWarrantyActivation() {
      this.loading = true;
      WarrantyActivationList(this.pagination)
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
    this.loadWarrantyActivation();
  },
};
</script>
