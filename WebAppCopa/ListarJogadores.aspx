<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListarJogadores.aspx.cs" Inherits="WebAppCopa.ListarJogadores" %>
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
        <div class="row">
            <div class="col-md-3"><br /><br /><br /><br /><br /><br />
                <button type="button" name="btnNovo" id="btnNovo" value="Novo" class="btn btn-primary form-control" onclick="ExibirCadastroJogador();">
                    <i class="glyphicon glyphicon-plus"></i> Novo
                </button> 
            </div>
            <div class="col-md-9">
            </div>
            <div class="col-md-12">
                <br /><br /><br /><br />
                <asp:GridView ID="gvJogadores" DataKeyNames="Id" AutoGenerateColumns="False" runat="server" CssClass="table-info">
                    <Columns>
                        <asp:BoundField HeaderText="Nome do Jogador" DataField="NmNome" />
                        <asp:BoundField HeaderText="Data de Nascimento" DataField="DtNascimento" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Nº da Camisa" DataField="NrCamisa" />
                        <asp:BoundField HeaderText="Posição" DataField="NmPosicao" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <button class="btn btn-success btn-sm" title="Editar Jogador" type="button" onclick='ExibirEdicaoJogador(<%#Eval("Id") %>); return false;'>
                                    <i class="glyphicon glyphicon-pencil"></i>
                                </button> 
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootbox.min.js"></script>
    <script src="Scripts/toastr.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript"> 
        function ExibirCadastroJogador() {
            var url = 'CadastroJogador.aspx';
            $("#frmModalUrl").attr("src", url);
            $("#frmModalUrl").attr("display", 'block');
            $("#frmModal").modal();
            return false;
        }

        function ExibirEdicaoJogador(id) {
            var url = 'CadastroJogador.aspx?JogadorId=' + id;
            $("#frmModalUrl").attr("src", url);
            $("#frmModalUrl").attr("display", 'block');
            $("#frmModal").modal();
            return false;
        }

        function FecharPopUp() {
            $("#frmModalUrl").attr("src", "about:blank");
            $("#frmModal").modal("hide");

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
