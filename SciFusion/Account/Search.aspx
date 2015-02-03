<%@ Page Title="Search SciFusion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SciFusion.Account.Search" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            color: Black;
            font-weight: bold;
        }

            .Initial:hover {
                color: darkgray;
            }

        .Clicked {
            float: left;
            display: block;
            background: center no-repeat right top;
            padding: 4px 18px 4px 18px;
            color: Black;
            font-weight: bold;
            color: White;
        }
    </style>
    <h2><%: Title %></h2>

    <div class="row">
        <table style="width: 80%;">
            <tr>
                <td>
                    <asp:Button Text="Researcher" Width="300" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
                        OnClick="Tab1_Click" />
                    <asp:Button Text="Research Work" Width="300" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                        OnClick="Tab2_Click" />
                    <asp:Button Text="Equipment" BorderStyle="None" Width="300" ID="Tab3" CssClass="Initial" runat="server"
                        OnClick="Tab3_Click" />
                    <asp:MultiView ID="MainView" runat="server">
                        <asp:View ID="View1" runat="server">
                            <table style="width: 100%; margin-top: 10px; border-width: 1px; border-color: #666; border-style: solid">
                                <tr>
                                    <asp:Label runat="server" AssociatedControlID="ResearcherName" CssClass="col-md-2 control-label">Last Name</asp:Label>
                                    <asp:TextBox runat="server" ID="ResearcherName" CssClass="form-control" TextMode="SingleLine" />
                                    <asp:Label runat="server" AssociatedControlID="AreName" CssClass="col-md-2 control-label">Area Name</asp:Label>
                                    <asp:TextBox runat="server" ID="AreName" CssClass="form-control" TextMode="SingleLine" />
                                    <asp:Button runat="server" OnClick="SearchResearcher" Text="Search" CssClass="btn btn-default" />
                                </tr>
                            </table>
                            <asp:GridView ID="ResearcherGrid" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="ResearcherId" ItemStyle-Width="50" />
                                    <asp:BoundField HeaderText="Name" DataField="ResearcherFullName" ItemStyle-Width="200" />
                                    <asp:BoundField HeaderText="Email" DataField="Email" ItemStyle-Width="200" />
                                    <asp:BoundField HeaderText="Contact" DataField="ContactNumber" ItemStyle-Width="200" />
                                    <asp:BoundField HeaderText="Type" DataField="Type" ItemStyle-Width="200" />
                                    <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-Width="200" />
                                    <asp:BoundField HeaderText="Major" DataField="Major" ItemStyle-Width="200" />
                                    <asp:BoundField HeaderText="Collaboration Rating" DataField="TotalRatings" ItemStyle-Width="50" />
                                    <asp:BoundField HeaderText="University Name" DataField="University.Name" ItemStyle-Width="200" />
                                    <asp:CommandField ShowSelectButton="True" SelectText="View Works" HeaderText="Research Work" />
                                </Columns>
                            </asp:GridView>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <table style="width: 100%; margin-top: 10px; border-width: 1px; border-color: #666; border-style: solid">
                                <tr>
                                    <asp:Label runat="server" AssociatedControlID="ResearchName" CssClass="col-md-2 control-label">Research Name</asp:Label>
                                    <asp:TextBox runat="server" ID="ResearchName" CssClass="form-control" TextMode="SingleLine" />                                   
                                    <asp:Label runat="server" AssociatedControlID="AreaName" CssClass="col-md-2 control-label">Area Name</asp:Label>
                                    <asp:TextBox runat="server" ID="AreaName" CssClass="form-control" TextMode="SingleLine" />
                                    <asp:Button runat="server" OnClick="SearchResearch" Text="Search" CssClass="btn btn-default" />
                                </tr>
                            </table>
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="true">
                                <Columns>
                                    <asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="50" />
                                    <asp:BoundField HeaderText="Researcher Name" DataField="Research.ResearcherFullName" ItemStyle-Width="200" />
                                    <asp:BoundField HeaderText="University Name" DataField="University.Name" ItemStyle-Width="200" />
                                </Columns>
                            </asp:GridView>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <table style="width: 100%; margin-top: 10px; border-width: 1px; border-color: #666; border-style: solid">
                                <tr>
                                    <asp:Label runat="server" AssociatedControlID="ResourceName" CssClass="col-md-2 control-label">Resource Type</asp:Label>
                                    <asp:TextBox runat="server" ID="ResourceName" CssClass="form-control" TextMode="SingleLine" />                                    
                                    <asp:Button runat="server" OnClick="SearchResource" Text="Search" CssClass="btn btn-default" />

                                </tr>
                            </table>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="EquipmentID" ItemStyle-Width="50" />
                                    <asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="200" />
                                     <asp:BoundField HeaderText="Type" DataField="Type" ItemStyle-Width="200" />
                                    <asp:TemplateField HeaderText="Equipment Calendar">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" NavigateUrl='<%# Eval("EquipmentID", "http://calendar.google.com?Id={0}") %>'
                                                Text='<%# "URL" %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="University Name" DataField="University.Name" ItemStyle-Width="200" />
                                    <asp:BoundField HeaderText="Years in use" DataField="YearsInUse" ItemStyle-Width="200" />
                                </Columns>
                            </asp:GridView>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
