
var BaseURL = "http://ventadecarrostaller.runasp.net";

class Servicio {
    constructor(Nombre_Servicio, Descripcion, Precio_Base) {
        this.ID_Servicio = Date.now()/1000;
        this.Nombre_Servicio = Nombre_Servicio;
        this.Descripcion = Descripcion;
        this.Precio_Base = Precio_Base;
        this.Detalle_Servicio = null;
        this.Servicios_Tipos = null;
    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaServicios();
});

function LlenarTablaServicios() {
    let URL = BaseURL + "/api/Servicios/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblServicios");
}
async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/Servicios/" + Funcion;
    //Se construye el objeto empleado
    const item = new Servicio($("#txtNombre_Servicio").val(), $("#txtDescripcion").val(), $("#txtPrecio_Base").val());
    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, item);
    LlenarTablaServicios();
}
async function Consultar() {
    let Documento = $("#txtDocumento").val();
    let URL = BaseURL + "api/Servicios/ConsultarXDocumento?Documento=" + Documento;
    const empleado = await ConsultarServicioAuth(URL);
    if (empleado != null) {
        $("#txtNombre").val(empleado.Nombre);
        $("#txtPrimerApellido").val(empleado.PrimerApellido);
        $("#txtSegundoApellido").val(empleado.SegundoApellido);
        $("#txtDireccion").val(empleado.Direccion);
        $("#txtFechaNacimiento").val(empleado.FechaNacimiento.split('T')[0]);
        $("#txtTelefono").val(empleado.Telefono);
    }
    else {
        $("#dvMensaje").html("El empleado no está en la base de datos");
        $("#txtNombre").val("");
        $("#txtPrimerApellido").val("");
        $("#txtSegundoApellido").val("");
        $("#txtDireccion").val("");
        $("#txtFechaNacimiento").val("");
        $("#txtTelefono").val("");
    }
}



