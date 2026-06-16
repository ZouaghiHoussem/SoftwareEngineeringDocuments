function togglePassword() {
    var pass = document.getElementById("txtPass");
    if (!pass) return;

    if (pass.type === "password") {
        pass.type = "text";
    } else {
        pass.type = "password";
    }
}

document.addEventListener("DOMContentLoaded", function () {
    var labels = document.querySelectorAll(".autoFade");

    labels.forEach(function (label) {
        if (label.innerText.trim() !== "") {
            setTimeout(function () {
                label.style.transition = "opacity 0.6s ease";
                label.style.opacity = "0";
            }, 4000);
        }
    });
});