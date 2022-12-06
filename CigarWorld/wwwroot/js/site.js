const div = document.querySelectorAll(".inpDiv");

for (var i = 0; i < div.length; i++) {
    let paragraph = div[i].querySelector(".inpReview");
    let edit_button = div[i].querySelector(".inpEdit");
    let end_button = div[i].querySelector(".inpDone");

    if (edit_button!= null) {
        edit_button.addEventListener("click", function () {
            paragraph.contentEditable = true;
            paragraph.disabled = false;
            paragraph.style.backgroundColor = "#dddbdb";

            edit_button.hidden = true;
            end_button.hidden = false;
        })

        end_button.addEventListener("click", function () {
            paragraph.contentEditable = false;
            paragraph.style.backgroundColor = "#ffe44d";
            /*paragraph.disabled = true;*/
            edit_button.hidden = false;
            end_button.hidden = true;
        });
    }
}

