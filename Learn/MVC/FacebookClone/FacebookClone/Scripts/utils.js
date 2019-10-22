function readUrl(input, preview) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(preview)
                .attr("src", e.target.result)
                .width(200)
                .height(200);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

function setupImageOnChange(id, preview) {
    $(id).change(function () {
        readUrl(this, preview);
        $(preview).removeClass("hide");
    });
}
