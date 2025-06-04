
var BaseURL = "http://ventadecarrostaller.runasp.net";

class DetalleFactura {
    constructor(ID_Detalle_Factura, ID_Factura, Tipo_Item, ID_Detalle_Servicio_Factura, Descripcion_Item, Cantidad, Precio_Unitario, Subtotal_Item, Detalle_Repuestos_Orden, Detalle_Servicio, Factura) {
        this.ID_Detalle_Factura = ID_Detalle_Factura;
        this.ID_Factura = ID_Factura;
        this.Tipo_Item = Tipo_Item;
        this.ID_Detalle_Servicio_Factura = ID_Detalle_Servicio_Factura;
        this.Descripcion_Item = Descripcion_Item;
        this.Cantidad = Cantidad;
        this.Precio_Unitario = Precio_Unitario;
        this.Subtotal_Item = Subtotal_Item;
    }
}


jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaDetalleFacturas();
});

function LlenarTablaDetalleFacturas() {
    let URL = BaseURL + "/api/DetalleFacturas/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblDetalleFacturas");
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
    let URL = BaseURL + "/api/DetalleFacturas/" + Funcion;
    //Se construye el objeto empleado
    const detalleFactura = new DetalleFactura(
        $("#txtID_Detalle_Factura").val(),             
        $("#txtID_Factura").val(),                     
        $("#txtTipo_Item").val(),                      
        $("#txtID_Detalle_Servicio_Factura").val(),    
        $("#txtDescripcion_Item").val(),               
        $("#txtCantidad").val(),           
        $("#txtPrecio_Unitario").val(),    
        $("#txtSubtotal_Item").val()) 


    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, detalleFactura);
    LlenarTablaDetalleFacturas();
}
//CALCULAR SUBTOTAL
$("#txtCantidad, #txtPrecio_Unitario").on('input', function () {
    const cantidad = parseFloat($("#txtCantidad").val()) || 0;
    const precio = parseFloat($("#txtPrecio_Unitario").val()) || 0;
    const subtotal = cantidad * precio;
    $("#txtSubtotal").val(subtotal.toFixed(2));
});

