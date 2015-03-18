<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Package.aspx.cs" Inherits="Package"%>

<asp:Content id="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link href="Styles/Package.css" rel="stylesheet" />
</asp:Content>


<asp:Content id="formContent" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <!-- Insert Content Below -->
        <h2>Customer&#39;s Package</h2><br />
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
    </form>
</asp:Content>