using System.Collections.Generic;
using www.veinid365.cn.Data.Entities;

namespace www.veinid365.cn.Models
{
    public class HomePaginationViewModel
    {
        public HomePaginationViewModel()
        {
        }

        public HomePaginationViewModel(int totalRows,
                                       int currentPage,
                                       int limit,
                                       List<HomeCategoryViewModel> categorys,
                                       object data)
        {
            TotalRows = totalRows;
            CurrentPage = currentPage;
            var totalPage = totalRows % limit == 0 ? totalRows / limit : totalRows / limit + 1;
            if (totalPage == 0)
            {
                totalPage = 1;
            }
            TotalPage = totalPage;
            Limit = limit;
            Start = currentPage > 4 ? currentPage - 4 : 1;
            End = (TotalPage - Start) > 8 ? Start + 8 : TotalPage;
            Categorys = categorys;
            Data = data;
        }

        public int TotalRows { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }

        public int Limit { get; set; }

        public int Start { get; set; }

        public int End { get; set; }

        public List<HomeCategoryViewModel> Categorys { get; set; }

        public object Data { get; set; }
    }
}