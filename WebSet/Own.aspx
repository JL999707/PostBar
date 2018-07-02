<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" CodeFile="Own.aspx.cs" Inherits="Default2" %>

<%@ Register Src="~/control/chartsPanel.ascx" TagPrefix="uc1" TagName="chartsPanel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="css/Own.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="lunimg"></div>
    <div class="functionbar1">
        <div class="fakeimg"></div>
        <div class="info">
            <asp:Label ID="userName1" runat="server" Text="xxx"></asp:Label>
            <br />
            用户名：<asp:Label ID="userName2" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="deliver">
        <div class="deliver-contain">
            <div class="functionbar2">
                <ul id="myTab" class="nav navbar-nav">
                    <li class="active"><a href="#MyMain" data-toggle="tab">我的主页</a></li>
                    <li><a href="#MyPost" data-toggle="tab">帖子</a></li>
                    <li><a href="#MyBar" data-toggle="tab">关注的吧</a></li>
                    <li><a href="#MyCollection" data-toggle="tab">收藏</a></li>
                </ul>
            </div>
            <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade in active" id="MyMain">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="barAttID" DataSourceID="SqlDataSource1" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="dynamic_hot_barName">
                                        <h4><a href="../Bar.aspx">
                                            <asp:Label ID="barName" runat="server" Text='<%# Eval("barAttName") %>'></asp:Label>
                                        </a></h4>
                                    </div>
                                    <div class="dynamic_hot_postName">
                                        <h4><a href="../Bar.aspx">
                                            <asp:Label ID="postName" runat="server"></asp:Label>
                                        </a></h4>
                                    </div>
                                    <div class="dynamic_hot_postContent">
                                        <asp:Label ID="postContent" runat="server"></asp:Label>
                                    </div>
                                    <div class="dynamic_hot_postImg"></div>
                                    <div class="dynamic_hot_postAuthor">
                                        <asp:Label ID="postAuthor" runat="server" Text='<%# Eval("userID") %>'></asp:Label>
                                        <asp:Label ID="postTime" runat="server" Text='<%# Eval("barAttTime") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PostBarConnectionString3 %>" SelectCommand="SELECT * FROM [T_BarAttention]"></asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="MyPost">
                    <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="MyBar">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="barAttID" DataSourceID="SqlDataSource1" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="dynamic_hot_barName">
                                        <h4><a href="../Bar.aspx">
                                            <asp:Label ID="barName" runat="server" Text='<%# Eval("barAttName") %>'></asp:Label>
                                        </a></h4>
                                    </div>
                                    <div class="dynamic_hot_postName">
                                        <h4><a href="../Bar.aspx">
                                            <asp:Label ID="postName" runat="server"></asp:Label>
                                        </a></h4>
                                    </div>
                                    <div class="dynamic_hot_postContent">
                                        <asp:Label ID="postContent" runat="server"></asp:Label>
                                    </div>
                                    <div class="dynamic_hot_postImg"></div>
                                    <div class="dynamic_hot_postAuthor">
                                        <asp:Label ID="postAuthor" runat="server" Text='<%# Eval("userID") %>'></asp:Label>
                                        <asp:Label ID="postTime" runat="server" Text='<%# Eval("barAttTime") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PostBarConnectionString3 %>" SelectCommand="SELECT * FROM [T_BarAttention]"></asp:SqlDataSource>
                </div>
                <div class="tab-pane fade" id="MyCollection">
                    
                </div>
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

