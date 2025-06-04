
var BaseURL = "http://ventadecarrostaller.runasp.net";

class Empleado {
    constructor(ID_Empleado, Tipo_Documento, Numero_Documento, Nombre_Completo, Especialidad, Telefono, Correo_Electronico) {
        this.ID_Empleado = ID_Empleado;
        this.Tipo_Documento = Tipo_Documento;
        this.Numero_Documento = Numero_Documento;
        this.Nombre_Completo = Nombre_Completo;
        this.Especialidad = Especialidad;
        this.Telefono = Telefono;
        this.Correo_Electronico = Correo_Electronico;
      
    }
}

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaEmpleados();
});

function LlenarTablaEmpleados() {
    let URL = BaseURL + "/api/Empleados/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblEmpleados");
}
async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "/api/Empleados/" + Funcion;
    //Se construye el objeto empleado
    const garantia = new Empleado(
        $("#txtID_Empleado").val(),
        $("#txtTipo_Documento").val(),
        $("#txtNumero_Documento").val(),
        $("#txtNombre_Completo").val(),
        $("#txtEspecialidad").val(),
        $("#txtTelefono").val(),
        $("#txtCorreo_Electronico").val());
       

    //Invoca el comando para ejecutar
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, garantia);
    LlenarTablaEmpleados();
}
/*async function Consultar() {
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
*/


