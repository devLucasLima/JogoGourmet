using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet.Model
{
    public class Prato: ItemAdivinhacao
    {
        private string nome { get; set; }
        private string caracteristica { get; set; }

        public Prato(string nome, string caracteristica)
        {
            this.nome = nome;
            this.caracteristica = caracteristica;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public string GetCaracteristica()
        {
            return this.caracteristica;
        }
    }
}
