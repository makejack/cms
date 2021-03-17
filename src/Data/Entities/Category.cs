using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Data.Entities
{
    public class Category : Aggregate
    {
        public Category()
        {
        }

        public Category(string title, CategoryTypes type)
        {
            Edit(title, type);
        }

        [Required]
        [MaxLength(512)]
        public string Title { get; set; }

        public CategoryTypes Type { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<Solution> Solutions { get; set; }

        public void Edit(string title, CategoryTypes type)
        {
            this.Title = title;
            this.Type = type;
        }
    }
}