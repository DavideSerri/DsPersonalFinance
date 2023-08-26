using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace DsPersonalFinance.DBModels
{
    [Table("Category")]
    public class DBCategory
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryId { get; set; }
        public string Description { get; set; }

    }
}
