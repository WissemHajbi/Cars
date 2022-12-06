let SaleDisc = document.querySelectorAll(".SaleDisc");
SaleDisc.forEach((e) => {
    if (e.innerText.length > 100) {
        e.innerText = e.innerText.slice(0, 100) + " ...";
    }
});

let TopSaleDisc = document.querySelectorAll(".TopSaleDisc");
TopSaleDisc.forEach((e) => {
    if (e.innerText.length > 150) {
        e.innerText = e.innerText.slice(0, 100) + " ...";
    }
});

// Wrap every letter in a span
var textWrapper = document.querySelector(".ml12");
textWrapper.innerHTML = textWrapper.textContent.replace(
    /\S/g,
    "<span class='lettre'>$&</span>"
);

anime
    .timeline({ loop: true })
    .add({
        targets: ".ml12 .lettre",
        translateX: [40, 0],
        translateZ: 0,
        opacity: [0, 1],
        easing: "easeOutExpo",
        duration: 1200,
        delay: (el, i) => 500 + 30 * i,
    })
    .add({
        targets: ".ml12 .lettre",
        translateX: [0, -30],
        opacity: [1, 0],
        easing: "easeInExpo",
        duration: 1100,
        delay: (el, i) => 100 + 30 * i,
    });
