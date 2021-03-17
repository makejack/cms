<template>
  <div>
    <div class="toolbar">
      <h2>员工管理</h2>
      <div class="toolbar-btn-group">
        <el-button type="primary" @click="$router.push({ name: 'UserInfo' })"
          >添加</el-button
        >
      </div>
    </div>
    <el-table v-loading="loading" :data="tableData" border>
      <el-table-column label="用户名" prop="userName"></el-table-column>
      <el-table-column label="手机号" prop="tel"></el-table-column>
      <el-table-column label="邮箱" prop="email"></el-table-column>
      <el-table-column label="角色" prop="role" :formatter="formatRole">
      </el-table-column>
      <el-table-column
        label="登录时间"
        prop="lastLoginTime"
        :formatter="formatDateTime"
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
  </div>
</template>

<script>
import { UserList, DeleteUser } from "../../api/user";
import { UserRoles } from "../../utils/constant";

export default {
  name: "UserList",
  data() {
    return {
      loading: false,
      tableData: [],
    };
  },
  methods: {
    formatDate(row, column, cellValue) {
      return this.$moment(cellValue).format("YYYY-MM-DD");
    },
    formatDateTime(row, column, cellValue) {
      return this.$moment(cellValue).format("YYYY-MM-DD HH:mm:ss");
    },
    formatRole(row, column, cellValue) {
      var role = UserRoles.find((item) => {
        return item.key == cellValue;
      });
      if (role) {
        return role.title;
      }
    },
    editHandle(row) {
      this.$router.push({ name: "UserInfo", query: { id: row.id } });
    },
    deleteHandle(row) {
      this.$confirm("确认是否删除用户数据?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          DeleteUser(row.id).then((res) => {
            if (res.code === 0) {
              this.$message({
                type: "success",
                message: "删除成功",
              });

              this.loadUsers();
            }
          });
        })
        .catch(() => {});
    },
    loadUsers() {
      this.loading = true;
      UserList()
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
    this.loadUsers();
  },
};
</script>
