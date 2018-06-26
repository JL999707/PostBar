<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/Main.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="picture">
        <div class="rotation">
            <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="4000">
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
        </div>
    </div>
    <div class="content">
        <div class="myselfInfo">
            <div class="info">
                <label class="info_userName">昵称</label>
                <label class="info_unmPost">帖子数：66</label>
            </div>
            <div class="img_head"></div>
            <div class="operation">
                <button type="button" class="btn btn-default sign">一键签到</button>
                <span class="glyphicon glyphicon-pencil"></span><br />
                <button type="button" class="btn btn-default collection">收藏的帖子</button>
                <span class="glyphicon glyphicon-star"></span><br />
                <asp:Calendar ID="Calendar1" runat="server" CellPadding="0" SelectedDate="06/26/2018 19:03:29"></asp:Calendar>
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
                    <%--<div id="demo" class="carousel slide">
	                        <div class="carousel-inner hotbar_div">
		                        <div class="item active ">
                                    
		                        </div>
		                        <div class="item">
			                        
		                        </div>
                                <div class="item">
			                        
		                        </div>
	                        </div>
	                        <a class="left carousel-control" href="#demo" role="button" data-slide="prev">
	                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
	                            <span class="sr-only">Previous</span>
	                        </a>
	                        <a class="right carousel-control" href="#demo" role="button" data-slide="next">
	                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
	                            <span class="sr-only">Next</span>
	                        </a>
                        </div> --%>
                    <marquee behavior="scroll" onMouseOut="this.start()" onMouseOver="this.stop()">scroll：表示由一端滚动到另一端，会重复。</marquee>
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
                        <div class="dynamic_hot_barName"><h4><a>废土行动吧</a></h4></div>
                        <div class="dynamic_hot_title"><h4><a>【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
                        <div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
                        <div class="dynamic_hot_img"></div>
                        <div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>
		            </div>
	            </div>
	            <div class="tab-pane fade" id="owndor">
		            <div class="dynamic_own">
                        <div class="dynamic_hot_barName"><h4><a>废土行动吧</a></h4></div>
                        <div class="dynamic_hot_title"><h4><a>【有奖活动】你生命中遇到过哪些惊心动魄的事情？</a></h4></div>
                        <div class="dynamic_hot_content">喜欢惊险刺激的小伙伴们， 总会有那么一个让你觉得刻骨铭心难以忘记的电影，小说或者游戏， 在这些电</div>
                        <div class="dynamic_hot_img"></div>
                        <div class="dynamic_hot_author">霓裳小舞儿   今天8:25</div>
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
                    <ul>
                        <li>
                            <span class="charts_num">1</span>
                            <a class="charts_content">dgasg</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">2</span>
                            <a class="charts_content">gfhadhgfdh</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">3</span>
                            <a class="charts_content">fdgf</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">4</span>
                            <a class="charts_content">fdgf</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">5</span>
                            <a class="charts_content">fdgf</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">6</span>
                            <a class="charts_content">fdgf</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">7</span>
                            <a class="charts_content">fdgf</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">8</span>
                            <a class="charts_content">fdgf</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">9</span>
                            <a class="charts_content">fdgf</a>
                            <span class="charts_people">1234567</span>
                        </li>
                        <li>
                            <span class="charts_num">10</span>
                            <a class="charts_content">fdgf</a>
                            <span class="charts_people">1234567</span>
                        </li>
                    </ul>
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
                                <a>贴吧开展违法赌博专项清理行动</a>
                            </li>
                            <li>
                                <a>贴吧积极配合网信办整改</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

