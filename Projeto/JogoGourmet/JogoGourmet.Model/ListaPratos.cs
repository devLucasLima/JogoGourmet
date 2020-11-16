using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet.Model
{
    public class ListaPratos<T> : IListaItensAdivinhacao<T> where T : ItemAdivinhacao
    {
        private List<ItemAdivinhacao> itensComCaracteristicaInicial = new List<ItemAdivinhacao>();
        private List<ItemAdivinhacao> itensSemCaracteristicaInicial = new List<ItemAdivinhacao>();

        public List<ItemAdivinhacao> GetItensComCaracteristicaInicial()
        {
            return this.itensComCaracteristicaInicial;
        }
        public List<ItemAdivinhacao> GetItensSemCaracteristicaInicial()
        {
            return this.itensSemCaracteristicaInicial;
        }
    }
}
