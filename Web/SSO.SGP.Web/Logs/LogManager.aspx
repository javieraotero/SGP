<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogManager.aspx.cs" Inherits="Syncro.Test.Web.Logs.LogManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <act:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></act:ToolkitScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <asp:Panel ID="panel" runat="server" DefaultButton="btnBuscar"
                                    GroupingText="Criterios de búsqueda">
                                    <table id="tablaFiltro">
                                        <tr>
                                            <td>Fecha Desde
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaDesde" runat="server" />
                                                <act:CalendarExtender
                                                    ID="fechaDesde_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtFechaDesde" Format="dd/MM/yyyy">
                                                </act:CalendarExtender>
                                                <act:MaskedEditExtender ID="txtFechaDesde_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                                    Enabled="True" MaskType="Date" TargetControlID="txtFechaDesde">
                                                </act:MaskedEditExtender>
                                            </td>
                                            <td>Fecha Hasta
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaHasta" runat="server" />
                                                <act:CalendarExtender
                                                    ID="txtFechaHasta_CalendarExtender" runat="server" Enabled="True"
                                                    TargetControlID="txtFechaHasta" Format="dd/MM/yyyy">
                                                </act:CalendarExtender>
                                                <act:MaskedEditExtender ID="txtFechaHasta_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                                    Enabled="True" MaskType="Date" TargetControlID="txtFechaHasta">
                                                </act:MaskedEditExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DataList ID="dtlArchivosLog" runat="server"
                                    OnItemDataBound="dtlArchivosLog_OnItemDataBound" BorderColor="Gray" BorderWidth="1px" CellSpacing="-1" GridLines="Both" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                    <AlternatingItemStyle BackColor="#CCCCCC" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Larger" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        Archivos del Log
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="tblListaArchivos">
                                            <tr>
                                                <td style="width: 70px">
                                                    <asp:HyperLink ID="lnkArchivo" runat="server" Target="_blank">Abrir</asp:HyperLink>
                                                </td>
                                                <td style="width: 270px">
                                                    <asp:Label ID="lblArchivo" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPesoArchivo" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
