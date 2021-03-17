using System.Collections.Generic;

namespace www.veinid365.cn.Models
{
    public class HomeDetailViewModel
    {
        public HomeDetailViewModel()
        {
        }

        public HomeDetailViewModel(List<HomeCategoryViewModel> categorys, object data, HomeDetailAdjacentViewModel prev, HomeDetailAdjacentViewModel next)
        {
            Categorys = categorys;
            Data = data;
            Prev = prev;
            Next = next;
        }

        public List<HomeCategoryViewModel> Categorys { get; set; }

        public object Data { get; set; }

        public HomeDetailAdjacentViewModel Prev { get; set; }

        public HomeDetailAdjacentViewModel Next { get; set; }

    }
}