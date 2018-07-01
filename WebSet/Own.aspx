<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" CodeFile="Own.aspx.cs" Inherits="Default2" %>

<%@ Register Src="~/control/chartsPanel.ascx" TagPrefix="uc1" TagName="chartsPanel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/Own.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="lunimg"></div>
    <div class="functionbar1">
        <div class="fakeimg"></div>
        <div class="info">
            <asp:label id="userName1" runat="server" text="xxx"></asp:label>
            <br />
            用户名：<asp:label id="userName2" runat="server" text=""></asp:label>
        </div>
    </div>
    <div class="deliver">
        <div class="deliver-contain">
            <div class="functionbar2">
                <ul id="myTab" class="nav navbar-nav">
	                <li class="active"><a href="#home" data-toggle="tab">我的主页</a></li>
	                <li class="active"><a href="#ios" data-toggle="tab">帖子</a></li>
		            <li class="active"><a href="#home" data-toggle="tab">关注的吧</a></li>
                    <li class="active"><a href="#home" data-toggle="tab">收藏</a></li>
                </ul>
            </div>
            <div id="myTabContent" class="tab-content">
                
            </div>
        </div>
        <div class="charts">
            <div class="charts_charts panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">热议榜</h3>
                </div>
                <div class="panel-body">
                    <uc1:chartsPanel runat="server" ID="chartsPanel" />
                </div>
            </div>
            <div class="charts_notice panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">公告栏</h3>
                    </div>
                    <div class="panel-body">
                        <div class="notice_img"></div>
                        <ul>
                            <li>
                                <a href="http://tieba.baidu.com/p/5757349508">贴吧开展违法赌博专项清理行动</a>
                            </li>
                            <li>
                                <a href="http://tieba.baidu.com/p/5267451989">贴吧积极配合网信办整改</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

