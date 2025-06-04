
var BaseURL = "http://ventadecarrostaller.runasp.net";


class InventarioRepuesto {
    constructor(ID_Repuesto, Codigo_Repuesto, Nombre_Repuesto, Descripcion, Cantidad_Stock, Precio_Unitario, ID_Proveedor, Fecha_Ultima_Entrada) {
        this.ID_Repuesto = ID_Repuesto;
        this.Codigo_Repuesto = Codigo_Repuesto;
        this.Nombre_Repuesto = Nombre_Repuesto;
        this.Descripcion = Descripcion;
        this.Cantidad_Stock = Cantidad_Stock;
        this.Precio_Unitario = Precio_Unitario;
        this.ID_Proveedor = ID_Proveedor;
        this.Fecha_Ultima_Entrada = Fecha_Ultima_Entrada;
    }
}


jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaInventarioRepuesto();
});

function LlenarTablaInventarioRepuesto() {
    let URL = BaseURL + "/api/InventarioRepuesto/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblInventarioRepuesto");
}


async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/InventarioRepuesto/" + Funcion;

    const repuesto = new InventarioRepuesto(
        $("#txtID_Repuesto").val(),
        $("#txtCodigo_Repuesto").val(),
        $("#txtNombre_Repuesto").val(),
        $("#txtDescripcion").val(),
        $("#txtCantidad_Stock").val(),
        $("#txtPrecio_Unitario").val(),
        $("#txtID_Proveedor").val(),
        $("#txtFecha_Ultima_Entrada").val()
    );

    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, repuesto);
    LlenarTablaInventarioRepuesto();
}


