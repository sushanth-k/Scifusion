<%@ Page Title="Research Work" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResearchWork.aspx.cs" Inherits="SciFusion.Account.ResearchWork" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h2><%: Title %></h2>

    <div class="row">
        <asp:GridView ID="ResearchWorkGrid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Work ID" DataField="WorkID" ItemStyle-Width="50" />
                <asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="200" />
                <asp:BoundField HeaderText="Link" DataField="Links" ItemStyle-Width="200" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
