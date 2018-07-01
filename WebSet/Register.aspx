<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册</title>
    <link href="bootstrap4/css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="bootstrap4/js/bootstrap.min.js"></script>
    <link href="css/Register.css" rel="stylesheet" />
</head>
<body>
    <div class="jumbotron text-center" style="margin-bottom: 0; background-color: #ffffff;">
        <div class="head-img">
            <img src="imgs/bd_logo1.png"style="height:100px;width:200px" />
        </div>
        <div class="head-right">
            我已注册,现在就
            <%--<input type="button" value="登录" />--%>
            <%--<asp:Button ID="login" runat="server" class="btn btn-default" Text="登录" href="Main.aspx" OnClick="login_Click"/>--%>
        </div>
    </div>
    <hr />
    <div class="jumbotron text-center" style="margin-bottom: 0; background-color: #aaa;height:800px">
        <div class="formbox">
            <div class="form row" style="width: 800px; background-color: #ccc;margin-top:20px">
                <form class="form-horizontal col-sm-offset-12 col-md-offset-12" id="register_form" runat="server" style="width: 1000px;">
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group">
                            <i class="fa fa-user fa-lg"></i>
                            <asp:TextBox ID="userName" runat="server" class="form-control required" type="text" placeholder="用户名" autofocus="autofocus" style="width:300px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="UserName" ErrorMessage="用户名不能为空" ForeColor="Red" Style="margin-left: -330px;position:absolute"></asp:RequiredFieldValidator>
                            <asp:LinkButton ID="lnkbtnCheck" runat="server" CausesValidation="False" OnClick="lnkbtnCheck_Click" Style="margin-left: -330px;position:absolute"></asp:LinkButton>
                        </div>
                        <div class="form-group">
                            <i class="fa fa-check fa-lg"></i>
                            <select  runat="server" style="width:300px" class="form-control required" id="Sex">
                                <option value="男">男</option>
                                <option value="女">女</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <i class="fa fa-lock fa-lg"></i>
                            <asp:TextBox ID="UserPassWord" runat="server" TextMode="Password" class="form-control required" type="password" placeholder="密码" name="password" Style="width: 300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserPassWord" ErrorMessage="密码不能为空" ForeColor="Red" Style="margin-left: -330px;position:absolute"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="UserPassWord" ErrorMessage="密码为8-16字母和数字的组合" ForeColor="Red" ValidationExpression="^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{8,16}$" Style="margin-left: -330px;position:absolute"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <i class="fa fa-check fa-lg"></i>
                            <asp:TextBox ID="RePassWord" runat="server" TextMode="Password" class="form-control required" type="text" placeholder="确认密码" name="rpassword" Style="width: 300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RePassWord" ErrorMessage="确认密码不能为空" ForeColor="red" Style="margin-left: -330px;position:absolute"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="UserPassWord" ControlToValidate="RePassWord" ErrorMessage="确认密码不正确" ForeColor="red" Style="margin-left: -330px;position:absolute"></asp:CompareValidator>
                        </div>
                        <div class="form-group">
                            <i class="fa fa-user fa-lg"></i>
                            <asp:TextBox ID="telNum" runat="server" class="form-control required" type="text" placeholder="手机号" autofocus="autofocus" Style="width: 300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="telNum" ErrorMessage="号码不能为空" ForeColor="Red" Style="margin-left: -330px;position:absolute"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="telNum" ErrorMessage="你的号码不正确" ForeColor="Red" ValidationExpression="^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$" Style="margin-left: -330px;position:absolute"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <i class="fa fa-envelope fa-lg"></i>
                            <asp:TextBox ID="Email" runat="server" class="form-control eamil" placeholder="邮箱" name="email" Style="width: 300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" ErrorMessage="邮箱不能为空" ForeColor="red" Style="margin-left: -330px;position:absolute"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="邮箱格式不正确" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Style="margin-left: -330px;position:absolute"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group" style="margin-left: -360px;margin-top:40px;">
                            <input type="submit" class="btn btn-info pull-left" id="back_btn" value="返回" style="width: 100px;" />
                            <asp:Button ID="btnZhuCe" runat="server" OnClick="btnZhuCe_Click" Text="注册" class="btn btn-success pull-right" Style="width: 100px" />
                        </div>
                    </div>
                </form>
            </div>
            <div class="picture-mobilephone"></div>
        </div>
    </div>
    <hr />
    <div class="jumbotron text-center" style="margin-bottom: 0; background-color: #ffffff;"></div>
</body>
</html>
