<template>
  <div id="app">
    <router-view />
  </div>
</template>

<style>
* {
  padding: 0px;
  margin: 0px;
}
html,
body,
#app,
.el-menu {
  height: 100%;
}

.layout-container {
  height: 100%;
}

.w-100 {
  width: 100%;
}

.box-inline {
  display: inline;
}

.toolbar {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin: 20px 0;
  padding-bottom: 10px;
  border-bottom: 1px solid #dcdfe6;
}

.quill-editor {
  line-height: 24px;
}
.quill-editor .ql-toolbar {
  border: 1px solid #dcdfe6;
}
.quill-editor .ql-container {
  border: 1px solid #dcdfe6;
  height: 300px;
}

.avatar-uploader .el-upload {
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}
.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}

.avatar {
  width: 148px;
  height: 148px;
  display: block;
}

.pagination {
  margin: 20px 0px;
}

.form-item-line-height-normal .el-form-item__content {
  line-height: normal;
}
</style>
