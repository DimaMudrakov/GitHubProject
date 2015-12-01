﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Gallery.Gallery" %>

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
                    <asp:HyperLink ID="linkToImage" runat="server" NavigateUrl='<%# "ImageStorage/" + DataBinder.Eval(Container.DataItem, "Image.UUIDName") %>'>
                        <asp:Label ID="lblIDImage" runat="server" Text='<%#"Image ID" +  DataBinder.Eval(Container.DataItem, "Image.ID") %>' ></asp:Label>
                        <asp:Image ID="imgGallery" ImageUrl='<%# "ImageStorage/" + DataBinder.Eval(Container.DataItem, "Image.UUIDName") %>' runat="server" Width="200px" Height="200px" AlternateText="Image" />
                    </asp:HyperLink>
                    <asp:Label ID="lblIDImageInComment" runat="server" Text= '<%#"Comment to image with ID" + DataBinder.Eval(Container.DataItem, "Comment.ImageID") %>'></asp:Label>
                    <asp:Label ID="lblComment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comment.Imgtext") %>'></asp:Label>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>