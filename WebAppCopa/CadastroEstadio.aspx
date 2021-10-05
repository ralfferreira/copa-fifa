<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroEstadio.aspx.cs" Inherits="WebAppCopa.CadastroEstadio" %>

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
                
                <div style="margin-top: 120px;">
                    Id
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div><br />

                <div>
                    Estádio<asp:TextBox ID="txtEstadio" runat="server" CssClass="form-control"></asp:TextBox>
                </div><br />

                <div>
                    Cidade<asp:TextBox ID="txtCidade" runat="server" CssClass="form-control"></asp:TextBox>
                </div><br />

                <div>
                    Capacidade
                    <asp:TextBox ID="txtCapacidade" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <br />

                <div>
                    
                    <asp:Button ID="btnAdicionar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnAdicionar_Click" />
                    
                    <asp:Button ID="btnExcluir" runat="server" CssClass="btn btn-danger" Text="Excluir" Visible="False" OnClick="btnExcluir_Click" />
                    
                    <asp:Button ID="btnConcluir" runat="server" Text="Concluir" CssClass="btn btn-info" OnClientClick="return ChamarFecharPopUp();"/>
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

            function ChamarExibirMensagemSucesso() {
                parent.ExibirMensagemSucesso(msg);
                ChamarFecharPopUp();
            }

        </script>
    </form>
</body>
</html>
