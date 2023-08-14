using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMedicine.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCadastro : ContentPage
	{
		public PageCadastro ()
		{
			InitializeComponent ();
		}

        private void DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void btnAddHorarios_Clicked(object sender, EventArgs e)
        {

        }
    }
}