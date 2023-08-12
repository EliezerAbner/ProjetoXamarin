using System;
using System.Collections.Generic;
using System.Text;
using AppMedicine.Models;
using SQLite;

namespace AppMedicine.Services
{
    public class ServiceDBMedicine
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public ServiceDBMedicine(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
        }
    }
}
