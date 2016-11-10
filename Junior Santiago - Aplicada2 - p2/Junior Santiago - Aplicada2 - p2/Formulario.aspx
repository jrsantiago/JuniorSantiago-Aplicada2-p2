<%@ Page Title="" Language="C#" MasterPageFile="~/ParcialAplicadaMaster.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Junior_Santiago___Aplicada2___p2.Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 185px;
        }
        .auto-style2 {
            width: 100%;
            height: 104px;
        }
        .auto-style3 {
            height: 13px;
        }
        .auto-style4 {
            height: 13px;
            width: 9px;
        }
        .auto-style5 {
            width: 9px;
        }
        .auto-style6 {
            width: 547px;
        }
        .auto-style7 {
            height: 72px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">

        <table class="auto-style1">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Id &nbsp;
                                <asp:TextBox ID="BuscarTextBox" runat="server"></asp:TextBox>
                                <asp:Button ID="BuscarButton" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fecha
                                <asp:TextBox ID="FecharTextBox" runat="server"></asp:TextBox>
                                &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Articulos&nbsp;
                                <asp:DropDownList ID="ArticulosDropDownList" runat="server" Height="16px" Width="113px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cantidad
                                <asp:TextBox ID="CantidadTextBox0" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                                <asp:Button ID="AgregarButton" CssClass ="btn btn-primary" runat="server" Text="Add" OnClick="AgregarButton_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <table class="nav-justified">
                        <tr>
                            <td class="auto-style6">&nbsp;&nbsp;</td>
                            <td>
                                <asp:GridView ID="DetalleGridView" runat="server" Height="140px" Width="221px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="ArticuloId" HeaderText="ArticuloId" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
&nbsp; Total
                                <asp:TextBox ID="TotalTextBox" runat="server"></asp:TextBox>
&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="GuardarButton" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="GuardarButton_Click"></asp:LinkButton>     

&nbsp;&nbsp;
        <asp:Button ID="NuevoButton" CssClass="btn btn-info" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
&nbsp;&nbsp;
      
        <asp:LinkButton ID="EliminarButton" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click"></asp:LinkButton>

    </div>
</asp:Content>
