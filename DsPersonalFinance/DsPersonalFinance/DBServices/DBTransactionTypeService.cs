using DsPersonalFinance.DBModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsPersonalFinance.DBServices
{
    public class DBTransactionTypeService
    {
        SQLiteAsyncConnection Database;

        public DBTransactionTypeService()
        {

        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<DBTransactionType>();
        }

        public async Task<List<DBTransactionType>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<DBTransactionType>().ToListAsync();
        }

        public async Task<DBTransactionType> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<DBTransactionType>().Where(i => i.TransactionTypeId == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(DBTransactionType item)
        {
            await Init();
            if (item.TransactionTypeId != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(DBTransactionType item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
