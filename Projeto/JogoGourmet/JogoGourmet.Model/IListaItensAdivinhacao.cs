using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet.Model
{
    public interface IListaItensAdivinhacao<T> where T : ItemAdivinhacao
    {
        List<ItemAdivinhacao> GetItensComCaracteristicaInicial();

        List<ItemAdivinhacao> GetItensSemCaracteristicaInicial(); 
    }
}
