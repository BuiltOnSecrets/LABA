<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-image: url(image/calcpic.jpg);
        }

        .tblCalc { 
            border:3px;
            margin: 170px 400px;
            padding:20px; 
            width:500px;
            text-align:center;
        }

        .tblCalc input { 
            border:6px inset #e67b09;
            width:80px;
            margin:6px;
            border-radius: 3px 3px 3px 3px;
        }

        #btnWide { 
            width:175px;
        }

        #editWide {
            width:450px;
            text-align:right;
            font-size: 1.1em;
        }

        #result {
            width:450px;
            font-size: 1.1em;
            border:6px inset #e67b09;
            border-radius: 3px 3px 3px 3px;
            background-color: white;
            padding: 0px;
        }

        #result p {
            margin: 2px 0 2px 4px;
            text-align: left;
        }

        #result p span {
            color: orange;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <form name="calc" action="">
            <table class="tblCalc" cellpadding=0 cellspacing=0>
                <tr>
                    <td colspan=5 align=middle>
                        <asp:TextBox ID="editWide" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="C" OnClick="btnClear_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btnClearEntry" runat="server" Text="CE" OnClick="btnClearEntry_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSeven" runat="server" Text="7" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnEight" runat="server" Text="8" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnNine" runat="server" Text="9" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnPlus" runat="server" Text="+" onClick="btnOperation_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnMultiply" runat="server" Text="*" OnClick="btnOperation_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnFour" runat="server" Text="4" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnFive" runat="server" Text="5" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnSix" runat="server" Text="6" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnMinus" runat="server" Text="-" OnClick="btnOperation_Click" />
                    </td>
                    <td align=middle>
                        <asp:Button ID="btnDivide" runat="server" Text="/" OnClick="btnOperation_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnOne" runat="server" Text="1" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnTwo" runat="server" Text="2" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnThree" runat="server" Text="3" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnPercent" runat="server" Text="%" OnClick="btnPercent_Click" />
                    </td>
                    <td align=middle>&nbsp;</td>
                </tr>       
                <tr>
                    <td>
                        <asp:Button ID="btnZero" runat="server" Text="0" OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnDecimal" runat="server" Text="," OnClick="btnDigit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnNeg" runat="server" Text="+/-" OnClick="btnNeg_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnWide" runat="server" Text="=" onClick="btnEqual_Click"/>
                    </td>
                </tr>
                <% if(list.Count != 0) { %> 
                    <tr>
                        <td colspan=5 align=middle>
                            <asp:Repeater runat="server" ID="myRepeater">
                                <HeaderTemplate>
                                    <div id="result">
                                </HeaderTemplate>
                                    
                                <ItemTemplate>
                                    <p><%# Eval("Content") %> <span>(<%# Eval("Created_at")%>)</span></p>
                                </ItemTemplate>

                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                <% } %>>
            </table>
        </form>
    </form>
</body>
</html>
