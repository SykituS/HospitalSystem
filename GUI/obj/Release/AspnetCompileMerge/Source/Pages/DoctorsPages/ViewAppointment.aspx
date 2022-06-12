<%@ Page Title="ViewAppointment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="GUI.ViewAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
     
    .column{
        display:flex;
        float:left;
        width:50%;
        height:100%;
    }
    .GridHeader{
        background-image: linear-gradient(black, grey);
        height:70px;
        
        
    }
    .RowStyle{
        height:35px;
    }
    .row{
        height:400px;
        width:100%;
        border:solid;
        border-color:black;
        border-radius:10px;
        margin-bottom:20px;
        
        box-shadow: 5px 5px 5px black;
    }
    .row1{
        height:400px;
        margin-bottom:20px;
        
    }

    .column3{
        display:grid;
        float:left;
        width:47.5%;
        height:100%;
        background-color:lightgray;
        border:solid;
        border-color:black;
        border-radius:10px;
        margin-left:0.8%;
        box-shadow: 5px 5px 5px black;
        
        
    }
    .column0{
        
        width: 48%;
        height:100%;
        float: left;
        background-color:lightgray;
        margin-left:1%;
    }
    .row2{
        width:100%;
        height:65%;
    }
    .smallRow{
        
        
        width:100%;
        height:15%;
        margin-left:3%;
        font-size:16px;
        margin-bottom:1%
        
    }
   
    h3{
        text-align:center;
    }
 
    .cbp-mc-column {
    width: 33.33%;
    height:100%;
    float: left;
    background-color:lightgray;


    }
    .cbp-mc-columnn {
    
     width: 48%;
     height:100%;
     float: left;
     margin-left:1%;
    
    }
    .roww{
        width:100%;
        height:100px;
    }
    .p{
        font-size:16px;
    }
    
    </style>

    <div style="margin:15px;">

    <div class="roww">
        <div class="cbp-mc-columnn">
        <asp:Button ID="BtnBackToMainPage" runat="server" OnClick="BtnBackToMainPage_Click" Text="Back to main page" /> <br /><br />
        <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" Text="Show Calendar" /></div>
        
        <div class="cbp-mc-columnn">
            <br /> <br />
            

        </div>
      
        <br /> <br />
    </div>
        <div class="row">
            <div class="column">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" DayNameFormat="Full" FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="100%" NextPrevFormat="FullMonth" Width="100%" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged" >

                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#000066" ForeColor="White" />
                    <SelectorStyle BorderStyle="Dotted" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#33CC33" />
                    <WeekendDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                
                <br /> <br />
            </div>
            <div class="column">
                
            
                <div style="overflow-y: scroll;height: 100%; width: 569px;">
                <asp:GridView ID="GridView1" runat="server" Width="550px" AllowSorting="True" OnSorting="GridView1_Sorting" CurrentSortField="Name" CurrentSortDirection="DESC" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="100%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                    <Columns>
                        <asp:CommandField ButtonType="Button" HeaderText="Appointment details" ShowHeader="True" ShowSelectButton="True" SelectText="Select"   >
                        <ControlStyle Width="120px" />
                        <HeaderStyle Width="130px" ForeColor="White" />

                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" ForeColor="White" />
                    <RowStyle CssClass="RowStyle" />
                </asp:GridView>
                </div>
            </div>
            
        </div>
        
        <div class="row"> 
            
            <div class="cbp-mc-column">
                <div class="smallRow"><p>Name: </p> <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox> </div>
                <div class="smallRow"><p>Phone Number: </p> <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox></div>
                <div class="smallRow"><p>Comments: </p> <asp:TextBox ID="TextBox4" runat="server" Height="160px" Width="389px" TextMode="MultiLine"></asp:TextBox></div>
                    <br /> <br />
                    <br /> <br />
                    <br /> <br />
                    <br /> <br />
                <div class="smallRow"><asp:Button ID="Button6" runat="server" Text="Approve" OnClick="Button6_Click" /></div>
            </div>
            <div class="cbp-mc-column">
                    <div class="smallRow"><p>Surname: </p> <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox></div>
                    <div class="smallRow"><p>Pesel: </p> <asp:TextBox ID="TextBox7" runat="server" ReadOnly="True"></asp:TextBox></div>
                    <br /> <br />
                    <div class="smallRow"><asp:TextBox ID="TextBox6" runat="server" TextMode="Date" OnTextChanged="TextBox6_TextChanged" Visible="False"></asp:TextBox></div>
                    
                    <div class="smallRow"><asp:TextBox ID="TextBox5" runat="server" TextMode="Time" OnTextChanged="TextBox5_TextChanged" Visible="False"></asp:TextBox></div>
                    
                    <div class="smallRow"><asp:Button ID="Button7" runat="server" Text="Confirm new appointment" OnClick="Button7_Click" Visible="False" /></div>
                    
                    <div class="smallRow"><asp:Button ID="Button5" runat="server" Text="Add new appointment" OnClick="Button5_Click" Visible="False" /></div>                
            </div>
            <div class="cbp-mc-column">
                       <p>Visits history</p>
                    <asp:ListBox ID="ListBox1" runat="server" Height="310px" Width="373px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True">
                        </asp:ListBox>
                    <br /> <br />
                    <div class="smallRow">
                          <asp:Button ID="Button4" runat="server" Text="Back to current visit" OnClick="Button4_Click" /></div>
            </div>
       </div> 


            
    </div>
        <div class="row1">
            <div class="column3">
                <h3>Prescription</h3>
                <div class="row_persc">
                    <div class="column0">
              

                        <div class="smallRow"><p>Medicine: </p> <asp:TextBox ID="PrescMedicine" runat="server" Height="100px" Width="250px" TextMode="MultiLine" Columns="0"></asp:TextBox></div>
                    </div>
                    <div class="column0">
                
                        <div class="smallRow"><p>Dosage: </p> <asp:TextBox ID="PrescSurname" runat="server" Height="100px" TextMode="MultiLine" Width="250px"></asp:TextBox></div>
                    </div>
                </div>
                    
                  <div class="smallRow">
                      <p><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
                      <asp:Button ID="Button2" runat="server" Text="Approve" OnClick="bt_add_prescription" /></div>


                   
            </div>
            <div class="column3">
                <h3>Referral</h3>
               

                  <div class="smallRow"><p>Medical examination:</p> 
                      <asp:TextBox ID="RefExamination" runat="server" EnableTheming="True" Height="200px" Width="300px" TextMode="MultiLine" OnTextChanged="RefExamination_TextChanged"></asp:TextBox>
                  </div>
                <div class="smallRow">
                    <p><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></p>
                      <asp:Button ID="Button3" runat="server" Text="Approve" OnClick="Button3_Click" /></div>


            </div>
         

        </div>

    
</asp:Content>
