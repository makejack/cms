<template>
  <div class="login-container">
    <div class="login-card">
      <h1 class="login-header">Register</h1>
      <div class="login-form">
        <el-form :model="form" ref="form" :rules="rules">
          <el-form-item prop="userName">
            <el-input v-model="form.userName" placeholder="请输入账号">
              <i slot="prefix" class="el-input__icon el-icon-user"></i>
            </el-input>
          </el-form-item>
          <el-form-item prop="password">
            <el-input
              v-model="form.password"
              placeholder="请输入密码"
              show-password
            >
              <i slot="prefix" class="el-input__icon el-icon-key"></i>
            </el-input>
          </el-form-item>
          <el-form-item prop="tel">
            <el-input v-model="form.tel" placeholder="手机号">
              <i slot="prefix" class="el-input__icon"></i>
            </el-input>
          </el-form-item>
          <el-form-item prop="email">
            <el-input v-model="form.email" placeholder="邮箱">
              <i slot="prefix" class="el-input__icon"></i>
            </el-input>
          </el-form-item>
          <el-form-item>
            <el-button
              type="primary"
              class="w-100"
              :loading="loading"
              @click="register"
              >注 册</el-button
            >
          </el-form-item>
        </el-form>
      </div>
    </div>
  </div>
</template>

<script>
import { Register } from "@/api/auth";
import { isTel, isEmail } from "../../utils/validate";

export default {
  name: "Register",
  data() {
    return {
      loading: false,
      form: {
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
    register() {
      this.$refs["form"].validate((valid) => {
        if (!valid) return;
        this.loading = true;
        Register(this.form)
          .then((res) => {
            this.loading = false;
            if (res.code == 0) {
              this.$router.push({ name: "Login" });
            }
          })
          .catch(() => {
            this.loading = false;
          });
      });
    },
  },
};
</script>

<style scoped>
.login-container {
  height: 100%;
  display: flex;
  align-items: center;
}

.login-header {
  padding: 20px 0;
  text-align: center;
  margin-bottom: 20px;
}

.login-card {
  width: 380px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-shadow: 5px 5px 10px #ccc;
}
</style>