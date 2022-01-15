using ProvaFinal.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProvaFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Mercadoria.MainPage());
        }

        static Mercadoria mercadoriaModel;

        public static Mercadoria MercadoriaModel
        {
            get
            {
                if (mercadoriaModel == null)
                {
                    mercadoriaModel = new Mercadoria();
                }
                return mercadoriaModel;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
