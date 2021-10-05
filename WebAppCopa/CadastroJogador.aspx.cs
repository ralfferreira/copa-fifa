using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.Business;
using Library.Business.Exceptions;
using Library.Model;
using Library.Model.Enuns;

namespace WebAppCopa
{
    public partial class CadastroJogador : System.Web.UI.Page
    {
        JogadorBLL jService = new JogadorBLL();
        PosicionamentoBLL posService = new PosicionamentoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlPosicao.DataSource = posService.GetAll();
                ddlPosicao.DataValueField = "IdPosicao";
                ddlPosicao.DataTextField = "DescricaoPosicao";
                ddlPosicao.DataBind();
                ddlPosicao.Items.Insert(0, new ListItem("---Selecione---", "0"));

                if (!string.IsNullOrEmpty(Request.QueryString["JogadorId"]))
                {
                    int jogadorId = Convert.ToInt32(Request.QueryString["JogadorId"].ToString());
                    Jogador j = jService.GetById(jogadorId);
                    SetJogador(j);
                }
            }
        }

        protected void btnExibirDados_Click(object sender, EventArgs e)
        {
            Jogador j = new Jogador(Convert.ToDateTime(txtDataNascimento.Text));

            j.Id = int.Parse(txtId.Text);
            j.NmNome = txtNome.Text;
            j.NrCamisa = Convert.ToInt32(txtNumeroCamisa.Text);

            j.Posicao = (PosicaoEnum)Enum.Parse(typeof(PosicaoEnum), ddlPosicao.SelectedValue);
            if (j.Posicao == PosicaoEnum.LateralDireito)
                j.NmPosicao = "Lateral Direito";
            else if (j.Posicao == PosicaoEnum.LateralEsquerdo)
                j.NmPosicao = "Lateral Esquerdo";
            else if (j.Posicao == PosicaoEnum.Atacante)
                j.NmPosicao = "Atacante";
            else if (j.Posicao == PosicaoEnum.Goleiro)
                j.NmPosicao = "Goleiro";
            else if (j.Posicao == PosicaoEnum.MeioCampo)
                j.NmPosicao = "Meio Campo";
            else if (j.Posicao == PosicaoEnum.Volante)
                j.NmPosicao = "Volante";
            else
                j.NmPosicao = "Zagueiro";

            j.DtConvocacao = Convert.ToDateTime(txtConvocacao.Text);
            j.DtDispensa = Convert.ToDateTime(txtDispensa.Text);

            lblMensagem.Text = j.ObterDados();
        }

        protected void btnCalcularIdade_Click(object sender, EventArgs e)
        {
            Jogador j = new Jogador(Convert.ToDateTime(txtDataNascimento.Text));

            j.Id = int.Parse(txtId.Text);
            j.NmNome = txtNome.Text;
            j.NrCamisa = Convert.ToInt32(txtNumeroCamisa.Text);

            string mensagem = $"A idade do Jogador {j.NmNome} é {j.CalcularIdade()} anos";

            lblMensagem.Text = mensagem;
            //lblMensagem.Text = string.Format("A idade do Jogador {0} é {1} anos", j.NmNome, j.CalcularIdade());
        }

        protected void btnIndenizacaoFifa_Click(object sender, EventArgs e)
        {
            Jogador j = new Jogador(Convert.ToDateTime(txtConvocacao.Text), Convert.ToDateTime(txtDispensa.Text));            

            j.Id = int.Parse(txtId.Text);
            j.NmNome = txtNome.Text;

            var real = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", (j.IndenizacaoFifa() * 5m));
            var dolar = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "US$ {0:#,###.##}", j.IndenizacaoFifa());

            string mensagem = $"A indenização a pagar pelo jogador {j.NmNome} é <b>{dolar}</b> ou <b>{real}</b>";

            lblMensagem.Text = mensagem;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {                
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    throw new NomeInvalidoException("O Nome deve ser digitado");
                }
                if(ddlPosicao.SelectedValue == "0")
                {
                    throw new PosicaoInvalidaException("Selecione a posição que o jogador atua");
                }

                Jogador j = new Jogador(Convert.ToDateTime(txtDataNascimento.Text));

                j.Id = (!string.IsNullOrEmpty(txtId.Text)) ? Convert.ToInt32(txtId.Text) : 0;
                j.NmNome = txtNome.Text;
                j.NrCamisa = (!string.IsNullOrEmpty(txtId.Text)) ? Convert.ToInt32(txtId.Text) : 0;

                j.Posicao = (PosicaoEnum)Enum.Parse(typeof(PosicaoEnum), ddlPosicao.SelectedValue);
                if (j.Posicao == PosicaoEnum.LateralDireito)
                    j.NmPosicao = "Lateral Direito";
                else if (j.Posicao == PosicaoEnum.LateralEsquerdo)
                    j.NmPosicao = "Lateral Esquerdo";
                else if (j.Posicao == PosicaoEnum.Atacante)
                    j.NmPosicao = "Atacante";
                else if (j.Posicao == PosicaoEnum.Goleiro)
                    j.NmPosicao = "Goleiro";
                else if (j.Posicao == PosicaoEnum.MeioCampo)
                    j.NmPosicao = "Meio Campo";
                else if (j.Posicao == PosicaoEnum.Volante)
                    j.NmPosicao = "Volante";
                else
                    j.NmPosicao = "Zagueiro";

                j.DtConvocacao = Convert.ToDateTime(txtConvocacao.Text);
                j.DtDispensa = Convert.ToDateTime(txtDispensa.Text);

                if(j.DtDispensa < j.DtConvocacao)
                {
                    throw new DtDispensaException("A Data de Dispensa não pode ser mais recente que a data de convocação");
                }

                string Mensagem = "";
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    jService.Insert(j);
                    Mensagem = string.Format("Jogador ID {0} salvo com sucesso.", j.Id);
                }
                else
                {
                    j.Id = Convert.ToInt32(txtId.Text);
                    jService.Update(j);
                    Mensagem = string.Format("Jogador ID {0} atualizado com sucesso.", j.Id);
                }

                lblMensagem.Text = Mensagem;

                btnCalcularIdade.Visible = true;
                btnExibirDados.Visible = true;
                btnIndenizacaoFifa.Visible = true;
            }
            catch (NomeInvalidoException nomeEx)
            {
                lblMensagem.Text = nomeEx.Message;
            }
            catch (PosicaoInvalidaException posicaoEx)
            {
                lblMensagem.Text = posicaoEx.Message;
            }
            catch (DtDispensaException dispensaEx)
            {
                lblMensagem.Text = dispensaEx.Message;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        public void SetJogador(Jogador j) {
            txtId.Text = j.Id.ToString();
            txtNome.Text = j.NmNome;
            txtDataNascimento.Text = string.Format("{0:dd/MM/yyyy}", j.DtNascimento);
            ddlPosicao.SelectedValue = string.Format("{0}", j.Posicao);
            txtNumeroCamisa.Text = j.NrCamisa.ToString();
            txtConvocacao.Text = string.Format("{0:dd/MM/yyyy}", j.DtConvocacao);
            txtDispensa.Text = string.Format("{0:dd/MM/yyyy}", j.DtDispensa);

            btnCalcularIdade.Visible = true;
            btnExibirDados.Visible = true;
            btnIndenizacaoFifa.Visible = true;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                bool excluiu = jService.Delete(id);

                if (excluiu)
                {
                    txtId.Text = "";
                    txtNome.Text = "";
                    txtDataNascimento.Text = "";
                    ddlPosicao.SelectedValue = "";
                    txtNumeroCamisa.Text = "";
                    txtConvocacao.Text = "";
                    txtDispensa.Text = "";

                    btnCalcularIdade.Visible = false;
                    btnExibirDados.Visible = false;
                    btnIndenizacaoFifa.Visible = false;

                    lblMensagem.Text = "Jogador excluido com sucesso";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;                
            }
        }
    }
}