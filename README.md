CMS 内容管理系统

本系统使用Fluid(https://github.com/sebastienros/fluid)做为模板引擎

Fluid是基于Liquid模板语言(https://liquid.bootcss.com/filters/slice/)

自定义Tag

render 用于加载部分文件内容

{% render fileName %}

自定义Block

list 加载部分列表内容

{% list menuId | row: rowquantity %}

    {{Data.Title}}
    
{% endlist %}

返回的数据为 
```json
Data:{
    Id:0,    
    Title:'',    
    EnTitle:'',
    Data:[{
        Id:0,
        Title:'', //标题
        Thumbnail:'', //缩略图
        Content:'', 富文本内容
        CreateTime:datetime //日期
    }]
}
```
menu 加载单页面菜单内容
{% menu menuId %}
    {{Data.Title}}
{% endmenu %}
返回的数据为 Data:{
    Id:0,
    Title:'',
    EnTitle:'',
    Data:{
        Id:0,
        Title:'', //标题
        Thumbnail:'', //缩略图
        Content:'', 富文本内容
    }
}

view 加载内容
{% view viewId %}
    {{Data.Title}}
{% endview %}
返回的数据为 Data:{
        Id:0,
        Title:'', //标题
        Thumbnail:'', //缩略图
        Content:'', 富文本内容
    }

全局数据
Model:{
    Setting:{
        WebsiteName:'', //网站名称
        WebsiteLogo:'', //网站Logo
        WebsiteAddressIcon:'', //地址栏图标
        WebsiteTitle:'', //网站标题
        WebsiteUrl:'', //网站地址
        WebsiteKeywords:'', //SEO关键词
        WebsiteDescription:'', //SEO描述
        Copyright:'', //版权信息
        CaseNumber:'', //备案号
        WebsiteCustomParams:[{
            Name:'',
            Value:'',
            Type: 0, // 0 = text , 1 = textArea , 2 = image
        }]
    },
    Menus:[{
        Id:0,
        Type:0, // 0 = 内容链接 , 1 = 外部链接
        ExternalUrl:'', //外部链接
        MenuName:'', //菜单名称
        EnMenuName:'', //英文别名
        Children:[Menus,Menus,Menus] //子菜单
    }],
    Id:0, //当前请求菜单或视图Id
    BannerUrl:'', //横幅图片
    Data: object , // Data 有多种数据内容
    // 第一种 单页面内容
    Data:{
        Categorys:[{ //分类
            Id:0,
            Title:'', //标题
            IsActive:true //是否选择
        }],
        Data:{
            Id:0,
            Title:'', //标题
            Thumbnail:'', //缩略图
            Content:'', 富文本内容
        }
    }
    // 第二种 自定义表单
    Data:{
        Categorys:[{ //分类
            Id:0,
            Title:'', //标题
            IsActive:true //是否选择
        }],
        Data:[{
            Name:'',//表单名称
            Type:0, // 0 = text , 1 = textArea , 2 = image
            IsRequired：true, //必需请求
        }]
    }
    // 第三种 列表
    Data:{
        TotalRows:0, // 总行数
        CurrentPage:0, //当前页
        TotalPage:0, //总页数
        Limit:0, //显示的行数
        Start:0, //分页开始位置
        End:0, //分页结束位置
        Categorys:[{ //分类
            Id:0,
            Title:'', //标题
            IsActive:true //是否选择
        }],
        Data:[{
            Id:0,
            Title:'', //标题
            Thumbnail:'', //缩略图
            Content:'', 富文本内容
            CreateTime:datetime
        }]
    }
    // 第四种 详情内容
    Data:{
        Categorys:[{ //分类
            Id:0,
            Title:'', //标题
            IsActive:true //是否选择
        }],
        Data:{
            Id:0,
            Title:'', //标题
            Thumbnail:'', //缩略图
            Content:'', 富文本内容
            CreateTime：datetime ,//创建时间
            Pageviews:0,//浏览量
            DownloadFiles:[{
                Id:0,
                FileName:'', // 文件名称
                FileUrl:'', //文件地址
                Title:'', //标题
                FileSize:0 //文件大小
            }]
        },
        Prev:{
            Id:0,
            Title:''
        },
        Next:{
            Id:0,
            Title:''
        }
    }
