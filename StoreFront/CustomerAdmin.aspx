<%@ Page Title="Store Front Customer Admin" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="CustomerAdmin.aspx.cs" Inherits="StoreFront.CustomerAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
    <h1>Customer Admin</h1>
    <p> Following is the gridview of the customer columns with their UserID, UserName, EmailID and Edit option</p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:HyperLinkField Text = "Edit" runat="server" datanavigateurlfields="UserID" DataNavigateUrlFormatString="CustomerAdminDetails.aspx?UserID={0}" />
            <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID" InsertVisible="False" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
        </Columns>
    </asp:GridView>
    <p>Add new users</p>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="UserID" DataSourceID="SqlDataSource2" DefaultMode="Insert" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString1 %>" InsertCommand="spAddUser" InsertCommandType="StoredProcedure" SelectCommand="spGetUsers" SelectCommandType="StoredProcedure">
        <InsertParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="EmailAddress" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br />
   <br />
    <br />
&nbsp;<br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString1 %>" DeleteCommand="DELETE FROM [Users] WHERE [UserID] = @UserID" InsertCommand="INSERT INTO [Users] ([UserName], [EmailAddress], [IsAdmin], [DateCreated], [CreatedBy], [DateModified], [ModifiedBy]) VALUES (@UserName, @EmailAddress, @IsAdmin, @DateCreated, @CreatedBy, @DateModified, @ModifiedBy)" SelectCommand="spGetUsers" UpdateCommand="UPDATE [Users] SET [UserName] = @UserName, [EmailAddress] = @EmailAddress, [IsAdmin] = @IsAdmin, [DateCreated] = @DateCreated, [CreatedBy] = @CreatedBy, [DateModified] = @DateModified, [ModifiedBy] = @ModifiedBy WHERE [UserID] = @UserID" SelectCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="UserID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="EmailAddress" Type="String" />
            <asp:Parameter Name="IsAdmin" Type="Boolean" />
            <asp:Parameter Name="DateCreated" Type="DateTime" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="DateModified" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="EmailAddress" Type="String" />
            <asp:Parameter Name="IsAdmin" Type="Boolean" />
            <asp:Parameter Name="DateCreated" Type="DateTime" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="DateModified" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="UserID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>


