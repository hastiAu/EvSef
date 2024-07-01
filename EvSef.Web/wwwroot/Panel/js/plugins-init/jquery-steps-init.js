(function ($) {
    "use strict"

    var form = $("#step-form-horizontal");
    form.children('div').steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        autoFocus: true,
        onStepChanging: function (event, currentIndex, newIndex) {
            // Check if the user is moving to the second step
            if (newIndex === 1) {
                // Scroll to the top of the page
                $('html, body').animate({ scrollTop: 0 }, 'fast');
            }
            // Validate the form on each step change
            form.validate().settings.ignore = ":disabled,:hidden";
            return form.valid();
        }
    });

    var form2 = $("#step-form-tab");
    form2.children('div').steps({
        headerTag: "h4",
        bodyTag: "section",
        enableFinishButton: false,
        enablePagination: false,
        enableAllSteps: true,
        titleTemplate: "#title#"
    });

    var form3 = $('#step-form-vertical');
    form3.children('div').steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        stepsOrientation: "vertical"
    });

})(jQuery);