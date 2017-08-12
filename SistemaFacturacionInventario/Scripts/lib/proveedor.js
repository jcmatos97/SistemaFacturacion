$(document).ready(function () {
    getProveedores();
});

//Declaramos una variable para verificar si se esta Insertando o Actualizando
var isUpdateable = false;

//Obtenemos una lista de productos, por defecto, esta funcion se pondra en marcha al cargar la pagina
function getProveedores() {
    $.ajax({
        url: '/Proveedor/GetProveedores/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var rows = '';
            $.each(data, function (i, item) {
                rows += "<tr>"
                rows += "<td>" + item.NombreProveedor + "</td>"
                rows += "<td>" + item.Telefono + "</td>"
                rows += "<td>" + item.Direccion + "</td>"
                rows += "<td><button type='button' id='btnEditar' class='btn btn-default' onclick='return getProveedoresById(" + item.Id + ")'>Editar</button></td>"
                rows += "</tr>";
                $("#tbodyProveedor").html(rows);
            });
        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}

// Get product by id
function getProveedoresById(id) {
    $("#title").text("Detalle del Proveedor");
    $.ajax({
        url: '/Proveedor/getProveedoresById/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            isUpdateable = true;
            $("#Id").val(data.Id);
            $("#Nombre").val(data.NombreProveedor);
            $("#Telefono").val(data.Telefono);
            $("#Direccion").val(data.Direccion);
            $("#NuevoProveedor").modal('show');
        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}

// evento al Presionar el boton de Guardado
$("#btnGuardar").click(function (e) {

    var data = {
        Id: $("#Id").val(),
        NombreProveedor: $("#Nombre").val(),
        Telefono: $("#Telefono").val(),
        Direccion: $("#Direccion").val()
    }
    if (isUpdateable) {
        $.ajax({
            url: '/Proveedor/ActualizarProveedor/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                getProveedores();
                isUpdateable = false;
                $("#NuevoProveedor").modal('hide');
                clear();
            },
            error: function (err) {
                //alert("Error: " + err.responseText);
            }
        })
}
     else{
        $.ajax({
            url: '/Proveedor/CrearProveedor/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                
                $("#NuevoProveedor").modal('hide');
                getProveedores();
                clear();
            },
            error: function (err) {
                //alert("Error: " + err.responseText);
            }
        })
    }
});

// Al presionar Añadir Proveedor pondra el siguiente nombre en titulo de nuestro modal
$("#btnCrear").click(function () {
    $("#title").text("Añadir Proveedor");
})
//Al presionar Añadir Proveedor pondra el siguiente nombre en titulo de nuestro modal
$("#btnEditar").click(function () {
    $("#title").text("Editar Proveedor");
})

// Evento cerrar Modal
$("#btnClose").click(function () {
    clear();
});

// Evento al Cancelar Modal
$("#btnCancelar").click(function () {
    clear();
});

// Funcion Borrar Campos
function clear() {
    $("#Id").val("");
    $("#Nombre").val("");
    $("#Telefono").val("");
    $("#Direccion").val("");
}
