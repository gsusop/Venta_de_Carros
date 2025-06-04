var BaseURL = "http://ventadecarrostaller.runasp.net";

class DetalleRepuestoOrden {
    constructor(ID_Detalle_Repuesto, ID_Orden, ID_Repuesto, Cantidad_Utilizada, Precio_Unitario, Subtotal) {
        this.ID_Detalle_Repuesto = ID_Detalle_Repuesto;
        this.ID_Orden = ID_Orden;
        this.ID_Repuesto = ID_Repuesto;
        this.Cantidad_Utilizada = Cantidad_Utilizada;
        this.Precio_Unitario = Precio_Unitario;
        this.Subtotal = Subtotal;

    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaDetalleRepuestoOrden();
});

function LlenarTablaDetalleRepuestoOrden() {
    let URL = BaseURL + "/api/DetalleRepuestoOrden/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblDetalleRepuestoOrden");
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
    let URL = BaseURL + "/api/DetalleRepuestoOrden/" + Funcion;

    const det = new DetalleRepuestoOrden(
        $("#txtID_Detalle_Repuesto").val(),
        $("#txtID_Orden").val(),
        $("#txtID_Repuesto").val(),
        $("#txtCantidad_Utilizada").val(),
        $("#txtPrecio_Unitario").val(),
        $("#txtSubtotal").val()
    );

    const objetoLimpio = limpiarObjeto(det);

    // Enviamos el objeto limpio sin propiedades nulas
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, objetoLimpio);
    LlenarTablaDetalleRepuestoOrden();
}
//CALCULAR SUBTOTAL
$("#txtCantidad_Utilizada, #txtPrecio_Unitario").on('input', function () {
    const cantidad = parseFloat($("#txtCantidad_Utilizada").val()) || 0;
    const precio = parseFloat($("#txtPrecio_Unitario").val()) || 0;
    const subtotal = cantidad * precio;
    $("#txtSubtotal").val(subtotal.toFixed(2));
});