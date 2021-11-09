using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TRAB2.Views;

namespace TRAB2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Avancar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EstiloPadrao());
        }

        private void Avancar2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EstiloDinamico());
        }
        private void Avancar3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TriggersView());
        }

        private void Avancar4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Home());
        }

        private void Avancar5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProdutoView());
        }
    }
}
