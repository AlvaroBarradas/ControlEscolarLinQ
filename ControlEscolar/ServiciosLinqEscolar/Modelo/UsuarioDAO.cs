using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public static class UsuarioDAO
    {
        public static List<usuario> obtenerUsuarios()
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            //var usuarios = ;
            IQueryable<usuario> usuariosBD = from usuarioQuery /*<--- se puede llamar como yo quiera*/ in conexionBD.usuario select usuarioQuery;
            return usuariosBD.ToList();
        }

        public static Mensaje iniciarSesion(string username, string password)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            Mensaje respuesta = new Mensaje();
            respuesta.Error = true;
            try
            {
                var usuario = conexionBD.usuario.FirstOrDefault(u => u.username.Equals(username)
                                        && u.password.Equals(password));
                                        //(from userLogin in conexionBD.usuario
                                        // where userLogin.username == username &&
                                        // userLogin.password == password
                                        // select userLogin).FirstOrDefault();
                respuesta.usuarioRegistrado = usuario;
                if (usuario != null)
                {
                    respuesta.respuesta = "Bienvenido al sistema";
                    respuesta.usuarioRegistrado = usuario;
                    respuesta.Error = false;
                }
                else
                {
                    respuesta.respuesta = "Error en el inicio de sesion, compruebe las credenciales";
                }

                
            }
            catch (Exception ex)
            {
                respuesta.respuesta = "Error en la conexion";
                throw new Exception("Error al obtener el usuario");
            }
            return respuesta;
        }

        public static Boolean guardarUsuario(usuario UsuarioNuevo)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var usuario = new usuario()
                {
                    nombre = UsuarioNuevo.nombre,
                    apellidoPaterno = UsuarioNuevo.apellidoPaterno,
                    apellidoMaterno = UsuarioNuevo.apellidoMaterno,
                    username = UsuarioNuevo.username,
                    password = UsuarioNuevo.password
                };
                conexionBD.usuario.InsertOnSubmit(usuario);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean editarUsuario(usuario UsuarioEdicion)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();

                var usuario = (from usuarioEdicion in conexionBD.usuario
                               where usuarioEdicion.idUsuario == UsuarioEdicion.idUsuario
                               select usuarioEdicion).FirstOrDefault();

                if (usuario != null)
                {
                    usuario.nombre = UsuarioEdicion.nombre;
                    usuario.apellidoPaterno = UsuarioEdicion.apellidoPaterno;
                    usuario.apellidoMaterno = UsuarioEdicion.apellidoMaterno;
                    usuario.password = UsuarioEdicion.password;
                    conexionBD.SubmitChanges();
                    return true; 
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public static Boolean eliminarUsuario(int idUsuario)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                usuario UsuarioEliminar = conexionBD.usuario.FirstOrDefault
                    (usuario => usuario.idUsuario == idUsuario);
                if (UsuarioEliminar != null)
                {
                    conexionBD.usuario.DeleteOnSubmit(UsuarioEliminar);
                    conexionBD.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["ConexionBDEscolarUV"].ConnectionString);
        }
    }
}