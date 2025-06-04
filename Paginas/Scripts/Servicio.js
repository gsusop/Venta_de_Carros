
var BaseURL = "http://ventadecarrostaller.runasp.net";

class Servicio {
    constructor(ID_Servicio, Nombre_Servicio, Descripcion, Precio_Base) {
        this.ID_Servicio = ID_Servicio;
        this.Nombre_Servicio = Nombre_Servicio;
        this.Descripcion = Descripcion;
        this.Precio_Base = Precio_Base;
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
    let URL = BaseURL + "/api/Servicios/" + Funcion;
    //Se construye el objeto empleado
    const item = new Servicio(
        $("#txtID_Servicio").val(),
        $("#txtNombre_Servicio").val(),
        $("#txtDescripcion").val(),
        $("#txtPrecio_Base").val());
    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, item);
    LlenarTablaServicios();
}




