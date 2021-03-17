using System.Collections.Generic;

namespace www.veinid365.cn.Models
{
    public class HomeSingleViewModel
    {
        public HomeSingleViewModel()
        {
        }

        public HomeSingleViewModel(List<HomeCategoryViewModel> categorys, object data)
        {
            Categorys = categorys;
            Data = data;
        }

        public List<HomeCategoryViewModel> Categorys { get; set; }

        public object Data { get; set; }
    }
}