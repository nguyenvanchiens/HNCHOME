$(document).ready(function() {
    $(".menu__nav").css("position", "fixed");
    $(".menu__nav").css("top", "0px");
    $(".menu__nav").css("left", "0px");
    $(".menu__nav").css("margin", "auto");
    $(".menu__nav").css("width", "100%");
    $(".nav__img img").css({
        "padding-left": "17vw",
    });
    $(".menu__nav .nav__img").css({
        "width": "26.7%",
    });
    if (window.innerWidth <= 1200) {
        $(".menu__nav .nav__img").css({
            "width": "30%"
        })
    }
})