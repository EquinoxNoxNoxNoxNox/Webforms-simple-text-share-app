<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Notebook.Login" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form id="form1" runat="server">
        <div id="divLoginRegisterForm">
            <asp:TextBox ID="txtUsername" placeholder="نام کاربری" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="TextValidator" runat="server" ControlToValidate="txtUsername" ErrorMessage="نام کاربری را وارد کنید" ForeColor="Red">

            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="TextValidator"
                runat="server" Display="dynamic"
                ControlToValidate="txtUsername"
                ValidationExpression="^([\S\s]{0,50})$"
                ErrorMessage="حداکثر 50 کاراکتر">
            </asp:RegularExpressionValidator>
            <br />

            <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="رمز عبور" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="TextValidator" runat="server" ControlToValidate="txtPassword" ErrorMessage="رمز عبور خود را وارد کنید" ForeColor="Red"></asp:RequiredFieldValidator>

            <br />
            <asp:Label runat="server" ID="txtUserNotFound" CssClass="txtRed">کاربر در سیستم پیدا نشد</asp:Label>
            <asp:Button ID="btnSubmit" runat="server" Text="ورود"
                OnClick="btnSubmit_Click" />
        </div>
    </form>
</asp:Content>
