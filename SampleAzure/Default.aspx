<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleAzure.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="50%">
                <tr>
                    <td>Resource Group :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRG" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>WebApp :
                    </td>
                    <td>
                        <asp:TextBox ID="txtWebappName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>App Service Plan :
                    </td>
                    <td>
                        <asp:TextBox ID="txtASP" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Location :
                    </td>
                    <td>
                        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Create" OnClick="btnSubmit_Click" />
                    </td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
