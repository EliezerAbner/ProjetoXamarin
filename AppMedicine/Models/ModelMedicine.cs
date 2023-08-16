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
        public bool h2 { get; set; }
        public bool h3 { get; set; }
        public bool h4 { get; set; }
        public string strHorario1 { get; set; }
        public string strHorario2 { get; set; }
        public string strHorario3 { get; set; }
        public string strHorario4 { get; set; }

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
            this.h2 = false;
            this.h3 = false;
            this.h4 = false;
            this.strHorario1 = "";
            this.strHorario2 = "";
            this.strHorario3 = "";
            this.strHorario4 = "";
        }
    }
}
