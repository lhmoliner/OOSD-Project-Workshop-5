
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<asp:Content id="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server"></asp:Content>

<asp:Content id="formContent" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <p>Welcome to the Travel Experts! Please select a customer by their first name to view their details below:</p>

    <form id="form1" runat="server">

        <h2>
            <asp:Label ID="lblSelectCustomer" runat="server" CssClass="h2" Text="Select Customer"></asp:Label>
        </h2><br />

        <asp:DropDownList ID="ddlCustomers" runat="server" 
            DataSourceID="GetCustomers" 
            DataTextField="CustFirstName" 
            DataValueField="CustomerID" 
            AutoPostBack="True" 
            Height="36px" 
            style="font-size: large" 
            Width="238px">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="GetCustomers" 
            runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCustomers" 
            TypeName="TravelExperts.CustomerDB">

        </asp:ObjectDataSource>
        
        <h2>
            <asp:Label ID="lblCustomerDetail" runat="server" CssClass="h2" Text="Customer Details"></asp:Label>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CustFirstName") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ErrorMessage="First Name is Required"
                             ControlToValidate="TextBox1">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CustLastName") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                             ErrorMessage="Last Name is Required"
                             ControlToValidate="TextBox2">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CustAddress") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                             ErrorMessage="Address is Required"
                             ControlToValidate="TextBox3">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CustCity") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                             ErrorMessage="City is Required"
                             ControlToValidate="TextBox4">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("CustCity") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Province" SortExpression="CustProv">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CustProv") %>' MaxLength="2"></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                             ErrorMessage="Province is Required"
                             ControlToValidate="TextBox5">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CustProv") %>' MaxLength="2"></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                             ErrorMessage="Province is Required"
                             ControlToValidate="TextBox5">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("CustPostal") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                             ErrorMessage="PostalCode is Required"
                             ControlToValidate="TextBox6">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("CustCountry") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                             ErrorMessage="Country is Required"
                             ControlToValidate="TextBox7">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("CustHomePhone") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                             ErrorMessage="Phone is Required"
                             ControlToValidate="TextBox8">
                         </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    </InsertItemTemplate>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("CustBusPhone") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                             ErrorMessage="Phone is Required"
                             ControlToValidate="TextBox9">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
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
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("CustEmail") %>'></asp:TextBox>
                        <!--Validator-->
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                             ErrorMessage="Email is Required"
                             ControlToValidate="TextBox10">
                         </asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("CustEmail") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="custdetails" />
                </asp:TemplateField>

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />

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
                <asp:ControlParameter ControlID="ddlCustomers" Name="customerID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="original_customer" Type="Object" />
                <asp:ControlParameter ControlID="DetailsView1" Name="customer" PropertyName="SelectedValue" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        
        <h2>
            <asp:Label ID="lblCustomerPackages" runat="server" CssClass="h2" Text="Customer's Packages"></asp:Label>
        </h2><br />
       
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="GetPackagesByCustomerID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" CellPadding="1" CellSpacing="1" CssClass="pkgborder">
            <Columns>
                <asp:CommandField ShowSelectButton="True" >
                <HeaderStyle Width="90px" />
                </asp:CommandField>
                <asp:BoundField DataField="PackageID" HeaderText="Package ID" SortExpression="PackageID" >
                <HeaderStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="PkgName" HeaderText="Package Name" SortExpression="PkgName" >
                <HeaderStyle Width="180px" />
                </asp:BoundField>
                <asp:BoundField DataField="PkgDesc" HeaderText="Package Description" SortExpression="PkgDesc" />
            </Columns>
            <HeaderStyle CssClass="pkgheader" />
            <RowStyle HorizontalAlign="Center" CssClass="custinfo" />
        </asp:GridView>
        <asp:ObjectDataSource ID="GetPackagesByCustomerID" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPackagesByCustomerID" TypeName="TravelExperts.PackageDB">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCustomers" Name="id" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>


    </form>

</asp:Content>
