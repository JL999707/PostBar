<%@ Page Title="" Language="C#" MasterPageFile="~/Head.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/control/chartsPanel.ascx" TagPrefix="uc1" TagName="chartsPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <link rel="stylesheet" type="text/css" href="css/Search.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="content">
        <div class="left">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeader="False">
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
                                                    <asp:Button ID="btnBarAtt" runat="server" Text="关注的贴吧" /></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="right-topDiv">
                                        <asp:Button ID="postName" runat="server" Text='<%# Eval("postName") %>' CssClass="btn-link" OnClick="postName_Click" Style="font-size: 16px;" /><br />
                                        <br />
                                        <asp:Button ID="postContent" runat="server" Text='<%# Eval("postContent") %>' CssClass="btn-link" Style="color: black; font-size: 14px;" OnClick="postContent_Click" />
                                    </div>
                                    <div id="right-centerDiv">
                                        <asp:Button ID="btnReport" runat="server" Text="举报" Style="color: #999999; background: none; border: none; font-size: 12px; position: absolute; top: 8px; right: 230px;" OnClick="btnReport_Click" />
                                        <label id="labL">楼数</label>
                                        <asp:Label ID="labTime" runat="server" Text='<%# Eval("postTime") %>' Style="font-size: 12px; color: #999999;"></asp:Label>
                                        <asp:Button ID="btnReply" runat="server" Text="回复" OnClick="btnReply_Click" CssClass="btn-link" Style="color: #999999; background: none; border: none; font-size: 12px; position: absolute; top: 8px; right: 20px;" />
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
        <uc1:chartsPanel runat="server" ID="chartsPanel" />
    </div>
</asp:Content>

