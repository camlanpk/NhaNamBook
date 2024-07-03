document.getElementById("submit-fieldset").addEventListener("submit", function (event) {
    event.preventDefault();

    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var confirmPassword = document.getElementById("confirm-password").value;
    var displayName = document.getElementById("display-name").value;
    var birthday = document.getElementById("birthday").value;

    if (password !== confirmPassword) {
        alert("Mật khẩu không khớp. Vui lòng nhập lại!");
        return;
    }
    alert("Đăng ký thành công!");
});