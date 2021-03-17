<template>
  <div>
    <div class="toolbar">
      <h2>{{ title }}</h2>
      <div
        v-if="selectedTree.model === 1 || selectedTree.model === 2"
        class="toolbar-btn-group"
      >
        <el-button type="primary" @click="createHandle">添加</el-button>
      </div>
    </div>
    <div class="layout-container">
      <div class="tree-container">
        <el-tree
          v-loading="loading"
          ref="my-tree"
          :data="treeData"
          :props="defaultProps"
          highlight-current
          default-expand-all
          :expand-on-click-node="false"
          node-key="id"
          :current-node-key="currentNodeKey"
          @node-click="handleNodeClick"
        ></el-tree>
      </div>
      <div class="box-container">
        <router-view :name="routeName" v-model="selectedTree.id" />
      </div>
    </div>
  </div>
</template>

<script>
import { MenuList } from "../../api/menu";

export default {
  name: "PageContent",
  watch: {
    currentNodeKey(val) {
      if (val) {
        console.log(val);
        this.$refs["my-tree"].setCurrentKey(val);
      } else {
        this.$refs["my-tree"].setCurrentKey(null);
      }
    },
  },
  data() {
    return {
      title: "内容管理",
      defaultProps: {
        children: "children",
        label: "menuName",
      },
      treeData: [],
      selectedTree: Object,
      currentNodeKey: undefined,
      loading: false,
      routeName: "default",
    };
  },
  methods: {
    handleNodeClick(data) {
      switch (data.model) {
        case 0:
          this.routeName = "single";
          break;
        case 3:
          this.routeName = "form";
          break;
        default:
          this.routeName = "default";
          break;
      }
      this.title = data.menuName + " - 内容管理";
      this.selectedTree = data;
    },
    createHandle() {
      if (this.selectedTree.id) {
        this.$router.push({
          name: "PageContentInfo",
          query: {
            menuId: this.selectedTree.id,
            model: this.selectedTree.model,
          },
        });
      } else {
        this.$message({
          message: "请选择所属的菜单",
          type: "warning",
        });
      }
    },
    loadMenus() {
      this.loading = true;
      MenuList()
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.treeData = res.data;
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    this.loadMenus();
  },
  created() {
    if (this.$route.query.key) {
      this.currentNodeKey = Number.parseInt(this.$route.query.key);
    }
  },
};
</script>

<style scoped>
.layout-container {
  display: flex;
  flex: 1;
  flex-direction: row;
  flex-basis: auto;
}

.tree-container {
  flex-shrink: 0;
  width: 200px;
}

.box-container {
  flex: 1;
  flex-basis: auto;
}
</style>