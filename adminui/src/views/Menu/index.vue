<template>
  <div>
    <div class="toolbar">
      <h2>菜单管理</h2>
      <div class="toolbar-btn-group">
        <el-button type="primary" @click="$router.push({ name: 'MenuInfo' })"
          >添加</el-button
        >
      </div>
    </div>
    <el-table
      v-loading="loading"
      :data="tableData"
      row-key="id"
      border
      default-expand-all
      :tree-props="{ children: 'children', hasChildren: 'hasChildren' }"
    >
      >
      <el-table-column label="ID" prop="id"></el-table-column>
      <el-table-column label="菜单名称" prop="menuName"></el-table-column>
      <el-table-column label="模型" prop="modelDescription"></el-table-column>
      <el-table-column label="是否隐藏" prop="isHidden" width="80px">
        <template slot-scope="scope">
          <el-tag v-if="scope.row.isHidden">隐藏</el-tag>
          <el-tag v-else type="info">否</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="排序" prop="order" width="180px">
        <template slot-scope="scope">
          <el-input-number
            v-model="scope.row.order"
            @change="orderChange(scope.$index, scope.row)"
            :min="0"
            :max="100"
            size="medium"
            class="input-number-limit-width"
          ></el-input-number>
        </template>
      </el-table-column>
      <el-table-column
        label="创建日期"
        prop="createTime"
        width="110px"
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
  </div>
</template>

<script>
import { MenuList, MenuDelete, MenuChangeOrder } from "../../api/menu";

export default {
  name: "Menu",
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
    orderChange(index, row) {
      MenuChangeOrder({ id: row.id, order: row.order })
        .then((res) => {
          if (res.code === 0) {
            this.$message({
              message: "修改成功",
              type: "success",
            });
          }
        })
        .catch(() => {
          this.$message({
            message: "请求失败",
            type: "error",
          });
        });
    },
    editHandle(row) {
      this.$router.push({ name: "MenuInfo", query: { id: row.id } });
    },
    deleteHandle(row) {
      this.$confirm("确认是否删除菜单数据?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          MenuDelete(row.id).then((res) => {
            if (res.code === 0) {
              this.$message({
                type: "success",
                message: "删除成功",
              });

              this.loadMenu();
            }
          });
        })
        .catch(() => {});
    },
    loadMenu() {
      this.loading = true;
      MenuList(this.pagination)
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.tableData = res.data;
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    this.loadMenu();
  },
};
</script>

<style scoped>
.input-number-limit-width {
  width: 150px;
}
</style>