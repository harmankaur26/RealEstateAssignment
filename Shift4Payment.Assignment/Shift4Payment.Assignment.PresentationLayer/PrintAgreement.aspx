<%@ Page Language="C#" AutoEventWireup="true" Title="Email and Print Agreement" CodeBehind="PrintAgreement.aspx.cs" MasterPageFile="~/Common/MainMaster.Master" Inherits="Shift4Payment.Assignment.PresentationLayer.PrintAgreement" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-left: 10px;" id="divOuter" class="layout">
        <table>
            <tr>
                <td colspan="2">
                    <h1>Rental Agreement</h1>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Literal ID="litMsg" runat="server"></asp:Literal></td>
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
            <tr>
                <td>First Name</td>
                <td>
                    <asp:Label ID="txttenantFirstName" runat="server"></asp:Label></td>
                <td></td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:Label ID="txttenantLastName" runat="server"></asp:Label></td>
                <td></td>
            </tr>
            <tr>
                <td>Lease Start Date</td>
                <td>
                    <asp:Label ID="txtStartDate" runat="server" placeholder="mm/dd/yyyy"></asp:Label></td>
                <td></td>
            </tr>
            <tr>
                <td>Lease End Date</td>
                <td>
                    <asp:Label ID="txtEndDate" runat="server" placeholder="mm/dd/yyyy"></asp:Label></td>

                <td></td>
            </tr>
            <tr>
                <td>Rent Amount</td>
                <td>
                    <asp:Label ID="txtRentAmount" runat="server"></asp:Label></td>
                <td></td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" Text="Send Email" />
                </td>
                <td>

                    <input type="button" onclick="window.print()" value="Print" /></td>
            </tr>
        </table>
    </div>
    <input type="hidden" runat="server" id="hdnHTML" />
    <script type="text/javascript">

        var html = encodeURIComponent(document.getElementById("divOuter").innerHTML);
        document.getElementById("ContentPlaceHolder1_hdnHTML").value = html;

    </script>
</asp:Content>

