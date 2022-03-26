<%@ Page Title="ViewAppointment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="GUI.ViewAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin:5px;">

        <asp:Button ID="BtnBackToMainPage" runat="server" OnClick="BtnBackToMainPage_Click" Text="Back to main page" /> <br /><br />
        <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" Text="Show Calendar" />

        <br /> <br />

        <div class="row">
            <div class="column1">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" DayNameFormat="Full" FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="297px" NextPrevFormat="FullMonth" Width="524px" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged" >

                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                    <WeekendDayStyle BackColor="#FF3300" />
                </asp:Calendar>
                <br /> <br />
            </div>
            <div class="column2">
                <asp:GridView ID="GridView1" runat="server" Width="263px" AllowSorting="True" OnSorting="GridView1_Sorting" CurrentSortField="Name" CurrentSortDirection="DESC" >
                <%--<Columns>
                        <asp:BoundField HeaderText="Day" DataField="Ap_appoitment_day" SortExpression="Day" />
                        <asp:BoundField HeaderText="Time" DataField="Ap_appoitment_time" SortExpression="Time" />
                        <asp:BoundField HeaderText="End time" DataField="Ap_appoitment_time_end" SortExpression="Time1" />
                        <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name" />
                        <asp:BoundField HeaderText="Surname" DataField="Surname" SortExpression="Surname" />
                        <asp:BoundField HeaderText="Office" DataField="Of_office_number" SortExpression="Office" />
                    </Columns>--%>
                </asp:GridView>
             
            </div>
        </div>
    </div>    
</asp:Content>
