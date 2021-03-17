<template>
  <el-select
    :loading="loading"
    v-model="selectId"
    clearable
    placeholder="请选择"
  >
    <div v-for="item in menus" :key="item.key">
      <el-option
        :label="item.menuName"
        :value="item.id"
        :disabled="item.disabled"
      >
      </el-option>
      <el-option
        v-for="child in item.children"
        :key="child.id"
        :label="child.menuName"
        :value="child.id"
        :disabled="child.disabled"
        style="text-indent: 20px"
      ></el-option>
    </div>
  </el-select>
</template>

<script>
import { MenuList } from "@/api/menu";

export default {
  name: "SelectMenu",
  props: ["value", "disabledId", "filterModel"],
  watch: {
    value(val) {
      this.selectId = val;
    },
    selectId(val) {
      this.$emit("input", val);
    },
  },
  data() {
    return {
      loading: false,
      selectId: this.value,
      disabledMenuId: this.disabledId,
      filterMenuModel: this.filterModel,
      menus: [],
    };
  },
  methods: {
    disabledMenu(data) {
      data.forEach((item) => {
        if (item.id == this.disabledMenuId) {
          this.$set(item, "disabled", true);
        } else if (item.children) {
          this.disabledMenu(item.children);
        }
      });
    },
    filterMenus(data) {
      return data.filter((item) => {
        if (item.children && item.children.length > 0) {
          item.children = this.filterMenus(item.children);
          if (item.model !== this.filterMenuModel && item.children.length > 0) {
            this.$set(item, "disabled", true);
            return item;
          }
        }
        return item.model === this.filterMenuModel;
      });
    },
    loadMenus() {
      this.loading = true;
      MenuList()
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.menus = res.data;
            if (this.disabledMenuId && this.disabledMenuId > 0) {
              this.disabledMenu(this.menus);
            }
            if (this.filterMenuModel > 0) {
              this.filterMenuModel = parseInt(this.filterMenuModel);
              this.menus = this.filterMenus(this.menus);
            }
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
};
</script>