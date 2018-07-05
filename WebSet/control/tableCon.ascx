<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tableCon.ascx.cs" Inherits="control_tableCon" %>


<link href="../css/bootstrap.min.css" rel="stylesheet" />
<link href="../css/fileinput.min.css" rel="stylesheet" />
<script src="../js/jqyery.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/fileinput.min.js"></script>
<script src="../js/fileinput_locale_zh.js"></script>
<script src="js/Vue.js"></script>
<link href="css/bootstrap-table.css" rel="stylesheet" />
<script src="js/bootstrap-table.js"></script>
<script src="js/bootstrap-table-zh-CN.js"></script>
<script src="js/jquery.pagination.js"></script>
<style>
    #app {
        width: 260px;
        height: auto;
        border: solid 1px #CCCCCC;
        position: relative;
    }

    #tableDiv {
        position: relative;
        left: -150px;
    }

    #tableDiv2 {
        position: relative;
        left: -150px;
    }

    #tableDiv3 {
        position: relative;
        left: -150px;
    }
    #tableDiv4 {
        position: relative;
        left: -150px;
    }
    #table {
        width: 400px;
        margin-top: 20px;
        margin-left: auto;
        margin-right: auto;
        text-align: center;
    }

    #table2 {
        width: 400px;
        margin-top: 20px;
        margin-left: auto;
        margin-right: auto;
        text-align: center;
    }

    #table3 {
        width: 400px;
        margin-top: 20px;
        margin-left: auto;
        margin-right: auto;
        text-align: center;
    }
     #table4 {
        width: 400px;
        margin-top: 20px;
        margin-left: auto;
        margin-right: auto;
        text-align: center;
    }
    #editGroup {
        width: 350px;
        height: 310px;
        position: absolute;
        top: 320px;
        right: 250px;
    }

    .txtGroup {
        width: 300px;
        height: 40px;
        position: relative;
    }

    #txtGroup1 {
        top: 0px;
    }

    #txtGroup2 {
        top: 10px;
    }

    #txtGroup3 {
        top: 20px;
    }

    #select {
        width: 150px;
        top: 30px;
    }

    .image1 {
        width: 50px;
        height: 50px;
        position: relative;
        left: 150px;
        top: -75px;
    }

    .button1 {
        position: relative;
        bottom: 35px;
        left: 200px;
    }

    .img {
        width: 40px;
        height: 40px;
    }
</style>
<script>
   
</script>

<ul id="myTab" class="nav nav-tabs">
    <li class="active"><a href="#info" data-toggle="tab">本吧信息</a></li>
    <li><a href="#checkPost" data-toggle="tab">审核贴子</a></li>
    <li><a href="#barPic" data-toggle="tab">本吧图片</a></li>
</ul>

