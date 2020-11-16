using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JogoGourmet.View
{
    public partial class View : Form
    {
        /// <summary>
        /// Objeto que será alimentado com os pratos informados.
        /// </summary>
        private Model.ListaPratos<Model.ItemAdivinhacao> listaPratos;
        /// <summary>
        /// Lista de pratos com caracteristica inicial ou sem caracteristica inciial, dependendo da manipulacao;
        /// </summary>
        List<Model.ItemAdivinhacao> listaManipulada;
        /// <summary>
        /// Resposta do questionamento
        /// </summary>
        private DialogResult resposta;

        public View()
        {
            InitializeComponent();

            this.listaPratos = new Model.ListaPratos<Model.ItemAdivinhacao>();

            this.listaPratos.GetItensComCaracteristicaInicial().Add(new Model.Prato("Lasanha", "")); /*não precisa de caracteristica, sempre vai ser a última opção*/
            this.listaPratos.GetItensSemCaracteristicaInicial().Add(new Model.Prato("Bolo de chocolate", "")); /*não precisa de caracteristica, sempre vai ser a última opção*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IniciarJogo();
        }

        private void IniciarJogo()
        {
            var prato = new Model.Prato("Lasanha", "massa");
            this.resposta = AdivinharCaracteristica(prato);

            if (this.resposta == DialogResult.Yes)
                listaManipulada = listaPratos.GetItensComCaracteristicaInicial();
            else
                listaManipulada = listaPratos.GetItensSemCaracteristicaInicial();
            AdivinharPratos();
        }

        private DialogResult AdivinharCaracteristica(Model.ItemAdivinhacao prato)
        {
            return MessageBox.Show("O Prato que você pensou é " + prato.GetCaracteristica() + "?", "", MessageBoxButtons.YesNo);
        }

        private DialogResult AdivinharPrato(Model.ItemAdivinhacao prato)
        {
            return MessageBox.Show("O Prato que você pensou é " + prato.GetNome() + "?", "", MessageBoxButtons.YesNo);
        }

        private void AdivinharPratos()
        {
            /*ponto de quebra (onde o novo prato deverá ser inserido caso necessario)*/
            int posicaoPrato = 0;

            /*percorro a lista de pratos perguntando sobre suas caracteristicas*/
            for (int i = 0; i < listaManipulada.Count; i++)
            {
                if (i == listaManipulada.Count - 1) /*se chegar no ultimo elemento (lasanha ou bolo de chocolate) é perguntado se é o prato*/
                {
                    this.resposta = AdivinharPrato(listaManipulada[i]);
                }
                else
                {
                    this.resposta = AdivinharCaracteristica(listaManipulada[i]);

                    /*se o prato perguntado possui a caracteristica é perguntado se é o prato*/
                    if (this.resposta == DialogResult.Yes)
                    {
                        this.resposta = AdivinharPrato(listaManipulada[i]);
                        break;
                    }
                }
                posicaoPrato = i;
            }
            
            /* se adivinhou o prato*/
            if (this.resposta == DialogResult.Yes)
            {
                MessageBox.Show("Acertei de novo!", "", MessageBoxButtons.OK);
            }
            else
            {
                AdicionarNovoPrato(posicaoPrato);
            }
        }

        private void AdicionarNovoPrato(int posicao)
        {
            var nomePrato = Microsoft.VisualBasic.Interaction.InputBox("Qual prato você pensou?", "Desisto", string.Empty, 200, 200);

            var caracteristicaPrato = Microsoft.VisualBasic.Interaction.InputBox(nomePrato + "é _____ mas " + listaManipulada[posicao].GetNome() + " não.", "Complete", string.Empty, 200, 200);

            if (nomePrato.Trim() == string.Empty || nomePrato.Trim() == string.Empty)
                MessageBox.Show("Não consegui identificar o novo prato, que pena!", "", MessageBoxButtons.OK);
            else
                listaManipulada.Insert(posicao, new Model.Prato(nomePrato, caracteristicaPrato));
        }
    }
}
