$(function (){

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-sf-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("pulsate");
        });

        return false;
    };

    var createAutoComplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-sf-autocomplete")
        };

      //  $input.autocomplete(options);
    };

    $("form[data-sf-ajax='true']").submit(ajaxFormSubmit); //allows form elements to be selected with that element set to true, when submit is hit, my function will be implemented
    $("input[data-sf-autocomplete]").each(createAutoComplete);

});

