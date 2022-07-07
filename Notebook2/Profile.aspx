<%@ Page MasterPageFile="~/Layout.Master" Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Notebook2.Profile" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form runat="server">
        <asp:Button
            runat="server"
            CssClass="btn btnRed"
            Text="خروج از حساب"
            OnClick="Logout" />
    </form>
    <br />
    <br />
    <table>
        <tr>
            <th>عنوان</th>
            <th>تاریخ</th>
        </tr>
        <asp:ListView ID="noteList" runat="server"
            ItemType="Notebook.Models.M_Note"
            SelectMethod="GetNotes">
            <EmptyDataTemplate>
                شما هیچ نوشته ای ثبت نکردید
            <div class="btn" onclick="window.location='/AddNote.aspx'">ثبت نوشته</div>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <h1 class="NoteItemTitle">
                            <%#:Item.Title%>
                        </h1>
                    </td>
                    <td>
                        <%#:Item.CreateDate%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </table>
</asp:Content>
