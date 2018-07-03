<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReplyT.ascx.cs" Inherits="control_ReplyT" %>
<style>
    #app {
        width: 750px;
        height: auto;
        border: solid 1px #CCCCCC;
    }

    #main {
        width: 750px;
        height: auto;
        position: relative;
    }

    #leftDiv {
        width: 130px;
        height: 250px;
        /*border-top:solid 1px #CCCCCC;*/
        position: absolute;
        left: 0px;
        top: 0px;
        background-color: #FBFBFD;
    }

    #rightDiv {
        width: 620px;
        height: auto;
        position: relative;
        left: 130px;
        background-color: aqua;
    }

    #right-topDiv {
        width: 620px;
        height: 220px;
        position: relative;
        left: 130px;
        top: 0px;
        z-index: 0;
    }

    #right-centerDiv {
        width: 620px;
        height: 30px;
        position: relative;
        left: 130px;
        top: 0px;
        z-index: 1;
    }

    #right-bottomDiv {
        width: 620px;
        height: auto;
        position: relative;
        left: 130px;
        top: 0px;
        z-index: 1;
    }

    #imgBG {
        width: 90px;
        height: 90px;
        border: solid #CCCCCC 1px;
        margin-top: 20px;
        margin-left: 19px;
    }

    #img {
        width: 84px;
        height: 84px;
        margin-top: 3px;
        margin-left: 3px;
    }

    #table {
        height: 64px;
        text-align: center;
    }

    #aName {
        text-decoration: none;
        margin-top: 0px;
        margin-left: 0px;
        margin-right: 0px;
        font-size:12px;
        color:black;
    }

    #btnReport {
        color: #999999;
        background: none;
        border: none;
        font-size: 12px;
        position: absolute;
        top: 8px;
        right: 230px;
    }

    #labL {
        color: #999999;
        background: none;
        border: none;
        font-size: 12px;
        position: absolute;
        top: 10px;
        right: 200px;
    }

    #labTime {
        color: #999999;
        background: none;
        border: none;
        position: relative;
        font-size: 12px;
        position: absolute;
        top: 10px;
        right: 80px;
    }

    #btnReply {
        color: #999999;
        background: none;
        border: none;
        font-size: 12px;
        position: absolute;
        top: 8px;
        right: 20px;
    }
</style>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
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
                                    <td><a id="aName" href="#">这是名字</a></td>
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
                        <div id="right-topDiv"></div>
                        <div id="right-centerDiv">
                            <button id="btnReport">举报</button>
                            <label id="labL">楼数</label>
                            <label id="labTime">时间</label>
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



