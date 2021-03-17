<template>
  <div v-loading="loading">
    <div class="toolbar">
      <h2>文件编辑</h2>
      <div class="toolbar-btn-group">
        <el-button type="primary" @click="saveHandle">保存</el-button>
        <el-button @click="returnHandle">返回</el-button>
      </div>
    </div>
    <el-form :model="form" ref="form" :rules="rules" label-width="120px">
      <el-form-item label="目录" prop="path">
        <el-input v-model="form.path" readonly></el-input>
      </el-form-item>
      <el-form-item label="文件名称" prop="file">
        <el-input v-model="form.file"></el-input>
      </el-form-item>
      <el-form-item label="HTML代码">
        <textarea ref="textarea"></textarea>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import { GetFileContent, ChangeFileContent } from "../../api/media";
import { fileSuffixTypeUtil } from "../../utils/file";
import CodeMirror from "codemirror";

import "codemirror/lib/codemirror.css";
import "codemirror/theme/cobalt.css";

// 需要引入具体的语法高亮库才会有对应的语法高亮效果
// codemirror 官方其实支持通过 /addon/mode/loadmode.js 和 /mode/meta.js 来实现动态加载对应语法高亮库
// 但 vue 貌似没有无法在实例初始化后再动态加载对应 JS ，所以此处才把对应的 JS 提前引入
import "codemirror/mode/javascript/javascript.js";
import "codemirror/mode/css/css.js";
import "codemirror/mode/xml/xml.js";
/*
import "codemirror/mode/clike/clike.js";
import "codemirror/mode/markdown/markdown.js";
import "codemirror/mode/python/python.js";
import "codemirror/mode/r/r.js";
import "codemirror/mode/shell/shell.js";
import "codemirror/mode/sql/sql.js";
import "codemirror/mode/swift/swift.js";
import "codemirror/mode/vue/vue.js";
*/

export default {
  name: "TemplateInfo",
  data() {
    return {
      loading: false,
      form: {
        path: "",
        file: "",
        content: "",
      },
      rules: {
        file: [{ required: true, message: "请输入文件名称", trigger: "blur" }],
      },
      // 编辑器实例
      coder: null,
      // 默认配置
      options: {
        // 缩进格式
        tabSize: 2,
        // 主题，对应主题库 JS 需要提前引入
        theme: "cobalt",
        // 显示行号
        lineNumbers: true,
        line: true,
        mode: "text/html",
      },
      // 支持切换的语法高亮类型，对应 JS 已经提前引入
      // 使用的是 MIME-TYPE ，不过作为前缀的 text/ 在后面指定时写死了
      modes: [
        {
          value: "css",
          label: "CSS",
        },
        {
          value: "javascript",
          label: "Javascript",
        },
        {
          value: "html",
          label: "XML/HTML",
        },
      ],
    };
  },
  methods: {
    returnHandle() {
      this.$router.push({ name: "Template", query: { path: this.form.path } });
    },
    saveHandle() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.loading = true;
          ChangeFileContent(this.form)
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
              this.$message({
                message: "操作失败",
                type: "error",
              });
            });
        }
      });
    },
    initCodeMirror() {
      if (this.form.file) {
        var fileType = fileSuffixTypeUtil.matchFileSuffixType(this.form.file);
        if (fileType) {
          var modeObj = this.modes.find((item) => {
            var currentType = fileType.toLowerCase();
            var modeLabel = item.label.toLowerCase();
            var modeValue = item.value.toLowerCase();
            return currentType === modeLabel || currentType === modeValue;
          });
          if (modeObj) {
            this.options.mode = `text/${modeObj.value}`;
          }
        }
      }

      this.coder = CodeMirror.fromTextArea(this.$refs.textarea, this.options);

      this.coder.on("change", (coder) => {
        this.form.content = coder.getValue();
      });
    },
    loadFileContent() {
      if (!this.form.file) return;
      this.loading = true;
      GetFileContent({ path: this.form.path + "/" + this.form.file })
        .then((res) => {
          this.loading = false;
          if (res.code === 0) {
            this.form.content = res.data;
            this.coder.setValue(this.form.content);
          }
        })
        .catch(() => {
          this.loading = false;
        });
    },
  },
  mounted() {
    this.initCodeMirror();

    this.loadFileContent();
  },
  created() {
    if (this.$route.query.file) {
      this.form.file = this.$route.query.file;
    }
    if (this.$route.query.path) {
      this.form.path = this.$route.query.path;
    }
  },
};
</script>

<style>
.CodeMirror {
  height: 100%;
}
</style>