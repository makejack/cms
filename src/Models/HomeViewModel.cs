using System.Collections.Generic;
using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }

        public HomeViewModel(WebsiteSetting setting, List<NavMenu> menus)
        {
            Setting = setting;
            Menus = menus;
        }

        public int Id { get; set; }

        public WebsiteSetting Setting { get; set; }

        public List<NavMenu> Menus { get; set; }

        public string BannerUrl { get; set; }

        public object Data { get; set; }
    }
}