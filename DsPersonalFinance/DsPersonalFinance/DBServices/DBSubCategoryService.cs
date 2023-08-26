using DsPersonalFinance.DBModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsPersonalFinance.DBServices
{
    public class DBSubCategoryService
    {
        SQLiteAsyncConnection Database;

        public DBSubCategoryService()
        {

        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<DBSubCategory>();
        }

        public async Task<List<DBSubCategory>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<DBSubCategory>().ToListAsync();
        }

        public async Task<DBSubCategory> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<DBSubCategory>().Where(i => i.SubCategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(DBSubCategory item)
        {
            await Init();
            if (item.SubCategoryId != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(DBSubCategory item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
