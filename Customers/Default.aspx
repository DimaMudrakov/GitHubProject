<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                <asp:Button runat="server" Text=" + Add New Customer" CssClass="btnAddNewCustomerDefault" ID="btnAddNewCustomer" OnClick="btnAddNewCustomer_Click"></asp:Button>
            <asp:GridView ID="grvCustomers" CssClass="Grid" runat="server" AutoGenerateColumns="false"
                PageSize="10" AllowPaging="true" AllowSorting="false" DataSourceID="dsCustomers">
                <Columns>
                    <asp:BoundField DataField="User.Name" HeaderText="Customer Name" />
                    <asp:BoundField DataField="User.Email" HeaderText="Email" />
                    <asp:BoundField DataField="User.Address" HeaderText="Address" />
                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "City.Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField DataField="User.Country" HeaderText="Country" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                                <a class="linkPageDefault" href="EditCustomer.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "User.ID") %>">Edit Customer</a>
                        </ItemTemplate>
                    </asp:TemplateField>    
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="dsCustomers" runat="server" EnablePaging="true" SelectMethod="GetCustomers"
                SelectCountMethod="GetCustomersCount" TypeName="CustomerDS" MaximumRowsParameterName="maxRows"
                StartRowIndexParameterName="startIndex">
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
