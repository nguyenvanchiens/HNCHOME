function unbindScroll() {

}
$(window).bind("scroll", function() {
    var windowLocation = window.pageYOffset;
    if (windowLocation >= 150) {
        $(".menu__nav").css("position", "fixed");
        $(".menu__nav").css("top", "0px");
        $(".menu__nav").css("left", "0px");
        $(".menu__nav").css("margin", "auto");
        $(".menu__nav").css("width", "100%");
        $(".nav__img img").css({
            "padding-left": "10vw",
        });
    }
})
$(window).bind("scroll", function() {
    var windowLocation = window.pageYOffset;
    if (windowLocation < 150) {
        $(".menu__nav").css("position", "absolute");
        $(".menu__nav").css("width", "auto");
        $(".menu__nav").css("z-index", "3");
        $(".menu__nav").css("width", "100%");
        $(".menu__nav").css("height", "70px");
        $(".menu__nav").css("display", "flex");
        $(".menu__nav").css("top", "30px");
        $(".menu__nav").css("width", "80%");
        $(".menu__nav").css("margin-left", "11%");
    }
})