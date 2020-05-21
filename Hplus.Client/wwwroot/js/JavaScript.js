
var url = "http://localhost:50024/Products";

var productList = fetch(url)
    .then(response => { return response.json(); })
    .then(data => syncShowProducts(data))
    .catch(ex => {
        alert("ERROR");
        console.log(ex)
    });



function syncShowProducts(products) {
    var p = document.querySelector(".sync");
    console.log((new Date).getTime());
    products.forEach(product => {
        let li = document.createElement("li");
        let text = `${product.name} ($${product.price})`;
        li.appendChild(document.createTextNode(text));
        p.appendChild(li);



    });
    console.log((new Date).getTime());
}

async function getProducts() {
    try {
        var result = await fetch(url);
        var prodcuts = await result.json();
        asyncShowProducts(prodcuts);
    }
    catch (error) {
        alert(error);
    }
}

getProducts();

function asyncShowProducts(products) {
    var p = document.querySelector(".async");
    console.log((new Date).getTime());
    products.forEach(product => {
        let li = document.createElement("li");
        let text = `${product.name} ($${product.price})`;
        li.appendChild(document.createTextNode(text));
        p.appendChild(li);

    });
    console.log((new Date).getTime());
}




