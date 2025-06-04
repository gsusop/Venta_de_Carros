
var BaseURL = "http://ventadecarrostaller.runasp.net";

class Venta {
    constructor(ID_Venta, ID_Vehiculo, ID_Cliente, Fecha_Venta, Precio_Venta, Numero_Factura_Venta) {
        this.ID_Venta = ID_Venta;//Date.now() / 1000;
        this.ID_Vehiculo = ID_Vehiculo;
        this.ID_Cliente = ID_Cliente;
        this.Fecha_Venta = Fecha_Venta;
        this.Precio_Venta = Precio_Venta;
        this.Numero_Factura_Venta = Numero_Factura_Venta;
    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaVentas();
});

function LlenarTablaVentas() {
    let URL = BaseURL + "/api/Ventas/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblVentas");
}



async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/Ventas/" + Funcion;
    //Se construye el objeto empleado
    const venta = new Venta(
        $("#txtID_Venta").val(),
        $("#txtID_Vehiculo").val(),
        $("#txtID_Cliente").val(),
        $("#txtFecha_Venta").val(),
        $("#txtPrecio_Venta").val(),
        $("#txtNumero_Factura_Venta").val());

    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, venta);
    LlenarTablaVentas();
}


/*
async function Consultar() {
    let Documento = $("#txtNumero_Factura_Venta").val();
    let URL = BaseURL + "api/Ventas/ConsultarXDocumento?Documento=" + Documento;
    const venta = await ConsultarServicioAuth(URL);
    if (venta != null) {
        $("#txtNombre").val(venta.Nombre);
        $("#txtPrimerApellido").val(venta.PrimerApellido);
        $("#txtSegundoApellido").val(venta.SegundoApellido);
        $("#txtDireccion").val(venta.Direccion);
        $("#txtFechaNacimiento").val(venta.FechaNacimiento.split('T')[0]);
        $("#txtTelefono").val(venta.Telefono);
    }
    else {
        $("#dvMensaje").html("la venta no está en la base de datos");
        $("#txtNombre").val("");
        $("#txtPrimerApellido").val("");
        $("#txtSegundoApellido").val("");
        $("#txtDireccion").val("");
        $("#txtFechaNacimiento").val("");
        $("#txtTelefono").val("");
    }
}*/



