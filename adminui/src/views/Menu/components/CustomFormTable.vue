<template>
  <div>
    <div class="table-toolber">
      <el-button type="primary" @click="dialogVisible = true">新增</el-button>
    </div>
    <el-table :data="tableData" border>
      <el-table-column label="属性标题" prop="name"></el-table-column>
      <el-table-column
        label="属性类型"
        prop="typeDescription"
      ></el-table-column>
      <el-table-column label="列表显示" prop="isShowList">
        <template slot-scope="scope">
          <el-tag v-if="scope.row.isShowList" type="success">显示</el-tag>
          <el-tag v-else type="info">不显示</el-tag>
        </template>
      </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button
            type="text"
            @click="editCustomForm(scope.row, scope.$index)"
            >编辑</el-button
          >
          <el-button type="text" @click="removeCustomForm(scope.$index)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>

    <el-dialog
      title="设置属性"
      :visible.sync="dialogVisible"
      @closed="closeDialog"
    >
      <el-form :model="form" ref="form" :rules="rules" label-width="120px">
        <el-form-item label="属性名称" prop="name">
          <el-input v-model="form.name"></el-input>
        </el-form-item>
        <el-form-item label="属性类型" prop="type">
          <el-select v-model="form.type">
            <el-option
              v-for="item in CustomParamTypes"
              :key="item.key"
              :label="item.title"
              :value="item.key"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="必需请求" prop="isRequired">
          <el-switch v-model="form.isRequired"> </el-switch>
        </el-form-item>
        <el-form-item label="显示列表" prop="isShowList">
          <el-switch v-model="form.isShowList"> </el-switch>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="setCustomForm">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import { CustomParamTypes } from "../../../utils/constant";

export default {
  name: "WebisteCustomFormTable",
  props: ["value"],
  watch: {
    value(val) {
      this.tableData = val;
    },
    tableData(val) {
      this.$emit("input", val);
    },
  },
  data() {
    return {
      tableData: this.value,
      dialogVisible: false,
      CustomParamTypes,
      editIndex: -1,
      form: {
        id: 0,
        name: "",
        type: 0,
        isRequired: true,
        isShowList: true,
      },
      rules: {
        name: [
          {
            required: true,
            message: "请输入属性名称",
            trigger: "blur",
          },
        ],
      },
    };
  },
  methods: {
    closeDialog() {
      this.editIndex = -1;
      this.form = {
        id: 0,
        name: "",
        type: 0,
        typeDescription: "",
        isRequired: true,
        isShowList: true,
      };
    },
    setCustomForm() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.form.typeDescription = CustomParamTypes.find((item) => {
            return item.key == this.form.type;
          }).title;
          if (this.editIndex > -1) {
            this.$set(this.tableData, this.editIndex, this.form);
          } else {
            this.tableData.push(JSON.parse(JSON.stringify(this.form)));
          }
          this.dialogVisible = false;
        }
      });
    },
    removeCustomForm(index) {
      this.tableData = this.tableData.filter((item, rowIndex) => {
        return rowIndex !== index;
      });
    },
    editCustomForm(row, index) {
      this.editIndex = index;
      this.form = JSON.parse(JSON.stringify(row));
      this.dialogVisible = true;
    },
  },
};
</script>

<style scoped>
.table-toolber {
  margin-bottom: 10px;
}
</style>