<template>
  <el-select v-model="categoryId" :loading="loading" placeholder="请选择">
    <el-option
      v-for="item in data"
      :key="item.id"
      :label="item.title"
      :value="item.id"
    >
    </el-option>
  </el-select>
</template>

<script>
import { CategoryAll } from "../api/category";

export default {
  name: "Category",
  props: {
    value: {
      required: true,
    },
    type: {
      required: true,
    },
  },
  watch: {
    value(val) {
      this.categoryId = val;
    },
    categoryId(val) {
      this.$emit("input", val);
    },
  },
  data() {
    return {
      loading: false,
      categoryId: this.value,
      categoryType: this.type,
      data: [],
    };
  },
  methods: {
    LoadCategory() {
      this.loading = true;
      CategoryAll({ type: this.type })
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.data = res.data;
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    this.LoadCategory();
  },
};
</script>