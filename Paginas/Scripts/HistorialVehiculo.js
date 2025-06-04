
var BaseURL = "http://ventadecarrostaller.runasp.net";

class HistorialVehiculo {
    constructor(ID_Historial, ID_Vehiculo, ID_Orden, Fecha_Visita, Descripcion_Problema) {
        this.ID_Historial = ID_Historial;//Date.now() / 1000;
        this.ID_Vehiculo = ID_Vehiculo;
        this.ID_Orden = ID_Orden;
        this.Fecha_Visita = Fecha_Visita;
        this.Descripcion_Problema = Descripcion_Problema;
    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaHistorialVehiculo();
});

function LlenarTablaHistorialVehiculo() {
    let URL = BaseURL + "/api/HistorialVehiculo/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblHistorialVehiculo");
}






async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/HistorialVehiculo/" + Funcion;



    //Se construye el objeto empleado
    const histo = new HistorialVehiculo(
        $("#txtID_Historial").val(),
        $("#txtID_Vehiculo").val(),
        $("#txtID_Orden").val(),
        $("#txtFecha_Visita").val(),
        $("#Descripcion_Problema").val());

    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, histo);
    LlenarTablaHistorialVehiculo();
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


