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
                                                <asp:Button ID="postName" runat="server" Text='<%# Eval("postName") %>' CssClass="btn-link" OnClick="postName_Click" style="font-size:16px;"/><br /><br />
                                                <asp:Button ID="postContent" runat="server" Text='<%# Eval("postContent") %>' CssClass="btn-link" style="color:black;font-size:14px;" OnClick="postContent_Click" />
                                            </div>
                                            <div id="right-centerDiv">
                                                <asp:Label ID="labTime" runat="server" Text='<%# Eval("postTime") %>' style="font-size:12px;color:#999999;"></asp:Label>
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
                <div class="tab-pane fade" id="MyPost">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="#CCCCCC" GridLines="None" ShowHeader="False" Width="775px">
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
                                                <asp:Button ID="postName" runat="server" Text='<%# Eval("postName") %>' CssClass="btn-link" OnClick="postName_Click" style="font-size:16px;"/><br /><br />
                                                <asp:Button ID="postContent" runat="server" Text='<%# Eval("postContent") %>' CssClass="btn-link" style="color:black;font-size:14px;" OnClick="postContent_Click" />
                                            </div>
                                            <div id="right-centerDiv">
                                                <asp:Label ID="labTime" runat="server" Text='<%# Eval("postTime") %>' style="font-size:12px;color:#999999;"></asp:Label>
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
                <div class="tab-pane fade" id="MyBar">
                    <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                </div>
                <div class="tab-pane fade" id="MyCollection">
                    
                </div>
            </div>
        </div>
        <uc1:chartsPanel runat="server" ID="chartsPanel" />
    </div>
</asp:Content>

