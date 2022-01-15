using PDM_TP04.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDM_TP04.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlunoPage : ContentPage
    {
        public AlunoPage()
        {
            BindingContext = new AlunoViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var vm = (AlunoViewModel)BindingContext;

            vm.AtualizarLista.Execute(null);
        }
        private async void OnNovo(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NovoAlunoPage());
        }
    }
}