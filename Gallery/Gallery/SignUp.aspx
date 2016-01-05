<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Gallery.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SignUp</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Main.aspx">Go to Main page</a>
            <br />
            <br />
            <asp:TextBox runat="server" ID="txtName" placeholder="Name" MaxLength="18"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTxtName" runat="server" ErrorMessage="* Mandatory field"
                ForeColor="Red" ControlToValidate="txtName"/>
            <br />
            <asp:RegularExpressionValidator ID="revTxtName" runat="server"
                ErrorMessage="Name contains only letters"
                ControlToValidate="txtName"
                ForeColor="Red"
                ValidationExpression="^[a-zA-ZА-Яа-я]+$" />
            <br />
            <asp:TextBox runat="server" ID="txtEmail" placeholder="Email" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTxtEmail" runat="server" ErrorMessage="* Mandatory field"
                ForeColor="Red" ControlToValidate="txtEmail"/>
            <br />
            <br />
            <asp:TextBox runat="server" ID="txtPassword" placeholder="Password" MaxLength="18" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTxtPassword" runat="server" ErrorMessage="* Mandatory field"
                ForeColor="Red" ControlToValidate="txtPassword"/>
            <br />
            <br />
            <asp:Button runat="server" ID="btnSignUp" Text="SignUp" OnClick="btnSignUp_Click" />
        </div>
    </form>
</body>
</html>
