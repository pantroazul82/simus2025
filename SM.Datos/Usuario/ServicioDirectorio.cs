using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;

namespace SM.Datos.Usuario
{
    public class ServicioDirectorio 
    {

        #region Atributes

        private PrincipalContext objPrincipalContext = null;

        #endregion

        #region Members

        private string strLDAPUser { get; set; }
        private string strLDAPPassword { get; set; }
        private string strDomain { get; set; }

        #endregion

        #region Methods

        public ServicioDirectorio(string domain)
        {
            this.strDomain = domain;
        }

        public ServicioDirectorio(string LDAPUser, string LDAPPassword, string domain)
        {
            this.strLDAPUser = LDAPUser;
            this.strLDAPPassword = LDAPPassword;
            this.strDomain = domain;
            objPrincipalContext = new PrincipalContext(ContextType.Domain, this.strDomain, "DC=gov,DC=mincultura,DC=gov", this.strLDAPUser, this.strLDAPPassword);
        }

        public string[] Get(string userName, string password)
        {

            string[] datos = null;
            DirectoryEntry directoryEntry = null;
            DirectorySearcher directorySearcher = null;
            SearchResult searchResult = null;

            try
            {

                userName = userName.Trim();
                password = password.Trim();

                directoryEntry = new DirectoryEntry(StringLDAP(), this.strDomain + @"\" + userName, password);
                directorySearcher = new DirectorySearcher(directoryEntry);

                directorySearcher.Filter = "(SAMAccountName=" + userName + ")";
                directorySearcher.PropertiesToLoad.Add("samAccountName");
                directorySearcher.PropertiesToLoad.Add("givenName");
                directorySearcher.PropertiesToLoad.Add("sn");
                directorySearcher.PropertiesToLoad.Add("mail");
                directorySearcher.PropertiesToLoad.Add("cn");

                searchResult = directorySearcher.FindOne();

                if (searchResult != null)
                {
                    datos = new string[13];
                    datos[0] = searchResult.Properties["SAMAccountName"].Count > 0 ? searchResult.Properties["SAMAccountName"][0].ToString() : string.Empty;
                    datos[1] = searchResult.Properties["givenName"].Count > 0 ? searchResult.Properties["givenName"][0].ToString() : string.Empty;
                    datos[2] = searchResult.Properties["sn"].Count > 0 ? searchResult.Properties["sn"][0].ToString() : string.Empty;
                    datos[3] = searchResult.Properties["mail"].Count > 0 ? searchResult.Properties["mail"][0].ToString() : string.Empty;
                    datos[4] = searchResult.Properties["cn"].Count > 0 ? searchResult.Properties["cn"][0].ToString() : string.Empty;
                }

            }
            catch
            {
            }
            finally
            {
                directoryEntry = null;
                directorySearcher = null;
                searchResult = null;
            }

            return datos;

        }

        public string SAMAccountName(string securityIdentifierHex, string usuario, string clave)
        {
            //DirectoryEntry directoryEntry = null;
            string samAccountName = null;

            //try
            //{

            //    //directoryEntry = new DirectoryEntry("LDAP://<SID=" + securityIdentifierHex + ">");
            //    //directoryEntry = new DirectoryEntry("LDAP://" + (string)directoryEntry.Properties["distinguishedName"][0], null, null, AuthenticationTypes.Secure | AuthenticationTypes.ReadonlyServer);

            //    //samAccountName = directoryEntry.Properties["SAMAccountName"].Value.ToString();
            //    samAccountName = this.Get(usuario, clave).Properties["SAMAccountName"][0].ToString();

            //}
            //catch
            //{
            //    samAccountName = null;
            //}
            //finally
            //{
            //    directoryEntry = null;
            //}

            return samAccountName;

        }

        private IEnumerable<Principal> GetListUsers(out int RowCount, string User = "", string UserName = "", int PageIndex = 0, int PageSize = 0)
        {
            PrincipalSearcher objPrincipalSearcher = null;
            UserPrincipal objUserPrincipal = null;
            PrincipalSearchResult<Principal> objlstPrincipalSearchResult = null;
            object objDirectorySearcher = null;

            try
            {
                objPrincipalSearcher = new PrincipalSearcher();
                objUserPrincipal = new UserPrincipal(objPrincipalContext);

                objUserPrincipal.Name = "*";

                if (!string.IsNullOrEmpty(User))
                    objUserPrincipal.SamAccountName = string.Concat("*", User, "*");
                //else
                //    objUserPrincipal.SamAccountName = "*";

                if (!string.IsNullOrEmpty(UserName))
                    objUserPrincipal.DisplayName = string.Concat("*", UserName, "*");
                //else
                //    objUserPrincipal.DisplayName = "*";

                objPrincipalSearcher.QueryFilter = objUserPrincipal;

                //Manejo para cambiar el paginado por defecto del PrincipalSearcher de 1000 a un valor mayor
                objDirectorySearcher = objPrincipalSearcher.GetUnderlyingSearcher();
                ((DirectorySearcher)objDirectorySearcher).PageSize = 9999999;

                objlstPrincipalSearchResult = objPrincipalSearcher.FindAll();

                if (objlstPrincipalSearchResult == null)
                    RowCount = 0;
                else
                    RowCount = objlstPrincipalSearchResult.Count();

                var objlstResultado = from elemento in objlstPrincipalSearchResult orderby elemento.SamAccountName select elemento;

                return objlstResultado.Skip((PageIndex - 1) * PageSize).Take(PageSize).AsEnumerable();
                //return objlstResultado.AsEnumerable();

            }
            catch (System.Exception objException)
            {
                throw new System.Exception("Ha ocurrido un error al obtener los usuarios del directorio activo.", objException);
            }
            finally
            {
                objPrincipalSearcher = null;
                objUserPrincipal = null;
                objlstPrincipalSearchResult = null;
                objDirectorySearcher = null;
            }
        }

        private IEnumerable<Principal> GetListUsersRol(out int RowCount, System.Data.DataTable rolesUsuarios, string User = "", string UserName = "", int PageIndex = 0, int PageSize = 0)
        {
            PrincipalSearcher objPrincipalSearcher = null;
            UserPrincipal objUserPrincipal = null;
            PrincipalSearchResult<Principal> objlstPrincipalSearchResult = null;
            List<String> lstUsuarios = new List<string>(0);
            object objDirectorySearcher = null;

            try
            {
                objPrincipalSearcher = new PrincipalSearcher();
                objUserPrincipal = new UserPrincipal(objPrincipalContext);

                objUserPrincipal.Name = "*";

                if (!string.IsNullOrEmpty(User))
                    objUserPrincipal.SamAccountName = string.Concat("*", User, "*");
                //else
                //    objUserPrincipal.SamAccountName = "*";

                if (!string.IsNullOrEmpty(UserName))
                    objUserPrincipal.DisplayName = string.Concat("*", UserName, "*");
                //else
                //    objUserPrincipal.DisplayName = "*";

                objPrincipalSearcher.QueryFilter = objUserPrincipal;

                //Manejo para cambiar el paginado por defecto del PrincipalSearcher de 1000 a un valor mayor
                objDirectorySearcher = objPrincipalSearcher.GetUnderlyingSearcher();
                ((DirectorySearcher)objDirectorySearcher).PageSize = 9999999;

                objlstPrincipalSearchResult = objPrincipalSearcher.FindAll();

                foreach (System.Data.DataRow drFila in rolesUsuarios.Rows)
                {
                    lstUsuarios.Add(drFila[1].ToString());
                }

                var usuariosRol = from elementoRol in objlstPrincipalSearchResult join elementoUsuario in lstUsuarios on elementoRol.SamAccountName.ToLower() equals elementoUsuario.ToString().ToLower() select elementoRol;

                if (objlstPrincipalSearchResult == null)
                    RowCount = 0;
                else
                    RowCount = usuariosRol.Count();

                var objlstResultado = from elemento in usuariosRol orderby elemento.SamAccountName select elemento;

                return objlstResultado.Skip((PageIndex - 1) * PageSize).Take(PageSize).AsEnumerable();
                //return objlstResultado.AsEnumerable();

            }
            catch (System.Exception objException)
            {
                throw new System.Exception("Ha ocurrido un error al obtener los usuarios del directorio activo.", objException);
            }
            finally
            {
                objPrincipalSearcher = null;
                objUserPrincipal = null;
                objlstPrincipalSearchResult = null;
                objDirectorySearcher = null;
            }
        }

        protected internal string StringLDAP()
        {
            DirectoryEntry root = new DirectoryEntry("LDAP://RootDSE");
            string strPath = "";
            using (root)
            {
                string strDnc = root.Properties["defaultNamingContext"][0].ToString();
                string strServer = root.Properties["dnsHostName"][0].ToString();

                strPath = String.Format("LDAP://{0}/{1}", strServer, strDnc);
            }
            return strPath;
        }

        public string SIDToHex(SecurityIdentifier securityIdentifier)
        {

            int binLength = securityIdentifier.BinaryLength;
            byte[] bt = new byte[binLength];
            securityIdentifier.GetBinaryForm(bt, 0);
            System.Text.StringBuilder retval = new System.Text.StringBuilder(binLength * 2, binLength * 2);
            for (int cx = 0; cx < binLength; cx++)
                retval.Append(bt[cx].ToString("X2"));

            return retval.ToString();

        }

        private static string GetFilterUserString(string Filter)
        {
            string FilterByName = "(samAccountName=*{0}*)";
            string AllUser = "(&(objectCategory=person)(objectClass=user){0})";

            if (Filter == string.Empty)
            {
                return string.Format(AllUser, string.Empty);
            }
            else
            {
                return string.Format(AllUser, string.Format(FilterByName, Filter));
            }
        }

        private UserPrincipal GetUserPrincipal(string userName, string password)
        {
            userName = userName.Trim();
            password = password.Trim();

            try
            {

                PrincipalContext context = new PrincipalContext(ContextType.Domain, this.strDomain, "DC=gov" + this.strDomain + ",DC=mincultura,DC=gov", this.strLDAPUser, this.strLDAPPassword);

                UserPrincipal userQuery = new UserPrincipal(context);

                userQuery.SamAccountName = userName;

                PrincipalSearcher principalSearcher = new PrincipalSearcher(userQuery);

                return principalSearcher.FindOne() as UserPrincipal;

            }
            catch (System.Exception objException)
            {
                throw new System.Exception("Ha ocurrido un error al obtener el usuario del directorio activo.", objException);
            }

        }

        #endregion

    }
}
