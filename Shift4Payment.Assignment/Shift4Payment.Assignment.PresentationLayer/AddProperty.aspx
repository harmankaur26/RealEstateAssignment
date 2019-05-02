<%@ Page Language="C#" AutoEventWireup="true" Title="Add New Properties" MasterPageFile="~/Common/MainMaster.Master" Inherits="Shift4Payment.Assignment.PresentationLayer.AddProperty" CodeBehind="AddProperty.aspx.cs" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <table>
            <tr>
                <td></td>
                <td>
                    <asp:Literal ID="litMsg" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>Property Name</td>
                <td>
                    <asp:TextBox ID="txtPropertyName" runat="server"></asp:TextBox></td><td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPropertyName" ErrorMessage="Enter Property Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td><td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td><td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCity" ErrorMessage="Enter City"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox></td><td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtState" ErrorMessage="Enter State"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Zip</td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td><td>


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtZip" ErrorMessage="Enter Zip"></asp:RequiredFieldValidator>


                </td>
            </tr>
            <tr>
                <td>Owner Name</td>
                <td>
                    <asp:TextBox ID="txtOwnerName" runat="server"></asp:TextBox></td><td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOwnerName" ErrorMessage="Enter Owner Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Property" OnClick="btnAdd_Click" /></td>
            </tr>
        </table>
    </div>

</asp:Content>
