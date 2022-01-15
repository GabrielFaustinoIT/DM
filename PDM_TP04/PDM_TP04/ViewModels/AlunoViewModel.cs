using PDM_TP04.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PDM_TP04.ViewModels
{
    class AlunoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<Aluno> listaAlunos = new ObservableCollection<Aluno>();


        // Recebendo o que foi digitado pelo usuário

        public string ParametroBusca { get; set; }

        //Gerenciando se mostra ao usúário o RefreshView (Atualiza arrastando para baixo)

        bool estaAtualizando = false;
        public bool EstaAtualizando
        {
            get => estaAtualizando;
            set
            {
                estaAtualizando = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EstaAtualizando"));
            }
        }

        //Armazenando os usuarios 

        public ObservableCollection<Aluno> ListaAlunos
        {
            get => listaAlunos;
            set => listaAlunos = value;
        }

        public ICommand AtualizarLista
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (EstaAtualizando)
                            return;

                        EstaAtualizando = true;

                        List<Aluno> tmp = await App.Database.GetAllRows();

                        ListaAlunos.Clear();

                        tmp.ForEach(i => ListaAlunos.Add(i));
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
                    }
                    finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        }

        public ICommand LimparLista
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (EstaAtualizando)
                            return;

                        EstaAtualizando = true;

                        List<Aluno> tmp = await App.Database.GetAllRows();

                        tmp.Clear();
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
                    }
                    finally
                    {
                        EstaAtualizando = false;
                    }
                });
            }
        }
    }
}   
