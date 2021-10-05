<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroJogador.aspx.cs" Inherits="WebAppCopa.CadastroJogador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>     
    <link href="Content/toastr.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />       
    <title>Cadastro de Jogadores</title>
</head>
<body>
    <form id="form1" runat="server" style="display: flex; align-items: center; justify-content: center; text-align: center;">
        <div>
            <div style="margin-left: 80px;">
                <div style="margin-top: 30px;">Id
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div><br />
                
                <div>Nome
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                </div><br />

                <div>Data de Nascimento - (dd/mm/aaaa)
                    <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control"></asp:TextBox>
                </div><br />

                <div>Número Camisa
                    <asp:TextBox ID="txtNumeroCamisa" runat="server" CssClass="form-control"></asp:TextBox>
                </div><br />

                <div>Posição
                    <asp:DropDownList ID="ddlPosicao" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div><br />

                <div>Data de Convocação - (dd/mm/aaaa)
                    <asp:TextBox ID="txtConvocacao" runat="server" CssClass="form-control"></asp:TextBox>
                </div><br />
                
                <div>Data de Dispensa - (dd/mm/aaaa)
                    <asp:TextBox ID="txtDispensa" runat="server" CssClass="form-control"></asp:TextBox>
                </div><br />

                <div>
                    
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" CssClass="btn btn-primary"/>
                    
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CssClass="btn btn-danger" OnClientClick="return ConfirmarExclusao(this);" OnClick="btnExcluir_Click"/>
                </div><br />

                <div>
                    <asp:Button ID="btnExibirDados" runat="server" Text="Exibir Dados" OnClick="btnExibirDados_Click" Visible="False" CssClass="btn btn-primary"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCalcularIdade" runat="server" Text="Calcular Idade" OnClick="btnCalcularIdade_Click" Visible="False" CssClass="btn btn-success"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnIndenizacaoFifa" runat="server" Text="Calcular Indenização" OnClick="btnIndenizacaoFifa_Click" Visible="False" CssClass="btn btn-info"/>
                </div><br />

                <div>
                    <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <script src="Scripts/jquery-3.3.1.min.js"></script>
        <script src="Scripts/bootbox.min.js"></script>
        <script src="Scripts/toastr.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
        <script type="text/javascript">

            function ChamarFecharPopUp() {
                parent.FecharPopUp();
            }

            function ChamarExibirMensagemErro(msg) {
                parent.ExibirMensagemErro(msg);
            }

            function ChamarExibirMensagemSucesso(msg) {
                parent.ExibirMensagemSucesso(msg);
                ChamarFecharPopUp();
            }

            function ConfirmarExclusao(sender) {

                if ($(sender).attr("ExclusaoConfirmada") == "true") {
                    return true;
                }

                bootbox.confirm({
                    message: "Deseja realmente excluir este jogador?";
                    buttons: {
                        confirm: {
                            label: 'Sim',
                            className: 'btn btn-sucess'
                        },
                        cancel: {
                            label: 'Não',
                            className: 'btn btn-danger'
                        }
                    },
                    callback: function (confirmed) {
                        if (confirmed) {
                            $(sender).attr("ExclusãoConfirmada", confirmed).trigger("click");
                        };
                    }
                });

                return false;
            };

        </script>
    </form>
</body>
</html>
