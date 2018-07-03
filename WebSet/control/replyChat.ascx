<%@ Control Language="C#" AutoEventWireup="true" CodeFile="replyChat.ascx.cs" Inherits="control_replyChat" %>
<style>
    #bgDiv {
        width: 600px;
        height: 106px;
        background-color: #F7F8FA;
        margin-top: 0px;
        margin-left: auto;
        margin-right: auto;
    }
    #btnSend
    {
        width:50px;
        height:20px;
        border:1px solid #CCCCCC;
        border-radius:10px;
        position:absolute;
        right:38px;
        bottom:5px;
        color:black;
        background-color:white;
    }
</style>

<div id="bgDiv">
    <br />
    <asp:TextBox ID="txtContent" runat="server" Height="41px" Width="529px" BorderColor="#D6DFFA" BorderStyle="Solid" style="margin-left: 25px"></asp:TextBox>
    <br />
    <label id=""></label>
    <button id="btnSend">发送</button>
    <br />
</div>
