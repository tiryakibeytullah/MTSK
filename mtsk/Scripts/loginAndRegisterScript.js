/*$("#giris-yap").on("submit",function(e) {
    e.preventDefault();
    location.href="anasayfa.html";
});*/

$("#registerForm").on("submit",function(e){
    var password = $("#register-password").val();
    var repeatPassword = $("#register-Repeatpassword").val();
    if(password != repeatPassword) {
        alert("Şifre, Şifre tekrar ile uyuşmuyor.");
        return true;
    }
    else {
        e.preventDefault();
        $("#staticBackdrop").modal("hide");
        alert("Kayıt Başarılı");
        return false;
    }
})

$("#btnClose").on('click', function () {
    Session.Remove(“token”);
});