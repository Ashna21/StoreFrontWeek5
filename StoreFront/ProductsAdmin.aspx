<%@ Page Title="Store Front Products Admin" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="ProductsAdmin.aspx.cs" Inherits="StoreFront.ProductsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
    <h1>Products Admin</h1>
    <p>This page provides a listing of all products with their ProductID, ProductName, IsPublished, and Price with 
        edit capabilities
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:HyperLinkField Text = "Edit" runat="server" datanavigateurlfields="ProductID" DataNavigateUrlFormatString="ProductAdminDetails.aspx?ProductID={0}" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:CheckBoxField DataField="IsPublished" HeaderText="IsPublished" SortExpression="IsPublished" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            </Columns>
        </asp:GridView>
        <p></p>
        <p>Insert new products</p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource2" DefaultMode="Insert" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:CheckBoxField DataField="IsPublished" HeaderText="IsPublished" SortExpression="IsPublished" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString1 %>" InsertCommand="spAddProduct" InsertCommandType="StoredProcedure" SelectCommand="spGetProductsAll" SelectCommandType="StoredProcedure">
            <InsertParameters>
                
                <asp:Parameter Name = "productName" Type="String" />
                <asp:Parameter Name ="Description" Type="String" />
                <asp:Parameter Name="IsPublished" Type="Boolean" />
                <asp:Parameter Name="Price" Type="Decimal" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString1 %>" SelectCommand="spGetProductsAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </p>

</asp:Content>
