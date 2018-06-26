﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
            <br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="Button1_Click" Text="    登录" />
            <br />
            <br />
            <asp:Label ID="tishi" runat="server" Text="提示"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtcheck" runat="server"></asp:TextBox>
            <asp:Button ID="check" runat="server" OnClick="check_Click" Text="精确查询" />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:TextBox ID="txtLike" runat="server"></asp:TextBox>
            <asp:Button ID="likeCheck" runat="server" OnClick="likeCheck_Click" Text="模糊查询" />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            <asp:Label ID="Label3" runat="server" Text="用户名"></asp:Label>
            <asp:TextBox ID="registName" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="密码"></asp:Label>
            <asp:TextBox ID="registPwd" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="性别"></asp:Label>
            <asp:RadioButtonList ID="radio" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="m">男</asp:ListItem>
                <asp:ListItem Value="w">女</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="txtRegistTIme" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="联系方式"></asp:Label>
            <asp:TextBox ID="registContact" runat="server"></asp:TextBox>
            <asp:TextBox ID="registAutoGraph" runat="server">签名</asp:TextBox>
            <asp:TextBox ID="txtRegistHeadPho" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtRegistTopImg" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtRegistBGIng" runat="server"></asp:TextBox>
            <asp:Button ID="regist" runat="server" OnClick="regist_Click" Text="注册" />
            <br />
            <br />
            <asp:TextBox ID="txtDelet" runat="server"></asp:TextBox>
            <asp:Button ID="btnDelet" runat="server" OnClick="btnDelet_Click" Text="删除" />
            <br />
            <br />
            <asp:Label ID="txtUpName" runat="server" Text="名字"></asp:Label>
            <asp:TextBox ID="upName" runat="server"></asp:TextBox>
            <asp:Label ID="jhg" runat="server" Text="密码"></asp:Label>
            <asp:TextBox ID="txtUpPwd" runat="server"></asp:TextBox>
            <asp:Label ID="oiu" runat="server" Text="联系方式"></asp:Label>
            <asp:TextBox ID="txtUpContact" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtUpAutoGraph" runat="server">签名</asp:TextBox>
            <asp:TextBox ID="txtUpUserHeadImg" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtUpUserTopImg" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtUpUserBGImg" runat="server"></asp:TextBox>
            <asp:Button ID="btnUp" runat="server" OnClick="btnUp_Click" Text="更新" />
            <br />
            <br />
            <asp:TextBox ID="txtResetName" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtResetPwd" runat="server"></asp:TextBox>
            <asp:Button ID="btnResetPwd" runat="server" OnClick="btnResetPwd_Click" Text="重置用户密码" />
            <asp:Label ID="labRestPwd" runat="server" Text="重置的密码"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtGetUserID" runat="server"></asp:TextBox>
            <asp:Button ID="btnGetUserID" runat="server" OnClick="btnGetUserID_Click" Text="获取用户ID" />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
