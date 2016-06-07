<%@ Page Title="Customer Details" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="CustomerAdminDetails.aspx.cs" Inherits="StoreFront.CustomerAdminDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
    <h1>Customer Admin Details</h1>
    <p> Please provide a UserId to get the user details</p>
<p>User Information</p>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="UserID" DataSourceID="SqlDataSource2" DefaultMode="Edit" Height="120px" OnPageIndexChanging="DetailsView1_PageIndexChanging" Width="203px">
            <Fields>
                <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </p>
<p>User Address Information</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                <asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="Address1" />
                <asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="Address2" />
                <asp:BoundField DataField="Address3" HeaderText="Address3" SortExpression="Address3" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="StateID" HeaderText="StateID" SortExpression="StateID" />
                <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
                <asp:CheckBoxField DataField="IsBilling" HeaderText="IsBilling" SortExpression="IsBilling" />
                <asp:CheckBoxField DataField="IsShipping" HeaderText="IsShipping" SortExpression="IsShipping" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="ButtonDel" runat="server" OnClick="Button1_Click1" Text="Delete User" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString1 %>" SelectCommand="spGetUserAddreses" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="UserID" QueryStringField="UserID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
</p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString1 %>" DeleteCommand="spDeleteUser" DeleteCommandType="StoredProcedure" InsertCommand="spAddUser" InsertCommandType="StoredProcedure" SelectCommand="spGetOneUser" SelectCommandType="StoredProcedure" UpdateCommand="spUpdateUser" UpdateCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="EmailAddress" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="UserID" QueryStringField="UserID" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="EmailAddress" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
        
    </asp:Content>
       