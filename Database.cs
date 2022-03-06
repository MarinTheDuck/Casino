using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Database
    {
        private readonly SQLiteAsyncConnection _connection;

        public Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<User>();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _connection.Table<User>().ToListAsync();
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var users = await GetUsersAsync();
            foreach (var user in users)
            {
                if (user.Name == name)
                {
                    return user;
                }
            }
            return null;
        }

        public Task<int> UpdateUserAsync(User user)
        {
            return _connection.UpdateAsync(user);
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _connection.InsertAsync(user);
        }
    }
}
