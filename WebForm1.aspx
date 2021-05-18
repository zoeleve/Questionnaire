<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="Questionnaire.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
        <div>
              <style type ="text/css">
                     .BUTTONCLASS
                     {
                         
                     }
                     .BUTTONCLASS:hover
                     {
                          border-color: aliceblue;
                         border-style: solid;

                      }
                 </style>
             <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BackColor="#538cc6"  style="max-width:900px;margin-left:auto; margin-right:auto;" Height="564px" Width="996px">
            
            <asp:Label ID="number" runat="server" style="font-size: 50px; color: forestgreen" Text="" ></asp:Label>
            <asp:Label runat="server" style="font-size: 16px; color: aliceblue" Text=" Ερωτήσεις"></asp:Label>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="1000" > </asp:Timer>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                          <asp:Label ID="timeLabel" runat="server" style="font-size: 20px; "></asp:Label>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick" />
                     </Triggers>
                 </asp:UpdatePanel>
            
            
           <br />
             <asp:Button ID="Button1" runat="server" Text="Εκκίνηση" />
           
           <br />
             &nbsp; 
             <br />
             <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="895px"></asp:TextBox>
             <br />
             <br />
             <asp:ImageButton ID="test1" runat="server" Height="100px" Width="100px" ImageAlign="Right"  OnClick="ImageButton_Click"  CssClass="BUTTONCLASS" />
             <asp:ImageButton ID="test2" runat="server" Height="100px" Width="100px" ImageAlign="Right" OnClick="ImageButton_Click" CssClass="BUTTONCLASS" />
                 <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                 </asp:RadioButtonList>
                 <asp:BulletedList ID="BulletedList1" DisplayMode="LinkButton" OnClick="BulletedList1_Click" BulletStyle="Numbered" runat="server" >
                 </asp:BulletedList>
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
                 <div style="text-align:right">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                     &nbsp; &nbsp; &nbsp; 
                 </div>
             <br />
             <br />
             <asp:Button ID="Button3" runat="server" style="position:relative; float:right; margin-right:10px;" Font-Bold="true" Text="Επόμενη" Width="100px" />
             <asp:Button ID="Button4" runat="server" style="position:relative; float:right; margin-right:10px;" Font-Bold="true" Text="Προηγούμενη" Width="100px"/>
             
             <br />
        </asp:Panel>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
