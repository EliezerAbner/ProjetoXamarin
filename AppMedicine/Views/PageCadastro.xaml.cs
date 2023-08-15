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
            ModelMedicine novoRemedio = new ModelMedicine();

            string dataInicial = dpInicial.Date.ToString();
			string dataFinal = dpFinal.Date.ToString();
			string horario1 = tpHorario1.Time.ToString();

			if(tpHorario2 != null)
			{
				string horario2 = tpHorario2.Time.ToString();
				novoRemedio.horario2 = horario2;
			}
			if(tpHorario3 != null)
			{
				string horario3 = tpHorario3.Time.ToString();
				novoRemedio.horario3 = horario3;
			}
			if(tpHorario4 != null)
			{
				string horario4 = tpHorario4.Time.ToString();
				novoRemedio.horario4 = horario4;
			}

			novoRemedio.nomeRemedio = txtNomeRemedio.Text;
			novoRemedio.quantidade = Convert.ToDecimal(txtQuantidade.Text);
			novoRemedio.gotas_Comprimidos = pickerGotasComprimidos.SelectedItem.ToString();
			novoRemedio.observacoes = txtObservacoes.Text;
			novoRemedio.dataInicio = dataInicial;
			novoRemedio.dataFinal = dataFinal;
			novoRemedio.horario1 = horario1;
        }

        private void tpHorario1_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
			if(tpHorario1 != null)
			{
                btnAddHorario.IsVisible = true;
            }
        }
    }
}