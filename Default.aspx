<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdvicentCalc.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            margin-left: 440px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         
        <div class="auto-style1">
            Simple College Cost Calculator<br />
            brought to you by Advicent!<br />
            <br />
        </div>
        <br />
        Choose your College:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
      
                     <br />
        <asp:DropDownList ID="ddlCollege" runat="server" OnSelectedIndexChanged="ddlCollege_SelectedIndexChanged" DataSourceID="collegeSQLData" DataTextField="Name" DataValueField="Name" Width="385px">
        </asp:DropDownList>

                    

        <asp:SqlDataSource ID="collegeSQLData" runat="server" ConnectionString="<%$ ConnectionStrings:myConnectionString %>" SelectCommand="SELECT [Name] FROM [collegeTable]" OnSelecting="collegeSQLData_Selecting"></asp:SqlDataSource>

                    

        <br />
        <br />
        <asp:Label ID="lblInState" runat="server" Text="In state or out of state tuition?"></asp:Label>
        <br />
        <div class="auto-style2">
            <asp:RadioButtonList ID="rdoStateful" runat="server" OnSelectedIndexChanged="rdoStateful_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">In State</asp:ListItem>
                <asp:ListItem Value="1">Out Of State</asp:ListItem>
            </asp:RadioButtonList>
&nbsp;&nbsp;&nbsp;
          
        </div>
        <p>
            Include Room and Board costs?&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBox ID="chkBoxBoard" runat="server" OnCheckedChanged="chkBoxBoard_CheckedChanged" Text=" " />
        </p>
        <p class="auto-style1">
            <asp:Button ID="btnCalc" runat="server" OnClick="btnCalc_Click" Text="Calculate!" />
        </p>
                     <p>
                         Your projected costs:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="lblTotal" runat="server" Text="X"></asp:Label>
                     </p>
    </form>
</body>
</html>
