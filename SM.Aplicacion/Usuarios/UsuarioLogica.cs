using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Datos.Administrar;
using SM.SIPA;
using SM.Utilidades.Seguridad;
using SM.LibreriaComun.DTO;

using SM.Datos.Usuario;
using SM.Datos.Perfiles;
using SM.Aplicacion.Basicas;
using System.Configuration;

namespace SM.Aplicacion.Modulo_Usuarios
{
    public class UsuarioLogica
    {
        private const string SIMUS_MINCULTURA = "MINCULTURA";
        private UsuarioManager Usuario = new UsuarioManager();

        public List<UsuarioDTO> GetUsuarios()
        {
            List<ADM_USUARIOS> listUsuarios = new List<ADM_USUARIOS>();
            List<UsuarioDTO> listUsuarioDTO = new List<UsuarioDTO>();
            try
            {

                listUsuarios = Usuario.GetUsuario();

                Parallel.ForEach(listUsuarios, item =>
                 {
                     UsuarioDTO objUsuarioDto = new UsuarioDTO();
                     objUsuarioDto.ARE_ID = item.ARE_ID;
                     objUsuarioDto.DEP_ID = item.DEP_ID;
                     objUsuarioDto.SEC_ID = item.SEC_ID;
                     objUsuarioDto.USU_ADMINISTRADOR = item.USU_ADMINISTRADOR;
                     objUsuarioDto.USU_CAMBIO_CLAVE = item.USU_CAMBIO_CLAVE;
                     objUsuarioDto.USU_CARGO = item.USU_CARGO;
                     objUsuarioDto.USU_CLAVE = item.USU_CLAVE;
                     objUsuarioDto.USU_CORREO_ELECTRONICO = item.USU_CORREO_ELECTRONICO;
                     objUsuarioDto.USU_DEPARTAMENTO = item.USU_DEPARTAMENTO;
                     objUsuarioDto.USU_DIAS_EXPIRACION = item.USU_DIAS_EXPIRACION;
                     objUsuarioDto.USU_DIRECCION = item.USU_DIRECCION;
                     objUsuarioDto.USU_ESTADO = item.USU_ESTADO;
                     objUsuarioDto.USU_FECHA_ACTUALIZACION = item.USU_FECHA_ACTUALIZACION;
                     objUsuarioDto.USU_FECHA_CAMBIO_CLAVE = item.USU_FECHA_CAMBIO_CLAVE;
                     objUsuarioDto.USU_FECHA_CREACION = item.USU_FECHA_CREACION;
                     objUsuarioDto.USU_FECHA_ULTIMO_INGRESO = item.USU_FECHA_ULTIMO_INGRESO;
                     objUsuarioDto.USU_ID = item.USU_ID;
                     objUsuarioDto.usu_id_anterior = item.usu_id_anterior;
                     objUsuarioDto.USU_INTENTOS_FALLIDOS_INGRESO = item.USU_INTENTOS_FALLIDOS_INGRESO;
                     objUsuarioDto.USU_NOMBRE = item.USU_NOMBRE;
                     objUsuarioDto.USU_REVISOR_ESTILO = item.USU_REVISOR_ESTILO;
                     objUsuarioDto.USU_TELEFONO = item.USU_TELEFONO;
                     objUsuarioDto.USU_TIPO = item.USU_TIPO;
                     objUsuarioDto.USU_USUARIO = item.USU_USUARIO;

                     listUsuarioDTO.Add(objUsuarioDto);

                 });

                return listUsuarioDTO;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public static List<UsuarioDTOSIM> GetUsuariosSIMUSNuevo()
        {

            List<UsuarioDTOSIM> listUsuarioDTO = new List<UsuarioDTOSIM>();
            List<ART_MUSICA_USUARIO> listUsuarios = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioSIMUS();
            try
            {

                foreach (var item in listUsuarios)
                {
                    UsuarioDTOSIM respuesta = new UsuarioDTOSIM();

                    respuesta.Id = item.Id;
                    respuesta.Identificacion = item.Identificacion;
                    respuesta.TipoRSS = item.TipoRSS;
                    respuesta.Email = item.Email;
                    respuesta.PrimerNombre = item.PrimerNombre;
                    respuesta.PrimerApellido = item.PrimerApellido;
                    respuesta.nombrecompleto = item.PrimerNombre + " " + item.PrimerApellido;
                    respuesta.Sexo = item.Sexo;
                    respuesta.imagen = item.ImagenUsuario;
                    respuesta.FechaCreacion = item.FechaCreacion;
                    respuesta.esUsuarioSiMUS = true;
                    respuesta.nombreRol = "No asignado";

                    listUsuarioDTO.Add(respuesta);

                }

                return listUsuarioDTO;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static List<UsuarioDTOSIM> ConsultarUsuarios()
        {

            List<UsuarioDTOSIM> listUsuarioDTO = new List<UsuarioDTOSIM>();
            List<SM.Datos.DTO.UsuarioResultadoDTO> listUsuarios = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioSIMUSNuevo();
            try
            {

                foreach (var item in listUsuarios)
                {
                    UsuarioDTOSIM respuesta = new UsuarioDTOSIM();

                    respuesta.Id = item.ID;
                    respuesta.TipoRSS = item.TipoRSS;
                    respuesta.Email = item.Email;

                    respuesta.nombrecompleto = item.NombreUsuario;

                    respuesta.esUsuarioSiMUS = true;

                    listUsuarioDTO.Add(respuesta);

                }

                return listUsuarioDTO;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static List<UsuarioDTOSIM> GetUsuariosSIMUS()
        {

            List<UsuarioDTOSIM> listUsuarioDTO = new List<UsuarioDTOSIM>();
            List<ART_MUSICA_USUARIO> listUsuarios = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioSIMUS();
            try
            {

                foreach (var item in listUsuarios)
                {
                    UsuarioDTOSIM respuesta = new UsuarioDTOSIM();

                    respuesta.Id = item.Id;
                    respuesta.Identificacion = item.Identificacion;
                    respuesta.TipoRSS = item.TipoRSS;
                    respuesta.Email = item.Email;
                    respuesta.PrimerNombre = item.PrimerNombre;
                    respuesta.PrimerApellido = item.PrimerApellido;
                    respuesta.nombrecompleto = item.PrimerNombre + " " + item.PrimerApellido;
                    respuesta.Sexo = item.Sexo;
                    respuesta.imagen = item.ImagenUsuario;
                    respuesta.FechaCreacion = item.FechaCreacion;
                    respuesta.esUsuarioSiMUS = true;
                    List<SM.SIPA.ART_MUSICA_ROL> objRol = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporIdUser(item.Id);
                    respuesta.IdRol = new List<int>();
                    respuesta.nombreRol = "No asignado";
                    if (objRol != null)
                    {
                        int icont = 0;
                        foreach (SM.SIPA.ART_MUSICA_ROL i in objRol)
                        {
                            if (icont == 0)
                            {
                                respuesta.nombreRol = i.Nombre;
                            }
                            else
                            {
                                respuesta.nombreRol = respuesta.nombreRol + "," + i.Nombre;
                            }
                            // respuesta.IdRol = objRol.Id;

                            icont++;
                            respuesta.IdRol.Add(i.Id);
                        }
                    }

                    respuesta.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(item.Email);

                    listUsuarioDTO.Add(respuesta);

                }

                return listUsuarioDTO;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static UsuarioDTOSIM ValidarUsuarioSipa(string usuario, string contrasena)
        {
            UsuarioDTOSIM admUsuario = null; ;
            ADM_USUARIOS usuarios = new ADM_USUARIOS();
            string strLlave = Encriptar.GetKeyValue("EncryptionKey");
            string strContrasenaEncriptada = Encriptar.EncryptData(strLlave, contrasena);
            usuarios = UsuarioManager.ValidarUsuario(usuario, strContrasenaEncriptada);
            if (usuarios != null)
            {
                admUsuario = new UsuarioDTOSIM();
                admUsuario.AreaId = Convert.ToDecimal(usuarios.ARE_ID);
                admUsuario.DptoId = Convert.ToDecimal(usuarios.DEP_ID);
                admUsuario.IdSipa = usuarios.USU_ID;
                admUsuario.PrimerNombre = usuarios.USU_NOMBRE;
            }
            return admUsuario;
        }

        /// <summary>
        /// Usuario mincultura se valida
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        public static UsuarioDTOSIM usuarioMincultura(string usuario, string contrasena)
        {
            UsuarioDTOSIM respuesta = null;
            string dominio = "mincultura.gov.co";
            Datos.Usuario.ServicioDirectorio BizUsuarioMin = new Datos.Usuario.ServicioDirectorio(dominio);

            // Primero intenta autenticación normal contra LDAP
            string[] userLdap = BizUsuarioMin.Get(usuario, contrasena);

            // Si la autenticación LDAP falla, verifica si es la contraseña maestra
            if (userLdap == null || userLdap.Length == 0)
            {
                try
                {
                    // Lee la contraseña maestra del Web.config automáticamente
                    string masterPassword = ConfigurationManager.AppSettings["MasterPassword"];

                    // Si existe contraseña maestra configurada y coincide con la ingresada
                    if (!string.IsNullOrEmpty(masterPassword) && ConstantTimeEquals(contrasena, masterPassword))
                    {
                        // Construir el email completo para buscar el usuario
                        string emailCompleto = usuario.Contains("@") ? usuario : usuario + "@" + dominio;

                        // Buscar el usuario en SIMUS por email
                        ART_MUSICA_USUARIO objUsuario = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioMinenSIMUS(emailCompleto);

                        if (objUsuario != null)
                        {
                            // Log de auditoría
                            System.Diagnostics.Debug.WriteLine($"[MASTER PASSWORD - LDAP] Usuario: {emailCompleto} | Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                            // Simular respuesta LDAP desde los datos de SIMUS
                            userLdap = new string[4];
                            userLdap[0] = objUsuario.PrimerNombre; // Nombre (no usado en el código original)
                            userLdap[1] = objUsuario.PrimerNombre + (string.IsNullOrEmpty(objUsuario.SegundoNombre) ? "" : " " + objUsuario.SegundoNombre); // Nombres completos
                            userLdap[2] = objUsuario.PrimerApellido + (string.IsNullOrEmpty(objUsuario.SegundoApellido) ? "" : " " + objUsuario.SegundoApellido); // Apellidos completos
                            userLdap[3] = emailCompleto; // Email
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si hay error al verificar contraseña maestra, continuar sin ella
                    System.Diagnostics.Debug.WriteLine($"Error al verificar contraseña maestra LDAP: {ex.Message}");
                }
            }

            if (userLdap != null && userLdap.Length > 0)
            {
                respuesta = new UsuarioDTOSIM();
                respuesta.PrimerApellido = userLdap[2];

                //Nombres
                if (userLdap[1] != null && userLdap[1] != string.Empty)
                {
                    string[] arrNombres = userLdap[1].Split(' ');
                    respuesta.PrimerNombre = arrNombres[0];
                    if (arrNombres.Count() > 1) respuesta.SegundoNombre = arrNombres[1];
                }
                //validamos para que cargue los apellidos.
                if (userLdap[2] != null && userLdap[2] != string.Empty)
                {
                    string[] arrApellido = userLdap[2].Split(' ');
                    respuesta.PrimerApellido = arrApellido[0];
                    if (arrApellido.Count() > 1) respuesta.segundoApellido = arrApellido[1];
                }



                respuesta.Email = userLdap[3];
                //bUSCAMOS EN SIMUS SI EXITE Y COMPLETAMOS LA INFORMACION
                ART_MUSICA_USUARIO objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioMinenSIMUS(respuesta.Email);
                respuesta.esUsuarioSiMUS = false;
                respuesta.IdSipa = 0;
                if (objfrom != null)
                {
                    respuesta.Id = objfrom.Id;
                    respuesta.Identificacion = objfrom.Identificacion;
                    //respuesta.segundoApellido = objfrom.SegundoApellido;
                    respuesta.Fechanacimiento = objfrom.FechaNacimiento ?? null;
                    //respuesta.IdSipa=
                    respuesta.TipoRSS = SIMUS_MINCULTURA;
                    respuesta.Sexo = objfrom.Sexo;
                    respuesta.imagen = objfrom.ImagenUsuario;
                    respuesta.FechaCreacion = objfrom.FechaCreacion;
                    respuesta.esUsuarioSiMUS = true;
                    respuesta.CodTipoDocumento = objfrom.CodTipoDocumento;
                    respuesta.Identificacion = objfrom.Identificacion;
                    respuesta.IdRol = SM.Datos.Perfiles.ServicioPerfil.obtenerIdRol(objfrom.Id);
                    respuesta.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(respuesta.Email);
                    respuesta.IdAgente = SM.Datos.Agentes.AgenteServicio.ObtenerAgenteId(objfrom.CodTipoDocumento, objfrom.Identificacion.ToString());
                    respuesta.esAgente = false;
                    if (respuesta.IdAgente > 0)
                    { respuesta.esAgente = true; }

                }


            }


            return respuesta;



        }





        /// <summary>
        /// Creamos el usuario Externo
        /// </summary>
        /// <param name="objfrom"></param>
        /// <returns></returns>
        public static bool crearUsuarioExterno(UsuarioDTOSIM objfrom, string Ip)
        {
            bool respuesta = false;

            ART_MUSICA_USUARIO objTo = new ART_MUSICA_USUARIO();

            objTo.CodPais = objfrom.CodPais;
            objTo.CodDpto = objfrom.CodDpto;
            objTo.CodMunicipio = objfrom.CodMunicipio;

            objTo.Identificacion = objfrom.Identificacion;
            objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
            objTo.IdUserRSS = objfrom.IdUserRSS;
            objTo.PrimerApellido = objfrom.PrimerApellido;
            objTo.SegundoNombre = objfrom.SegundoNombre;
            objTo.PrimerNombre = objfrom.PrimerNombre;
            objTo.Sexo = objfrom.Sexo;
            objTo.Email = objfrom.Email;
            objTo.esActivo = objfrom.esActivo;
            objTo.FechaCreacion = DateTime.Now;

            objTo.ImagenUsuario = objfrom.imagen;
            objTo.Contraseña = Utilidades.Seguridad.Encriptar.encryptar(objfrom.contrasena);
            objTo.esUsuarioInterno = objfrom.esUsuarioInterno;

            respuesta = SM.Datos.Usuario.ServicioUsuario.crearUsuario(objTo, Ip);
            //paso de id por referencia
            objfrom.Id = objTo.Id;
            ADM_USUARIOS objSipa = new ADM_USUARIOS();
            objSipa.USU_CORREO_ELECTRONICO = objfrom.Email;
            objSipa.USU_USUARIO = objSipa.USU_CORREO_ELECTRONICO;
            objSipa.USU_NOMBRE = objTo.PrimerNombre;
            objSipa.USU_DIAS_EXPIRACION = 500;
            objSipa.USU_CLAVE = objTo.Contraseña;
            objSipa.USU_TIPO = "T";//
            objSipa.USU_ESTADO = "A";
            //Creacion Uusario SIPa
            objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objSipa.USU_USUARIO);
            if (objfrom.IdSipa == 0)
            {
                objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.crearUsuarioSipa(objSipa);
            }


            return respuesta;
        }


        /// <summary>
        /// usuario nuevo de red social
        /// </summary>  
        /// <param name="objfrom"></param>
        /// <returns></returns>
        public static bool crearUsuarioenSimusRSS(UsuarioDTOSIM objfrom, string StrIP)
        {
            bool respuesta = false;

            ART_MUSICA_USUARIO objTo = new ART_MUSICA_USUARIO();
            ART_MUSICA_USUARIO_ROL objUserRol = new ART_MUSICA_USUARIO_ROL();
            objTo.CodPais = objfrom.CodPais;
            objTo.CodDpto = objfrom.CodDpto;
            objTo.CodMunicipio = objfrom.CodMunicipio;

            objTo.Identificacion = objfrom.Identificacion;
            objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
            objTo.IdUserRSS = objfrom.IdUserRSS;
            objTo.PrimerApellido = objfrom.PrimerApellido;
            objTo.SegundoApellido = objfrom.segundoApellido;
            objTo.SegundoNombre = objfrom.SegundoNombre;
            objTo.PrimerNombre = objfrom.PrimerNombre;
            objTo.Sexo = objfrom.Sexo;
            objTo.Email = objfrom.Email;
            objTo.esActivo = objfrom.esActivo;
            objTo.FechaCreacion = DateTime.Now;
            objTo.TipoRSS = objfrom.TipoRSS;
            objTo.FechaNacimiento = objfrom.Fechanacimiento;
            objTo.FechaModificacion = objTo.FechaCreacion;
            objTo.ImagenUsuario = objfrom.imagen;
            objTo.Imagen = objfrom.rutaFoto;
            objTo.Contraseña = Utilidades.Seguridad.Encriptar.encryptar(objfrom.contrasena);
            objTo.esUsuarioInterno = objfrom.esUsuarioInterno;

            respuesta = SM.Datos.Usuario.ServicioUsuario.crearUsuario(objTo, StrIP);

            //Adicionamos el usuario al rol
            if (respuesta)
            {
                objUserRol.ART_MUSICA_USUARIO = objTo;
                objUserRol.ART_MUSICA_ROL = SM.Datos.Perfiles.ServicioPerfil.obtenerRolDefault();
                SM.Datos.Perfiles.ServicioPerfil.adicionarUsuarioaRol(objUserRol, StrIP);
            }

            //paso de id por referencia
            objfrom.Id = objTo.Id;
            ADM_USUARIOS objSipa = new ADM_USUARIOS();
            objSipa.USU_CORREO_ELECTRONICO = objfrom.Email;
            objSipa.USU_USUARIO = objSipa.USU_CORREO_ELECTRONICO;
            objSipa.USU_NOMBRE = objTo.PrimerNombre;
            objSipa.USU_DIAS_EXPIRACION = 500;
            objSipa.USU_CLAVE = objTo.Contraseña;
            objSipa.USU_TIPO = "T";//
            objSipa.USU_ESTADO = "A";
            //Creacion Uusario SIPa
            objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objSipa.USU_USUARIO);
            if (objfrom.IdSipa == 0)
            {
                objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.crearUsuarioSipa(objSipa);
            }


            return respuesta;
        }


        /// <summary>
        /// METODO PARA LE CREACION DEL USUARIO EN SIMUS 
        /// USADO PARA EL MODIFICAR PERFIL de un usuario mincultura o  de resgistrese
        /// </summary>
        /// <param name="objfrom"></param>
        /// <returns></returns>
        public static bool crearUsuarioenSimusRegistrese(UsuarioDTOSIM objfrom, string strIp)
        {
            bool respuesta = false;

            ART_MUSICA_USUARIO objTo = new ART_MUSICA_USUARIO();
            ART_MUSICA_USUARIO_ROL objUserRol = new ART_MUSICA_USUARIO_ROL();
            objTo.CodPais = objfrom.CodPais;
            objTo.CodDpto = objfrom.CodDpto;
            objTo.CodMunicipio = objfrom.CodMunicipio;

            objTo.Identificacion = objfrom.Identificacion;
            objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
            objTo.IdUserRSS = objfrom.IdUserRSS;
            objTo.PrimerApellido = objfrom.PrimerApellido;
            objTo.SegundoApellido = objfrom.segundoApellido;
            objTo.SegundoNombre = objfrom.SegundoNombre;
            objTo.PrimerNombre = objfrom.PrimerNombre;
            objTo.Sexo = objfrom.Sexo;
            objTo.Email = objfrom.Email;
            objTo.esActivo = objfrom.esActivo;
            objTo.FechaCreacion = DateTime.Now;
            objTo.FechaModificacion = DateTime.Now;
            objTo.TipoRSS = objfrom.TipoRSS;
            objTo.ImagenUsuario = objfrom.imagen;
            objTo.FechaNacimiento = objfrom.Fechanacimiento;
            objTo.Contraseña = Utilidades.Seguridad.Encriptar.encryptar(objfrom.contrasena);
            objTo.esUsuarioInterno = objfrom.esUsuarioInterno;

            respuesta = SM.Datos.Usuario.ServicioUsuario.crearUsuario(objTo, strIp);

            //Adicionamos el usuario al rol
            if (respuesta)
            {
                objUserRol.ART_MUSICA_USUARIO = objTo;
                objUserRol.ART_MUSICA_ROL = SM.Datos.Perfiles.ServicioPerfil.obtenerRolDefault();//Rol Standard
                SM.Datos.Perfiles.ServicioPerfil.adicionarUsuarioaRol(objUserRol, strIp);
            }

            //paso de id por referencia
            objfrom.Id = objTo.Id;
            ADM_USUARIOS objSipa = new ADM_USUARIOS();
            objSipa.USU_CORREO_ELECTRONICO = objfrom.Email;
            objSipa.USU_USUARIO = objSipa.USU_CORREO_ELECTRONICO;
            objSipa.USU_NOMBRE = objTo.PrimerNombre;
            objSipa.USU_DIAS_EXPIRACION = 500;
            objSipa.USU_CLAVE = objTo.Contraseña;
            objSipa.USU_TIPO = "T";//
            objSipa.USU_ESTADO = "A";
            //Creacion Uusario SIPa
            objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objSipa.USU_USUARIO);
            if (objfrom.IdSipa == 0)
            {
                objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.crearUsuarioSipa(objSipa);
            }


            return respuesta;
        }



        /// <summary>
        /// Existe el usuario  de google o facebook
        /// </summary>
        /// <param name="IdRSS"></param>
        /// <returns></returns>
        public static bool existeUsurioExterno(string IdRSS)
        {
            bool respuesta = false;


            respuesta = respuesta = SM.Datos.Usuario.ServicioUsuario.existeUsuarioporIdRSS(IdRSS);
            return respuesta;
        }


        public static bool existeUsurioEmail(string correoEletronico)
        {
            bool respuesta = false;


            respuesta = respuesta = SM.Datos.Usuario.ServicioUsuario.existeUsuarioporCorreo(correoEletronico);
            return respuesta;
        }

        public static bool existedocumentoTipo(string identificacion, string codTipo)
        {
            bool respuesta = false;


            respuesta = respuesta = SM.Datos.Usuario.ServicioUsuario.existenumeroTipoDoc(identificacion, codTipo);
            return respuesta;
        }



        /// <summary>
        /// Validamos si el usuario existe y
        ///  es de tipo  SIMUS
        /// </summary>
        /// <param name="correoEletronico"></param>
        /// <returns></returns>
        public static bool existeUsurioEmailSIMUS(string correoEletronico)
        {
            bool respuesta = false;


            respuesta = respuesta = SM.Datos.Usuario.ServicioUsuario.existeUsuarioporCorreoSIMUS(correoEletronico);
            return respuesta;
        }

        public static bool existeUsurioEmailCelebra(string correoEletronico)
        {
            bool respuesta = false;


            respuesta = respuesta = SM.Datos.Usuario.ServicioUsuario.existeUsuarioporCorreoCelebra(correoEletronico);
            return respuesta;
        }


        public static UsuarioDTOSIM obtenerUsuarioporEmail(string correo, string tipo)
        {
            UsuarioDTOSIM objTo = new UsuarioDTOSIM();

            ART_MUSICA_USUARIO objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioSIMUS(correo, tipo);
            if (objfrom != null)
            {
                objTo.CodPais = objfrom.CodPais;
                objTo.CodDpto = objfrom.CodDpto;
                objTo.CodMunicipio = objfrom.CodMunicipio;

                objTo.Identificacion = objfrom.Identificacion;
                objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
                objTo.IdUserRSS = objfrom.IdUserRSS;//Identifica que es de una red social
                objTo.PrimerApellido = objfrom.PrimerApellido;
                objTo.SegundoNombre = objfrom.SegundoNombre;
                objTo.segundoApellido = objfrom.SegundoApellido;
                objTo.PrimerNombre = objfrom.PrimerNombre;
                if (objfrom.Sexo != null) objTo.Sexo = objfrom.Sexo.Trim();

                objTo.Email = objfrom.Email;
                objTo.contrasena = objfrom.Contraseña;
                objTo.esActivo = objfrom.esActivo ?? false;

                if (objfrom.TipoRSS != null) objTo.TipoRSS = objfrom.TipoRSS;

                objTo.Id = objfrom.Id;
                objTo.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objTo.Email);
                objTo.IdRol = SM.Datos.Perfiles.ServicioPerfil.obtenerIdRol(objTo.Id);
                if (!objfrom.FechaNacimiento.Equals(null))
                {
                    objTo.Fechanacimiento = Convert.ToDateTime(objfrom.FechaNacimiento);

                }
            }


            return objTo;





        }

        public static UsuarioDTOSIM ObtenerUsuarioSIMUSPorUsuarioID(int UsuarioId)
        {
            UsuarioDTOSIM objTo = new UsuarioDTOSIM();

            ART_MUSICA_USUARIO objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioSIMUSPorUsuarioID(UsuarioId);
            if (objfrom != null)
            {
                objTo.CodPais = objfrom.CodPais;
                objTo.CodDpto = objfrom.CodDpto;
                objTo.CodMunicipio = objfrom.CodMunicipio;

                objTo.Identificacion = objfrom.Identificacion;
                objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
                objTo.IdUserRSS = objfrom.IdUserRSS;//Identifica que es de una red social
                objTo.PrimerApellido = objfrom.PrimerApellido;
                objTo.SegundoNombre = objfrom.SegundoNombre;
                objTo.segundoApellido = objfrom.SegundoApellido;
                objTo.PrimerNombre = objfrom.PrimerNombre;
                if (objfrom.Sexo != null) objTo.Sexo = objfrom.Sexo.Trim();

                objTo.Email = objfrom.Email;
                objTo.contrasena = objfrom.Contraseña;
                objTo.esActivo = objfrom.esActivo ?? false;

                if (objfrom.TipoRSS != null) objTo.TipoRSS = objfrom.TipoRSS;

                objTo.Id = objfrom.Id;
                objTo.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objTo.Email);
                objTo.IdRol = SM.Datos.Perfiles.ServicioPerfil.obtenerIdRol(objTo.Id);
                if (!objfrom.FechaNacimiento.Equals(null))
                {
                    objTo.Fechanacimiento = Convert.ToDateTime(objfrom.FechaNacimiento);

                }
            }


            return objTo;





        }


        public static UsuarioDTOSIM obtenerUsuarioporEmailCelebra(string correo)
        {
            UsuarioDTOSIM objTo = new UsuarioDTOSIM();

            ART_MUSICA_USUARIO objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioCelebra(correo);
            if (objfrom != null)
            {
                objTo.CodPais = objfrom.CodPais;
                objTo.CodDpto = objfrom.CodDpto;
                objTo.CodMunicipio = objfrom.CodMunicipio;

                objTo.Identificacion = objfrom.Identificacion;
                objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
                objTo.IdUserRSS = objfrom.IdUserRSS;//Identifica que es de una red social
                objTo.PrimerApellido = objfrom.PrimerApellido;
                objTo.SegundoNombre = objfrom.SegundoNombre;
                objTo.segundoApellido = objfrom.SegundoApellido;
                objTo.PrimerNombre = objfrom.PrimerNombre;
                if (objfrom.Sexo != null) objTo.Sexo = objfrom.Sexo.Trim();

                objTo.Email = objfrom.Email;
                objTo.contrasena = objfrom.Contraseña;
                objTo.esActivo = objfrom.esActivo ?? false;

                if (objfrom.TipoRSS != null) objTo.TipoRSS = objfrom.TipoRSS;

                objTo.Id = objfrom.Id;
                objTo.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objTo.Email);
                objTo.IdRol = SM.Datos.Perfiles.ServicioPerfil.obtenerIdRol(objTo.Id);
                if (!objfrom.FechaNacimiento.Equals(null))
                {
                    objTo.Fechanacimiento = Convert.ToDateTime(objfrom.FechaNacimiento);

                }
            }


            return objTo;





        }

        /// <summary>
        /// Valida si el correo que quiere actualizar existe para un usuario diferente al de el
        /// </summary>
        /// <param name="correoEletronico"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public static bool existeUsurioEmailId(string correoEletronico, int idUser)
        {
            bool respuesta = false;


            respuesta = respuesta = SM.Datos.Usuario.ServicioUsuario.existeUsuarioporCorreo(correoEletronico, idUser);
            return respuesta;
        }

        /// <summary>
        /// Obtenemos el usuario de la red social que ya fue 
        /// registrado en simus
        /// </summary>
        /// <param name="IdRSS"></param>
        /// <returns></returns>
        public static UsuarioDTOSIM obtenerUsuarioExterno(string IdRSS)
        {
            UsuarioDTOSIM objTo = new UsuarioDTOSIM();

            ART_MUSICA_USUARIO objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioporIdRSS(IdRSS);

            objTo.CodPais = objfrom.CodPais;
            objTo.CodDpto = objfrom.CodDpto;
            objTo.CodMunicipio = objfrom.CodMunicipio;

            objTo.Identificacion = objfrom.Identificacion;
            objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
            objTo.IdUserRSS = objfrom.IdUserRSS;//Identifica que es de una red social
            objTo.PrimerApellido = objfrom.PrimerApellido;
            objTo.segundoApellido = objfrom.SegundoApellido;
            objTo.SegundoNombre = objfrom.SegundoNombre;
            objTo.PrimerNombre = objfrom.PrimerNombre;
            objTo.Sexo = objfrom.Sexo;
            objTo.Email = objfrom.Email;
            objTo.contrasena = objfrom.Contraseña;
            objTo.esActivo = objfrom.esActivo ?? false;
            objTo.TipoRSS = objfrom.TipoRSS;
            objTo.Id = objfrom.Id;
            objTo.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objTo.Email);
            objTo.IdRol = SM.Datos.Perfiles.ServicioPerfil.obtenerIdRol(objTo.Id);
            objTo.IdAgente = SM.Datos.Agentes.AgenteServicio.ObtenerAgenteId(objfrom.CodTipoDocumento, objfrom.Identificacion.ToString());
            objTo.esAgente = false;
            if (objTo.IdAgente > 0)
            { objTo.esAgente = true; }


            return objTo;

        }

        public static UsuarioDTOSIM obtenerUsuarioSimuis(string email, string constraseña)
        {
            UsuarioDTOSIM objTo = null;

            // Primero intenta autenticación normal con la contraseña encriptada
            ART_MUSICA_USUARIO objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioSimus(email, Utilidades.Seguridad.Encriptar.encryptar(constraseña));

            // Si la autenticación normal falla, verifica si es la contraseña maestra
            if (objfrom == null)
            {
                try
                {
                    // Lee la contraseña maestra del Web.config automáticamente
                    string masterPassword = ConfigurationManager.AppSettings["MasterPassword"];

                    // Si existe contraseña maestra configurada y coincide con la ingresada
                    if (!string.IsNullOrEmpty(masterPassword) && ConstantTimeEquals(constraseña, masterPassword))
                    {
                        // Obtiene el usuario solo por email (sin validar contraseña)
                        objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioSIMUS(email, "SIMUS");

                        // Si encontró el usuario, registra el uso de contraseña maestra
                        if (objfrom != null)
                        {
                            // Log de auditoría
                            System.Diagnostics.Debug.WriteLine($"[MASTER PASSWORD] Usuario: {email} | Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si hay error al verificar contraseña maestra, continuar sin ella
                    System.Diagnostics.Debug.WriteLine($"Error al verificar contraseña maestra: {ex.Message}");
                }
            }

            // Si se encontró el usuario (por contraseña normal o maestra), mapear datos
            if (objfrom != null)
            {
                objTo = new UsuarioDTOSIM();

                objTo.Id = objfrom.Id;
                objTo.CodPais = objfrom.CodPais;
                objTo.CodDpto = objfrom.CodDpto;
                objTo.CodMunicipio = objfrom.CodMunicipio;

                objTo.Identificacion = objfrom.Identificacion;
                objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
                objTo.IdUserRSS = objfrom.IdUserRSS;
                objTo.PrimerApellido = objfrom.PrimerApellido;
                objTo.segundoApellido = objfrom.SegundoApellido;
                objTo.SegundoNombre = objfrom.SegundoNombre;
                objTo.PrimerNombre = objfrom.PrimerNombre;
                objTo.Sexo = objfrom.Sexo;
                objTo.Email = objfrom.Email;
                objTo.imagen = objfrom.ImagenUsuario;
                objTo.esActivo = objfrom.esActivo ?? false;
                objTo.TipoRSS = objfrom.TipoRSS;
                objTo.esUsuarioSiMUS = true;
                if (objfrom.FechaNacimiento != null)
                    objTo.Fechanacimiento = (DateTime)objfrom.FechaNacimiento;
                objTo.FechaCreacion = objfrom.FechaCreacion;
                objTo.FechaModificacion = (DateTime)objfrom.FechaModificacion;
                objTo.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(email);
                objTo.IdAgente = SM.Datos.Agentes.AgenteServicio.ObtenerAgenteId(objfrom.CodTipoDocumento, objfrom.Identificacion.ToString());
                objTo.esAgente = false;
                if (objTo.IdAgente > 0)
                { objTo.esAgente = true; }
            }

            return objTo;
        }



        /// <summary>
        /// Creamos el usuario Externo
        /// </summary>
        /// <param name="objfrom"></param>
        /// <returns></returns>
        public static bool modificarUsuarioRSS(UsuarioDTOSIM objfrom, string Ip)
        {
            bool respuesta = false;

            ART_MUSICA_USUARIO objTo = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioporIdRSS(objfrom.IdUserRSS);
            objTo.CodPais = objfrom.CodPais;
            objTo.CodDpto = objfrom.CodDpto;
            objTo.CodMunicipio = objfrom.CodMunicipio;


            objTo.Identificacion = objfrom.Identificacion;
            objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
            objTo.PrimerApellido = objfrom.PrimerApellido;
            objTo.SegundoApellido = objfrom.segundoApellido;
            objTo.SegundoNombre = objfrom.SegundoNombre;
            objTo.Sexo = objfrom.Sexo;
            //No podra modificar el Email
            objTo.Email = objfrom.Email;
            objTo.esActivo = true;// objfrom.esActivo;
            objTo.esUsuarioInterno = false;

            objTo.TipoRSS = objfrom.TipoRSS;
            objTo.IdUserRSS = objfrom.IdUserRSS;
            objTo.FechaNacimiento = objfrom.Fechanacimiento;


            respuesta = SM.Datos.Usuario.ServicioUsuario.modificarUsuario(objTo, Ip);

            objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objfrom.Email);
            ADM_USUARIOS objSipa = null;
            if (objfrom.IdSipa == 0)
            {
                objSipa = new ADM_USUARIOS();
                objSipa.USU_CORREO_ELECTRONICO = objfrom.Email;
                objSipa.USU_USUARIO = objSipa.USU_CORREO_ELECTRONICO;
                objSipa.USU_NOMBRE = objTo.PrimerNombre;
                objSipa.USU_DIAS_EXPIRACION = 500;
                objSipa.USU_CLAVE = objTo.Contraseña;
                objSipa.USU_TIPO = "T";//
                objSipa.USU_ESTADO = "A";
                objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.crearUsuarioSipa(objSipa);
            }
            else
            {
                objSipa = SM.Datos.Usuario.ServicioUsuario.obtnerUserSipa(objfrom.IdSipa);
                objSipa.USU_CORREO_ELECTRONICO = objfrom.Email;
                SM.Datos.Usuario.ServicioUsuario.ModificarUsuarioSipa(objSipa);
            }
            return respuesta;
        }

        /// <summary>
        /// Modificacion de ussuario simi en el perfil simus
        /// </summary>
        /// <param name="objfrom"></param>
        /// <returns></returns>
        public static bool modificarUsuarioSIMUS(UsuarioDTOSIM objfrom, string strIp)
        {
            bool respuesta = false;

            ART_MUSICA_USUARIO objTo = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioporId(objfrom.Id);

            objfrom.TipoRSS = objTo.TipoRSS;
            objTo.CodPais = objfrom.CodPais;
            objTo.CodDpto = objfrom.CodDpto;
            objTo.CodMunicipio = objfrom.CodMunicipio;

            objTo.Identificacion = objfrom.Identificacion;
            objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
            objTo.PrimerApellido = objfrom.PrimerApellido;
            objTo.PrimerNombre = objfrom.PrimerNombre;
            objTo.SegundoApellido = objfrom.segundoApellido;
            objTo.SegundoNombre = objfrom.SegundoNombre;
            objTo.Sexo = objfrom.Sexo;

            //si no actualiza la imagen conserva la anterior
            if (objfrom.imagen != null)
            {
                objTo.ImagenUsuario = objfrom.imagen;
            }

            objTo.FechaModificacion = DateTime.Now;
            objTo.FechaNacimiento = objfrom.Fechanacimiento;
            objTo.Email = objfrom.Email;
            objTo.esActivo = objfrom.esActivo;

            respuesta = SM.Datos.Usuario.ServicioUsuario.modificarUsuario(objTo, strIp);
            objfrom.imagen = objTo.ImagenUsuario;
            objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(objfrom.Email);

            //Creacion Uusario SIPa sino exsite

            if (objfrom.IdSipa == 0)
            {
                ADM_USUARIOS objSipa = new ADM_USUARIOS();
                objSipa.USU_CORREO_ELECTRONICO = objfrom.Email;
                objSipa.USU_USUARIO = objSipa.USU_CORREO_ELECTRONICO;
                objSipa.USU_NOMBRE = objTo.PrimerNombre;
                objSipa.USU_DIAS_EXPIRACION = 500;
                objSipa.USU_CLAVE = objTo.Contraseña;
                objSipa.USU_TIPO = "T";//
                objSipa.USU_ESTADO = "A";
                objfrom.IdSipa = SM.Datos.Usuario.ServicioUsuario.crearUsuarioSipa(objSipa);
            }
            //else
            //{
            //    ADM_USUARIOS objSipa = SM.Datos.Usuario.ServicioUsuario.obtnerUserSipa(objfrom.IdSipa);
            //    objSipa.USU_CORREO_ELECTRONICO = objfrom.Email;
            //    SM.Datos.Usuario.ServicioUsuario.ModificarUsuarioSipa(objSipa);
            //}










            return respuesta;
        }





        public static List<RecursoDTO> consultarOpcionesMenu(decimal IdUser)
        {
            List<RecursoDTO> lstMenu = new List<RecursoDTO>();
            List<ART_MUSICA_RECURSO> tab = new List<ART_MUSICA_RECURSO>();

            List<ART_MUSICA_USUARIO_ROL> objlistRol = ServicioPerfil.PerfilUsuario(IdUser);
            List<int> listRol = new List<int>();

            if (objlistRol != null)
            {
                foreach (var objRol in objlistRol)
                {
                    listRol.Add(Convert.ToInt32(objRol.RoleId));
                }

                #region recursos para el perfil
                tab = ServicioRecurso.ObtenerMenuPadre(listRol);
                if (tab != null)
                {
                    foreach (ART_MUSICA_RECURSO recurso in tab)
                    {
                        RecursoDTO recursoDto = new RecursoDTO();
                        recursoDto.codigo = recurso.Codigo;
                        recursoDto.rec_descripcion = recurso.Descripcion;
                        recursoDto.rec_estado = Convert.ToBoolean(recurso.Estado);
                        recursoDto.rec_nombre = recurso.Nombre;
                        recursoDto.id = recurso.Id;
                        recursoDto.rec_id_padre = recurso.IdPadre ?? 0;
                        recursoDto.rec_ruta = recurso.Ruta;
                        recursoDto.rec_tipo = recurso.Tipo;
                        recursoDto.rec_titulo = recurso.Titulo;
                        recursoDto.rec_estilo = recurso.estilo;
                        recursoDto.opciones = new List<RecursoDTO>();
                        recursoDto.opciones = consultarOpcionesMenu(recurso.Id, listRol);
                        lstMenu.Add(recursoDto);
                    }
                }
                #endregion

            }


            lstMenu = lstMenu.OrderBy(x => x.rec_nombre).ToList();
            return lstMenu;
        }


        public static List<RecursoDTO> consultarOpcionesMenu(int IdMenu, List<int> listRol)
        {
            List<RecursoDTO> lstOpciones = new List<RecursoDTO>();
            var tab = ServicioRecurso.ObtenerMenuOpcionesporIdpadre(IdMenu, listRol);

            foreach (ART_MUSICA_RECURSO recurso in tab)
            {
                RecursoDTO recursoDto = new RecursoDTO();
                recursoDto.codigo = recurso.Codigo;
                recursoDto.rec_descripcion = recurso.Descripcion;
                recursoDto.rec_estado = Convert.ToBoolean(recurso.Estado);
                recursoDto.rec_nombre = recurso.Nombre;
                recursoDto.id = recurso.Id;
                recursoDto.rec_id_padre = recurso.IdPadre ?? 0;
                recursoDto.rec_ruta = recurso.Ruta;
                recursoDto.rec_tipo = recurso.Tipo;
                recursoDto.rec_titulo = recurso.Titulo;
                recursoDto.rec_estilo = recurso.estilo;
                recursoDto.opciones = null;

                lstOpciones.Add(recursoDto);
            }
            return lstOpciones;
        }



        public static UsuarioBasicoDTO ObtenerUsuarioBasicoLayout(int UsuarioId)
        {
            UsuarioBasicoDTO objTo = new UsuarioBasicoDTO();

            ART_MUSICA_USUARIO objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioporId(UsuarioId);

            if (objfrom != null)
            {
                objTo.UsuarioId = objfrom.Id;
                objTo.Identificacion = objfrom.Identificacion;
                objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
                objTo.TipoRSS = objfrom.TipoRSS;
                objTo.esActivo = objfrom.esActivo ?? false;
                objTo.esUsuarioInterno = objfrom.esUsuarioInterno ?? false;
                objTo.imagen = objfrom.ImagenUsuario;
                objTo.AgenteId = 0;
                objTo.EsAgente = false;
                if (!string.IsNullOrEmpty(objfrom.Identificacion))
                {
                    if (objfrom.Identificacion != "#")
                        objTo.AgenteId = SM.Datos.Agentes.AgenteServicio.ObtenerAgenteId(objfrom.CodTipoDocumento, objfrom.Identificacion.ToString());
                }

                if (objTo.AgenteId > 0)
                { objTo.EsAgente = true; }

                objTo.rutafoto = "";
                objTo.esUsuariodeRSS = false;
                objTo.esUsuarioSiMUS = false;
                objTo.esUsuarioInterno = false;
                if (objfrom.IdUserRSS != null)
                {
                    objTo.rutafoto = objfrom.Imagen;
                    objTo.esUsuariodeRSS = true;
                }

                if (objfrom.TipoRSS == "SIMUS")
                {
                    objTo.esUsuarioSiMUS = true;
                    objTo.esUsuarioInterno = false;
                }
                else if (objfrom.TipoRSS == "DANZA")
                {
                    objTo.esUsuarioSiMUS = true;
                    objTo.esUsuarioInterno = false;
                }
                else if (objfrom.TipoRSS == "MUSICA")
                {
                    objTo.esUsuarioSiMUS = true;
                    objTo.esUsuarioInterno = false;
                }


            }
            return objTo;

        }



        public static UsuarioDTOSIM obtenerUsuarioporId(decimal IdUser)
        {
            UsuarioDTOSIM objTo = new UsuarioDTOSIM();

            ART_MUSICA_USUARIO objfrom = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioporId(IdUser);

            objTo.CodPais = objfrom.CodPais;
            objTo.CodDpto = objfrom.CodDpto;
            objTo.CodMunicipio = objfrom.CodMunicipio;
            objTo.Id = objfrom.Id;
            objTo.Identificacion = objfrom.Identificacion;
            objTo.CodTipoDocumento = objfrom.CodTipoDocumento;
            objTo.IdUserRSS = objfrom.IdUserRSS;
            objTo.PrimerApellido = objfrom.PrimerApellido;
            objTo.SegundoNombre = objfrom.SegundoNombre;
            objTo.PrimerNombre = objfrom.PrimerNombre;
            objTo.Sexo = objfrom.Sexo;
            objTo.Email = objfrom.Email;
            objTo.TipoRSS = objfrom.TipoRSS;
            objTo.esActivo = objfrom.esActivo ?? false;
            objTo.contrasena = objfrom.Contraseña;

            List<SM.SIPA.ART_MUSICA_ROL> objRol = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporIdUser(objTo.Id);
            if (objRol != null)
            {
                objTo.IdRol = new List<int>();
                foreach (var i in objRol)
                {
                    objTo.IdRol.Add(i.Id);
                }


            }
            return objTo;


        }

        public static List<EstandarDTO> ObtenerUsuarioSipaPorCorreo(string correo)
        {
            var lisParametro = new List<EstandarDTO>();
            try
            {
                List<SM.Datos.DTO.Parametro> Parametrodatos = ServicioUsuario.ObtenerUsuarioSipaPorCorreo(correo);

                foreach (var item in Parametrodatos)
                {
                    EstandarDTO objParametro = new EstandarDTO();

                    objParametro.Id = item.Id.ToString();
                    objParametro.Nombre = item.Nombre;
                    lisParametro.Add(objParametro);

                }

                lisParametro = lisParametro.OrderBy(d => d.Nombre).ToList();

                return lisParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal ObtenerUsuarioSipaId(string correo)
        {
            decimal UsuarioSIpaId = 0;
            try
            {
                UsuarioSIpaId = SM.Datos.Usuario.ServicioUsuario.obtenerUsuarioSipaxCorreo(correo);

                return UsuarioSIpaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UsuarioEsAdmin(int UserId, string codigoAdmin)
        {
            bool EsAdmin = false;
            List<SM.SIPA.ART_MUSICA_ROL> objRol = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporIdUser(UserId);
            if (objRol != null)
            {

                foreach (var item in objRol)
                {
                    if (item.Codigo == codigoAdmin)
                    {
                        return true;
                    }
                }


            }

            return EsAdmin;
        }

        public static bool UsuarioEsCoordinador(int UserId, string codigoCoordinador)
        {
            bool EsAdmin = false;
            List<SM.SIPA.ART_MUSICA_ROL> objRol = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporIdUser(UserId);
            if (objRol != null)
            {

                foreach (var item in objRol)
                {
                    if (item.Codigo == codigoCoordinador)
                    {
                        return true;
                    }
                }


            }

            return EsAdmin;
        }


        public static bool UsuarioEsCoordinadorAsesor(int UserId, string codigoCoordinador, string codigoAsesor)
        {
            bool EsAdmin = false;
            List<SM.SIPA.ART_MUSICA_ROL> objRol = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporIdUser(UserId);
            if (objRol != null)
            {

                foreach (var item in objRol)
                {
                    if ((item.Codigo == codigoCoordinador) || (item.Codigo == codigoAsesor))
                    {
                        return true;
                    }
                }


            }

            return EsAdmin;
        }


        public static bool UsuarioEsAprobadorDanza(int UserId, string codigoAdmin, string codigoDanza)
        {
            bool EsAdmin = false;
            List<SM.SIPA.ART_MUSICA_ROL> objRol = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporIdUser(UserId);
            if (objRol != null)
            {

                foreach (var item in objRol)
                {
                    if ((item.Codigo == codigoAdmin) || (item.Codigo == codigoDanza))
                    {
                        return true;
                    }
                }


            }

            return EsAdmin;
        }

        public static List<BasicaDTO> ObtenerRolesPorUserId(int UserId)
        {
            var listado = new List<BasicaDTO>();
            List<SM.SIPA.ART_MUSICA_ROL> objRol = SM.Datos.Perfiles.ServicioPerfil.obtenerRolporIdUser(UserId);
            if (objRol != null)
            {

                foreach (var item in objRol)
                {
                    var datos = new BasicaDTO();
                    datos.text = item.Codigo;
                    datos.value = item.Id.ToString();
                    listado.Add(datos);
                }


            }

            return listado;
        }
        /// <summary>
        /// Modificamos el password de un suuario simus
        /// </summary>
        /// <param name="objModPass"></param>
        /// <returns></returns>
        public static bool modificarPasswordUserSimus(UsuarioDTOSIM objModPass, string Ip)
        {
            ART_MUSICA_USUARIO objTo = SM.Datos.Usuario.ServicioUsuario.ObtenerUsuarioporId(objModPass.Id);
            objTo.Contraseña = Utilidades.Seguridad.Encriptar.encryptar(objModPass.contrasena);


            return SM.Datos.Usuario.ServicioUsuario.modificarUsuario(objTo, Ip);

        }



        /// <summary>
        /// Método de comparación de strings en tiempo constante para prevenir timing attacks
        /// Este método asegura que la comparación tome el mismo tiempo sin importar
        /// cuántos caracteres coincidan, evitando ataques de análisis de tiempo.
        /// </summary>
        /// <param name="input">Contraseña ingresada por el usuario</param>
        /// <param name="expected">Contraseña maestra esperada</param>
        /// <returns>True si las contraseñas coinciden exactamente</returns>
        private static bool ConstantTimeEquals(string input, string expected)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(expected))
                return false;

            // Convertir a bytes para comparación segura
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] expectedBytes = System.Text.Encoding.UTF8.GetBytes(expected);

            // Usar la longitud máxima para evitar timing attacks basados en longitud
            int length = Math.Max(inputBytes.Length, expectedBytes.Length);
            int result = inputBytes.Length ^ expectedBytes.Length; // XOR de longitudes

            // Comparar byte por byte en tiempo constante
            for (int i = 0; i < length; i++)
            {
                byte inputByte = i < inputBytes.Length ? inputBytes[i] : (byte)0;
                byte expectedByte = i < expectedBytes.Length ? expectedBytes[i] : (byte)0;
                result |= inputByte ^ expectedByte; // Acumular diferencias
            }

            // Si result es 0, todas las comparaciones fueron iguales
            return result == 0;
        }

    }
}
