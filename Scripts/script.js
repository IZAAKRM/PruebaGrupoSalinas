function altaProducto() {
    var nombre = document.getElementById('nom').value;
    var precio = document.getElementById('pre').value;
    var existencia = document.getElementById('exis').value;
    var url = "../Home/altaProducto";
c
    fetch(url, {
        method: "POST", // or 'PUT'
        body: JSON.stringify(data), // data can be `string` or {object}!
        headers: {
            "Content-Type": "application/json",
        },
    })
        .then((res) => res.json())
        .catch((error) => console.error("Error:", error))
        .then((response) => alert(response.message));
    location.reload();
}

function ventaProducto(codigo) {
    document.getElementById('codigo').value = codigo;
    $('#ModalVenta').modal('show');
    
}
function venderProducto() {
    var cant = document.getElementById('cant').value;
    var codigo = document.getElementById('codigo').value;

    var url = "../Home/ventaProducto";
    var data = { codigo: codigo, cant: cant };

    fetch(url, {
        method: "POST", // or 'PUT'
        body: JSON.stringify(data), // data can be `string` or {object}!
        headers: {
            "Content-Type": "application/json",
        },
    })
        .then((res) => res.json())
        .catch((error) => console.error("Error:", error))
        .then((response) => alert(response.message));
    location.reload();
}