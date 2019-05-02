<%@ Page Title="Tenant details" Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/MainMaster.Master" CodeBehind="AddTenants.aspx.cs" Inherits="Shift4Payment.Assignment.PresentationLayer.AddTenants" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layout">
        <table>
            <tr>
                <td colspan="2"><a href="ViewProperties.aspx"> &lt;&lt; View All Properties</a><h1>Property Details</h1></td>
            </tr>
            <tr>
                <td>Property Name</td>
                <td>
                    <asp:Label ID="lblPropertyName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <asp:Label ID="lblState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Zip</td>
                <td>
                    <asp:Label ID="lblZip" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Owner Name</td>
                <td>
                    <asp:Label ID="lblOwnerName" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr><td colspan="2"><h1>Tenant Details</h1></td></tr>
            <tr>
                <td colspan="2">
                    <asp:Literal ID="litMsg" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="txttenantFirstName" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttenantFirstName" ErrorMessage="Please Enter FirstName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txttenantLastName" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttenantLastName" ErrorMessage="Please Enter Last Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Lease Start Date</td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStartDate" ErrorMessage="Please enter lease start date"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Lease End Date</td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox></td>

                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEndDate" ErrorMessage="Please enter lease end date"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Rent Amount</td>
                <td>
                    <asp:TextBox ID="txtRentAmount" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRentAmount" ErrorMessage="Please enter rental cost"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>File Upload</td>
                <td>
                    <asp:FileUpload ID="fileUploadControl" runat="server" />
                </td>
                <td>
                </td>
            </tr>
            <tr style='<%=documentName.Length > 0 ? "": "display:none" %>'>
                <td>Download file</td>
                <td><a  target="_blank" href="<%=documentURL %>"><%=documentName %></a></td>
                <td> <asp:Button ID="btnGoogleDrive" runat="server" Text="Upload to Google Drive" OnClick="btnGoogleDrive_Click" /></td>
            </tr>


            <tr>
                <td></td>
                <td>
                    <asp:HiddenField runat="server" ID="hdnTenantId" />
                    <asp:HiddenField runat="server" ID="hdnFileName" />
                    <asp:Button ID="btnAdd" runat="server" Text="Add Tenant" OnClick="btnAdd_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