<div id="myTabContent" class="tab-content">
    <div class="active tab-pane fade in info" id="info">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="myCollapse" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">本吧信息表</a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel-heading">
                        <div id="tableDiv">
                            <table class="table table-striped table-bordered table-hover" id="table" <%-- data-url="@Url.Action('GetStudent','DataOne')"--%>>
                                <thead>
                                    <tr>
                                        <th data-field="sno" style="text-align: center">信息类别</th>
                                        <th class="infoWidth" data-field="sname" style="text-align: center">信息内容</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>贴吧名称</td>
                                        <td class="infoWidth">绑定的数据</td>
                                    </tr>
                                    <tr>
                                        <td>贴吧管理员</td>
                                        <td class="infoWidth">绑定的数据</td>
                                    </tr>
                                    <tr>
                                        <td>贴吧类型</td>
                                        <td class="infoWidth">绑定的数据</td>

                                    </tr>
                                    <tr>
                                        <td>贴吧签名</td>
                                        <td class="infoWidth">绑定的数据</td>
                                    </tr>
                                    <tr>
                                        <td>建吧时间</td>
                                        <td class="infoWidth">绑定的数据</td>
                                    </tr>
                                    <tr>
                                        <td>贴吧头像</td>
                                        <td class="infoWidth">
                                            <img class="img" id="headImg" src="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>粉丝数量</td>
                                        <td class="infoWidth">绑定的数据</td>
                                    </tr>
                                    <tr>
                                        <td>帖子数量</td>
                                        <td class="infoWidth">绑定的数据</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div id="editGroup">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="myCollapse" data-toggle="collapse" data-parent="#accordion" href="#infoEdit">展开信息修改面板</a>
                            </h4>
                        </div>
                        <div id="infoEdit" class="panel-collapse collapse">
                            <div class="panel-heading">
                                <div id="txtGroup1" class="txtGroup">
                                    <input id="barName" style="height: 40px; width: 300px;" type="text" class="form-control" placeholder="请输入需要修改的贴吧名称">
                                </div>
                                <div id="txtGroup2" class="txtGroup">
                                    <input id="userName" style="height: 40px; width: 300px;" type="text" class="form-control" placeholder="请输入需要修改的管理员名称">
                                </div>
                                <div id="txtGroup3" class="txtGroup">
                                    <input id="barAutoGraph" style="height: 40px; width: 300px;" type="text" class="form-control" placeholder="请输入需要修改的贴吧签名">
                                </div>
                                <div id="select" class="txtGroup">
                                    <div role="dialog">请选择贴吧类型</div>
                                    <select id="barTypeName" class="form-control" role="radio">
                                        <option>运动类</option>
                                        <option>游戏类</option>
                                        <option>饮食类</option>
                                        <option>歌曲类</option>
                                    </select>

                                    <div>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <button class="button1" id="Button1" runat="server" onserverclick="Button1_Click">是是是</button>
                                        <img class="image1" id="Image1" runat="server" src="" />
                                        <asp:Label ID="tiShi" runat="server" BorderStyle="None"></asp:Label>
                                    </div>
                                    <div></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="myCollapse" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">展开贴吧粉丝表</a>
                    </h4>
                </div>
                <div id="collapseTwo" class="panel-collapse collapse">
                    <div class="panel-body">
                        <div id="tableDiv2">
                            <table class="table table-striped table-bordered table-hover" id="table2" <%-- data-url="@Url.Action('GetStudent','DataOne')"--%>>
                                <thead>
                                    <tr>
                                        <th data-field="sno" style="text-align: center">粉丝名称</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>张大壮</td>
                                    </tr>
                                    <tr>
                                        <td>周扒皮</td>
                                    </tr>
                                    <tr>
                                        <td>王大炮</td>

                                    </tr>
                                    <tr>
                                        <td>刘万能</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="tab-pane fade" id="checkPost">
        <div id="tableDiv3">
            <table class="table table-striped table-bordered table-hover" id="table3" <%-- data-url="@Url.Action('GetStudent','DataOne')"--%>>
                <thead>
                    <tr>
                        <th data-field="sno" style="text-align: center">贴子名称</th>
                        <th data-field="sno" style="text-align: center">帖子内容</th>
                        <th data-field="sno" style="text-align: center">创建时间</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>不客观</td>
                        <td>大伸出芙蓉</td>
                        <td>20105-23</td>
                    </tr>
                    <tr>
                        <td>酷热测试</td>
                        <td>酷热测试发的国际恐怕</td>
                        <td>2018-1-1</td>
                    </tr>
                    <tr>
                        <td>好的撒</td>
                        <td>好的撒门板北辰福第</td>
                        <td>2018-3-8</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="tab-pane fade" id="barPic">
        <div id="tableDiv4">
            <table class="table table-striped table-bordered table-hover" id="table4" <%-- data-url="@Url.Action('GetStudent','DataOne')"--%>>
 <%--               <thead>
                    <tr>
                        <th data-field="sno" style="text-align: center"></th>
                    </tr>
                </thead>--%>
                <tbody>
                    <tr>
                        <td>
                            <img src="../imgs/20160516220714_AeHNF.png" /></td>
                    </tr>
                    <tr>
                        <td>
                            <img src="../imgs/Penguins.jpg" /></td>
                    </tr>
                    <tr>
                        <td>
                            <img src="../imgs/three.jpg" /></td>

                    </tr>
                    <tr>
                        <td>
                            <img src="../imgs/two.jpg" /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>

<script src="js/jqyery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script>


    //alert("Hello world!");

    //获取属性的值，例如下面获取选中option的id的值
    //$('#grantrole').find("option:selected").attr('id')
    //获取下卡选中的值        
    //var selectVal = $('#barTypeName').selectpicker('val');
    //document.getElementById('<%=tiShi.ClientID%>'.value = selectVal;
    //$('#button1').val = selectVal;


</script>
<script>
    $(function () {
        var hash = window.location.hash;
        hash && $('ul.nav a:first').tab('show');
        $("#myTab a").click(function (e) {
            //e.preventDefault();
            $(this).tab('show');
        });
    });

    /*启用选项卡*/
    //$("#myTab a").click(function (e) {
    //    e.preventDefault();/*不要执行与事件有关的默认动作*/
    //    $(this).tab('show');
    //})

    // 通过名称选取标签页
    //$('#myTab a[href="#tapPage1"]').tab('show')

    // 选取第一个标签页
    //$('#myTab a:first').tab('show')

    // 选取最后一个标签页
    //$('#myTab a:last').tab('show')


    //bootstrap-table 数据行内修改
    //js中设置列的属性 

    $(function () {
        //修复collapse不能正常折叠的问题
        $(".myCollapse").click(function () {
            var itemHref = $(this).attr("href");
            var itemClass = $(itemHref).attr("class");
            if (itemClass === "panel-collapse collapse") {
                $(itemHref).attr("class", "panel-collapse collapse in").css("height", "auto");
            } else {
                $(itemHref).attr("class", "panel-collapse collapse").css("height", "0px");
            }
            return false;//停止运行bootstrap自带的函数
        });
    });
</script>
