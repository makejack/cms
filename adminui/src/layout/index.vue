<template>
  <el-container class="layout-container" direction="vertical">
    <el-header>
      <Header />
    </el-header>
    <el-container>
      <el-aside width="200px">
        <Navtion />
      </el-aside>
      <el-main>
        <router-view />
      </el-main>
    </el-container>
  </el-container>
</template>

<script>
import Header from "./components/Header.vue";
import Navtion from "./components/Navtion.vue";

export default {
  components: { Navtion, Header },
};
</script>

<style scoped>
.el-header {
  border-bottom: 1px solid #ccc;
}
</style>