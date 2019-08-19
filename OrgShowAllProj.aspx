<%@ Page Title="" Language="C#" MasterPageFile="~/Organization.Master" AutoEventWireup="true" CodeBehind="OrgShowAllProj.aspx.cs" Inherits="CommunityESwap.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <p>
    Welcome</p>
<p>
    <asp:Button ID="btnAddProject" class="btn btn-info" runat="server" Text="+ New Project" OnClick="btnAddProject_Click" />
    </p>
    <p>
        <strong>Your Projects:</strong></p>
<p>
    <asp:GridView class="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="projectid">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="projectid" HeaderText="Project ID" InsertVisible="False" ReadOnly="True" SortExpression="projectid" />
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
            <asp:BoundField DataField="PostedDate" HeaderText="PostedDate" SortExpression="PostedDate" />
            <asp:BoundField DataField="AppCount" HeaderText="AppCount" SortExpression="AppCount" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CommunityESwapConnectionString %>" SelectCommand="SELECT [projectid], [ProjectName], [PostedDate], [AppCount] FROM [ProjectsTable] WHERE ([userid] = @userid) ORDER BY [PostedDate] DESC, [OrgName]">
        <SelectParameters>
            <asp:SessionParameter Name="userid" SessionField="userid" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</p>
<p>
    &nbsp;</p>

   
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:LinkButton ID="lbLogout" class="navbar-brand" runat="server" OnClick="lbLogout_Click">Log Out</asp:LinkButton>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="collapsibleNavbar">
    <ul class="navbar-nav">
      <li class="nav-item">
         <asp:LinkButton ID="lbProjects" CausesValidation="False" class="nav-link" runat="server" OnClick="lbProjects_Click">Projects</asp:LinkButton>
      </li>
      <li class="nav-item">
         <asp:LinkButton ID="lbStudents" CausesValidation="False" class="nav-link" runat="server" OnClick="lbStudents_Click">Students</asp:LinkButton>
      </li>
        
    </ul>
    </div>
</asp:Content>

