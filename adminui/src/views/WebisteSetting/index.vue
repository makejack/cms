<template>
  <div>
    <div class="toolbar">
      <h2>基础设置</h2>
      <div>
        <el-button type="primary" :disabled="loading" @click="saveHandle"
          >保存</el-button
        >
      </div>
    </div>

    <el-form
      v-loading="loading"
      :model="form"
      ref="form"
      :rules="rules"
      label-width="120px"
    >
      <el-form-item label="网站名称" prop="websiteName">
        <el-input v-model="form.websiteName" placeholder="网站名称"></el-input>
      </el-form-item>
      <el-form-item label="网站Logo" prop="websiteLogo">
        <upload-banner v-model="form.websiteLogo"></upload-banner>
      </el-form-item>
      <el-form-item label="地址栏图标" prop="websiteAddressIcon">
        <upload-banner v-model="form.websiteAddressIcon"></upload-banner>
      </el-form-item>
      <el-form-item label="网站标题" prop="websiteTitle">
        <el-input v-model="form.websiteTitle" placeholder="网站标题"></el-input>
      </el-form-item>
      <el-form-item label="网站地址" prop="websiteUrl">
        <el-input v-model="form.websiteUrl" placeholder="网站地址"></el-input>
      </el-form-item>
      <el-form-item label="SEO关键词" prop="websiteKeywords">
        <el-input
          v-model="form.websiteKeywords"
          placeholder="SEO关键字"
        ></el-input>
        <span>多个关键词请用英文逗号（,）隔开，建议3到5个关键词。</span>
      </el-form-item>
      <el-form-item label="SEO描述" prop="websiteDescription">
        <el-input
          type="textarea"
          :rows="3"
          maxlength="200"
          show-word-limit
          placeholder="SEO描述"
          v-model="form.websiteDescription"
        ></el-input>
      </el-form-item>
      <el-form-item label="版权信息" prop="copyright">
        <el-input v-model="form.copyright" placeholder="版权信息"></el-input>
      </el-form-item>
      <el-form-item label="备案号" prop="caseNumber">
        <el-input v-model="form.caseNumber" placeholder="备案号"></el-input>
      </el-form-item>

      <el-divider content-position="left"
        >自定义变量
        <el-button type="text" @click="dialogVisible = true"
          >管理</el-button
        ></el-divider
      >

      <el-form-item
        v-for="(item, index) in form.websiteCustomParams"
        :key="index"
        :label="item.name"
      >
        <el-input
          v-if="item.type === 0"
          v-model="item.value"
          :placeholder="item.name"
        ></el-input>
        <el-input
          v-else-if="item.type === 1"
          type="textarea"
          v-model="item.value"
          :placeholder="item.name"
        ></el-input>
        <upload-banner v-else v-model="item.value"></upload-banner>
      </el-form-item>
    </el-form>

    <el-dialog title="自定义变量管理" width="80%" :visible.sync="dialogVisible">
      <el-table :data="form.websiteCustomParams" border>
        <el-table-column prop="name" label="变量名称">
          <template slot-scope="scope">
            <el-input v-model="scope.row.name" :maxlength="32"></el-input>
          </template>
        </el-table-column>
        <el-table-column prop="type" label="表单类型" width="220px">
          <template slot-scope="scope">
            <el-select v-model="scope.row.type" placeholder="请选择">
              <el-option
                v-for="(item, index) in CustomParamTypes"
                :key="index"
                :label="item.title"
                :value="item.key"
              >
              </el-option>
            </el-select>
          </template>
        </el-table-column>
        <el-table-column label="操作" width="100px">
          <template slot-scope="scope">
            <el-button type="text" @click="removeCustomParam(scope.$index)"
              >删除</el-button
            >
          </template>
        </el-table-column>
      </el-table>

      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="addCustomParam">新增</el-button>
        <el-button type="primary" @click="dialogVisible = false"
          >确 定</el-button
        >
      </div>
    </el-dialog>
  </div>
</template>

<script>
import UploadBanner from "../../components/UploadBanner";
import { CustomParamTypes } from "../../utils/constant";
import {
  LoadWebsiteSetting,
  WebsiteSettingSave,
} from "../../api/websiteSetting";

export default {
  name: "WebsiteSetting",
  components: {
    UploadBanner,
  },
  data() {
    return {
      loading: false,
      dialogVisible: false,
      CustomParamTypes,
      form: {
        websiteName: "",
        websiteLogo: "",
        websiteAddressIcon: "",
        websiteTitle: "",
        websiteUrl: "",
        websiteKeywords: "",
        websiteDescription: "",
        copyright: "",
        caseNumber: "",
        websiteCustomParams: [],
      },
      rules: {
        websiteName: [
          {
            required: true,
            message: "请输入网站名称",
            trigger: "blur",
          },
        ],
        websiteTitle: [
          {
            required: true,
            message: "请输入网站名称",
            trigger: "blur",
          },
        ],
        websiteUrl: [
          {
            required: true,
            message: "请输入网站名称",
            trigger: "blur",
          },
        ],
      },
    };
  },
  methods: {
    removeCustomParam(index) {
      this.form.websiteCustomParams = this.form.websiteCustomParams.filter(
        (item, rowIndex) => {
          return index !== rowIndex;
        }
      );
    },
    addCustomParam() {
      this.form.websiteCustomParams.push({
        id: 0,
        name: "",
        value: "",
        type: 0,
      });
    },
    saveHandle() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.loading = true;
          WebsiteSettingSave(this.form)
            .then((res) => {
              this.loading = false;
              if (res.code === 0) {
                this.$message({
                  message: "保存成功",
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
    loadSetting() {
      this.loading = true;
      LoadWebsiteSetting()
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.form = res.data;
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    this.loadSetting();
  },
};
</script>

<style scoped>
.dialog-footer {
  display: flex;
  justify-content: space-between;
}
</style>