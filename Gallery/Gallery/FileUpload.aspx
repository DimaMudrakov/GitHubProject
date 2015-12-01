<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="Gallery.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Upload Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="fplFileUpload" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnSaveFile" runat="server" OnClick="btnSaveFile_Click" Text="Upload File" />
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtComment" runat="server" TextMode="SingleLine"  placeholder="Write a comment" MaxLength="200"></asp:TextBox>
            <br />
            <br />
            <a href="Gallery.aspx">Go to Gallery</a>
        </div>
    </form>
</body>
</html>
