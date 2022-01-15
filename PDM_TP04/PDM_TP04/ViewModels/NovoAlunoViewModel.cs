using PDM_TP04.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PDM_TP04.ViewModels
{
    class NovoAlunoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        int id;
        string nome, rm, email;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nome"));
            }
        }
        public string RM
        {
            get => rm;
            set
            {
                rm = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RM"));
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public ICommand NovoAluno
        {
            get => new Command(() =>
            {
                Id = 0;
                Nome = String.Empty;
                RM = String.Empty;
                Email = String.Empty;
            });
        }

        public ICommand SalvarAluno
        {
            get => new Command(async () =>
            {
                try
                {
                    Aluno model = new Aluno()
                    {
                        Nome = this.Nome,
                        RM = this.RM,
                        Email = this.Email,
                    };

                    List<Aluno> tmp = await App.Database.GetAllRows();

                    if (this.Id == 0)
                    {
                        await App.Database.Insert(model);
                    }
                    else
                    {
                        model.Id = this.Id;
                        await App.Database.Update(model);
                    }

                    await Application.Current.MainPage.DisplayAlert("Alerta", "Usuário Salvo!", "OK");


                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Alerta", ex.Message, "OK");
                }

            });
        }


    }
}
