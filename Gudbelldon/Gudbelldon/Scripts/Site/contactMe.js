$(document).ready(function () {
    $("#contact-form").submit(function (ev) {
        ev.preventDefault();
        if (!$(this).valid()) return false;
        
        $.ajax({
            type: "POST",
            url:  "/Home/ContactMe",
            data: $(this).serialize(),
            success: function (data) {
                console.log("success");
            }
        });

        return false;
    });

    $("#contact-form").validate();
});