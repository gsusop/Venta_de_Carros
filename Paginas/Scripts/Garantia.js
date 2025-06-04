
var BaseURL = "http://ventadecarrostaller.runasp.net";

class Garantia {
    constructor(ID_Garantia, ID_Vehiculo_Vendido, Fecha_Inicio_Garantia, Fecha_Fin_Garantia, Descripcion_Garantia, Kilometraje_Inicio, Kilometraje_Fin, Estado_Garantia) {
        this.ID_Garantia = ID_Garantia;
        this.ID_Vehiculo_Vendido = ID_Vehiculo_Vendido;
        this.Fecha_Inicio_Garantia = Fecha_Inicio_Garantia;
        this.Fecha_Fin_Garantia = Fecha_Fin_Garantia;
        this.Descripcion_Garantia = Descripcion_Garantia;
        this.Kilometraje_Inicio = Kilometraje_Inicio;
        this.Kilometraje_Fin = Kilometraje_Fin;
        this.Estado_Garantia = Estado_Garantia;
    }
}


jQuery(function () {    
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaGarantias();
});

function LlenarTablaGarantias() {
    let URL = BaseURL + "/api/Garantias/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblGarantias");
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
    let URL = BaseURL + "/api/Garantias/" + Funcion;
    //Se construye el objeto empleado
    const garantia = new Garantia(
        $("#txtID_Garantia").val(),
        $("#txtID_Vehiculo_Vendido").val(),
        $("#txtFecha_Inicio_Garantia").val(),
        $("#txtFecha_Fin_Garantia").val(),
        $("#txtDescripcion_Garantia").val(),
        $("#txtKilometraje_Inicio").val(),  // texto
        $("#txtKilometraje_Fin").val(),     // texto
        $("#txtEstado_Garantia").val());

    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, garantia);
    LlenarTablaGarantias();
}