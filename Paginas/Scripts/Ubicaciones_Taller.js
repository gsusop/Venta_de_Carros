var BaseURL = "http://ventadecarrostaller.runasp.net";

class Ubicacion {
    constructor(ID_Ubicacion, Nombre_Ubicacion, Direccion, Ciudad) {
        this.ID_Ubicacion = ID_Ubicacion;
        this.Nombre_Ubicacion = Nombre_Ubicacion;
        this.Direccion = Direccion;
        this.Ciudad = Ciudad;
    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaUbicaciones();
});

function LlenarTablaUbicaciones() {
    let URL = BaseURL + "/api/Ubicaciones/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblUbicaciones");
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/Ubicaciones/" + Funcion;

    // Construir objeto Ubicacion desde el formulario
    const ubicacion = new Ubicacion(
        parseInt($("#txtID_Ubicacion").val()),
        $("#txtNombre_Ubicacion").val(),
        $("#txtDireccion").val(),
        $("#txtCiudad").val()
    );

    // Ejecutar llamada a servicio (función que debe estar definida en tus utilidades)
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, ubicacion);
    LlenarTablaUbicaciones();
}

async function Consultar() {
    const id = $("#txtID_Ubicacion").val();
    if (!id) {
        LlenarTablaUbicaciones();
        return;
    }

    let URL = BaseURL + "/api/Ubicaciones/ConsultarPorID/" + id;
    const data = await ConsultarServicioAuth(URL);
    if (data) {
        $("#txtID_Ubicacion").val(data.ID_Ubicacion);
        $("#txtNombre_Ubicacion").val(data.Nombre_Ubicacion);
        $("#txtDireccion").val(data.Direccion);
        $("#txtCiudad").val(data.Ciudad);
    }
}
