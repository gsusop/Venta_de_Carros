var BaseURL = "http://ventadecarrostaller.runasp.net";

class Proveedor {
    constructor(ID_Proveedor, NIT, Nombre_Proveedor, Direccion, Telefono, Correo_Electronico, Inventario_Repuesto) {
        this.ID_Proveedor = ID_Proveedor;
        this.NIT = NIT;
        this.Nombre_Proveedor = Nombre_Proveedor;
        this.Direccion = Direccion;
        this.Telefono = Telefono;
        this.Correo_Electronico = Correo_Electronico;
        this.Inventario_Repuesto = Inventario_Repuesto;
    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaProveedores();
});

function LlenarTablaProveedores() {
    let URL = BaseURL + "/api/Proveedores/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblProveedores");
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/Proveedores/" + Funcion;

    // Se construye el objeto proveedor
    const proveedor = new Proveedor(
        $("#txtID_Proveedor").val(),
        $("#txtNIT").val(),
        $("#txtNombre_Proveedor").val(),
        $("#txtDireccion").val(),
        $("#txtTelefono").val(),
        $("#txtCorreo_Electronico").val(),
        $("#txtInventario_Repuesto").val()
    );

    // Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, proveedor);
    LlenarTablaProveedores();
}
