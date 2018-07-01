<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/control/tabContent.ascx" TagPrefix="uc2" TagName="tabContent" %>
<%@ Register Src="~/control/chartsPanel.ascx" TagPrefix="uc2" TagName="chartsPanel" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/Main.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="picture">
        <div class="rotation">
            <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="2000">
	            <ol class="carousel-indicators">
		            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
		            <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
	            </ol>   
	            <div class="carousel-inner rotation_img">
		            <div class="item active">
			            <img src="imgs/one.jpg" alt="First slide"/>
			            <div class="carousel-caption">dskjafhklJIFIWEJJ</div>
		            </div>
		            <div class="item">
			            <img src="imgs/two.jpg" alt="Second slide"/>
			            <div class="carousel-caption">fjhgfdsaghg</div>
		            </div>
                    <div class="item">
			            <img src="imgs/three.jpg" alt="Third slide"/>
			            <div class="carousel-caption">gfdhgjhkjferytuy</div>
		            </div>
	            </div>
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
        <div class="sumBar">
            <div class="num">
                <div class="num_show">0</div>
                <div class="num_show">0</div>
                <div class="num_show">0</div>
                <div class="num_show">0</div>
                <div class="num_show">0</div>
                <div class="num_show">0</div>
                <div class="num_show">0</div>
                <div class="num_show">0</div>
            </div>
        </div>
    </div>
    <div class="content">
        <div class="myselfInfo">
            <div class="info">
                <div class="info_div">
                    用户名：<br />
                    <asp:Label ID="userName" runat="server" Text=""></asp:Label>
                    <%--<asp:label runat="server" text=""></asp:label>--%>
                    <br />
                    帖子数：<asp:Label ID="postNum" runat="server" Text=""></asp:Label>
                    <%--<asp:Label ID="postNum" runat="server" Text=""></asp:Label>--%>
                </div>
            </div>
            <div class="img_head"></div>
            <div class="operation">
                <%--<button type="button" class="btn btn-default sign">一键签到</button>--%>
                <asp:Button ID="sign" runat="server" class="btn btn-default sign" Text="一键签到" />
                <span class="glyphicon glyphicon-pencil"></span><br />
                <%--<button type="button" class="btn btn-default collection">收藏的帖子</button>--%>
                <asp:Button ID="collection" runat="server" class="btn btn-default collection" Text="收藏的帖子" OnClick="collection_Click" />
                <span class="glyphicon glyphicon-star"></span><br />
                <div class="calendar">
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </div>
                <div>

                </div>
            </div>
        </div>
        <div class="barType">
            <div class="qipaBar">
                <div class="barTitle">奇葩吧</div>
                <div class="oneBar">
                    <div class="onebar_img"></div>
                    <div class="onebar_txt">
                        <h5>世界杯吧</h5>
                        <p>签名<span class="glyphicon glyphicon-pencil"></span></p>
                    </div>
                </div>
                <div class="twoBar">
                    <div class="twobar_img"></div>
                    <div class="twobar_txt">
                        <h5>王者吧</h5>
                        <p>签名<span class="glyphicon glyphicon-pencil"></span></p>
                    </div>
                </div>
            </div>
            <div class="hotBar">
                <div class="barTitle">热门吧</div>
                <div class="hotBar_bar">
                    <marquee behavior="scroll" onMouseOut="this.start()" onMouseOver="this.stop()">
                        <div class="hotBar_div">
                            <img src="imgs/qipa_one.jpeg"/>
                            <h5>葡萄牙吧</h5>
                            <h5>人数</h5>
                            <h5>评论</h5>
                        </div>
                        <div class="hotBar_div">
                            <img src="imgs/qipa_one.jpeg"/>
                            <h5>葡萄牙吧</h5>
                            <h5>人数</h5>
                            <h5>评论</h5>
                        </div>
                        <div class="hotBar_div">
                            <img src="imgs/qipa_one.jpeg"/>
                            <h5>葡萄牙吧</h5>
                            <h5>人数</h5>
                            <h5>评论</h5>
                        </div>
                        <div class="hotBar_div">
                            <img src="imgs/qipa_one.jpeg"/>
                            <h5>葡萄牙吧</h5>
                            <h5>人数</h5>
                            <h5>评论</h5>
                        </div>
                        <div class="hotBar_div">
                            <img src="imgs/qipa_one.jpeg"/>
                            <h5>葡萄牙吧</h5>
                            <h5>人数</h5>
                            <h5>评论</h5>
                        </div>
                    </marquee>
                </div>
            </div>
        </div>
        <div class="dynamic">
            <ul id="myTab" class="nav nav-tabs">
	            <li class="active">
		            <a href="#hotdoor" data-toggle="tab">热门动态</a>
	            </li>
	            <li>
                    <a href="#owndor" data-toggle="tab">个性动态</a>
	            </li>
            </ul>
            <div id="myTabContent" class="tab-content">
	            <div class="tab-pane fade in active" id="hotdoor">
		            <div class="dynamic_hot">
                        <%--<asp:PlaceHolder ID="dynamic_hot" runat="server">
                            <uc2:tabContent runat="server" ID="tabContent" />
                        </asp:PlaceHolder>--%>
                        <uc2:tabContent runat="server" id="tabContent" />
		            </div>
	            </div>
	            <div class="tab-pane fade" id="owndor">
		            <div class="dynamic_own">
		            </div>
	            </div>
            </div>
        </div>
        <div class="charts">
            <div class="charts_charts panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">热议榜</h3>
                </div>
                <div class="panel-body">
                    <uc2:chartsPanel runat="server" ID="chartsPanel" />
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

