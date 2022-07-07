<%@ Page MasterPageFile="~/Layout.Master" Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Notebook._default" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div style="float: right; width: 100%; box-sizing: border-box; padding: 1em; margin: 1em 0; border-bottom: solid 1px #cacaca">
        <asp:LoginView runat="server">
            <AnonymousTemplate>
                برای ثبت نوشته ابتدا <a href="Register.aspx">عضو</a> شوید
            </AnonymousTemplate>
            <LoggedInTemplate>
                <div id="divButtonsAddNew" onclick="window.location='/AddNote.aspx'" class="btn btnGreen">
                    ثبت نوشته جدید
                </div>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
    <div style="float: right;">
        <asp:ListView ID="noteList" runat="server"
            ItemType="Notebook.Models.M_Note"
            SelectMethod="GetNotes">
            <EmptyDataTemplate>
                هیج نوشته ای در سیستم ثبت نشده است
            </EmptyDataTemplate>
            <ItemTemplate>
                <div style="float: right; width: 100%; margin: 1em 0; box-sizing: border-box; padding: 1em;">
                    <div class="NoteHorizontalLine">
                        <div></div>
                    </div>
                    <h1 class="NoteItemTitle">
                        <%#:Item.Title%>
                    </h1>
                    <small class="NoteItemDate">نوشته شده در تاریخ : <%#:Item.CreateDate%>
                    </small>
                    <div class="NoteItemText">
                        <%#:Item.Content%>
                    </div>
                    <div>
                        <form runat="server" style="float:left;display:flex;">
                            <asp:Button
                                runat="server"
                                ID="btnLikeButton"
                                ItemId="<%# Item.Id  %>"
                                OnClick="btnLikeButton_Click"
                                CssClass="LikeButton"
                                Visible='<%# GetIsLiked(Item.Id) %>'
                                Text="❤️"></asp:Button>
                            <asp:Button
                                runat="server"
                                ID="Button1"
                                ItemId="<%# Item.Id  %>"
                                OnClick="btnLikeButton_Click"
                                CssClass="LikeButton"
                                Visible='<%# !GetIsLiked(Item.Id) %>'
                                Text="🖤"></asp:Button>
                            <asp:Label runat="server" CssClass="lblShowLikes" ID="lblLikes">
                            <%# GetLikeCounts(Item.Id) %>
                            </asp:Label>
                        </form>


                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
