document.getElementById("#s").addEventListener("click", function () {
    var a = document.getElementById("#img");
    var b = document.getElementById("#res");
    a.src = a.src.replace(a.src,b.src);
});