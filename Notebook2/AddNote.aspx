<%@ Page MasterPageFile="~/Layout.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddNote.aspx.cs" Inherits="Notebook.AddNote" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <form runat="server">
        <div id="divLoginRegisterForm">
            <asp:TextBox ID="txtTitle" MaxLength="110" placeholder="عنوان نوشته" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="TextValidator" runat="server" ControlToValidate="txtTitle" ErrorMessage="عنوان را وارد کنید" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="TextValidator"
                runat="server" Display="dynamic"
                ControlToValidate="txtTitle"
                ValidationExpression="^([\S\s]{0,80})$"
                ErrorMessage="حداکثر 80 کاراکتر">
            </asp:RegularExpressionValidator>
            
            <br />

            <asp:TextBox MaxLength="1000" ID="txtContent" placeholder="متن نوشته را وارد کنید حداکثر 1000 کاراکتر" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="TextValidator"
                runat="server" Display="dynamic"
                ControlToValidate="txtContent"
                ValidationExpression="^([\S\s]{0,1000})$"
                ErrorMessage="حداکثر 1000 کاراکتر">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="TextValidator" runat="server" ControlToValidate="txtContent" ErrorMessage="متن را وارد کنید" ForeColor="Red"></asp:RequiredFieldValidator>

            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="ثبت متن"
                OnClick="btnSubmit_Click" />

        </div>
    </form>
</asp:Content>
