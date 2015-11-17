<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewCustomer.aspx.cs" Inherits="Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Add New Customer</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contanierForm">
            <asp:Label AssociatedControlID="txtName" runat="server">Name</asp:Label>
            <asp:TextBox id="txtName" runat="server"></asp:TextBox>
            <br>
            <br>
            <asp:Label AssociatedControlID="txtEmail" runat="server">Email address</asp:Label>
            <asp:TextBox id="txtEmail" runat="server"></asp:TextBox>
            <br>
            <br>
            <asp:Label AssociatedControlID="txtAddress" runat="server">Address</asp:Label>
            <asp:TextBox id="txtAddress" runat="server"></asp:TextBox>
            <br>
            <br>
            <asp:Label AssociatedControlID="ddlCity" runat="server">City</asp:Label>
            <asp:DropDownList runat="server" ID="ddlCity"></asp:DropDownList>
            <br>
            <br>
            <asp:Label AssociatedControlID="txtCountry" runat="server">Country</asp:Label>
            <asp:TextBox runat="server" ID="txtCountry"></asp:TextBox>
            <br>
            <br>
            <asp:Label AssociatedControlID="btnAddNewCustomer" runat="server"></asp:Label>
            <asp:Button runat="server" ID="btnAddNewCustomer" Text=" + Add New Customer" OnClick="btnAddNewCustomer_Click"/>
            
            <a class="linkPageAddNewCustomer" href="Default.aspx">Cancel</a>
        </div>
    </form>
</body>
</html>
