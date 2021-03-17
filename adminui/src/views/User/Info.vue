<template>
  <div v-loading="loading">
    <div class="toolbar">
      <h2>{{ form.id === 0 ? "新增员工" : "编辑员工" }}</h2>
      <div>
        <el-button type="primary" @click="saveHandle">保存</el-button>
        <el-button @click="returnHandle">返回</el-button>
      </div>
    </div>

    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-form-item label="用户名" prop="userName">
        <el-input v-model="form.userName" placeholder="请输入账号">
          <i slot="prefix" class="el-input__icon el-icon-user"></i>
        </el-input>
      </el-form-item>
      <el-form-item v-if="form.id === 0" label="密码" prop="password">
        <el-input
          v-model="form.password"
          placeholder="请输入密码"
          show-password
        >
          <i slot="prefix" class="el-input__icon el-icon-key"></i>
        </el-input>
      </el-form-item>
      <el-form-item label="手机号" prop="tel">
        <el-input v-model="form.tel" placeholder="手机号">
          <i slot="prefix" class="el-input__icon"></i>
        </el-input>
      </el-form-item>
      <el-form-item label="邮箱" prop="email">
        <el-input v-model="form.email" placeholder="邮箱">
          <i slot="prefix" class="el-input__icon"></i>
        </el-input>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import { UserDetail, CreateUser, EditUser } from "../../api/user";
import { isTel, isEmail } from "../../utils/validate";

export default {
  name: "UserInfo",
  data() {
    return {
      loading: false,
      form: {
        id: 0,
        userName: "",
        password: "",
        tel: "",
        email: "",
      },
      rules: {
        userName: [
          { required: true, message: "请输入账号", trigger: "blur" },
          {
            min: 6,
            max: 32,
            message: "长度在 6 到 32 个字符",
            trigger: "blur",
          },
        ],
        password: [
          { required: true, message: "请输入密码", trigger: "blur" },
          {
            min: 6,
            max: 32,
            message: "长度在 6 到 32 个字符",
            trigger: "blur",
          },
        ],
        tel: [
          {
            validator: isTel,
            trigger: "blur",
          },
        ],
        email: [{ validator: isEmail, trigger: "blur" }],
      },
    };
  },
  methods: {
    saveHandle() {
      this.$refs.form.validate((valid) => {
        if (!valid) return;
        this.loading = true;
        if (this.form.id) {
          EditUser(this.form)
            .then((res) => {
              this.loading = false;
              if (res.code === 0) {
                this.$router.push({ name: "UserList" });
              } else {
                this.$message({
                  message: res.msg,
                  type: "warning",
                });
              }
            })
            .catch(() => {
              this.loading = false;
            });
        } else {
          CreateUser(this.form)
            .then((res) => {
              this.loading = false;
              if (res.code === 0) {
                this.$router.push({ name: "UserList" });
              } else {
                this.$message({
                  message: res.msg,
                  type: "warning",
                });
              }
            })
            .catch(() => {
              this.loading = false;
            });
        }
      });
    },
    returnHandle() {
      this.$router.push({ name: "UserList" });
    },
    loadUser() {
      this.loading = true;
      UserDetail(this.form.id)
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.form = res.data;
          } else {
            this.$message({
              message: res.msg,
              type: "warning",
            });
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    if (this.form.id) {
      this.loadUser();
    }
  },
  created() {
    if (this.$route.query.id) {
      this.form.id = this.$route.query.id;
    }
  },
};
</script>