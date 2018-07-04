<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="Bar.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/control/chartsPanel.ascx" TagPrefix="uc1" TagName="chartsPanel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="css/Bar.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="lunimg">
        <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="4000">
            <!-- 轮播（Carousel）指标 -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>
            <!-- 轮播（Carousel）项目 -->
            <div class="carousel-inner">
                <div class="item active">
                    <img src="../images/bgimg1.jpeg" style="width: 1200px; height: 250px;" alt="First slide" class="img-responsive center-block">
                </div>
                <div class="item">
                    <img src="../images/bgimg2.png" style="width: 1200px; height: 250px;" alt="Second slide">
                </div>
                <div class="item">
                    <img src="../images/bgimg5.png" style="width: 1200px; height: 250px;" alt="Third slide">
                </div>
            </div>
            <!-- 轮播（Carousel）导航 -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
    <div class="functionbar1">
        <div class="fakeimg"></div>
        <ul class="nav navbar-nav">
            <li class="active"><a href="#"><asp:Label ID="barName" runat="server" Text=""></asp:Label></a></li>
            <li class="active"><a href="#">关注／取关</a></li>
            <li class="active"><a href="#">
                关注数：<asp:Label ID="barAtt" runat="server" Text="Label"></asp:Label></a></li>
            <li class="active"><a href="#">
                帖子数：<asp:Label ID="postNum" runat="server" Text="Label"></asp:Label></a></li>
            <asp:Label ID="BarID" runat="server" Text="" style="display:none"></asp:Label>
        </ul>
        <p>
            <asp:Label ID="graph" runat="server" Text="Label"></asp:Label><span class="glyphicon glyphicon-pencil"></span></p>
    </div>
    <div class="deliver">
        <div class="deliver-contain">
            <div class="functionbar2">
                <ul id="myTab" class="nav navbar-nav">
                    <li class="active"><a href="#BarPost" data-toggle="tab">看贴</a></li>
                    <li><a href="#BarPicture" data-toggle="tab">图片</a></li>
                </ul>
            </div>
            <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade in active" id="BarPost">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#CCCCCC" GridLines="None" ShowHeader="False" Width="775px">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div id="app">
                                        <div id="main">
                                            <div id="leftDiv">
                                                <div id="imgBG">
                                                    <img id="img" src="../imgs/Penguins.jpg" />
                                                </div>
                                                <table id="table" style="width: 100%;">
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td><a id="aName" href="#">
                                                           <%-- <asp:Label ID="userName" runat="server" Text=""></asp:Label>--%>
                                                            <asp:Button ID="userName" runat="server" Text="" CssClass="btn-link" />
                                                            </a></td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnBarAtt" runat="server" Text="关注的贴吧"/></td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="right-topDiv">
                                                <%--<asp:Label ID="postName" runat="server" Text='<%# Eval("postName") %>'></asp:Label>--%>
                                                <asp:Button ID="postName" runat="server" Text='<%# Eval("postName") %>' CssClass="btn-link" OnClick="postName_Click" style="font-size:16px;"/><br /><br />
                                                <%--<asp:Label ID="postContent" runat="server" Text='<%# Eval("postContent") %>'></asp:Label>--%>
                                                <asp:Button ID="postContent" runat="server" Text='<%# Eval("postContent") %>' CssClass="btn-link" style="color:black;font-size:14px;" OnClick="postContent_Click" />
                                            </div>
                                            <div id="right-centerDiv">
                                                <button id="btnReport">举报</button>
                                                <label id="labL">楼数</label>
                                                <%--<label id="labTime">时间</label>--%>
                                                <asp:Label ID="labTime" runat="server" Text='<%# Eval("postTime") %>' style="font-size:12px;color:#999999;"></asp:Label>
                                                <%--<button id="btnReply">回复</button>--%>
                                                <asp:Button ID="btnReply" runat="server" Text="回复" OnClick="btnReply_Click" CssClass="btn-link" style="color: #999999;background: none;border: none;font-size: 12px;position: absolute;top: 8px;right: 20px;"/>
                                            </div>
                                            <div id="right-bottomDiv">
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="tab-pane fade" id="BarPicture">
                    
                </div>
            </div>
        </div>
        <uc1:chartsPanel runat="server" ID="chartsPanel" />
    </div>
</asp:Content>

