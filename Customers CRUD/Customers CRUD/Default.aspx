<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Customers_CRUD._Default" %>


<!DOCTYPE html>
<html>
    <head runat="server">
        <title>Customer CRUD</title>
    </head>
    <body>
            <div class="row">
                <div class="col-lg-6">
                    <form ID="FormAddCustomer" runat="server"> 
                        <span>Add Customer</span>
                        <br>
                        <div>

                            <span>Name</span>
                            <div>
                                <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                            </div>

                            <span>Email address</span>
                            <div>
                                <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>
                            </div>

                            <span>Address</span>
                            <div>
                                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
                            </div>

                            <span>City</span>
                            <div>
                                <asp:TextBox ID="City" runat="server"></asp:TextBox>
                            </div>

                            <span>Country</span>
                            <div>
                                <asp:TextBox ID="Country" runat="server"></asp:TextBox>
                            </div>
                            <input type="reset" value="Cancel" />
                            <input type="submit" value="Add New Customer" />
                        </div>
                    </form>
                 </div>
            </div>
        </body>
</html>
