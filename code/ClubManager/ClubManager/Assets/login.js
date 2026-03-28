function togglePassword() {

    var pass = document.getElementById("txtPass");

    if (pass.type === "password")

        pass.type = "text";

    else

        pass.type = "password";

}