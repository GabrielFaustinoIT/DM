using PDM_TP04.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PDM_TP04.Helper
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _db;

        public SQLiteDataBaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            _db.CreateTableAsync<Aluno>().Wait();
        }

        // GetAllRows()
        public Task<List<Aluno>> GetAllRows()
        {
            return _db.Table<Aluno>().OrderByDescending(i => i.Id).ToListAsync();
        }

        // GetById(int id)
        public Task<Aluno> GetById(int id)
        {
            return _db.Table<Aluno>().FirstAsync(i => i.Id == id);
        }

        // Insert(Usuario model)
        public Task<int> Insert(Aluno model)
        {
            return _db.InsertAsync(model);
        }

        // Update(Usuario model)
        public Task<List<Aluno>> Update(Aluno model)
        {
            string sql = "UPDATE Aluno SET Nome=?, RM=?, Email=? WHERE Id=/";
            return _db.QueryAsync<Aluno>(
                sql,
                model.Nome,
                model.RM,
                model.Email,
                model.Id
                );
        }

        // Delete(int id)
        public Task<int> Delete(int id)
        {
            return _db.Table<Aluno>().DeleteAsync(i => i.Id == id);
        }

        // Search(string query)
        public Task<List<Aluno>> Search(string q)
        {
            string sql = "SELECT * FROM Aluno WHERE RM = '" + q + "'";

            return _db.QueryAsync<Aluno>(sql);
        }

        // Search(string query)
        public Task<List<Aluno>> SearchByEmail(string q)
        {
            string sql = "SELECT * FROM Aluno WHERE Email = '" + q + "'";

            return _db.QueryAsync<Aluno>(sql);
        }
    }
}
