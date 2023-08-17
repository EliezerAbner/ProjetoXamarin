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
using System.Xml;

namespace AppMedicine.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCadastro : ContentPage
	{
        public int counter = 0;
        public TimeSpan padrao = new TimeSpan(0, 0, 3);

		public PageCadastro ()
		{
			InitializeComponent ();
            tpHorario2.Time = padrao;
            tpHorario3.Time = padrao;
            tpHorario4.Time = padrao;
		}

        public PageCadastro(ModelMedicine teste)
        {
            txtCodigo.Text = teste.id.ToString();
            txtNomeRemedio.Text = teste.nomeRemedio;
            txtQuantidade.Text = teste.quantidade.ToString();
            pickerGotasComprimidos.SelectedItem = teste.gotas_Comprimidos;
            txtObservacoes.Text = teste.observacoes;
            dpInicial.Date = Convert.ToDateTime(teste.dataInicio);
            dpFinal.Date = Convert.ToDateTime(teste.dataFinal);
            tpHorario1.Time = teste.horario1;

            if(teste.horario2 != padrao)
                tpHorario2.Time = teste.horario2;
            if(teste.horario3 != padrao)
                tpHorario3.Time = teste.horario3;
            if(teste.horario4 != padrao)
                tpHorario4.Time = teste.horario4;

            btnSalvar.Text = "Alterar";
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
                string gotasComprimidos = pickerGotasComprimidos.SelectedItem.ToString();

                novoRemedio.horario1 = tpHorario1.Time;

                if (tpHorario2.Time != padrao)
                {
                    novoRemedio.horario2 = tpHorario2.Time;
                }
                if (tpHorario3.Time != padrao)
                {
                    novoRemedio.horario3 = tpHorario3.Time;
                }
                if (tpHorario4.Time != padrao)
                {
                    novoRemedio.horario4 = tpHorario4.Time;
                }

                novoRemedio.nomeRemedio = txtNomeRemedio.Text;
                novoRemedio.quantidade = Convert.ToDecimal(txtQuantidade.Text);
                novoRemedio.gotas_Comprimidos = gotasComprimidos;
                novoRemedio.observacoes = txtObservacoes.Text;
                novoRemedio.dataInicio = dataInicial;
                novoRemedio.dataFinal = dataFinal;

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