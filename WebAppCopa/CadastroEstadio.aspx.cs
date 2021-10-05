using Library.Business;
using Library.Business.Exceptions;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCopa
{
    public partial class CadastroEstadio : System.Web.UI.Page
    {
        EstadioBLL eService = new EstadioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["EstadioId"]))
                {
                    int estadioId = Convert.ToInt32(Request.QueryString["EstadioId"]);
                    Estadio estadio = eService.GetById(estadioId);
                    SetEstadio(estadio);
                }
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEstadio.Text))
                {
                    throw new NomeInvalidoException("O nome do Estádio deve ser informado");
                }
                if (string.IsNullOrWhiteSpace(txtCidade.Text))
                {
                    throw new NomeInvalidoException("O nome da Cidade deve ser informado");
                }

                Estadio estadio = new Estadio();
                estadio.Id = (!string.IsNullOrEmpty(txtId.Text)) ? Convert.ToInt32(txtId.Text) : 0;
                estadio.Nome = txtEstadio.Text;
                estadio.Cidade = txtCidade.Text;
                estadio.Capacidade = (!string.IsNullOrEmpty(txtCapacidade.Text)) ? Convert.ToInt32(txtCapacidade.Text) : 0;

                string mensagem = "";

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    eService.Insert(estadio);

                    mensagem = string.Format("Estadio ID {0} cadastrado com sucesso!", estadio.Id);
                }
                else
                {
                    estadio.Id = Convert.ToInt32(txtId.Text);

                    eService.Update(estadio);

                    mensagem = string.Format("Estadio ID {0} atualizado com sucesso!", estadio.Id);
                }

                lblMensagem.Text = mensagem;
            }
            catch (NomeInvalidoException ex)
            {
                lblMensagem.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        public void SetEstadio(Estadio e)
        {
            txtId.Text = e.Id.ToString();
            txtEstadio.Text = e.Nome;
            txtCidade.Text = e.Cidade;
            txtCapacidade.Text = e.Capacidade.ToString();

            btnExcluir.Visible = true;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                bool excluiu = eService.Delete(id);

                if (excluiu)
                {
                    txtId.Text = "";
                    txtEstadio.Text = "";
                    txtCidade.Text = "";
                    txtCapacidade.Text = "";

                    btnExcluir.Visible = false;

                    lblMensagem.Text = "Estadio exluido com sucesso";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}