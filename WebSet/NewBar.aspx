<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewBar.aspx.cs" Inherits="NewBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>贴吧注册界面</title>
    <link href="bootstrap4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/newbar.css" rel="stylesheet" />
    <script src="js/jqyery.min.js"></script>
    <script src="bootstrap4/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="bootstrap4/js/bootstrap.min.js"></script>
    <script type="text/html" src="js/newbar.js"></script>
</head>
<body>
    <div class="jumbotron text-center" style="margin-bottom: 0; background-color: #ffffff;">
        <div class="head-right">
            <input type="button" value="用户" style="margin-top: -20px; margin-left: 00px" /><input type="button" value="登陆" style="margin-top: -20px; margin-left: 00px" />
        </div>
        <div class="head-img">
            <img src="imgs/bd_logo1.png" style="height: 100px; width: 200px; margin-top: -50px" /><input type="text" style="width: 300px; margin-top: 50px" /><input type="button" value="搜索" style="margin-top: 50px" />
        </div>
    </div>
    <hr />
    <div class="neirongbox">
        <div class="form row" style="width: 550px; height: 500px; background-color: #ffffff; margin-left: 400px; float: left; margin-top: 70px;">
            <form class="form-horizontal col-sm-offset-12 col-md-offset-12" id="register_form" runat="server" style="width: 600px; position: absolute">
                <div class="col-sm-12 col-md-12">
                    <h3 style="text-align: center">创建贴吧</h3>
                    <div class="form-group">
                        <i class="fa fa-user fa-lg"></i>
                        <asp:TextBox ID="UserName" runat="server" class="form-control required" type="text" placeholder="吧主" autofocus="autofocus" Style="width: 300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="UserName" ErrorMessage="用户名不能为空" ForeColor="Red" Style="position: absolute; top: 92px; left: 115px; width: 300px;"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <i class="fa fa-user fa-lg"></i>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="barTypeName" DataValueField="barTypeName" Width="300px">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PostBarConnectionString5 %>" SelectCommand="SELECT * FROM [T_BarType]"></asp:SqlDataSource>
                    </div>
                    <div class="form-group">
                        <i class="fa fa-lock fa-lg"></i>
                        <asp:TextBox ID="barName" runat="server" class="form-control required" type="text" placeholder="吧名" name="password" Style="width: 300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="barName" ErrorMessage="吧名不能为空" ForeColor="Red" Style="position: absolute"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <i class="fa fa-envelope fa-lg"></i>
                        <span>
                            <asp:TextBox ID="chkCode" runat="server" class="form-control eamil" placeholder="验证码" name="email" Style="width: 180px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="chkCode" ErrorMessage="验证码能为空" ForeColor="red" Style="position: absolute"></asp:RequiredFieldValidator>
                            <asp:Image ID="yanzhengma" runat="server" Height="35px" ImageUrl="~/验证码.aspx" Width="100px" Style="cursor: hand; border: 1px solid #ccc; vertical-align: top; margin-top: -38px; margin-left: 200px"
                                onclick="this.src=this.src+'?temp='+ Math.random();" /></span>
                        <p>验证码看不清请点击图片换一张</p>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnZhuCe" runat="server" Text="创建" class="btn btn-success pull-right" Style="width: 100px" OnClick="btnZhuCe_Click" />
                        <a href="Main.aspx">
                            <input type="button" class="btn btn-info pull-left" id="back_btn" value="返回" style="width: 100px;" /></a>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <hr />
    <div class="jumbotron text-center" style="margin-bottom: 0; background-color: #ffffff;"></div>
</body>
</html>
