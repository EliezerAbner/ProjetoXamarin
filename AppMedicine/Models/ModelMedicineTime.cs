using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppMedicine.Models
{
    public class ModelMedicineTime
    {
        public int id { get; set; }
        public int medicineId { get; set; }
        public string time { get; set; }

        public ModelMedicineTime()
        {
            this.id = 0;
            this.medicineId = 0;
            this.time = "";
        }
    }
}
