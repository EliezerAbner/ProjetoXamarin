using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMedicine.Models;
using AppMedicine.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMedicine.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageLista : ContentPage
	{
		public PageLista ()
		{
			InitializeComponent ();
            atualizarLista();
		}

        private void atualizarLista()
        {
            ServiceDBMedicine listaRemedio = new ServiceDBMedicine(App.DbPath);
            listaRemedio.Listar();
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnApagar_Clicked(object sender, EventArgs e)
        {

        }
    }
}