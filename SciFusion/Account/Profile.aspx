<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SciFusion.Account.Profile" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h2><%: Title %></h2>

    <div class="row">
        <div class="col-md-8">
            <table style="width: 100%; margin-top: 10px; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                    <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-8 control-label">First Name</asp:Label>
                    <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" />
                    <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-8 control-label">Last Name</asp:Label>
                    <asp:TextBox runat="server" ID="LastName" CssClass="form-control" TextMode="SingleLine" />
                    <asp:Label runat="server" AssociatedControlID="UniName" CssClass="col-md-8 control-label">University Name</asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ID="UniName" CssClass="form-control" TextMode="SingleLine" />
                    <asp:Label runat="server" AssociatedControlID="Type" CssClass="col-md-8 control-label">Type</asp:Label>
                    <asp:TextBox runat="server" ID="Type" CssClass="form-control" TextMode="SingleLine" />
                    <asp:Label runat="server" AssociatedControlID="Contact" CssClass="col-md-8 control-label">Contact</asp:Label>
                    <asp:TextBox runat="server" ID="Contact" CssClass="form-control" TextMode="SingleLine" />
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-8 control-label">Email</asp:Label>
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="SingleLine" />
                    <asp:Label runat="server" AssociatedControlID="City" CssClass="col-md-8 control-label">City</asp:Label>
                    <asp:TextBox runat="server" ID="City" CssClass="form-control" TextMode="SingleLine" />
                    <asp:Label runat="server" AssociatedControlID="State" CssClass="col-md-8 control-label">State</asp:Label>
                    <asp:TextBox runat="server" ID="State" CssClass="form-control" TextMode="SingleLine" />

                    <asp:Button runat="server" ID="SaveButton" OnClick="SaveProfile" Text="Save Profile" CssClass="btn btn-default" />
                </tr>
            </table>
        </div>
        <div class="col-md-8">
            <asp:GridView ID="ResearcherGrid" runat="server" AutoGenerateEditButton="true" AutoGenerateColumns="false" AutoGenerateSelectButton="true">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ResearchId" ItemStyle-Width="50" ReadOnly="true" />
                    <asp:BoundField HeaderText="Name" DataField="ResearchName" ItemStyle-Width="200" />
                    <asp:BoundField HeaderText="Area Name" DataField="AreaName" ItemStyle-Width="200" />                    
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
