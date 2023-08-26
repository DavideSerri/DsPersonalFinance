using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsPersonalFinance.DBModels
{
    [Table("TransactionType")]
    public class DBTransactionType
    {
        [PrimaryKey, AutoIncrement]
        public int TransactionTypeId { get; set; }
        public string Description { get; set; }
        public int SubCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
