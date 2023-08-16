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
            List<ModelMedicine> lista = new List<ModelMedicine> ();
            TimeSpan padrao = new TimeSpan(0, 0, 3);
            lista = listaRemedio.Listar();

            for(int i = 0; i < lista.Count; i++)
            {
                if (lista[i].horario2 != padrao)
                {
                    
                }
            }
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnApagar_Clicked(object sender, EventArgs e)
        {

        }
    }
}

/*
    Hello,

Those Labels(named lblDueDate1, lblDueDate) are in <DataTemplate>. You cannot access templated elements by name.

If you have a <Label> on your <Page> and set it an x:Name myLabelTest in XAML,

The XAML compiler creates a variable named myLabel that you can use to reference that control from your code behind.

But if you have a ListView that has two Labels in it's <DataTemplate>, there may be 0, or 10, or 100 copies of that Label generated at runtime depending on the number of items in your ItemsSource.
You cannot refer to it by name because it is not a single, it is changing at runtime.

You can use Listview‘s databinding to binding your properties in your listview to your ViewModel. You can update your value of properties in viewModel at runtime, then your label in listview will be changed. 
*/