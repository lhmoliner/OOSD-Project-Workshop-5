<%@ Page Title="Customer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Customer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
        <h2>
            <asp:Label ID="lblCustomerDetail" runat="server" CssClass="h2" Text="Personal Information"></asp:Label>
        </h2><br />

        <asp:DetailsView ID="DetailsView1" 
            runat="server" 
            AutoGenerateRows="False" 
            DataSourceID="GetCustomerbyID" 
            Height="50px" 
            Width="100%" 
            BorderColor="#2F73C1" 
            BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="5" 
            CellSpacing="1" 
            style="margin-top: 0px" 
            CssClass="custdetailsview" OnModeChanged="DetailsView1_ModeChanged" DataKeyNames="CustomerId,CustFirstName,CustLastName,CustAddress,CustCity,CustProv,CustPostal,CustCountry,CustHomePhone,CustBusPhone,CustEmail,AgentID" OnItemDeleted="DetailsView1_ItemDeleted">
            <EditRowStyle BackColor="White" />
            <Fields>
                <asp:TemplateField HeaderText="First Name" SortExpression="CustFirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CustFirstName") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ErrorMessage="First Name is Required"
                             ControlToValidate="TextBox1">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CustFirstName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Last Name" SortExpression="CustLastName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CustLastName") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                             ErrorMessage="Last Name is Required"
                             ControlToValidate="TextBox2">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CustLastName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Address" SortExpression="CustAddress">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CustAddress") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                             ErrorMessage="Address is Required"
                             ControlToValidate="TextBox3">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CustAddress") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="City" SortExpression="CustCity">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CustCity") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                             ErrorMessage="City is Required"
                             ControlToValidate="TextBox4">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("CustCity") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Province" SortExpression="CustProv">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlProvince" runat="server" SelectedValue='<%# Bind("CustProv") %>' AppendDataBoundItems="true">
                        <asp:ListItem Value="AB">AB</asp:ListItem>
                        <asp:ListItem Value="BC">BC</asp:ListItem>
                        <asp:ListItem Value="MB">MB</asp:ListItem>
                        <asp:ListItem Value="NB">NB</asp:ListItem>
                        <asp:ListItem Value="NL">NL</asp:ListItem>
                        <asp:ListItem Value="NT">NT</asp:ListItem>
                        <asp:ListItem Value="NS">NS</asp:ListItem>
                        <asp:ListItem Value="NU">NU</asp:ListItem>
                        <asp:ListItem Value="ON">ON</asp:ListItem>
                        <asp:ListItem Value="PE">PE</asp:ListItem>
                        <asp:ListItem Value="QC">QC</asp:ListItem>
                        <asp:ListItem Value="SK">SK</asp:ListItem>
                        <asp:ListItem Value="YT">YT</asp:ListItem>
                    </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("CustProv") %>' MaxLength="2"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Postal Code" SortExpression="CustPostal">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("CustPostal") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                             ErrorMessage="PostalCode is Required"
                             ControlToValidate="TextBox6">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("CustPostal") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Country" SortExpression="CustCountry">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("CustCountry") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                             ErrorMessage="Country is Required"
                             ControlToValidate="TextBox7">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("CustCountry") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Home Phone" SortExpression="CustHomePhone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("CustHomePhone") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                             ErrorMessage="Phone is Required"
                             ControlToValidate="TextBox8">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("CustHomePhone") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Business Phone" SortExpression="CustBusPhone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("CustBusPhone") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                             ErrorMessage="Phone is Required"
                             ControlToValidate="TextBox9">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("CustBusPhone") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email" SortExpression="CustEmail">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("CustEmail") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                             ErrorMessage="Email is Required"
                             ControlToValidate="TextBox10">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("CustEmail") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="True" />

            </Fields>
            <HeaderStyle HorizontalAlign="Right" BackColor="#2F73C1" ForeColor="White" Width="160px" Font-Bold="True" />
            <RowStyle CssClass="custinfo" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="GetCustomerbyID" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCustomer" 
            TypeName="TravelExperts.CustomerDB" 
            ConflictDetection="CompareAllValues" 
            DataObjectTypeName="TravelExperts.Customer" 
            DeleteMethod="DeleteCustomer" 
            InsertMethod="AddCustomer" 
            UpdateMethod="UpdateCustomer">
            <SelectParameters>
                <asp:SessionParameter Name="customerID" SessionField="userID" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="original_customer" Type="Object" />
                <asp:ControlParameter ControlID="DetailsView1" Name="customer" PropertyName="SelectedValue" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        
        <h2>
            <asp:Label ID="lblCustomerPackages" runat="server" CssClass="h2" Text="Package Orders"></asp:Label>
        </h2><br />
       
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="GetPackagesByCustomerID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" CellPadding="1" CellSpacing="1" CssClass="pkgborder">
            <Columns>
                <asp:BoundField DataField="BookingNo" HeaderText="Booking #" SortExpression="BookingNo" >
                <HeaderStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="BookingDate" DataFormatString="{0:D}" HeaderText="Booking Date" SortExpression="BookingDate">
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="PkgName" HeaderText="Package Name" SortExpression="PkgName" >
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="PkgBasePrice" DataFormatString="{0:C}" HeaderText="Price" SortExpression="PkgBasePrice">
                <HeaderStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="PackageID" HeaderText="ID" SortExpression="PackageID">
                <HeaderStyle Width="0px" />
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="True" SelectText="More" HeaderText="Info" >
                <HeaderStyle Width="50px" />
                </asp:CommandField>
            </Columns>
            <HeaderStyle CssClass="pkgheader" />
            <RowStyle HorizontalAlign="Center" CssClass="custinfo" />
        </asp:GridView>
        <asp:ObjectDataSource ID="GetPackagesByCustomerID" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPackagesByCustomerID" TypeName="TravelExperts.PackageDB">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="userID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <br />

        <asp:Label ID="lblTotal" runat="server" style="font-weight: 700; font-size: x-large; float: right;"></asp:Label>

        <asp:Label ID="lblTotal0" runat="server" style="font-weight: 700; font-size: x-large; float: right;">Order Total to Date</asp:Label>
        <br />

</asp:Content>
