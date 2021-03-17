<template>
  <div>
    <div class="toolbar">
      <h2>分类管理</h2>
      <div class="toolbar-btn-group">
        <el-button
          type="primary"
          @click="$router.push({ name: 'CategoryInfo' })"
          >添加</el-button
        >
      </div>
    </div>
    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column label="标题" prop="title"></el-table-column>
      <el-table-column
        label="类型"
        prop="type"
        :formatter="formCategoryType"
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
import { CategoryList, CategoryDelete } from "../../api/category";
import { CategoryTypes } from "../../utils/constant";

export default {
  name: "News",
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
    formCategoryType(row, column, cellValue) {
      var first = CategoryTypes.find((item) => {
        return item.key == cellValue;
      });
      return first.title;
    },
    formatDate(row, column, cellValue) {
      return this.$moment(cellValue).format("YYYY-MM-DD");
    },
    sizeChange(val) {
      this.pagination.limit = val;
      this.loadCategory();
    },
    currentChange(val) {
      this.pagination.page = val;
      this.loadCategory();
    },
    editHandle(row) {
      this.$router.push({ name: "CategoryInfo", query: { id: row.id } });
    },
    deleteHandle(row) {
      this.$confirm("确认是否删除分类数据?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          CategoryDelete(row.id).then((res) => {
            if (res.code === 0) {
              this.$message({
                type: "success",
                message: "删除成功",
              });

              this.loadCategory();
            }
          });
        })
        .catch(() => {});
    },
    loadCategory() {
      this.loading = true;
      CategoryList(this.pagination)
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
    this.loadCategory();
  },
};
</script>
