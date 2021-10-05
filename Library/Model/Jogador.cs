using Library.Model.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Jogador
    {
        private int id;
        private string nmNome;
        private DateTime dtNascimento;
        private int nrCamisa;
        private string nmPosicao;
        private DateTime dtConvocacao;
        private DateTime dtDispensa;
        private PosicaoEnum posicao;

        public int Id { get => id; set => id = value; }
        public string NmNome { get => nmNome; set => nmNome = value; }
        public DateTime DtNascimento { get => dtNascimento; set => dtNascimento = value; }
        public int NrCamisa { get => nrCamisa; set => nrCamisa = value; }
        public string NmPosicao { get => nmPosicao; set => nmPosicao = value; }
        public DateTime DtConvocacao { get => dtConvocacao; set => dtConvocacao = value; }
        public DateTime DtDispensa { get => dtDispensa; set => dtDispensa = value; }
        public PosicaoEnum Posicao { get => posicao; set => posicao = value; }

        public Jogador()
        {
            Id = id++;
            NmNome = "";
            NrCamisa = 1;
            NmPosicao = "Meio campista";
            DtConvocacao = DateTime.Now;
        }

        public Jogador(DateTime Nascimento)
        {
            this.dtNascimento = Nascimento;
        }

        public Jogador(DateTime Convocacao, DateTime Dispensa)
        {
            this.dtConvocacao = Convocacao;
            this.dtDispensa = Dispensa;
        }

        public string ObterDados()
        {
            return string.Format("Nome: {0}, Camisa {1}, Posição {2}", nmNome, nrCamisa, nmPosicao);

            /*
            string mensagemFormatada =
                string.Format("Nome: {0}, Camisa {1}, Posição {2}", nmNome, nrCamisa, nmPosicao);

            return mensagemFormatada;
            */
        }

        public int CalcularIdade()
        {
            TimeSpan idade = DateTime.Now.Subtract(dtNascimento);
            int idadef = (int)idade.TotalDays / 365;
            return idadef;
        }

        public decimal IndenizacaoFifa() {
            TimeSpan diasPagar = dtDispensa.Subtract(dtConvocacao);
            decimal valorPagar = (decimal)(diasPagar.TotalDays * 8530);
            return valorPagar;
        }
    }
}
