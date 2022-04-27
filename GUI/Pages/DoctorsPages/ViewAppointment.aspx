<%@ Page Title="ViewAppointment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="GUI.ViewAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .column{
        display:flex;
        float:left;
        width:50%;
    }
    .GridHeader{
        background-image: linear-gradient(black, grey);
    }
    
    </style>
    <div style="margin:5px;">

        <asp:Button ID="BtnBackToMainPage" runat="server" OnClick="BtnBackToMainPage_Click" Text="Back to main page" /> <br /><br />
        <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" Text="Show Calendar" />

        <br /> <br />

        <div class="row">
            <div class="column">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" DayNameFormat="Full" FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="297px" NextPrevFormat="FullMonth" Width="524px" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged" >

                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#000066" ForeColor="White" />
                    <SelectorStyle BorderStyle="Dotted" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#33CC33" />
                    <WeekendDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                <asp:GridView ID="GridView2" runat="server" Width="260px">
                </asp:GridView>
                <br /> <br />
            </div>
            <div class="column">
                <asp:GridView ID="GridView1" runat="server" Width="530px" AllowSorting="True" OnSorting="GridView1_Sorting" CurrentSortField="Name" CurrentSortDirection="DESC" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                    <Columns>
                        <asp:CommandField ButtonType="Button" HeaderText="Szczegóły wizyty" ShowHeader="True" ShowSelectButton="True"   >
                        <ControlStyle Width="120px" />
                        <HeaderStyle Width="130px" ForeColor="White" />

                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" ForeColor="White" />
                </asp:GridView>
             
            </div>
        </div>
    </div>    
</asp:Content>
