using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCopa
{
    public partial class ListarEstadio : System.Web.UI.Page
    {
        EstadioBLL eService = new EstadioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarEstadios();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            List<Estadio> listaEstadiosAdicionados = eService.GetAll();

            List<Estadio> listaFiltrada = (from r in listaEstadiosAdicionados
                                           where r.Cidade.Contains(txtPesquisa.Text)
                                           select r).ToList();

            gvEstadiosAdicionados.DataSource = listaFiltrada;
            gvEstadiosAdicionados.DataBind();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            CarregarEstadios();
            txtPesquisa.Text = "";
        }

        public void CarregarEstadios()
        {
            gvEstadiosAdicionados.DataSource = eService.GetAll();
            gvEstadiosAdicionados.DataBind();
        }
    }
}