using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsPersonalFinance.DBModels
{
    [Table("Transaction")]
    public class DBTransaction
    {
        [PrimaryKey, AutoIncrement]
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public int TransactionTypeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool Recurring { get; set; }
        public int Cadence { get; set; }
        public int NextTransactionId { get; set; }

    }
}
