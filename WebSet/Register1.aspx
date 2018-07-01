<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register1.aspx.cs" Inherits="Register1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>贴吧注册界面</title> 
        <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet"/> 
        <link href="css/Register.css" rel="stylesheet"/> 
        <script src="js/jqyery.min.js"></script> 
        <script src="bootstrap/js/bootstrap.min.js"></script>

            <style type="text/css">  
                body{background-color:#ffffff; no-repeat;background-size:cover;font-size: 16px;}  
                .form{background: #ccc;width:1000px;}  
                #login_form{display: none;}  
                #register_form{display: block;}  
                .fa{display: inline-block;top: 27px;left: 6px;position: relative;color: #ccc;}  
                input[type="text"],input[type="password"]{padding-left:26px;}  
                .checkbox{padding-left:21px;}
                .form-group{
                    margin-left: 100px;
                }
            .head-right{
                float:right;
                margin-top:-100px;
            }
             .head-img{
                margin-top:-20px;
            }
             .picture-mobilephone{
                 height:400px;
                 width:200px;
                 background-color:#ffffff;
                 margin-top:-440px;
                 margin-left:500px;
             }
             .formbox{
                 width:790px;
                 height:auto;
                 background-color:#ff0000;
                 margin-left:auto;
                 margin-right:auto;
             }
            </style>  
</head>
<body>
    <div class="jumbotron text-center" style="margin-bottom:0; background-color:#ffffff;">
        <div class="head-img">
            <img src="../images/loginzhuce.PNG" />
        </div>
        <div class="head-right">
            我已注册,现在就 <input type="button" value="登录" />
        </div>
    </div>
    <hr />
      <div class="jumbotron text-center" style="margin-bottom:0; background-color:#aaa;">
       <div class="formbox">
        <div class="form row" style="width:800px; background-color:yellow;  ">
                <form class="form-horizontal col-sm-offset-12 col-md-offset-12" id="register_form" runat="server" style="width:1000px;">
                    <div class="col-sm-12 col-md-12" style="background-color:red ;  ">  
                        <div class="form-group">  
                                <i class="fa fa-user fa-lg"></i>  
                                <asp:TextBox ID="UserName" runat="server" class="form-control required" type="text" placeholder="手机号"  autofocus="autofocus"  style="width:300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="UserName" ErrorMessage="用户名不能为空" ForeColor="Red"></asp:RequiredFieldValidator><%--style="margin-left:-295px;"--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  ControlToValidate="UserName" ErrorMessage="你的号码不正确" ForeColor="Red" ValidationExpression="^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$"></asp:RegularExpressionValidator>
                                <asp:LinkButton ID="lnkbtnCheck" runat="server" CausesValidation="False" OnClick="lnkbtnCheck_Click"> 检测用户名是否存在</asp:LinkButton>
                        </div>  
                        <div class="form-group">  
                                <i class="fa fa-lock fa-lg"></i>  
                                <asp:TextBox ID="UserPassWord" runat="server" TextMode="Password" class="form-control required" type="password" placeholder="密码"  name="password" style="width:300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserPassWord" ErrorMessage="密码不能为空" ForeColor="Red"  ></asp:RequiredFieldValidator><%--style="margin-left:-375px;"--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ControlToValidate="UserPassWord" ErrorMessage="密码为8-10个大小写字母和数字的组合" ForeColor="Red" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8，10}$"></asp:RegularExpressionValidator>
                        </div>  
                        <div class="form-group">  
                                <i class="fa fa-check fa-lg"></i>  
                                <asp:TextBox ID="RePassWord" runat="server" TextMode="Password"  class="form-control required" type="text" placeholder="确认密码" name="rpassword" style="width:300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RePassWord" ErrorMessage="确认密码不能为空" ForeColor="red"  ></asp:RequiredFieldValidator><%--style="margin-left:-400px;"--%>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="UserPassWord" ControlToValidate="RePassWord" ErrorMessage="确认密码正确" ForeColor="red" ></asp:CompareValidator><%--style="margin-left:40px"--%>
                        </div>  
                        <div class="form-group">  
                                <i class="fa fa-envelope fa-lg"></i>
                                <asp:TextBox ID="Email" runat="server" class="form-control eamil"  placeholder="邮箱" name="email" style="width:300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" ErrorMessage="邮箱不能为空" ForeColor="red" ></asp:RequiredFieldValidator> s<%--tyle="margin-left:-448px;"--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="邮箱格式不正确" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator><%--style="margin-left:20px"--%>
                        </div>  
                        <div class="form-group"  > <%--style="margin-left:-360px" --%>
                            <input type="submit" class="btn btn-info pull-left" id="back_btn" value="返回" style="width:100px;" />
                            <asp:Button ID="btnZhuCe" runat="server" OnClick="btnZhuCe_Click" Text="注册"  class="btn btn-success pull-right" style="width:100px"  />  
                        </div>  
                   </div>
                </form>
                </div>
            <div class="picture-mobilephone"></div>
           </div>
          </div>
     <hr />
     <div class="jumbotron text-center" style="margin-bottom:0; background-color:#ffffff;"></div>
</body>
</html>
