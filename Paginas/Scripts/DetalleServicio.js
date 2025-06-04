
var BaseURL = "http://ventadecarrostaller.runasp.net";

class DetalleServicio {
    constructor(ID_Detalle_Servicio, ID_Orden, ID_Servicio, Descripcion_Servicio, Cantidad, Precio_Unitario, Subtotal) {
        this.ID_Detalle_Servicio = ID_Detalle_Servicio;
        this.ID_Orden = ID_Orden;
        this.ID_Servicio = ID_Servicio;
        this.Descripcion_Servicio = Descripcion_Servicio;
        this.Cantidad = Cantidad;
        this.Precio_Unitario = Precio_Unitario;
        this.Subtotal = Subtotal;
    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaDetalleServicios();
});

function LlenarTablaDetalleServicios() {
    let URL = BaseURL + "/api/DetalleServicios/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblDetalleServicios");
}
function limpiarObjeto(obj) {
    const nuevoObj = {};
    for (const key in obj) {
        if (obj[key] !== null && obj[key] !== undefined) {
            nuevoObj[key] = obj[key];
        }
    }
    return nuevoObj;
}


async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/DetalleServicios/" + Funcion;
    // Construir el objeto detalle servicio con los valores de los inputs
    const detalleServicio = new DetalleServicio(
        $("#txtID_Detalle_Servicio").val(),
        $("#txtID_Orden").val(),
        $("#txtID_Servicio").val(),
        $("#txtDescripcion_Servicio").val(),
        $("#txtCantidad").val(),
        $("#txtPrecio_Unitario").val(),
        $("#txtSubtotal").val());
    

    // Invocar el servicio para ejecutar el comando
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, detalleServicio);
    LlenarTablaDetalleServicios();
}

//CALCULAR SUBTOTAL
$("#txtCantidad, #txtPrecio_Unitario").on('input', function () {
    const cantidad = parseFloat($("#txtCantidad").val()) || 0;
    const precio = parseFloat($("#txtPrecio_Unitario").val()) || 0;
    const subtotal = cantidad * precio;
    $("#txtSubtotal").val(subtotal.toFixed(2));
});

