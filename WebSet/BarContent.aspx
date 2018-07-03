<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" CodeFile="BarContent.aspx.cs" Inherits="Default2" %>

<%@ Register Src="~/control/chartsPanel.ascx" TagPrefix="uc1" TagName="chartsPanel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/BarContent.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="functionbar1">
        <div class="fakeimg"></div>
        <ul class="nav navbar-nav" >
            <li class="active"><a href="#">
                <asp:Label ID="barName" runat="server" Text=""></asp:Label></a></li>
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
        <uc1:chartsPanel runat="server" ID="chartsPanel" />
</asp:Content>

