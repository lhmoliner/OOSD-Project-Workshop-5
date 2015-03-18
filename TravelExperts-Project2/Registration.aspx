<%-- * CMPP248 Project 2 Website
     * Web Form for Registration
     * Created By: John, MB Jae
     * January 23rd, 2015
     * --%>

<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content id="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
        .auto-style3 {
            font-family: Calibri;
            color: #FF0000;
            font-style: italic;
        }
        .auto-style4 {
            font-style: italic;
        }
    </style>
</asp:Content>

<asp:Content id="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <form id="formRegistration" runat="server" style="margin: 0 auto;">
    <div style="margin: 0 auto; display: block;">
        <h2>
            <asp:Label ID="lblCustomerDetail" runat="server" CssClass="h2" Text="Create Account"></asp:Label>
        </h2>
        <p>
            &nbsp;</p>
        <table class="auto-style1">
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="25" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter your first name." style="color: #FF0000" CssClass="auto-style4"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="25" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter your last name." style="color: #FF0000" CssClass="auto-style4"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="75" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter your address." style="color: #FF0000" CssClass="auto-style4"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" MaxLength="50" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity" ErrorMessage="Please enter your city." style="color: #FF0000" CssClass="auto-style4"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Province</td>
                <td>
                    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" CssClass="dropdown">
                        <asp:ListItem Value="AB">Alberta</asp:ListItem>
                        <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                        <asp:ListItem Value="MB">Manitoba</asp:ListItem>
                        <asp:ListItem Value="NB">New Brunswick</asp:ListItem>
                        <asp:ListItem Value="NL">Newfoundland and Labrador</asp:ListItem>
                        <asp:ListItem Value="NT">Nortwest Territories</asp:ListItem>
                        <asp:ListItem Value="NS">Nova Scotia</asp:ListItem>
                        <asp:ListItem Value="NU">Nunavut</asp:ListItem>
                        <asp:ListItem Value="ON">Ontario</asp:ListItem>
                        <asp:ListItem Value="PE">Prince Edward Island</asp:ListItem>
                        <asp:ListItem Value="QC">Quebec</asp:ListItem>
                        <asp:ListItem Value="SK">Saskatchewan</asp:ListItem>
                        <asp:ListItem Value="YT">Yukon</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Postal Code</td>
                <td>
                    <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="7" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPostalCode" ErrorMessage="Please enter your postal code." style="color: #FF0000" Display="Dynamic" CssClass="auto-style4"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="e.g. A1A 1A1" ValidationExpression="^[A-Za-z]{1}[0-9]{1}[A-Za-z]{1}\s[0-9]{1}[A-Za-z]{1}[0-9]{1}$" CssClass="auto-style3"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Country</td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server" MaxLength="25" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCountry" ErrorMessage="Please enter your country." style="color: #FF0000" CssClass="auto-style4"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Home Phone</td>
                <td>
                    <asp:TextBox ID="txtHomePhone" runat="server" MaxLength="10" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtHomePhone" ErrorMessage="Please enter your home phone number." style="color: #FF0000" Display="Dynamic" CssClass="auto-style4"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHomePhone" Display="Dynamic" ErrorMessage="e.g. 1112223344" ValidationExpression="^[0-9]{10,14}$" CssClass="auto-style3"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Business Phone</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtBusinessPhone" runat="server" MaxLength="20" CssClass="textbox" Height="25px"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBusinessPhone" ErrorMessage="Please enter your business phone number." style="color: #FF0000" Display="Dynamic" CssClass="auto-style4"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtBusinessPhone" Display="Dynamic" ErrorMessage="e.g. 1112223344" ValidationExpression="^[0-9]{10,14}$" CssClass="auto-style3"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Email Address</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter your email address." style="color: #FF0000" Display="Dynamic" CssClass="auto-style4"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="e.g. text@gmail.com (Should start with a letter)" ValidationExpression="^[A-Za-z]+([A-Za-z0-9._+$-]*[A-Za-z0-9].)?[@]{1}[A-Za-z0-9]{2,}([.]{1}[A-Za-z]{2,}){1,2}$" CssClass="auto-style3"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" TextMode="Password" CssClass="textbox"></asp:TextBox>
                </td>
                <td rowspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter your password." style="color: #FF0000" Display="Dynamic" CssClass="auto-style4"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPassword" CssClass="auto-style3" Display="Dynamic" ErrorMessage="Password must be between 8 and 50 characters, contain at least one digit and one alphabetic character, and must not contain special characters." ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,50})$"></asp:RegularExpressionValidator>
                  
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="The passwords do not match." style="color: #FF0000; font-family: Calibri; font-style: italic;"></asp:CompareValidator>
                  
                </td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="50" TextMode="Password" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" aria-autocomplete="none">
                    <asp:Label ID="lblErrorMsg" runat="server" style="color: #FF0000; font-family: Calibri"></asp:Label>
                </td>
            </tr>
        </table>

        <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="button" />
            &nbsp;<asp:Button ID="btnClear" runat="server" CausesValidation="False" OnClick="btnClear_Click" Text="Clear" CssClass="button" />
            &nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="button" CausesValidation="False" />
        </div>
        <br />
        <br />
        <br />
        <br />
    </form>
</asp:Content>
