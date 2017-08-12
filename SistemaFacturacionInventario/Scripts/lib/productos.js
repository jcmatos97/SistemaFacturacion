function getProducto(all) {
    stringall = all.toString();
    arreglo = stringall.split('-');
    PrecioArreglo = arreglo[2].split(',');
    PrecioFixedString = PrecioArreglo[0]+"."+PrecioArreglo[1];
    document.getElementById('Id').value = arreglo[0];
    document.getElementById('Nombre').value = arreglo[1].toString();
    document.getElementById('Precio').value = parseFloat(PrecioFixedString);
    document.getElementById('LimiteExistencia').value = arreglo[3];
    document.getElementById('Existencia').value = arreglo[4];
    document.getElementById('Disponibilidad').value = arreglo[5];
    
    //Cada vez que presionemos el boton de crear se modificara el action de nuestro form
    $("#form_product").attr('action', '/Productos/ModificarProducto');
    $("#form_product").attr('method', 'get');
}

$("#btnCrear").click(function () {
    clear();
});

function clear() {
    $("#Id").val(""); 
    $("#Nombre").val("");
    $("#Precio").val("");
    $("#LimiteExistencia").val("");
    $("#Existencia").val("0");
    $("#Disponibilidad").val("1");
    //Cada vez que presionemos el boton de crear se modificara el action de nuestro form
    $("#form_product").attr('action', '/Productos/GuardarProducto');
    $("#form_product").attr('method', 'post');
}
