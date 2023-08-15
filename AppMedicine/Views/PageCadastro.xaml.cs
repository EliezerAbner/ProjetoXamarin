using AppMedicine.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMedicine.Services;

namespace AppMedicine.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCadastro : ContentPage
	{
        public int counter = 0;
		public PageCadastro ()
		{
			InitializeComponent ();
		}

        private void btnAddHorario_Clicked(object sender, EventArgs e)
        {
			counter++;
            switch (counter)
			{
				case 1:
					stackLayout1.IsVisible = true;
					break;
				case 2:
					stackLayout2.IsVisible = true;
					break;
				case 3:
					stackLayout3.IsVisible = true;
					break;
				case 4:
					btnAddHorario.IsEnabled = false;
					break;
			}
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
			try
			{
                ModelMedicine novoRemedio = new ModelMedicine();

                if (string.IsNullOrEmpty(txtQuantidade.Text))
                    throw new Exception("Adicione a quantidade neccessária");

                string dataInicial = dpInicial.Date.ToString();
                string dataFinal = dpFinal.Date.ToString();
                string horario1 = tpHorario1.Time.ToString();
                string gotasComprimidos = pickerGotasComprimidos.SelectedItem.ToString();

                if (tpHorario2 != null)
                {
                    string horario2 = tpHorario2.Time.ToString();
                    novoRemedio.horario2 = horario2;
                }
                if (tpHorario3 != null)
                {
                    string horario3 = tpHorario3.Time.ToString();
                    novoRemedio.horario3 = horario3;
                }
                if (tpHorario4 != null)
                {
                    string horario4 = tpHorario4.Time.ToString();
                    novoRemedio.horario4 = horario4;
                }

                novoRemedio.nomeRemedio = txtNomeRemedio.Text;
                novoRemedio.quantidade = Convert.ToDecimal(txtQuantidade.Text);
                novoRemedio.gotas_Comprimidos = gotasComprimidos;
                novoRemedio.observacoes = txtObservacoes.Text;
                novoRemedio.dataInicio = dataInicial;
                novoRemedio.dataFinal = dataFinal;
                novoRemedio.horario1 = horario1;

                ServiceDBMedicine remedio = new ServiceDBMedicine(App.DbPath);

                remedio.Inserir(novoRemedio);
                DisplayAlert("Inserção", remedio.StatusMessage, "OK");
            }
			catch (Exception ex)
			{
                DisplayAlert("Erro:", ex.Message, "OK");
			}
        }
    }
}