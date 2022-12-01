const paragraph = document.getElementById("petko");
const edit_button = document.getElementById("edit-button");
const end_button = document.getElementById("end-editing");

edit_button.addEventListener("click", function () {
    paragraph.contentEditable = true;
    paragraph.style.backgroundColor = "#dddbdb";

    edit_button.hidden = true;
    end_button.hidden = false;
});


end_button.addEventListener("click", function () {
    paragraph.contentEditable = false;
    paragraph.style.backgroundColor = "#ffe44d";

    edit_button.hidden = false;
    end_button.hidden = true;
})