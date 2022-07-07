<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Notebook.Register" %>

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

        <asp:TextBox ID="txtPassword" placeholder="رمز عبور" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator CssClass="TextValidator" runat="server" ControlToValidate="txtPassword" ErrorMessage="رمز عبور خود را وارد کنید" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator CssClass="TextValidator"
            runat="server" Display="dynamic"
            ControlToValidate="txtPassword"
            ValidationExpression="^([\S\s]{8,50})$"
            ErrorMessage="حداقل 8 کاراکتر و حداکثر 50 کاراکتر">
        </asp:RegularExpressionValidator>

        <br />

        <asp:Button ID="btnSubmit" runat="server" Text="ثبت نام"
            OnClick="btnSubmit_Click" />
    </div>
</form>
    
</asp:Content>