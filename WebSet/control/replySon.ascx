<%@ Control Language="C#" AutoEventWireup="true" CodeFile="replySon.ascx.cs" Inherits="control_replySon" %>
<style>
    #appSon {
        width:560px;
        height: auto;
        border: solid 1px #CCCCCC;
        position: relative;
    }

    #right-centerDivSon {
        width: 560px;
        height: 70px;
        position: relative;
        left: 0px;
        top: 0px;
        z-index: 1;
    }

    #imgBGSon {
        width: 34px;
        height: 34px;
        border: solid #CCCCCC 1px;
        margin-top: 10px;
        margin-left: 19px;
    }

    #imgSon {
        width: 32px;
        height: 32px;
        margin-top: 1px;
        margin-left: 1px;
    }


    #aNameSon {
        text-decoration: none;
        position: absolute;
        top:50px;
        left:10px;
        font-size:12px;
        color:black;
    }

    #btnReportSon {
        color: #999999;
        background: none;
        border: none;
        font-size: 12px;
        position: absolute;
        bottom: 8px;
        right: 230px;
    }

    #labLSon {
        color: #999999;
        background: none;
        border: none;
        font-size: 12px;
        position: absolute;
        bottom: 10px;
        right: 200px;
    }

    #labTimeSon {
        color: #999999;
        background: none;
        border: none;
        position: relative;
        font-size: 12px;
        position: absolute;
        bottom: 10px;
        right: 80px;
    }

    #btnReplySon {
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
                <div id="appSon">
                    <div id="right-centerDivSon">
                        <div id="imgBGSon">
                            <img id="imgSon" src="../imgs/Penguins.jpg" />
                        </div>
                        <a id="aNameSon" href="#">
                            <asp:Label ID="replyUserName" runat="server" Text=""></asp:Label></a>
                        <button id="btnReportSon">举报</button>
                        <label id="labLSon">楼数</label>
                        <label id="labTimeSon">
                            <asp:Label ID="replyTime" runat="server" Text=""></asp:Label></label>
                        <button id="btnReplySon">回复</button>
                    </div>
                </div>

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>



