
document.addEventListener("DOMContentLoaded", () => {
    const userId = localStorage.getItem("userId");

    if (!userId) {
        alert("Para acceder a esta función, debes estar registrado.");
        window.location.href = "register.html";
    }
});
