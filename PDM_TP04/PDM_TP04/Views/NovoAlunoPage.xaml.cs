using PDM_TP04.Models;
using PDM_TP04.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDM_TP04.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoAlunoPage : ContentPage
    {
        public NovoAlunoPage()
        {
            InitializeComponent();

            BindingContext = new NovoAlunoViewModel();
        }

        protected override async void OnAppearing()
        {
            var vm = (NovoAlunoViewModel)BindingContext;

            if (vm.Id == 0)
            {
                vm.NovoAluno.Execute(null);
            }
        }

        private async void Listar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlunoPage());
        }

        public void OnCancelar(object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }
    }
}