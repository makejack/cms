<template>
  <el-menu router :default-active="activeMenu">
    <!-- <el-menu-item index="/product">
      <i class="el-icon-menu"></i>
      <span slot="title">产品中心</span>
    </el-menu-item>
    <el-menu-item index="/solution">
      <i class="el-icon-menu"></i>
      <span slot="title">解决方案</span>
    </el-menu-item>
    <el-menu-item index="/category">
      <i class="el-icon-menu"></i>
      <span slot="title">分类管理</span>
    </el-menu-item>
    <el-menu-item index="/news">
      <i class="el-icon-menu"></i>
      <span slot="title">新闻中心</span>
    </el-menu-item>
    <el-menu-item index="/onlinemessage">
      <i class="el-icon-menu"></i>
      <span slot="title">在线留言</span>
    </el-menu-item>
    <el-menu-item index="/offlinestore">
      <i class="el-icon-menu"></i>
      <span slot="title">线下门店</span>
    </el-menu-item>
    <el-menu-item index="/warrantyactivation">
      <i class="el-icon-menu"></i>
      <span slot="title">保修激活</span>
    </el-menu-item> -->

    <el-menu-item index="/menu">
      <i class="el-icon-menu"></i>
      <span slot="title">菜单管理</span>
    </el-menu-item>
    <el-menu-item index="/content">
      <i class="el-icon-menu"></i>
      <span slot="title">内容管理</span>
    </el-menu-item>
    <el-menu-item index="/template">
      <i class="el-icon-menu"></i>
      <span slot="title">模板管理</span>
    </el-menu-item>
    <el-menu-item index="/websitesetting">
      <i class="el-icon-menu"></i>
      <span slot="title">基础设置</span>
    </el-menu-item>
    <el-menu-item index="/user">
      <i class="el-icon-menu"></i>
      <span slot="title">员工管理</span>
    </el-menu-item>
  </el-menu>
</template>

<script>
export default {
  computed: {
    activeMenu() {
      const { path } = this.$route;

      return path;
    },
  },
};
</script>