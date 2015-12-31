<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Gallery.Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gallery</title>
    <link href="CSS/Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList runat="server" ID="ddlSort">
            <asp:ListItem Text="ascending upload date" Value="0"></asp:ListItem>
            <asp:ListItem Text="descending upload date" Value="1"></asp:ListItem>
            <asp:ListItem Text="ascending size image" Value="2"></asp:ListItem>
            <asp:ListItem Text="descending size image" Value="3"></asp:ListItem>
            <asp:ListItem Text="ascending rating image" Value="4"></asp:ListItem>
            <asp:ListItem Text="descending rating image" Value="5"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button runat="server" ID="btnSort" Text="sort" OnClick="btnSort_Click" />
        <div>
            <asp:Repeater runat="server" ID="rptImage" OnItemCommand="rptImage_ItemCommand">
                <ItemTemplate>
                    <div id="containerImageAndComment">
                        <div id="containerImage">
                            <asp:HyperLink ID="linkToImage" runat="server" NavigateUrl='<%# "ImageStorage/" + DataBinder.Eval(Container.DataItem, "Image.UUIDName") %>'>
                                <asp:Image ID="imgGallery" ImageUrl='<%# "ImageStorage/" + DataBinder.Eval(Container.DataItem, "Image.UUIDName") %>' runat="server" Width="250px" Height="250px" AlternateText="Image" style="margin-top: 5pt;"/>
                            </asp:HyperLink>
                        </div>
                        <div id="commentImageId">
                            <asp:Label ID="lblNumberImage" runat="server" Text='<%#"Image №" + DataBinder.Eval(Container.DataItem, "Image.ID") %>'></asp:Label>
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
                            <%# DataBinder.Eval(Container.DataItem, "Comment.Imgtext") %>
                        </div>
                        <div id="containerLinkToEditComment">
                            <a href="EditComment.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "Comment.ID") %>" id="linkEditComment">Edit Comment</a>
                        </div>
                        <div id="containerDeleteImage">
                            <asp:Button runat="server" Text="Delete image" CommandName="Delete" ID="btnDeleteImageAndComment" OnClientClick="javascript:if(!confirm('Delete this image?'))return false;" CommandArgument='<%#Eval("Image.ID") %>'
                                Style="width: 115%; background-color: #19C88D; color: white; border: none; border-radius: 5px; height: 100%; font-size: 13pt; cursor: pointer;"></asp:Button>
                        </div>
                        <div class="containerTextRatingImage">
                            <span class="textRatingImage">Rating image :</span>
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
                    <div class="clearBoth"></div>
                    <div id="containerLinhGoBack">
                        <asp:HyperLink ID="hplToFileUpload" NavigateUrl="~/FileUpload.aspx" runat="server">go back</asp:HyperLink>
                    </div>
                    <div class="clearBoth"></div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
