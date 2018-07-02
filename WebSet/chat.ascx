<%@ Control Language="C#" AutoEventWireup="true" CodeFile="chat.ascx.cs" Inherits="chat" %>
<style>
    #bgDiv {
        width: 800px;
        height: 511px;
        /*background-color: burlywood;*/
        margin-top: 0px;
        margin-left: auto;
        margin-right: auto;
        background-image: url('http://localhost:2932/imgs/moSha.jpg');
    }


</style>


<div id="bgDiv">
    
    <br />
    <br />
    <asp:Label ID="labBlock2" runat="server" Height="20px" Width="30px"></asp:Label>
    <asp:Label ID="labPostTitle" runat="server" Text="新贴名称"></asp:Label>
    <br />
    <asp:Label ID="labBlock1" runat="server" Height="20px" Width="30px"></asp:Label>
    <asp:TextBox ID="txtPostTitle" runat="server" Height="25px" Width="506px"></asp:TextBox>
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="323px">
        <br />
        <asp:Label ID="labBlock" runat="server" Height="20px" Width="30px"></asp:Label>
        <asp:Button ID="btnUpPic" runat="server" OnClick="btnUpPic_Click" Text="上传图片" />
        <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" Width="223px" />
        <asp:Image ID="Image1" runat="server" Height="50px" Visible="False" Width="50px" />
        <asp:Literal ID="tiShi" runat="server"></asp:Literal>
        <br />
        <asp:Label ID="labBlock0" runat="server" Height="20px" Width="30px"></asp:Label>
        <asp:TextBox ID="txtContent" runat="server" Height="228px" Width="573px"></asp:TextBox>
        <br />
    </asp:Panel>
    <br />
    <asp:Label ID="labBlock3" runat="server" Height="20px" Width="30px"></asp:Label>
    <asp:Button ID="btnRelease" runat="server" Text="发表" Height="26px" OnClick="btnRelease_Click" />
    <asp:Literal ID="tiShi2" runat="server"></asp:Literal>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
</div>