<%@ Page Title="Package" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Package.aspx.cs" Inherits="Package" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
        <!-- Insert Content Below -->
        <h2>Package Details</h2><br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="GetPackageByID" Height="50px" Width="100%" CellPadding="5" CellSpacing="1">
            <FieldHeaderStyle CssClass="custdetails" />
            <Fields>
                <asp:BoundField DataField="PkgName" HeaderText="Package Name" SortExpression="PkgName" />
                <asp:BoundField DataField="PkgDesc" HeaderText="Description" SortExpression="PkgDesc" />
                <asp:BoundField DataField="PkgStartDate" HeaderText="Start Date" SortExpression="PkgStartDate" DataFormatString=" {0:D}" />
                <asp:BoundField DataField="PkgEndDate" HeaderText="End Date" SortExpression="PkgEndDate" DataFormatString=" {0:D}" />
                <asp:BoundField DataField="PkgBasePrice" HeaderText="Base Price" SortExpression="PkgBasePrice" DataFormatString="{0:C}" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="GetPackageByID" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPackagesByID" TypeName="TravelExperts.PackageDB">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="PackageID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
       
         <h2>Products</h2><br />
        <asp:GridView ID="dgvProducts" runat="server" AutoGenerateColumns="False" DataSourceID="GetProductsSuppliersByPackageId" CellPadding="5" CellSpacing="1" HorizontalAlign="Center" Width="100%">
            <Columns>
                <asp:BoundField DataField="ProductSupplierId" HeaderText="ID" SortExpression="ProductSupplierId" >
                <HeaderStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="ProdName" HeaderText="Product Name" SortExpression="ProdName" >
                <HeaderStyle Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="SupName" HeaderText="Supplier Name" SortExpression="SupName" />
                <asp:BoundField DataField="BasePrice" DataFormatString="{0:C}" HeaderText="Price" SortExpression="BasePrice">
                <HeaderStyle Width="100px" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle CssClass="pkgheader" />
            <RowStyle CssClass="pkgborder" HorizontalAlign="Center" />
        </asp:GridView>
        <asp:ObjectDataSource ID="GetProductsSuppliersByPackageId" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductSupplierByPackageID" TypeName="TravelExperts.ProductSupplierDB">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="PackageID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
                <br />
        <asp:Image ID="Image" runat="server" style="margin: 0 auto; display: block;" Width="550px" />
        <br /><br /><br />
</asp:Content>
