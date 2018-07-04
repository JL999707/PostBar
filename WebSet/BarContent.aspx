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
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#CCCCCC" GridLines="None" ShowHeader="False">
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
                                                <asp:Label ID="postName" runat="server" Text=""></asp:Label><br />
                                                <br />
                                                <asp:Label ID="postCOntent" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div id="right-centerDiv">
                                                <button id="btnReport">举报</button>
                                                <label id="labL">楼数</label>
                                                <%--<label id="labTime">时间</label>--%>
                                                <asp:Label ID="labTime" runat="server" Text=""></asp:Label>
                                                <button id="btnReply">回复</button>
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

