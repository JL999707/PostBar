﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="replyChat.ascx.cs" Inherits="control_replyChat" %>
<style>
    #bgDiv {
        width: 597px;
        height: 87px;
        /*background-color: burlywood;*/
        margin-top: 0px;
        margin-left: auto;
        margin-right: auto;
        /*background-image: url('http://localhost:2932/imgs/moSha.jpg');*/
        background-color:#F7F8FA;
    }


</style>


<div id="bgDiv">
    
    <br />
        <asp:TextBox ID="txtContent" runat="server" Height="35px" Width="573px"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Width="541px"></asp:Label>
    <asp:Button ID="btnRelease" runat="server" Text="发表" Height="26px" OnClick="btnRelease_Click" />
    <br /> 
</div>