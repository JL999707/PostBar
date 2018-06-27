$(document).ready(function () {
    $(".top_login").click(function () {
        $(".zheZhao").css("display", "block");
        $(".main").css("display", "block");
        return false;
    })
    $(".main a").click(function () {
        $(".main").css("display", "none");
        $(".zheZhao").css("display", "none");
    })
    $(".sure").click(function () {
        $(".main").css("display", "none");
        $(".zheZhao").css("display", "none");
    })
})