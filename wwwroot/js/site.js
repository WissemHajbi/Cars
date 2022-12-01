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
