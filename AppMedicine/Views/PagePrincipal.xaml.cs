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
    public partial class PagePrincipal : MasterDetailPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageCadastro());
            IsPresented = false;
        }

        private void btnHoje_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PagePraHoje());
            IsPresented = false;
        }

        private void btnListarTudo_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageLista());
            IsPresented = false;
        }

        private void btnSobre_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageSobre());
            IsPresented = false;
        }
    }
}