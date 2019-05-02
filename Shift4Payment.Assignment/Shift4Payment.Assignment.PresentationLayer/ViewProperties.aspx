<%@ Page Title="Properties view" Language="C#" AutoEventWireup="true" MasterPageFile="~/Common/MainMaster.Master" Inherits="Shift4Payment.Assignment.PresentationLayer.ViewProperties" Codebehind="ViewProperties.aspx.cs" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layout">
        <table>
            <tr>
                <td><h1>View Properties</h1></td>
            </tr>
            <tr>
                <td>
                    <a href="AddProperty.aspx">Add New Property</a></td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0">
                        <asp:Repeater ID="rptPropertyList" runat="server">
                             <HeaderTemplate>
                                <tr class="propertyheader">
                                    <td>Property Name</td>
                                    <td>Address</td>
                                    <td>City</td>
                                    <td>State</td>
                                    <td>Zip Code</td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="propertyRow">
                                    <td><%#Eval("PropertyName") %></td>
                                    <td><%#Eval("Address") %></td>
                                    <td><%#Eval("City") %></td>
                                    <td><%#Eval("State") %></td>
                                    <td><%#Eval("Zip") %></td>
                                    <td><a href="AddTenants.aspx?id=<%#Eval("PropertyId") %>">View/Link</a></td>
                                    <td><a target="_blank" href="printagreement.aspx?id=<%#Eval("PropertyId") %>">Print/Email</a></td>

                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="propertyRow altColor">
                                    <td><%#Eval("PropertyName") %></td>
                                    <td><%#Eval("Address") %></td>
                                    <td><%#Eval("City") %></td>
                                    <td><%#Eval("State") %></td>
                                    <td><%#Eval("Zip") %></td>
                                    <td><a href="AddTenants.aspx?id=<%#Eval("PropertyId") %>">View/Link</a></td>
                                    <td><a target="_blank" href="printagreement.aspx?id=<%#Eval("PropertyId") %>">Print/Email</a></td>
                                </tr>
                            </AlternatingItemTemplate>


                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
