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
        public decimal quantidade { get; set; }
        [NotNull]
        public string gotas_Comprimidos { get; set; }
        [NotNull]
        public string dataInicio { get; set; }
        [NotNull]
        public string dataFinal { get; set; }
        public string observacoes { get; set; }
        [NotNull]
        public TimeSpan horario1 { get; set; }
        public TimeSpan horario2 { get; set; }
        public TimeSpan horario3 { get; set; }
        public TimeSpan horario4 { get; set; }

        public ModelMedicine()
        {
            this.id = 0;
            this.nomeRemedio = "";
            this.quantidade = 0;
            this.dataInicio = "";
            this.dataFinal = "";
            this.observacoes = "";
            this.horario1 = new TimeSpan(0, 0, 3);
            this.horario2 = new TimeSpan(0, 0, 3);
            this.horario3 = new TimeSpan(0, 0, 3);
            this.horario4 = new TimeSpan(0, 0, 3);
        }
    }
}
