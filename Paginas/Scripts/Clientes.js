var BaseURL = "http://ventadecarrostaller.runasp.net";

class Cliente {
    constructor(ID_Cliente, Tipo_Documento, Numero_Documento, Nombre_Completo, Direccion, Telefono, Correo_Electronico) {
        this.ID_Cliente = ID_Cliente;
        this.Tipo_Documento = Tipo_Documento;
        this.Numero_Documento = Numero_Documento;
        this.Nombre_Completo = Nombre_Completo;
        this.Direccion = Direccion;
        this.Telefono = Telefono;
        this.Correo_Electronico = Correo_Electronico;
    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaClientes();
});

function LlenarTablaClientes() {
    let URL = BaseURL + "/api/Clientes/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblClientes");
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/Clientes/" + Funcion;

    // Se construye el objeto cliente
    const cliente = new Cliente(
        $("#txtID_Cliente").val(),
        $("#txtTipo_Documento").val(),
        $("#txtNumero_Documento").val(),
        $("#txtNombre_Completo").val(),
        $("#txtDireccion").val(),
        $("#txtTelefono").val(),
        $("#txtCorreo_Electronico").val()
    );

    // Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, cliente);
    LlenarTablaClientes();
}
