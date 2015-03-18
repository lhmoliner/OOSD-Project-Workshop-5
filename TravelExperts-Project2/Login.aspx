<%-- * CMPP248 Project 2 Website
     * Web Form for Login
     * Created By: Leisy
     * January 23rd, 2015
     * --%>

<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content id="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">

    <style type="text/css">
        .auto-style2 {
            height: 47px;
        }
        .auto-style3 {
            height: 38px;
        }
    </style>

</asp:Content>

<asp:Content id="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <form id="formLogin" runat="server">
    <div style="position:relative; left: 220px; margin: 20px 0; width: 550px;">
        <h2>
            <asp:Label ID="lblLogin" runat="server" CssClass="h2" Text="Login"></asp:Label>
        </h2><br />
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="textbox" Width="180px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1" style="color: #FF0000; font-family: Calibri; font-style: italic"> * Username is required.</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" CssClass="textbox" TextMode="Password" Width="180px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1" style="color: #FF0000; font-style: italic; font-family: Calibri"> * Password is required.</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                    </td>
                                    <td class="auto-style2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center" class="auto-style3"> <asp:Label ID="FailureText" runat="server" style="color: #FF0000; font-family: Calibri; font-style: italic; text-align: center;"></asp:Label></td>
                                    <td class="auto-style3"></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" width="130px" ValidationGroup="Login1" CssClass="button" />
                                    </td>
                                    <td rowspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align:center; height: 40px;">- or -</td>
                                </tr>
                                <tr> 
                                    <td colspan="2" style="text-align:center;">
                                        <asp:Button ID="Button1" runat="server" CssClass="button" Text="Create Account" width="180px" PostBackUrl="~/Registration.aspx" OnClick="Button1_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
    </div>
        <div style="height: 470px; display:block;"></div>
    </form>
</asp:Content>
