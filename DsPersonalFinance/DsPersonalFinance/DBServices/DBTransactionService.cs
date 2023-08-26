using DsPersonalFinance.DBModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsPersonalFinance.DBServices
{
    public class DBTransactionService
    {
        SQLiteAsyncConnection Database;

        public DBTransactionService()
        {

        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<DBTransaction>();
        }

        public async Task<List<DBTransaction>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<DBTransaction>().ToListAsync();
        }

        public async Task<DBTransaction> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<DBTransaction>().Where(i => i.TransactionId == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(DBTransaction item)
        {
            await Init();
            if (item.TransactionId != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(DBTransaction item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
