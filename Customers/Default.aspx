﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Customer CRUD</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <asp:Button runat="server" Text="Add New Customer" ID="btnAddNewCustomer" OnClick="btnAddNewCustomer_Click"></asp:Button>
            <asp:Repeater ID="rptUsers" runat="server">

                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Customer Name</th>
                            <th>Email</th>
                            <th>Address</th>
                            <th>City</th>
                            <th>Country</th>
                            <th>Action</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                        </td>
                        <td>
                        <%# DataBinder.Eval(Container.DataItem, "Email") %>
                        </td>
                        <td>
                        <%# DataBinder.Eval(Container.DataItem, "Address") %>
                        </td>
                        <td>
                        <%# DataBinder.Eval(Container.DataItem, "City.Name") %>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Country") %>
                        </td>
                        <td>
                            <a href="EditCustomer.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID") %>">Edit Customer</a>
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
