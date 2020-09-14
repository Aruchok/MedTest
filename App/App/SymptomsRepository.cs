using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class SymptomsRepository
    {
        SQLiteConnection database;
        public SymptomsRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Symptoms>();
            database.CreateTable<Desiase>();
        }
        public IEnumerable<Symptoms> GetItems()
        {
            return database.Table<Symptoms>().ToList();
        }
        public Symptoms GetItem(int id)
        {
            return database.Get<Symptoms>(id);
        }
        public Desiase GetItemD(int id)
        {
            return database.Get<Desiase>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Symptoms>(id);
        }

        public void SaveItem(Symptoms item)
        {
            if (item.idSymptom != 0)
            {
                database.Update(item);
            }
            else
            {
                 database.Insert(item);
            }
        }
    }
}

