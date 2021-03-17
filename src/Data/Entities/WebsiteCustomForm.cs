using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Data.Entities
{
    /// <summary>
    /// 自定义表单
    /// </summary>
    public class WebsiteCustomForm : Aggregate
    {
        public WebsiteCustomForm()
        {
        }


        public int NavMenuId { get; set; }
        public virtual NavMenu NavMenu { get; set; }
        [Required]
        [MaxLength(512)]
        public string Name { get; set; }
        public CustomParamTypes Type { get; set; }
        public bool IsRequired { get; set; }
        public bool IsShowList { get; set; }

        public void Edit(int navMenuId,
                         string name,
                         CustomParamTypes type,
                         bool isRequired,
                         bool isShowList)
        {
            NavMenuId = navMenuId;
            Name = name;
            Type = type;
            IsRequired = isRequired;
            IsShowList = isShowList;
        }
    }
}