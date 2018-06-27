<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

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
            <asp:Label ID="labIDTiShi0" runat="server" Text="at表获取用户ID"></asp:Label>
            <asp:TextBox ID="txtGetUserID" runat="server"></asp:TextBox>
            <asp:Button ID="btnGetUserID" runat="server" OnClick="btnGetUserID_Click" Text="获取用户ID" />
            <asp:Label ID="lbGetUserID" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="labIDTiShi" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="labIDTiShi1" runat="server" Text="barAtt表："></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="查询所有信息"></asp:Label>
            <asp:TextBox ID="txtByBarName" runat="server"></asp:TextBox>
            <asp:Button ID="btnByBarName" runat="server" OnClick="btnByBarName_Click" Text="btnByBarName" />
            <asp:TextBox ID="txtByUserID" runat="server"></asp:TextBox>
            <asp:Button ID="btnByUserID" runat="server" OnClick="btnByUserID_Click" Text="btnByUserID" />
            <asp:Label ID="labBarAtt" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server" Text="查询相关个数"></asp:Label>
            <asp:TextBox ID="txtBarAttCountName" runat="server"></asp:TextBox>
            <asp:Button ID="btnBarAttCountName" runat="server" OnClick="btnBarAttCountName_Click" Text="name" />
            <asp:TextBox ID="txtBarAttCountID" runat="server"></asp:TextBox>
            <asp:Button ID="btnBarAttCountID" runat="server" OnClick="btnBarAttCountID_Click" Text="id" />
            <asp:Label ID="labBarAttCount" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="labIDTiShi2" runat="server" Text="barType表:"></asp:Label>
            <asp:TextBox ID="txtBarType" runat="server"></asp:TextBox>
            <asp:Button ID="btnBarType" runat="server" OnClick="btnBarType_Click" Text="查询barType" />
            <asp:Button ID="btnCheckLike" runat="server" OnClick="btnCheckLike_Click" Text="模糊查询Bartype" />
            <asp:Label ID="labBarType" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="labIDTiShi3" runat="server" Text="notice表:"></asp:Label>
            <asp:TextBox ID="txtNotice" runat="server"></asp:TextBox>
            <asp:Button ID="btntxtNotice" runat="server" OnClick="btntxtNotice_Click" Text="   精确查询" />
            <asp:Button ID="txtNoticeLikeCheck" runat="server" OnClick="txtNoticeLikeCheck_Click" Text="模糊查询" />
            <asp:Label ID="labNotice" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="labIDTiShi4" runat="server" Text="postColl表："></asp:Label>
            <br />
            <asp:Label ID="Label10" runat="server" Text="查询所有信息"></asp:Label>
            <asp:TextBox ID="txtByCollName" runat="server"></asp:TextBox>
            <asp:Button ID="btnByCollName" runat="server" OnClick="btnByCollName_Click" Text="ByCollName" />
            <asp:TextBox ID="txtCollByUserID" runat="server"></asp:TextBox>
            <asp:Button ID="btnCollByUserID" runat="server" OnClick="btnCollByUserID_Click" Text="CollByUserID" />
            <asp:Label ID="labPostColl" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text="查询相关个数"></asp:Label>
            <asp:TextBox ID="txtPostCollCountName" runat="server"></asp:TextBox>
            <asp:Button ID="btnPostCollCountName" runat="server" OnClick="btnPostCollCountName_Click" Text="name" />
            <asp:TextBox ID="txtPostCollCountID" runat="server"></asp:TextBox>
            <asp:Button ID="btnPostCollCountID" runat="server" OnClick="btnPostCollCountID_Click" Text="ID" />
            <asp:Label ID="labPostCollCount" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
