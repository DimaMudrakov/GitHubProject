<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Gallery.Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gallery</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater runat="server" ID="rptImage">
                <ItemTemplate>
                    <asp:Image ID="imgGallery" ImageUrl='<%# "ImageStorage/" + DataBinder.Eval(Container.DataItem, "UUIDName") %>' runat="server" Width="200px" Height="200px" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
