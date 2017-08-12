$(document).ready(function () {
    getProductos();
    getDetalles();
    getTotales();
});


function getProductos() {
    $.ajax({
        url: '/Ventas/getExistencia',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var rows = '';
            $.each(data, function (i, item) {
                rows += "<option value=" + item.Id + "," + item.Existencia + ">" + item.Nombre + "</option>";
                $("#select_Producto").html(rows);
            });
        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}
function getDetalles() {
    $.ajax({
        url: '/Ventas/getDetalles/' + $("#VentaId").val(),
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
                    rows += "<td><button class='btn btn-danger' onclick='return delete_Detalle(" + item.id_detalleVenta + ")'>Eliminar</button></td>"
                    rows += "</tr>";
                    $("#tbdoy_detalles_venta").html(rows);
                });
            }
            else {
                $("#tbdoy_detalles_venta").html("");
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
        url: '/Ventas/getTotales/' + $("#VentaId").val(),
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
                    $("#total_venta").html(rows);
                });
            }
            else { $("#total_venta").html(""); }

        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}
function delete_Detalle(id) {
    $.ajax({
        url: '/Ventas/delete_Detalle/' + id,
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
    var idProducto_y_Existencia = $("#select_Producto").val().split(",");
    var cantidad = parseInt($("#Cantidad").val());
    var existencia = parseInt(idProducto_y_Existencia[1]);
    if ((cantidad > existencia) || (cantidad < 1)) {
        $("#ErrorInventario").attr('style', 'margin-top:0.5%;display:;');
    }
    else {
        $("#ErrorInventario").attr('style', 'margin-top:0.5%;display:none;');
        $.ajax({
            url: '/Ventas/CrearDetalleVenta/',
            type: 'GET',
            dataType: 'json',
            data: {
                IdVenta: $("#VentaId").val(),
                Producto_Id: idProducto_y_Existencia[0],
                _Cantidad: $("#Cantidad").val()
            },
            success: function (data) {
                
                getProductos();
                getDetalles();
                getTotales();
            },
            error: function (err) {
                getProductos();
                getDetalles();
                getTotales();
            }
        })
    }
});
