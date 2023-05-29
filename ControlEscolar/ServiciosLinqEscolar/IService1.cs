using ServiciosLinqEscolar.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosLinqEscolar
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<usuario> obtenerUsuarios();

        [OperationContract]
        Boolean guardarUsuario(usuario UsuarioNuevo);
        
        [OperationContract]
        Mensaje iniciarSesion(string username, string password);

        [OperationContract]
        Boolean editarUsuario(usuario UsuarioEdicion);

        [OperationContract]
        Boolean eliminarUsuario(int idUsuario);


        // TODO: agregue aquí sus operaciones de servicio
    }
}
