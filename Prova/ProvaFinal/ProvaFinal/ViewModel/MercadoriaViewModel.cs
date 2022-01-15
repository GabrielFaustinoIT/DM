using ProvaFinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaFinal.ViewModel
{
    class MercadoriaViewModel
    {
        public MercadoriaViewModel() { }
        #region Propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Peso { get; set; }
        public string NomeProd { get; set; }
        public string Email { get; set; }
        public List<Mercadoria> Mercadorias
        {
            get
            {
                return App.MercadoriaModel.GetMercadorias().ToList();
            }
        }
        #endregion
    }
}
