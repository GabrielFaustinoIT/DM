using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaFinal.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConexao();

    }
}
