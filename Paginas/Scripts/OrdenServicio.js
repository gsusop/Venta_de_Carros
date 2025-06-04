
var BaseURL = "http://ventadecarrostaller.runasp.net";

class OrdenServicio {
    constructor(ID_Orden, Numero_Orden, ID_Vehiculo, Fecha_Creacion, Fecha_Inicio, Fecha_Fin_Estimada, Fecha_Fin_Real,
        ID_Empleado_Asignado, Estado_Orden, Diagnostico_Inicial, Comentarios_Adicionales) {
        this.ID_Orden = ID_Orden;//Date.now() / 1000;
        this.Numero_Orden = Numero_Orden;
        this.ID_Vehiculo = ID_Vehiculo;
        this.Fecha_Creacion = Fecha_Creacion;
        this.Fecha_Inicio = Fecha_Inicio;
        this.Fecha_Fin_Estimada = Fecha_Fin_Estimada;
        this.Fecha_Fin_Real = Fecha_Fin_Real;
        this.ID_Empleado_Asignado = ID_Empleado_Asignado;
        this.Estado_Orden = Estado_Orden;
        this.Diagnostico_Inicial = Diagnostico_Inicial;
        this.Comentarios_Adicionales = Comentarios_Adicionales;

    }

}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaOrdenServicio();
});

function LlenarTablaOrdenServicio() {
    let URL = BaseURL + "/api/OrdenServicio/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblOrdenServicio");
}



async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/OrdenServicio/" + Funcion;
    //Se construye el objeto empleado
    const ordser = new OrdenServicio(
        $("#txtID_Orden").val(),
        $("#txtNumero_Orden").val(),
        $("#txtID_Vehiculo").val(),
        $("#txtFecha_Creacion").val(),
        $("#txtFecha_Inicio").val(),
        $("#txtFecha_Fin_Estimada").val(),
        $("#txtFecha_Fin_Real").val(),
        $("#txtID_Empleado_Asignado").val(),
        $("#txtEstado_Orden").val(),
        $("#txtDiagnostico_Inicial").val(),
        $("#txtComentarios_Adicionales").val());


    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, ordser);
    LlenarTablaOrdenServicio();
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



