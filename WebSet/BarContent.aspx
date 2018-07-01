<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" CodeFile="BarContent.aspx.cs" Inherits="Default2" %>

<%@ Register Src="~/control/chartsPanel.ascx" TagPrefix="uc1" TagName="chartsPanel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/BarContent.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="functionbar1">
        <div class="fakeimg"></div>
        <ul class="nav navbar-nav" >
            <li class="active"><a href="#"> 足球吧</a></li>
            <li class="active"><a href="#">关注／取关</a></li>
            <li class="active"><a href="#">关注数</a></li>
            <li class="active"><a href="#">帖子数</a></li>
        </ul>
    </div>
    <div class="deliver">
        <div class="deliver-contain">
            <div class="functionbar2">
                <ul id="myTab" class="nav navbar-nav">
	                <li class="active"><a href="#home" data-toggle="tab">看帖</a></li>
	                <li class="active"><a href="#ios" data-toggle="tab">图片</a></li>
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

