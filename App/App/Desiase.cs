using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App
{
    [Table("Diagnoz")]
    public class Desiase
    {
        [PrimaryKey, AutoIncrement, Column("idDiagnoz"), Unique]
        public int idDiagnoz{ get; set; }
        public string Diagnoz_one { get; set; }
    }
}
