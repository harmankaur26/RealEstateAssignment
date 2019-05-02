<%@ Page Language="C#" AutoEventWireup="true" Title="Login to view properties" CodeBehind="Default.aspx.cs" Inherits="Shift4Payment.Assignment.PresentationLayer.Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="layout" style="position: relative;">
            <div class="login">
            <table>
                <tr>
                    <td colspan="2">Log In</td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Label ForeColor="Red" Visible="false" ID="lblErroMsg" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox></td><td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Enter Username"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox></td><td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click" /></td>
                </tr>
            </table>
                </div>
        </div>
    </form>
</body>
</html>
