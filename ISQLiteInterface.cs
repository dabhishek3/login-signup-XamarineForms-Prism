using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logintest.Models
{
   public interface ISQLiteInterface
    {
        SQLiteConnection GetConnection();
    }
}
