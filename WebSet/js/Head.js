$(document).ready(function () {
    $(".top_login").click(function () {
        if ($(".top_login").text() != "登录") {
            $(".main").css("display", "none");
            $(".zheZhao").css("display", "none");
        }
        else {
            $(".zheZhao").css("display", "block");
            $(".main").css("display", "block");
        }
        return false;
    })

    $(".main a").click(function () {
        $(".main").css("display", "none");
        $(".zheZhao").css("display", "none");
    })

    //$(".sure").click(function () {
    //    $(".main").css("display", "none");
    //    $(".zheZhao").css("display", "none");
    //})
})