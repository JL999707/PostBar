<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="BarContent.aspx.cs" Inherits="Default2" %>

<%@ Register Src="~/control/chartsPanel.ascx" TagPrefix="uc1" TagName="chartsPanel" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/BarContent.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="functionbar1">
        <div class="fakeimg"></div>
        <ul class="nav navbar-nav" >
            <li class="active"><a href="#">
                <asp:Button ID="barName" runat="server" Text="" CssClass="btn-link" OnClick="barName_Click"/></a></li>
            <li class="active"><a href="#">关注／取关</a></li>
            <li class="active"><a href="#">
                关注数：<asp:Label ID="barAtt" runat="server" Text="Label"></asp:Label></a></li>
            <li class="active"><a href="#">
                帖子数：<asp:Label ID="postNum" runat="server" Text="Label"></asp:Label></a></li>
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
                                            <asp:Label ID="userName" runat="server" Text=""></asp:Label></a></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnBarAtt" runat="server" Text="关注的贴吧" /></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                            <div id="right-topDiv">
                                <asp:Label ID="postName" runat="server" Text="" style="font-size:16px;"></asp:Label><br />
                                <br />
                                <asp:Label ID="postContent" runat="server" Text="" style="color:black;font-size:14px;"></asp:Label>
                            </div>
                            <div id="right-centerDiv">
                                <button id="btnReport">举报</button>
                                <label id="labL">楼数</label>
                                <%--<label id="labTime">时间</label>--%>
                                <asp:Label ID="labTime" runat="server" Text="" style="font-size:12px;color:#999999;"></asp:Label>
                                <button id="btnReply">回复</button>
                            </div>
                            <div id="right-bottomDiv">
                            </div>
                        </div>
                    </div>
                    <asp:GridView ID="GridView1" runat="server" BorderColor="#CCCCCC" GridLines="None" ShowHeader="False" AutoGenerateColumns="False">
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
                                                            <%--<asp:Label ID="userName" runat="server" Text=""></asp:Label>--%>
                                                            <asp:Button ID="userName" runat="server" Text="" CssClass="btn-link"/>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnBarAtt" runat="server" Text="关注的贴吧" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="right-topDiv">
                                                <asp:Label ID="replyContent" runat="server" Text='<%# Eval("replyContent") %>'></asp:Label>
                                            </div>
                                            <div id="right-centerDiv">
                                                <button id="btnReport">举报</button>
                                                <label id="labL">楼数</label>
                                                <%--<label id="labTime">时间</label>--%>
                                                <asp:Label ID="labTime" runat="server" Text='<%# Eval("replyTime") %>' style="font-size:12px;color:#999999;"></asp:Label>
                                                <%--<label id="btnReply1">回复</label>--%>
                                                <asp:Button ID="btnReply1" runat="server" Text="回复" CssClass="btn-link" style="color: #999999;font-size: 12px;" BorderStyle="None" OnClick="btnReply1_Click"/>
                                                <%--<panel id="replySon"></panel>--%>
                                                <asp:Panel ID="replySon" runat="server" Height="100px" Width="100%" BackColor="#FBFBFD" BorderStyle="None">
                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowHeader="False">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <div id="appSon">
                                                                        <div id="imgBGSon">
                                                                            <img id="imgSon" src="../imgs/Penguins.jpg" />
                                                                        </div>
                                                                        <a id="aNameSon" href="#">
                                                                            <asp:Label ID="replyUserName" runat="server" Text=""></asp:Label></a>
                                                                        <asp:Label ID="replyContent" runat="server" Text="" style="position:absolute;margin-top:20px;margin-left:30px;"></asp:Label>
                                                                        <button id="btnReportSon">举报</button>
                                                                        <label id="labLSon">楼数</label>
                                                                        <label id="labTimeSon">
                                                                            <asp:Label ID="replyTime" runat="server" Text=""></asp:Label></label>
                                                                        <%--<button id="btnReplySon">回复</button>--%>
                                                                        <asp:Button ID="btnReplySon" runat="server" Text="回复" CssClass="btn-link" OnClick="btnReplySon_Click" style="color: #999999;font-size: 12px;margin-top:48px;position:absolute;margin-left:530px;"/>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                                <asp:Panel ID="addReplySon" runat="server" Visible="False">
                                                    <div id="bgDiv">
                                                        <br />
                                                        <asp:TextBox ID="txtContent" runat="server" Height="41px" Width="529px" BorderColor="#D6DFFA" BorderStyle="Solid" Style="margin-left: 25px"></asp:TextBox>
                                                        <br />
                                                        <label id=""></label>
                                                        <%--<button id="btnSend">发送</button>--%>
                                                        <asp:Button ID="btnSend" runat="server" Text="发送" CssClass="btn-link" style="width: 50px;height: 20px;border: 1px solid #CCCCCC;border-radius: 10px;position: absolute;right: 38px;bottom: 5px;color: black;background-color: white;" OnClick="btnSend_Click"/>
                                                        <br />
                                                    </div>
                                                </asp:Panel>
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
                <div class="tab-pane fade" id="BarPicture"></div>
            </div>
        </div>
        <uc1:chartsPanel runat="server" ID="chartsPanel" />
    </div>
</asp:Content>

