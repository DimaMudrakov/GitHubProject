﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Gallery.Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gallery</title>
    <link href="CSS/Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server" ID="ddlSort">
                <asp:ListItem Text="ascending upload date" Value="0"></asp:ListItem>
                <asp:ListItem Text="descending upload date" Value="1"></asp:ListItem>
                <asp:ListItem Text="ascending size image" Value="2"></asp:ListItem>
                <asp:ListItem Text="descending size image" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button runat="server" ID="btnSort" Text="sort" OnClick="btnSort_Click" />
            <asp:Repeater runat="server" ID="rptImage" OnItemCommand="rptImage_ItemCommand">
                <ItemTemplate>
                    <div id="containerImageAndComment">
                        <div id="imageID">
                            <asp:Label ID="lblIDImage" runat="server" Text='<%#"Image ID" +  DataBinder.Eval(Container.DataItem, "Image.ID") %>'></asp:Label>
                        </div>
                        <div id="containerImage">
                            <asp:HyperLink ID="linkToImage" runat="server" NavigateUrl='<%# "ImageStorage/" + DataBinder.Eval(Container.DataItem, "Image.UUIDName") %>'>
                                <asp:Image ID="imgGallery" ImageUrl='<%# "ImageStorage/" + DataBinder.Eval(Container.DataItem, "Image.UUIDName") %>' runat="server" Width="200px" Height="200px" AlternateText="Image" />
                            </asp:HyperLink>
                        </div>
                        <div id="commentImageId">
                            <asp:Label ID="lblIDImageInComment" runat="server" Text='<%#"Comment to image with ID" + DataBinder.Eval(Container.DataItem, "Comment.ImageID") %>'></asp:Label>
                        </div>
                        <div id="contanierUploadedDate">
                            <asp:Label ID="lblDate" runat="server" Text='<%#"Date uploaded" + " " + " : " + " " + DataBinder.Eval(Container.DataItem, "Image.CreateTS") %>'></asp:Label>
                        </div>
                        <div id="containerFilesize">
                            <asp:Label ID="lblFileSize" runat="server" Text='<%#"File Size" + " " + " : " + " " + DataBinder.Eval(Container.DataItem, "Image.FileSize") %>'></asp:Label>
                        </div>
                        <div id="containerYourComment">
                            <asp:Label ID="lblYourComment" runat="server" Text="Your Comment"></asp:Label>
                        </div>
                        <div id="containerComment">
                            <asp:Label ID="lblComment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comment.Imgtext") %>'></asp:Label>
                        </div>
                        <div id="containerLinkToEditComment">
                            <a href="EditComment.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "Comment.ID") %>">Edit Comment</a>
                        </div>
                        <div id="containerDeleteImage">
                            <asp:Button runat="server" Text="Delete image" CommandName="Delete" ID="btnDeleteImageAndComment" OnClientClick="javascript:if(!confirm('Delete this image?'))return false;" CommandArgument='<%#Eval("Image.ID") %>'></asp:Button>
                        </div>
                        <div id="containerRating">
                            <asp:RadioButtonList runat="server" ID="rblRating" AutoPostBack="true" 
                                                 OnSelectedIndexChanged="rblRating_SelectedIndexChanged" 
                                                 RepeatDirection="Horizontal" DataValueField='<%# DataBinder.Eval(Container.DataItem, "Image.ID") %>'>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <div id="containerLinhGoBack">
                        <asp:HyperLink ID="hplToFileUpload" NavigateUrl="~/FileUpload.aspx" runat="server">go back</asp:HyperLink>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
