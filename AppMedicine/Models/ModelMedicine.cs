using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppMedicine.Models
{
    [Table("Remedios")]
    public class ModelMedicine
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string nomeRemedio { get; set; }
        [NotNull]
        public float quantidade { get; set; }
        [NotNull]
        public string dataInicio { get; set; }
        [NotNull]
        public string dataFinal { get; set; }
        [NotNull]
        public string observacoes { get; set; }

        public ModelMedicine()
        {
            this.id = 0;
            this.nomeRemedio = "";
            this.quantidade = 0;
            this.dataInicio = "";
            this.dataFinal = "";
            this.observacoes = "";
        }
    }
}
