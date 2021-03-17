<template>
  <div>
    <div class="toolbar">
      <h2>产品中心</h2>
      <div class="toolbar-btn-group">
        <el-button type="primary" @click="$router.push({ name: 'ProductInfo' })"
          >添加</el-button
        >
      </div>
    </div>
    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column label="标题" prop="title"></el-table-column>
      <el-table-column label="浏览量" prop="pageviews"></el-table-column>
      <el-table-column label="是否发布" prop="isPublished">
        <template slot-scope="scope">
          <el-tag v-if="scope.row.isPublished">已发布</el-tag>
          <el-tag v-else type="info">未发布</el-tag>
        </template>
      </el-table-column>
      <el-table-column
        label="更新时间"
        prop="lastUpdateTime"
        :formatter="formatDate"
      ></el-table-column>
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
import { ProductList, ProductDelete } from "../../api/product";

export default {
  name: "Product",
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
      this.loadProduct();
    },
    currentChange(val) {
      this.pagination.page = val;
      this.loadProduct();
    },
    editHandle(row) {
      this.$router.push({ name: "ProductInfo", query: { id: row.id } });
    },
    deleteHandle(row) {
      this.$confirm("确认是否删除产品数据?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          ProductDelete(row.id).then((res) => {
            if (res.code === 0) {
              this.$message({
                type: "success",
                message: "删除成功",
              });

              this.loadProduct();
            }
          });
        })
        .catch(() => {});
    },
    loadProduct() {
      this.loading = true;
      ProductList(this.pagination)
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
    this.loadProduct();
  },
};
</script>
