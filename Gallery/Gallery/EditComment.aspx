<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditComment.aspx.cs" Inherits="Gallery.EditComment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:TextBox ID="txtComment" runat="server" TextMode="SingleLine"  placeholder="Write a comment" MaxLength="200"></asp:TextBox>
        <asp:Button ID="btnEditComment" runat="server" Text="Edit Comment" OnClick="btnEditComment_Click"/>
        <a href="Gallery.aspx" id="linkReturnToPageGallery">go back</a>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
