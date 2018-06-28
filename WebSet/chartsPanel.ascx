<%@ Control Language="C#" AutoEventWireup="true" CodeFile="chartsPanel.ascx.cs" Inherits="chartsPanel" %>
<style>
    .charts_charts li{
        list-style:none;
        height:22px;
        line-height:22px;
        margin-top:5px;
    }
        .charts_num{
        height:20px;
        width:20px;
        text-align:center;
        position:absolute;
        margin-top:1px;
    }

    .charts_content{
        height:20px;
        width:100px;
        position:absolute;
        margin-top:1px;
        margin-left:25px;
    }

    .charts_people{
        height:20px;
        width:58px;
        text-align:right;
        position:absolute;
        margin-top:1px;
        margin-left:125px;
    }
</style>

<ul>
    <script language="javascript">
        for (var i = 1; i <= 10; i++) {
            document.write("<li><span class='charts_num'>" + i + "</span><a class='charts_content'>dgasg</a><span class='charts_people'>1234567</span></li>");
        }
    </script>
</ul>

