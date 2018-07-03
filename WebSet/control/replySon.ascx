<%@ Control Language="C#" AutoEventWireup="true" CodeFile="replySon.ascx.cs" Inherits="control_replySon" %>
<style>
    #app {
        width:560px;
        height: auto;
        border: solid 1px #CCCCCC;
        position: relative;
    }

    #right-centerDiv {
        width: 560px;
        height: 70px;
        position: relative;
        left: 0px;
        top: 0px;
        z-index: 1;
    }

    #imgBG {
        width: 34px;
        height: 34px;
        border: solid #CCCCCC 1px;
        margin-top: 10px;
        margin-left: 19px;
    }

    #img {
        width: 32px;
        height: 32px;
        margin-top: 1px;
        margin-left: 1px;
    }


    #aName {
        text-decoration: none;
        position: absolute;
        top:50px;
        left:10px;
        font-size:12px;
        color:black;
    }

    #btnReport {
        color: #999999;
        background: none;
        border: none;
        font-size: 12px;
        position: absolute;
        bottom: 8px;
        right: 230px;
    }

    #labL {
        color: #999999;
        background: none;
        border: none;
        font-size: 12px;
        position: absolute;
        bottom: 10px;
        right: 200px;
    }

    #labTime {
        color: #999999;
        background: none;
        border: none;
        position: relative;
        font-size: 12px;
        position: absolute;
        bottom: 10px;
        right: 80px;
    }

    #btnReply {
        color: #999999;
        background: none;
        border: none;
        font-size: 12px;
        position: absolute;
        bottom: 8px;
        right: 20px;
    }
</style>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <div id="app">
                    <div id="right-centerDiv">
                        <div id="imgBG">
                            <img id="img" src="../imgs/Penguins.jpg" />
                        </div>
                        <a id="aName" href="#">这是名字</a>
                        <button id="btnReport">举报</button>
                        <label id="labL">楼数</label>
                        <label id="labTime">时间</label>
                        <button id="btnReply">回复</button>
                    </div>
                </div>

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>



