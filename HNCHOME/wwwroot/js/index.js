var counter = 0;
$(document).ready(
    function () {
        $('#carouselExampleControls img').click(function () { return false; }),
            $("#search-home-icon").bind("click", function () {
                if (counter == 0) {
                    $(".collaspe").css("display", "none");

                    $(".body__search-form").css("z-index", "2");
                    $(".body__search-form").css("transition", "0.5s");
                    $(".body__background-blur").css("z-index", "1");
                    $(".body__background-blur").css("opacity", "0.5");
                    $(".body__background-blur").css("transition", "0.5s");
                    $("#search-container").css("z-index", "2");
                    $("#search-container").css("opacity", "1");
                    $("#search-container").css("margin-top", "50px");
                    $("#search-container").css("transition", "0.6s");
                    $("#header-form__container").css('z-index', '0.6');
                    scrollTop = window.pageYOffset || document.documentElement.scrollTop;
                    scrollLeft = window.pageXOffset || document.documentElement.scrollLeft,

                        // if any scroll is attempted, set this to the previous value
                        window.onscroll = function () {
                            window.scrollTo(scrollLeft, scrollTop);
                        };
                    counter = 1;
                } else {
                    $(".body__search-form").css("z-index", "-1");
                    $(".body__search-form").css("transition", "0.5s");
                    $(".body__background-blur").css("z-index", "-1");
                    $(".body__background-blur").css("opacity", "0");
                    $(".body__background-blur").css("transition", "0.5s");

                    $("#search-container").css("z-index", "-1");
                    $("#search-container").css("opacity", "0");
                    $("#search-container").css("margin-top", "0px");
                    $("#search-container").css("transition", "0,5")
                    window.onscroll = function () { };
                    counter = 0;
                }
            }),
            $(".body__background-blur").click(function () {
                $(".body__search-form").css("z-index", "-1");
                $(".body__search-form").css("transition", "0.5s");
                $(".body__background-blur").css("z-index", "-1");
                $(".body__background-blur").css("opacity", "0");
                $(".body__background-blur").css("transition", "0.5s");

                $("#search-container").css("z-index", "-1");
                $("#search-container").css("opacity", "0");
                $("#search-container").css("margin-top", "0px");
                $("#search-container").css("transition", "0,5")
                window.onscroll = function () { };
                counter = 0;
            }),
            $("#search-container button").bind("click", function () {
                $(".body__search-form").css("z-index", "-1");
                $(".body__search-form").css("transition", "0.5s");
                $(".body__background-blur").css("z-index", "-1");
                $(".body__background-blur").css("opacity", "0");
                $(".body__background-blur").css("transition", "0.5s");

                $("#search-container").css("z-index", "-1");
                $("#search-container").css("opacity", "0");
                $("#search-container").css("margin-top", "0px");
                $("#search-container").css("transition", "0,5")
                window.onscroll = function () { };
                counter = 0;
            }),
            $("#select2").select(function () {
                $("#select2").css("border", "none");
                $("#select2").css("outline", "solid 1px gray");
            }),

            $("#password").click(function () {
                $("#password").css("border", "none");
                $("#password").css("outline", "solid 1px gray");
                $("#password").css("box-shadow", "none");
            }),
            $(".fancyformcontainer button").click(function () {
                $(".fancyformcontainer button").css("box-shadow", "none");
            }),
            $(".fancyformcontainer textarea").focus(function () {
                $(".fancyformcontainer textarea").css("box-shadow", "none");
            }),
            //$(".js-example-basic-single").select2(),
            $(".fancyformcontainer button").css("box-shadow", "none"),
            $(".fancyformcontainer input").css("box-shadow", "none"),
            $("#select2").click(function () {

            }),
            $("#lang-img li a img").click(function () {
                $("#lang").attr("src", $(this).attr("src"));
                var arrImg = $("#lang-img li a img");
                console.log(arrImg);
            })
    }
);