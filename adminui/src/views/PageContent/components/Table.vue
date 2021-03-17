<template>
  <div>
    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column label="ID" prop="id"></el-table-column>
      <el-table-column label="标题" prop="title"></el-table-column>
      <el-table-column label="所属菜单" prop="menuName"></el-table-column>
      <el-table-column label="是否发布" prop="isPublished">
        <template slot-scope="scope">
          <el-tag v-if="scope.row.isPublished">已发布</el-tag>
          <el-tag v-else type="info">未发布</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="浏览量" prop="pageviews"></el-table-column>
      <el-table-column
        label="创建时间"
        prop="createTime"
        :formatter="formatDate"
      ></el-table-column>
      <el-table-column label="操作" width="100px">
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
import { ContentList, ContentDelete } from "../../../api/pageContent";

export default {
  name: "PageContentTable",
  props: ["value"],
  watch: {
    value(val) {
      this.pagination.menuId = val;
      this.loadContent();
    },
  },
  data() {
    return {
      loading: false,
      tableData: [],
      totalRows: 0,
      pagination: {
        menuId: this.value,
        page: 1,
        limit: 10,
      },
    };
  },
  methods: {
    editHandle(row) {
      this.$router.push({
        name: "PageContentInfo",
        query: { id: row.id, model: row.menuModel },
      });
    },
    deleteHandle(row) {
      this.$confirm("确认是否删除内容数据?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          ContentDelete(row.id).then((res) => {
            if (res.code === 0) {
              this.$message({
                type: "success",
                message: "删除成功",
              });

              this.loadContent();
            }
          });
        })
        .catch(() => {});
    },
    formatDate(row, column, cellValue) {
      return this.$moment(cellValue).format("YYYY-MM-DD");
    },
    sizeChange(val) {
      this.pagination.limit = val;
      this.loadContent();
    },
    currentChange(val) {
      this.pagination.page = val;
      this.loadContent();
    },
    loadContent() {
      this.loading = true;
      ContentList(this.pagination)
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
    this.loadContent();
  },
  created() {
    if (this.$route.query.key) {
      this.pagination.menuId = this.$route.query.key;
    }
  },
};
</script>