$(document).ready(function () {
    getProductos();
    getDetalles();
    getTotales();
});

//Obtenemos una lista de productos, por defecto, esta funcion se pondra en marcha al cargar la pagina
function getProductos() {
    $.ajax({
        url: '/Pedidos/getParametersAndProducts',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var rows = '';
            $.each(data, function (i, item) {
                var espacioLibre = item.LimiteExistencia-item.Existencia;
                rows += "<option value=" + item.Id + "," + espacioLibre + ">" + item.Nombre + "</option>";
                $("#select_Producto").html(rows);
            });
        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}
//Esto nos permitira actualizar nuestra lista al seleccionar cada producto sin recargarse
function getDetalles() {
    $.ajax({
        url: '/Pedidos/getDetalles/'+$("#PedidoId").val(),
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.length > 0) {
                $.each(data, function (i, item) {
                    rows += "<tr>";
                    rows += "<td>" + item.Producto + "</td>";
                    rows += "<td>" + item.Cantidad + "</td>";
                    rows += "<td>" + item.PrecioUnitario + "</td>";
                    rows += "<td>" + item.Subtotal + "</td>";
                    rows += "<td>" + item.ITBIS + "</td>";
                    rows += "<td>" + item.TotalDetalle + "</td>";
                    rows += "<td><button class='btn btn-danger' onclick='return delete_Detalle(" + item.id_detallePedido + ")'>Eliminar</button></td>"
                    rows += "</tr>";
                    $("#tbdoy_detalles_pedido").html(rows);
                });
            }
            else {
                $("#tbdoy_detalles_pedido").html("");
            }
            var rows = '';
            
        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}
function getTotales() {
    $.ajax({
        url: '/Pedidos/getTotales/' + $("#PedidoId").val(),
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.length > 0) {
                var rows = '';
                $.each(data, function (i, item) {
                    rows += "<tr>";
                    rows += "<td><strong>SubTotal</strong></td>";
                    rows += "<td>" + item.SubTotal + "</td>";
                    rows += "</tr>";
                    rows += "<tr>";
                    rows += "<td><strong>ITBIS</strong></td>";
                    rows += " <td>" + item.ITBIS + "</td>";
                    rows += "</tr>";
                    rows += "<tr>";
                    rows += "<td><strong>Total</strong></td>";
                    rows += "<td>" + item.Total + "</td>";
                    rows += "</tr>";
                    $("#total_pedido").html(rows);
                });
            }
            else { $("#total_pedido").html(""); }
            
        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}
function delete_Detalle(id){
    $.ajax({
        url: '/Pedidos/delete_Detalle/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            getProductos();
            getDetalles();
            getTotales()
        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}
$("#btnAgregar").click(function (e) {
    var idProducto_y_EspacioLibreEnInventario = $("#select_Producto").val().split(",");
    var cantidad = parseInt($("#Cantidad").val());
    var espacioLibre = parseInt(idProducto_y_EspacioLibreEnInventario[1]);
    if ((cantidad > espacioLibre) || (cantidad < 1)) {
        $("#ErrorInventario").attr('style', 'margin-top:0.5%;display:;');
    }
    else {
        $("#ErrorInventario").attr('style', 'margin-top:0.5%;display:none;');
       $.ajax({
        url: '/Pedidos/CrearDetallePedido/',
        type: 'GET',
        dataType: 'json',
        data : {
            PedidoId: $("#PedidoId").val(),
            Precio: $("#Precio").val(),
            IdProducto: idProducto_y_EspacioLibreEnInventario[0],
            Cantidad: $("#Cantidad").val()
        },
        success: function (data) {
            getProductos();
            getDetalles();
            getTotales()
        },
        error: function (err) {
            //alert('Exeption:'+exception);
        }
    })
    }
});
