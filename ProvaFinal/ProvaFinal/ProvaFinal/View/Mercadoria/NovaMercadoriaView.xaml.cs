using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProvaFinal.View.Mercadoria
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovaMercadoriaView : ContentPage
    {
        private int mercadoriaId = 0;

        public NovaMercadoriaView()
        {
            InitializeComponent();
        }
        public NovaMercadoriaView(int Id)
        {
            InitializeComponent();
            var mercadoria = App.MercadoriaModel.GetMercadoria(Id);
            txtNome.Text = mercadoria.Nome;
            txtPeso.Text = mercadoria.Peso;
            txtNomeProd.Text = mercadoria.NomeProd;
            txtEmail.Text = mercadoria.Email;
            txtNCM.Text = mercadoria.NCM;
            mercadoriaId = mercadoria.Id;
        }
        public void OnSalvar(object sender, EventArgs args)
        {
            ProvaFinal.Model.Mercadoria mercadoria = new
            ProvaFinal.Model.Mercadoria()
            {
                Nome = txtNome.Text,
                Peso = txtPeso.Text,
                NomeProd = txtNomeProd.Text,
                Email = txtEmail.Text,
                NCM = txtNCM.Text,
                Id = mercadoriaId
            };
            if (mercadoriaId == 0)
            {
                App.MercadoriaModel.SalvarMercadoria(mercadoria);
            }
            else
            {
                App.MercadoriaModel.AtualizarMercadoria(mercadoria);
            }
            Limpar();
            Navigation.PopAsync();
        }
        public void OnCancelar(object sender, EventArgs args)
        {
            Limpar();
            Navigation.PopAsync();
        }
        private void Limpar()
        {
            txtNome.Text = txtPeso.Text = txtEmail.Text = txtNomeProd.Text = txtNCM.Text = string.Empty;
            mercadoriaId = 0;
        }
    }
}