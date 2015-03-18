<%@ Page Title="PasswordReset" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="PasswordReset.aspx.cs" Inherits="PasswordReset" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h3>Retrieve Password</h3>

        <asp:Label id="Msg" runat="server" ForeColor="maroon" /><br />

        Username: <asp:Textbox id="UsernameTextBox" Columns="30" runat="server" AutoPostBack="true" />
        <asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                    ControlToValidate="UsernameTextBox" ForeColor="red"
                                    Display="Static" ErrorMessage="Required" /><br />

        <asp:Button id="ResetPasswordButton" Text="Reset Password" 
                    OnClick="ResetPassword_OnClick" runat="server" Enabled="False" />
    </div>
</asp:Content>
