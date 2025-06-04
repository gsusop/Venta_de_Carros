var BaseURL = "http://ventadecarrostaller.runasp.net";

class Garantia {
    constructor(ID_Revision, ID_Garantia, Fecha_Revision, Descripcion_Revision, ID_Empleado_Responsable,Empleado, Garantia) {
        this.ID_Revision = ID_Revision;
        this.ID_Garantia = ID_Garantia;
        this.Fecha_Revision = Fecha_Revision;
        this.Descripcion_Revision = Descripcion_Revision;
        this.ID_Empleado_Responsable = ID_Empleado_Responsable;
        this.Empleado = Empleado;
        this.Garantia = Garantia;

    }
}


jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaRevisionGarantia();
});

function LlenarTablaRevisionGarantia() {
    let URL = BaseURL + "/api/RevisionGarantia/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblRevisionGarantia");
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
    let URL = BaseURL + "/api/RevisionGarantia/" + Funcion;
    //Se construye el objeto empleado
    const RevisionGarantia = new Garantia(
        $("#txtID_Revision").val(),
        $("#txtID_Garantia").val(),
        $("#txtFecha_Revision").val(),
        $("#txtDescripcion_Revision").val(),
        $("#ID_Empleado_Responsable").val(),
        $("#txtEmpleado").val(),  // texto
        $("#txtGarantia").val(),     // texto
    );

    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, RevisionGarantia);
    LlenarTablaRevisionGarantia();
}