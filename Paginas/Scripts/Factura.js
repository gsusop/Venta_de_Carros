
var BaseURL = "http://ventadecarrostaller.runasp.net";

class Factura {
    constructor(ID_Factura, Numero_Factura, ID_Orden, Fecha_Emision, IVA, Total, Estado_Pago, Metodo_Pago, Comentarios) {
        this.ID_Factura = ID_Factura;
        this.Numero_Factura = Numero_Factura;
        this.ID_Orden = ID_Orden;
        this.Fecha_Emision = Fecha_Emision;
        this.IVA = IVA;
        this.Total = Total;
        this.Estado_Pago = Estado_Pago;
        this.Metodo_Pago = Metodo_Pago;
        this.Comentarios = Comentarios;
    }
}


jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaFacturas();
});

function LlenarTablaFacturas() {
    let URL = BaseURL + "/api/Facturas/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblFacturas");
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
    let URL = BaseURL + "/api/Facturas/" + Funcion;
    //Se construye el objeto empleado
    const fact = new Factura(
        $("#txtID_Factura").val(),
        $("#txtNumero_Factura").val(),
        $("#txtID_Orden").val(),
        $("#txtFecha_Emision").val(),
        $("#txtIVA").val(),
        $("#txtTotal").val(),
        $("#txtEstado_Pago").val(),
        $("#txtMetodo_Pago").val(),
        $("#txtComentarios").val());


    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, fact);
    LlenarTablaFacturas();
}

