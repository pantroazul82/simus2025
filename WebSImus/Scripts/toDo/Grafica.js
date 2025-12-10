var page_actions = function () {



    var html_click_avail = true;


    /* WIDGETS (DEMO)*/
    $(".widget-remove").on("click", function () {
        $(this).parents(".widget").fadeOut(400, function () {
            $(this).remove();
            $("body > .tooltip").remove();
        });
        return false;
    });
    /* END WIDGETS */



    /* DROPDOWN TOGGLE */
    $(".dropdown-toggle").on("click", function () {
        onresize();
    });
    /* DROPDOWN TOGGLE */





    /* PANELS */

    $(".panel-fullscreen").on("click", function () {
        panel_fullscreen($(this).parents(".panel"));
        return false;
    });

    $(".panel-collapse").on("click", function () {
        panel_collapse($(this).parents(".panel"));
        $(this).parents(".dropdown").removeClass("open");
        return false;
    });
    $(".panel-remove").on("click", function () {
        panel_remove($(this).parents(".panel"));
        $(this).parents(".dropdown").removeClass("open");
        return false;
    });
    $(".panel-refresh").on("click", function () {
        var panel = $(this).parents(".panel");
        panel_refresh(panel);

        setTimeout(function () {
            panel_refresh(panel);
        }, 3000);

        $(this).parents(".dropdown").removeClass("open");
        return false;
    });
    /* EOF PANELS */


    /* DATATABLES/CONTENT HEIGHT FIX */
    $(".dataTables_length select").on("change", function () {
        onresize();
    });
    /* END DATATABLES/CONTENT HEIGHT FIX */

    /* TOGGLE FUNCTION */
    $(".toggle").on("click", function () {
        var elm = $("#" + $(this).data("toggle"));
        if (elm.is(":visible"))
            elm.addClass("hidden").removeClass("show");
        else
            elm.addClass("show").removeClass("hidden");

        return false;
    });
    /* END TOGGLE FUNCTION */

    /* MESSAGES LOADING */
    $(".messages .item").each(function (index) {
        var elm = $(this);
        setInterval(function () {
            elm.addClass("item-visible");
        }, index * 300);
    });
    /* END MESSAGES LOADING */

    /* LOCK SCREEN */
    $(".lockscreen-box .lsb-access").on("click", function () {
        $(this).parent(".lockscreen-box").addClass("active").find("input").focus();
        return false;
    });
    $(".lockscreen-box .user_signin").on("click", function () {
        $(".sign-in").show();
        $(this).remove();
        $(".user").hide().find("img").attr("src", "assets/images/users/no-image.jpg");
        $(".user").show();
        return false;
    });
    /* END LOCK SCREEN */

    /* SIDEBAR */
    $(".sidebar-toggle").on("click", function () {
        $("body").toggleClass("sidebar-opened");
        return false;
    });
    $(".sidebar .sidebar-tab").on("click", function () {
        $(".sidebar .sidebar-tab").removeClass("active");
        $(".sidebar .sidebar-tab-content").removeClass("active");

        $($(this).attr("href")).addClass("active");
        $(this).addClass("active");

        return false;
    });
    $(".page-container").on("click", function () {
        $("body").removeClass("sidebar-opened");
    });
    /* END SIDEBAR */

;
    /* END PAGE TABBED */

    /* PAGE MODE TOGGLE */
    $(".page-mode-toggle").on("click", function () {
        page_mode_boxed();
        return false;
    });
    /* END PAGE MODE TOGGLE */


}

$(document).ready(function () {
    page_actions();
});




function panel_fullscreen(panel) {

    if (panel.hasClass("panel-fullscreened")) {
        panel.removeClass("panel-fullscreened").unwrap();
        panel.find(".panel-body,.chart-holder").css("height", "");
        panel.find(".panel-fullscreen .fa").removeClass("fa-compress").addClass("fa-expand");

        $(window).resize();
    } else {
        var head = panel.find(".panel-heading");
        var body = panel.find(".panel-body");
        var footer = panel.find(".panel-footer");
        var hplus = 30;

        if (body.hasClass("panel-body-table") || body.hasClass("padding-0")) {
            hplus = 0;
        }
        if (head.length > 0) {
            hplus += head.height() + 21;
        }
        if (footer.length > 0) {
            hplus += footer.height() + 21;
        }

        panel.find(".panel-body,.chart-holder").height($(window).height() - hplus);


        panel.addClass("panel-fullscreened").wrap('<div class="panel-fullscreen-wrap"></div>');
        panel.find(".panel-fullscreen .fa").removeClass("fa-expand").addClass("fa-compress");

        $(window).resize();
    }
}