using DsPersonalFinance.DBModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsPersonalFinance.DBServices
{
    public class DBCategoryService
    {
        SQLiteAsyncConnection Database;

        public DBCategoryService()
        {

        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<DBCategory>();
        }

        public async Task<List<DBCategory>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<DBCategory>().ToListAsync();
        }

        public async Task<DBCategory> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<DBCategory>().Where(i => i.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(DBCategory item)
        {
            await Init();
            if (item.CategoryId != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(DBCategory item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
