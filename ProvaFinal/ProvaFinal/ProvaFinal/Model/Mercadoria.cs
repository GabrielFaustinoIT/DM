using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProvaFinal.Model
{
    public class Mercadoria
    {
        string pasta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mercadorias.db3");
        public Mercadoria()
        {
            database = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mercadorias.db3"));
            database.CreateTable<Mercadoria>();
        }
        #region Propriedades
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Peso { get; set; }
        public string NomeProd { get; set; }
        public string Email { get; set; }
        public string NCM { get; set; }
        #endregion
        #region Aluno Local Database
        private SQLiteConnection database;
        static object locker = new object();
        public int SalvarMercadoria(Mercadoria merc)
        {
            lock (locker)
            {
                if (merc.Id != 0)
                {
                    database.Update(merc);
                    return merc.Id;
                }
                else return database.Insert(merc);
            }
        }
        public IEnumerable<Mercadoria> GetMercadorias()
        {
            lock (locker)
            {
                return (from c in database.Table<Mercadoria>()
                        select c).ToList();
            }
        }
        public Mercadoria GetMercadoria(int Id)
        {
            lock (locker)
            {
                // return database.Query< Aluno>("SELECT * FROM [Aluno] WHERE[Id] = " + Id);
                return database.Table<Mercadoria>().Where(c => c.Id == Id).FirstOrDefault();
            }
        }
        public bool InserirMercadoria(Mercadoria merc)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Mercadorias.db3")))
                {
                    conexao.Insert(merc);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                //Log.Info("SQLiteEx", ex.Message);
                string exe = ex.Message;
                return false;
            }
        }
        public bool AtualizarMercadoria(Mercadoria merc)
        {
            try
            {
                lock (locker)
                {
                    database.Update(merc);
                    //conexao.Query<Mercadoria>("UPDATE Mercadoria set Nome=?, Peso=?, NomeProd=?, Email=?, NCM=? Where Id=?", merc.Nome, merc.Peso, merc.NomeProd, merc.Email, merc.NCM, merc.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                //Log.Info("SQLiteEx", ex.Message);
                string exe = ex.Message;
                return false;
            }
        }
        public int RemoverMercadoria(int Id)
        {
            lock (locker)
            {
                return database.Delete<Mercadoria>(Id);
            }
        }
        #endregion
    }
}
