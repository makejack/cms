<template>
  <div>
    <div class="toolbar">
      <h2>修改密码</h2>
    </div>
    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-form-item label="旧密码" prop="OldPassword">
        <el-input v-model="form.OldPassword" type="password"></el-input>
      </el-form-item>
      <el-form-item label="新密码" prop="NewPassword">
        <el-input v-model="form.NewPassword" type="password"></el-input>
      </el-form-item>
      <el-form-item label="确认密码" prop="confirmPwd">
        <el-input v-model="form.confirmPwd" type="password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" :loading="loading" @click="saveHandler"
          >保存</el-button
        >
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import { ChnagePwd } from "../../api/user";

export default {
  name: "ChangePwd",
  data() {
    var checkConfirmPwd = (rule, value, callback) => {
      if (value !== this.form.NewPassword) {
        callback(new Error("新密码与确认密码不一致"));
      } else {
        callback();
      }
    };
    return {
      loading: false,
      form: {
        OldPassword: "",
        NewPassword: "",
        confirmPwd: "",
      },
      rules: {
        OldPassword: [{ required: true, message: "请输入旧密码", trigger: "blur" }],
        NewPassword: [
          { required: true, message: "请输入新密码", trigger: "blur" },
          {
            min: 6,
            max: 32,
            message: "密码长度不正确 6-32",
            trigger: "blur",
          },
        ],
        confirmPwd: [
          { required: true, message: "请输入确认密码", trigger: "blur" },
          { validator: checkConfirmPwd, trigger: "blur" },
        ],
      },
    };
  },
  methods: {
    saveHandler() {
      this.$refs["form"].validate((valid) => {
        if (valid) {
          this.loading = true;
          ChnagePwd(this.form)
            .then((res) => {
              this.loading = false;
              if (res.code === 0) {
                this.$refs["form"].resetFields();
                this.$message({
                  message: "修改成功",
                  type: "success",
                });
              }
            })
            .catch(() => {
              this.loading = false;
            });
        }
      });
    },
  },
};
</script>
