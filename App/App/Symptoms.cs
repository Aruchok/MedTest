using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App
{
    [Table("Symptoms")]
    public class Symptoms
    {
        [PrimaryKey, AutoIncrement, Column("idSymptom"), Unique]
        public int idSymptom { get; set; }
        public string Symptom { get; set; }
        public int Diagnoz_id { get; set; }
        public int Uverennost { get; set; }             
    }
}
