using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsPersonalFinance.DBModels
{
    [Table("SubCategory")]
    public class DBSubCategory
    {
        [PrimaryKey, AutoIncrement]
        public int SubCategoryId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
