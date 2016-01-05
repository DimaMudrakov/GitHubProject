<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="Gallery.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Upload Page</title>

    <link href="Lib/Bootstrap/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/FileUploadStyles.css" rel="stylesheet" />

    <script src="Lib/Jquery/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script src="Lib/Bootstrap/JS/bootstrap.file-input.js" type="text/javascript"></script>
    <script src="JS/script.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="containerFileUpload">
                <div class="row">
                <asp:FileUpload ID="fplFileUpload" runat="server" CssClass=""/>
                </div>
                <div class="row">
                <asp:Button ID="btnSaveFile" runat="server" OnClick="btnSaveFile_Click" Text="Upload File" CssClass="btn col-lg-6 col-md-6" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" CssClass="btn col-lg-6 col-md-6" />
                </div>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>

                <asp:TextBox ID="txtComment" runat="server" TextMode="SingleLine" placeholder="Write a comment" MaxLength="200"></asp:TextBox>

                <a href="Gallery.aspx">Go to Gallery</a>
            </div>
        </div>
    </form>
</body>
</html>
