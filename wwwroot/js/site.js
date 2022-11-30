let SaleDisc = document.querySelectorAll(".SaleDisc");
SaleDisc.forEach((e) => {
    if (e.innerText.length > 100) {
        e.innerText = e.innerText.slice(0, 100) + " ...";
    }
});
