<template>
  <div v-loading="loading">
    <div class="toolbar">
      <h2>{{ menuId === 0 ? "新增菜单" : "编辑菜单" }}</h2>
      <div>
        <el-button type="primary" @click="saveHandle">保存</el-button>
        <el-button @click="returnHandle">返回</el-button>
      </div>
    </div>

    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-tabs v-model="activeName">
        <el-tab-pane label="基础选项" name="first">
          <el-form-item label="菜单标题" prop="menuName">
            <el-input v-model="form.menuName" placeholder="标题"></el-input>
          </el-form-item>

          <el-form-item label="内容模型" prop="model">
            <el-select v-model="form.model" placeholder="请选择">
              <el-option
                v-for="item in MenuModels"
                :key="item.key"
                :label="item.title"
                :value="item.key"
              >
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="父级菜单" prop="parentId">
            <select-menu
              v-model="form.parentId"
              :disabledId="menuId"
            ></select-menu>
          </el-form-item>
          <el-form-item label="排序" prop="order">
            <el-input-number
              v-model="form.order"
              :min="0"
              :max="100"
            ></el-input-number>
          </el-form-item>
          <el-form-item label="是否隐藏">
            <el-switch v-model="form.isHidden"></el-switch>
          </el-form-item>
        </el-tab-pane>
        <el-tab-pane label="高级选项" name="second">
          <el-form-item label="菜单类型" prop="type">
            <el-radio-group v-model="form.type">
              <el-radio-button :label="0">内部菜单</el-radio-button>
              <el-radio-button :label="1">外部链接</el-radio-button>
            </el-radio-group>
          </el-form-item>
          <el-form-item
            v-if="form.type === 1"
            label="外部链接"
            prop="externalUrl"
          >
            <el-input
              v-model="form.externalUrl"
              placeholder="外部链接"
            ></el-input>
          </el-form-item>
          <el-form-item label="英文别名" prop="enMenuName">
            <el-input
              v-model="form.enMenuName"
              placeholder="英文别名"
            ></el-input>
          </el-form-item>
          <el-form-item label="栏目图片" prop="bannerImg">
            <upload-banner v-model="form.bannerImg"></upload-banner>
          </el-form-item>
          <el-form-item
            v-if="form.model === 1 || form.model === 2"
            label="列表模板"
            prop="listTemplateFile"
          >
            <el-select v-model="form.listTemplateFile" placeholder="列表模板">
              <el-option
                v-for="(item, index) in templateFiles"
                :key="index"
                :label="item"
                :value="item"
              >
              </el-option>
            </el-select>
            <upload-template
              @complete="templateuploadcomplete"
            ></upload-template>
          </el-form-item>
          <el-form-item label="文档模板" prop="contentTemplateFile">
            <el-select
              v-model="form.contentTemplateFile"
              placeholder="文档模板"
            >
              <el-option
                v-for="(item, index) in templateFiles"
                :key="index"
                :label="item"
                :value="item"
              >
              </el-option>
            </el-select>
            <upload-template
              @complete="templateuploadcomplete"
            ></upload-template>
          </el-form-item>
          <el-form-item label="SEO关键字" prop="websiteKeywords">
            <el-input
              v-model="form.websiteKeywords"
              placeholder="SEO关键字"
            ></el-input>
            <span>多个关键词请用英文逗号（,）隔开，建议3到5个关键词。</span>
          </el-form-item>
          <el-form-item label="SEO描述" prop="websiteDescription">
            <el-input
              v-model="form.websiteDescription"
              type="textarea"
              :rows="3"
              maxlength="200"
              show-word-limit
              placeholder="SEO描述"
            ></el-input>
          </el-form-item>
        </el-tab-pane>
        <el-tab-pane v-if="form.model === 3" label="表单选项" name="third">
          <custom-form-table
            v-model="form.websiteCustomForms"
          ></custom-form-table>
        </el-tab-pane>
      </el-tabs>
    </el-form>
  </div>
</template>

<script>
import { TemplateFiles } from "../../api/media";
import { MenuDetail, MenuCreate, MenuEdit } from "../../api/menu";
import { MenuModels } from "../../utils/constant";
import UploadTemplate from "../../components/UploadTemplate";
import UploadBanner from "../../components/UploadBanner";
import SelectMenu from "../../components/SelectMenu";
import CustomFormTable from "./components/CustomFormTable";

export default {
  name: "MenuInfo",
  components: {
    UploadTemplate,
    UploadBanner,
    SelectMenu,
    CustomFormTable,
  },
  data() {
    return {
      menuId: 0,
      loading: false,
      activeName: "first",
      MenuModels,
      templateFiles: [],
      form: {
        id: 0,
        parentId: undefined,
        order: 0,
        type: 0,
        externalUrl: "",
        menuName: "",
        enMenuName: "",
        isHidden: false,
        bannerImg: "",
        websiteKeywords: "",
        websiteDescription: "",
        model: 0,
        listTemplateFile: "",
        contentTemplateFile: "",
        websiteCustomForms: [],
      },
      rules: {
        menuName: [
          {
            required: true,
            message: "请输入标题",
            trigger: "blur",
          },
        ],
        order: [
          {
            required: true,
            message: "请设置排序",
            trigger: "blur",
          },
        ],
        externalUrl: [
          {
            required: true,
            message: "请输入标题",
            trigger: "blur",
          },
        ],
        listTemplateFile: [
          {
            required: true,
            message: "请选择模板文件",
            trigger: "blur",
          },
        ],
        contentTemplateFile: [
          {
            required: true,
            message: "请选择模板文件",
            trigger: "blur",
          },
        ],
      },
    };
  },
  methods: {
    templateuploadcomplete(data) {
      var any = this.templateFiles.find((item) => {
        return item == data;
      });
      if (!any) this.templateFiles.push(data);
    },
    saveHandle() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.loading = true;
          if (this.menuId > 0) {
            MenuEdit(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "Menu" });
                }
              })
              .catch(() => {
                this.loading = false;
              });
          } else {
            MenuCreate(this.form)
              .then((res) => {
                this.loading = false;
                if (res.code === 0) {
                  this.$router.push({ name: "Menu" });
                }
              })
              .catch(() => {
                this.loading = false;
              });
          }
        }
      });
    },
    returnHandle() {
      this.$router.push({ name: "Menu" });
    },
  },
  mounted() {
    if (this.menuId > 0) {
      this.loading = true;
      MenuDetail(this.menuId)
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.form = res.data;
          }
        })
        .catch(() => {
          this.loading = false;
        });
    }

    TemplateFiles()
      .then((res) => {
        if (res.code === 0) {
          this.templateFiles = res.data;
        }
      })
      .catch(() => {});
  },
  created() {
    if (this.$route.query.id) {
      this.menuId = this.$route.query.id;
    }
  },
};
</script>