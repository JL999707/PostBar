<%@ Control Language="C#" AutoEventWireup="true" CodeFile="chartsPanel.ascx.cs" Inherits="chartsPanel" %>
<style>
    .charts {
        width: 215px;
        height: auto;
        margin-left: 10px;
        margin-top: 10px;
        float: left;
    }

    .charts a {
        color: black;
        font-size: 12px;
    }

    .charts_notice {
        margin-top: -10px;
    }

     .charts_notice .panel-body {
        padding: 0;
        margin: 0;
    }

    .charts_notice li {
        margin-left: 15px;
    }

    .notice_img {
        margin-left: -2px;
        height: 90px;
        width: 215px;
        background-image: url(../imgs/111公告板.png);
        background-size: 100% 100%;
    }

    .charts_charts .panel-body{
        margin-top:-20px;
    }

    .charts_charts li {
        list-style: none;
        height: 22px;
        line-height: 22px;
        margin-top: -5px;
    }

    .charts_num {
        height: 20px;
        width: 20px;
        text-align: center;
        position: absolute;
        margin-top: 1px;
    }

    .charts_content {
        height: 20px;
        width: 100px;
        position: absolute;
        margin-top: 1px;
        margin-left: 25px;
    }

    .charts_people {
        height: 20px;
        width: 58px;
        text-align: right;
        position: absolute;
        margin-top: 1px;
        margin-left: 125px;
    }
</style>


<div class="charts">
    <div class="charts_charts panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">热议榜</h3>
        </div>
        <div class="panel-body">
            <%--<ul>
                <li>
                    <span class='charts_num'></span>
                    <a class='charts_content'>dgasg</a>
                    <span class='charts_people'>1234567</span>
                <asp:Label ID="Label2" runat="server" Text='<%# this.GridView1.PageIndex * this.GridView1.PageSize + this.GridView1.Rows.Count + 1%>' /> 
                </li>
            </ul>--%>
            <asp:GridView ID="GridView1" runat="server" GridLines="None" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <li>
                                <span class='charts_num'>
                                <asp:Label ID="No" runat="server" Text='<%# this.GridView1.Rows.Count + 1%>'></asp:Label></span>
                            <a class='charts_content'>
                                <asp:Label ID="barName" runat="server" Text='<%# Eval("barName")%>'></asp:Label></a>
                            <span class='charts_people'>
                                <asp:Label ID="peopleNum" runat="server" Text='<%# Eval("barName")%>'></asp:Label></span>
                            </li>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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

