
$(document).ready(
    UpdateFancyDropDown(),

    $(".fancy_select").on("change", SetFancyData),


    $(".fancy_text").on("click",
        ".fancy-delete",
        function () {
            var id = $(this).parent().find("div > input").attr("id");
            alert("Du klickade på en deleteknapp med id: " + id);
        }),
    $(".fancy_text").on("keyup",
        ".fancy_input",
        function () {
            var id = $(this).attr("id");
            UpdateFancyText(this);
            //alert("du vill ändra text på rad" + id);

        }),

    $(".fancy_text").on("change",
        ".fancy_drop",
        function () {
            ChangeColor(this);
            if ($(this).hasClass("no_update")) {
                $(this).removeClass("no_update");
            }
            else {
                UpdateFancyText(this);
            }


        }),

    $(".fancy_text").on("click",
        ".add_fancy",
        function (event) {
            event.preventDefault();
            $.ajax("api/fancyText/Add",
                {
                    type: "POST",
                    data: $("form").serialize(),
                    success: function (result) {
                        console.log(result);
                        UpdateFancyDropDown();
                        ResetInputs();
                        $(".fancy_drop").addClass("no_update");
                        $(".fancy_drop").trigger("change");

                    }
                });

        })


);
function UpdateFancyText(element) {
    var form = $(element).closest("form");
    var data = form.serialize();
    var dataWithNoDigits = data.replace(/text[0-9]/, 'text').replace(/color[0-9]/, 'color');
    var formData = form.attr("data-fancy");
    var fancyTextId = JSON.parse(formData).id;
    dataWithNoDigits += "&id=" + fancyTextId;

    $.ajax("api/fancyText/Update",
        {
            type: "Patch",
            data: dataWithNoDigits,
            success: function () {
                UpdateFancyDropDown();
            }
        });
}
function SetFancyData() {
    var fancyText = $(this).find("option:selected").data();
    if (fancyText.fancy === undefined) {
        ResetInputs();

    } else {
        $("#fancy_name").val(fancyText.fancy.name);
        $.each(fancyText.fancy.fancyTexts, SetAllInputs);

    };
    $(".fancy_drop").addClass("no_update");
    $(".fancy_drop").trigger("change");


}
function ResetInputs() {

    $("#fancy_name").val("");
    var text = {
        text: "",
        color: 0
    };
    for (var i = 0; i < 3; i++) {
        SetAllInputs(i, text);
    }
}
function SetAllInputs(index, text) {

    $("#input_" + (index + 1)).val(text.text);
    $("#drop_" + (index + 1)).val(text.color);
    $("#form" + (index + 1)).attr("data-fancy", JSON.stringify(text));

};
function UpdateFancyDropDown() {

    $.ajax("api/fancyText/GetAll",
        {
            type: "GET",
            dataType: "json",
            success: function (result) {
                $(".fancy_select").empty().append("<option/>");
                $.each(result,
                    function (index, fancyText) {
                        var element = $("<option/>");
                        element.attr("value", fancyText.id).text(fancyText.name)
                            .attr("data-fancy", JSON.stringify(fancyText));
                        $(".fancy_select").append(element);

                    });
            }


        });

};
function ChangeColor(element) {

    var color = $(element).find("option:selected").text();
    switch (color) {
        case "Green":
            $(element).parent().find("div > input").parent().alterClass("input_border_*", "input_border_green").fadeOut(0).fadeIn();
            break;
        case "Yellow":
            $(element).parent().find("div > input").parent().alterClass("input_border_*", "input_border_yellow").fadeOut(0).fadeIn();
            break;
        case "Pink":
            $(element).parent().find("div > input").parent().alterClass("input_border_*", "input_border_pink").fadeOut(0).fadeIn();
            break;
        case "Blue":
            $(element).parent().find("div > input").parent().alterClass("input_border_*", "input_border_blue").fadeOut(0).fadeIn();
            break;
        case "Transparent":
            $(element).parent().find("div > input").parent().alterClass("input_border_*", "input_border_transparent").fadeOut(0).fadeIn();
            break;
        default:
    }

}
(function ($) {

    $.fn.alterClass = function (removals, additions) {

        var self = this;

        if (removals.indexOf('*') === -1) {
            // Use native jQuery methods if there is no wildcard matching
            self.removeClass(removals);
            return !additions ? self : self.addClass(additions);
        }

        var patt = new RegExp('\\s' +
            removals.
                replace(/\*/g, '[A-Za-z0-9-_]+').
                split(' ').
                join('\\s|\\s') +
            '\\s', 'g');

        self.each(function (i, it) {
            var cn = ' ' + it.className + ' ';
            while (patt.test(cn)) {
                cn = cn.replace(patt, ' ');
            }
            it.className = $.trim(cn);
        });

        return !additions ? self : self.addClass(additions);
    };

})(jQuery);