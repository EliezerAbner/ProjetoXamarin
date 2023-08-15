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

        public void Inserir(ModelMedicine medicine)
        {
            try
            {
                if (string.IsNullOrEmpty(medicine.nomeRemedio))
                    throw new Exception("Nome do remédio não informado");
                if (medicine.quantidade == 0)
                    throw new Exception("informe a quantidade");
                if (string.IsNullOrEmpty(medicine.dataInicio))
                    throw new Exception("Insforme a data inicial");
                if (string.IsNullOrEmpty(medicine.dataFinal))
                    throw new Exception("Informe a data final");
                if (string.IsNullOrEmpty(medicine.horario1))
                    throw new Exception("Insira pelo menos 1 horário");

                int result = conn.Insert(medicine);

                

                if (result != 0)
                {
                    this.StatusMessage = "Remédio adicionado com sucesso";
                }
                else
                {
                    this.StatusMessage = "Remédio não foi adicionado";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(ModelMedicine medicine)
        {
            try
            {
                if (string.IsNullOrEmpty(medicine.nomeRemedio))
                    throw new Exception("Nome do remédio não informado");
                if (medicine.quantidade == 0)
                    throw new Exception("informe a quantidade");
                if (string.IsNullOrEmpty(medicine.dataInicio))
                    throw new Exception("Insforme a data inicial");
                if (string.IsNullOrEmpty(medicine.dataFinal))
                    throw new Exception("Informe a data final");
                if (string.IsNullOrEmpty(medicine.horario1))
                    throw new Exception("Insira pelo menos 1 horário");
                if (medicine.id == 0)
                    throw new Exception("Id não informado");

                int result = conn.Update(medicine);

                if (result != 0)
                {
                    StatusMessage = "Remédio editado com sucesso";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                int result = conn.Table<ModelMedicine>().Delete(r => r.id == id);
                StatusMessage = "Remédio deletado";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
