<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditCustomer.aspx.cs" Inherits="EditCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Edit Customer</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" />
    <script src="lib/jquery/jquery-1.11.3.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contanierForm">
            <div class="FieldName">
                <asp:Label AssociatedControlID="txtName" runat="server">Name</asp:Label>
                <asp:TextBox ID="txtName" runat="server" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTxtName" runat="server" ErrorMessage="* Mandatory field"
                    ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
            </div>
            <div class="FieldEmail">
                <asp:Label AssociatedControlID="txtEmail" runat="server">Email address</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="* Mandatory field"
                    ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail"
                    runat="server" ErrorMessage="Please Enter Valid Email"
                    ValidationGroup="vgSubmit" ControlToValidate="txtEmail"
                    CssClass="requiredFieldValidateStyle"
                    ForeColor="Red"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </div>
            <div class="FieldAddress">
                <asp:Label AssociatedControlID="txtAddress" runat="server">Address</asp:Label>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="* Mandatory field"
                    ForeColor="Red" ControlToValidate="txtAddress">
                </asp:RequiredFieldValidator>
            </div>
            <div class="FieldDdlCity">
                <asp:Label AssociatedControlID="ddlCity" runat="server">City</asp:Label>
                <asp:DropDownList runat="server" ID="ddlCity"></asp:DropDownList>
            </div>
            <div class="FieldCountry">
                <asp:Label AssociatedControlID="txtCountry" runat="server">Country</asp:Label>
                <asp:TextBox runat="server" ID="txtCountry"></asp:TextBox>
            </div>

            <asp:Label AssociatedControlID="btnEditCustomer" runat="server"></asp:Label>
            <asp:Button runat="server" ID="btnEditCustomer" Text="Save" OnClick="btnEditCustomer_Click" />
            <asp:Button runat="server" ID="btnDeleteCustomer" Text="Delete" OnClick="btnDeleteCustomer_Click" />
            <a class="linkPageEditCustomer" href="Default.aspx">Cancel</a>
             <div class="containerForWrongLabel">
                <asp:Label ID="lblInformLabel" runat="server" AssociatedControlID="hdfWrongEmail" ></asp:Label>
                <asp:HiddenField ID="hdfWrongEmail" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
