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
using Plugin.LocalNotification;

namespace AppMedicine.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCadastro : ContentPage
	{
        public int counter = 0;
        public TimeSpan padrao = new TimeSpan(0, 0, 3);
        public int notificationCounter = 0;

		public PageCadastro ()
		{
			InitializeComponent ();
            tpHorario2.Time = padrao;
            tpHorario3.Time = padrao;
            tpHorario4.Time = padrao;
		}

        public PageCadastro(ModelMedicine teste)
        {
            InitializeComponent();
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
                AddNotification(txtNomeRemedio.Text, tpHorario1.Time);

                if (tpHorario2.Time != padrao)
                {
                    novoRemedio.horario2 = tpHorario2.Time;
                    AddNotification(txtNomeRemedio.Text, tpHorario2.Time);
                }
                if (tpHorario3.Time != padrao)
                {
                    novoRemedio.horario3 = tpHorario3.Time;
                    AddNotification(txtNomeRemedio.Text, tpHorario3.Time);
                }
                if (tpHorario4.Time != padrao)
                {
                    novoRemedio.horario4 = tpHorario4.Time;
                    AddNotification(txtNomeRemedio.Text, tpHorario4.Time);
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

                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PagePrincipal());
            }
			catch (Exception ex)
			{
                DisplayAlert("Erro:", ex.Message, "OK");
			}
        }

        private DateTime tsToDtConversor(TimeSpan oldValue)
        {
            DateTime newValue = DateTime.Today;
            newValue = newValue + oldValue;

            return newValue;
        }

        private void AddNotification(string nomeRemedio, TimeSpan horario)
        {
            notificationCounter++;

            var notificationH1 = new NotificationRequest
            {
                NotificationId = notificationCounter,
                Title = "Hora de tomar remédio",
                Description = string.Format("Hora de tomar {0}", nomeRemedio),
                //ReturningData = "Dummy data", Returning data when tapped on notification.
                Schedule =
                {
                    NotifyTime = tsToDtConversor(horario),
                    RepeatType = NotificationRepeat.Daily
                }
            };
            LocalNotificationCenter.Current.Show(notificationH1);
        }
    }
}