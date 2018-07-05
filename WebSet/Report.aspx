<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>举报</title>
    <link rel="stylesheet" type="text/css" href="css/Report.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="app">
            <div id="topDiv">
                <div id="titleDiv">
                    &nbsp;<label id="w">贴吧举报</label>
                    <asp:Label ID="Label1" runat="server" Text="个人/企业举报 > "></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="个人"></asp:Label>
                </div>
                <div id="stepDiv">
                    <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl="~/imgs/屏幕快照 2018-07-04 上午8.15.43.png" Width="750px" />
                </div>
            </div>
            <div id="mainDiv">
                <div id="centerDiv">
                    <label id="selectLab">请选择举报类型:</label>
                    <div id="copyDiv">
                        <div id="reportDiv1">
                            <div>
                                <asp:Label ID="Label3" runat="server" Text="个人/企业举报"></asp:Label>
                            </div>
                        </div>

                        <div id="leftDiv">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="个人侵权" Selected="True">个人侵权</asp:ListItem>
                                <asp:ListItem Value="企业侵权">企业侵权</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div id="otherDiv">
                        <div id="reportDiv2">
                            <div>
                                <asp:Label ID="Label4" runat="server" Text="垃圾举报"></asp:Label>
                            </div>
                        </div>
                        <div id="rightDiv">
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" RepeatColumns="2" Width="230px" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                <asp:ListItem>广告类</asp:ListItem>
                                <asp:ListItem>政治有害类</asp:ListItem>
                                <asp:ListItem>暴恐类</asp:ListItem>
                                <asp:ListItem>淫秽色情类</asp:ListItem>
                                <asp:ListItem>头像、签名档</asp:ListItem>
                                <asp:ListItem>赌博类</asp:ListItem>
                                <asp:ListItem>私服外挂类</asp:ListItem>
                                <asp:ListItem>诈骗类</asp:ListItem>
                                <asp:ListItem>其他有害类</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div id="bottomDiv">
                    <div id="reportInfoDiv">
                        <label>我举报的信息:</label>
                    </div>
                    <div id="reportContent">
                        <div id="headImg">
                            <img src="imgs/userLogo.png" />
                        </div>
                        <div id="infoDiv">
                            <asp:Label ID="replyContent" runat="server" Text="Label"></asp:Label></div>
                        <div id="userName">
                            <asp:Label ID="beReportName" runat="server" Text=""></asp:Label></div>
                        <div id="timeDiv">
                            <asp:Label ID="replyTime" runat="server" Text=""></asp:Label></div>
                    </div>
                    <div id="btnNextDiv">
                        <asp:Button ID="btnNext" runat="server" Text="下一步" Width="62px" BackColor="#3B85F3" ForeColor="White" OnClick="btnNext_Click" />
                    </div>
                    <label id="tiShiLab">由于本公司法律顾问最近脑阔有点问题，所以，举报功能暂时不能更进一步，谢谢您的谅解！</label>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
