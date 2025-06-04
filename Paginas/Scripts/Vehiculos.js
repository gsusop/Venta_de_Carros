var BaseURL = "http://ventadecarrostaller.runasp.net";

class Vehiculo {
    constructor(ID_Vehiculo, VIN, Marca, Modelo, Año, Color, Placa, ID_Cliente, Fecha_Ingreso, Fecha_Salida, Estado_Vehiculo) {
        this.ID_Vehiculo = ID_Vehiculo;
        this.VIN = VIN;
        this.Marca = Marca;
        this.Modelo = Modelo;
        this.Año = Año;
        this.Color = Color;
        this.Placa = Placa;
        this.ID_Cliente = ID_Cliente;
        this.Fecha_Ingreso = Fecha_Ingreso;
        this.Fecha_Salida = Fecha_Salida;
        this.Estado_Vehiculo = Estado_Vehiculo;
    }
}


jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaVehiculos();
});



function LlenarTablaVehiculos() {
    let URL = BaseURL + "/api/Vehiculos/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblVehiculos");
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/Vehiculos/" + Funcion;

    // Se construye el objeto vehículo
    const vehiculo = new Vehiculo(
        $("#txtID_Vehiculo").val(),
        $("#txtVIN").val(),
        $("#txtMarca").val(),
        $("#txtModelo").val(),
        $("#txtAnio").val(),
        $("#txtColor").val(),
        $("#txtPlaca").val(),
        $("#txtID_Cliente").val(),
        $("#txtFecha_Ingreso").val(),
        $("#txtFecha_Salida").val(),
        $("#txtEstado_Vehiculo").val()
    );

    // Invoca el comando para ejecutar (POST, PUT, DELETE)
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, vehiculo);
    LlenarTablaVehiculos();
}
