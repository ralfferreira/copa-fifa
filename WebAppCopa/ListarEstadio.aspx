<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListarEstadio.aspx.cs" Inherits="WebAppCopa.ListarEstadio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/toastr.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div id="frmModal" class="modal fade" name="frmModal" role="dialog" style="display:none">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div>
                        <iframe src="javascript:" id="frmModalUrl" name="frmModalUrl" class="frame-param" style="border: 0; width: 800px; height: 600px"></iframe>                        
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
        <br /> <br /> <br />
        <div class="row">
            <div class="col-md-3">
                <br />
                <button type="button" name="btnNovo" id="btnNovo" value="Novo" class="btn btn-primary form-control" onclick="ExibirCadastroEstadio();">
                    <i class="glyphicon glyphicon-plus"></i> Novo
                </button> 
            </div><br />
            <div class="col-md-9">
                <asp:TextBox ID="txtPesquisa" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" CssClass="btn btn-sucess" OnClick="btnPesquisar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar Pesquisa" CssClass="btn btn-warning" OnClick="btnLimpar_Click" />
            </div>
        </div><br />
        <div>
            <asp:GridView ID="gvEstadiosAdicionados" DataKeyNames="Id" runat="server" CssClass="table-info" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id Estádio" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome Estádio" />
                    <asp:BoundField DataField="Cidade" HeaderText="Cidade Estádio" />
                    <asp:BoundField DataField="Capacidade" HeaderText="Capacidade Estádio" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <button class="btn btn-success btn-sm" title="Editar Estadio" type="button" onclick='ExibirEdicaoEstadio(<%#Eval("Id") %>); return false;'>
                                <i class="glyphicon glyphicon-pencil"></i>
                            </button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootbox.min.js"></script>
    <script src="Scripts/toastr.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript"> 
        function ExibirCadastroEstadio() {
            var url = 'CadastroEstadio.aspx';
            $("#frmModalUrl").attr("src", url);
            $("#frmModalUrl").attr("display", 'block');
            $("#frmModal").modal();
            return false;
        }

        function ExibirEdicaoEstadio(id) {
            var url = 'CadastroEstadio.aspx?EstadioId=' + id;
            $("#frmModalUrl").attr("src", url);
            $("#frmModalUrl").attr("display", 'block');
            $("#frmModal").modal();
            return false;
        }

        function FecharPopUp() {
            $("#frmModalUrl").attr("src", "about:blank");
            $("#frmModal").modal("hide");

            location.href = location.href
        }

        function ExibirMensagemSucesso(msg) {
            toastr.success(msg, "Informação:", {
                //"timeOut": "0",
                "extendedTimeOut": "0",
                "progressBar": true
            });
        }

        function ExibirMensagemErro(msg) {
            toastr.error(msg, "Informação:", {
                //"timeOut": "0",
                "extendedTimeOut": "0",
                "progressBar": true
            });

        }
    </script>
</asp:Content>
