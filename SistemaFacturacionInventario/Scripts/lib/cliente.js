$(document).ready(function () {
    getClientes();
});

//Declaramos una variable para verificar si se esta Insertando o Actualizando
var isUpdateable = false;

//Obtenemos una lista de productos, por defecto, esta funcion se pondra en marcha al cargar la pagina
function getClientes() {
    $.ajax({
        url: '/Clientes/GetClientes/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var rows = '';
            $.each(data, function (i, item) {
                rows += "<tr>"
                rows += "<td>" + item.Nombre + "</td>"
                rows += "<td>" + item.Apellido + "</td>"
                rows += "<td>" + item.Cedula + "</td>"
                rows += "<td>" + item.Telefono + "</td>"
                rows += "<td>" + item.Email + "</td>"
                rows += "<td><button type='button' id='btnEditar' class='btn btn-default' onclick='return getClientesById(" + item.Id + ")'>Editar</button></td>"
                rows += "</tr>";
                $("#tbodyCliente").html(rows);
            });
        },
        error: function (err) {
            //alert("Error: " + err.responseText);
        }
    });
}

// Get product by id
function getClientesById(id) {
    $("#title").text("Detalle del Cliente");
    $.ajax({
        url: '/Clientes/getClientesById/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            isUpdateable = true;
            $("#Id").val(data.Id);
            $("#Nombre").val(data.Nombre);
            $("#Apellido").val(data.Apellido);
            $("#Cedula").val(data.Cedula);
            $("#Telefono").val(data.Telefono);
            $("#email").val(data.Email);
            $("#NuevoCliente").modal('show');
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
        Nombre: $("#Nombre").val(),
        Apellido: $("#Apellido").val(),
        Cedula: $("#Cedula").val(),
        Telefono: $("#Telefono").val(),
        Email: $("#email").val()
    }
    if (isUpdateable) {
        $.ajax({
            url: '/Clientes/ActualizarClientes/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                getClientes();
                isUpdateable = false;
                $("#NuevoCliente").modal('hide');
                clear();
            },
            error: function (err) {
                //alert("Error: " + err.responseText);
            }
        })
    }
    else {
        $.ajax({
            url: '/Clientes/CrearCliente/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {

                $("#NuevoCliente").modal('hide');
                getClientes();
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
    $("#title").text("Añadir Cliente");
})
//Al presionar Añadir Proveedor pondra el siguiente nombre en titulo de nuestro modal
$("#btnEditar").click(function () {
    $("#title").text("Editar Editar");
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
    $("#Apellido").val("");
    $("#Cedula").val("");
    $("#Telefono").val("");
    $("#email").val("");
}
