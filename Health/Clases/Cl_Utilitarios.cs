using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Health.MasterPage;
using System.Globalization;

namespace Health.Clases
{
    public class Cl_Utilitarios
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conexion"]);
        Cl_Traductor ClTraductor;
        Cl_Usuario ClUsuario;

        string Variable = "Var";
        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            // Get the key from config file

            string key = "QUERY";
            //string key = (string)settingsReader.GetValue("SecurityKey",
            //                                                 typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            string Encriptado = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            return Encriptado.Replace("+", "!");
        }

        public string Decrypt(string cipherString, bool useHashing)
        {
            cipherString = cipherString.Replace("!", "+");
            byte[] keyArray;

            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = "QUERY";
            //string key = (st ring)settingsReader.GetValue("SecurityKey",
            //                                             typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public DateTime FechaDB()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_FechaDb", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Resul", SqlDbType.Date).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                cn.Close();
                return Convert.ToDateTime(cmd.Parameters["@Resul"].Value);

            }
            catch (Exception ex)
            {
                cn.Close();
                return Convert.ToDateTime("01/01/2000");
            }
        }

        public string GenerarPass(int LongPassMin, int LongPassMax)
        {
            char[] ValueAfanumeric = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '!', '#', '$', '%', '&', '?', '¿' };
            Random ram = new Random();
            int LogitudPass = ram.Next(LongPassMin, LongPassMax);
            string Password = String.Empty;

            for (int i = 0; i < LogitudPass; i++)
            {
                int rm = ram.Next(0, 2);

                if (rm == 0)
                {
                    Password += ram.Next(0, 10);
                }
                else
                {
                    Password += ValueAfanumeric[ram.Next(0, 59)];
                }
            }

            return Password;

        }

        public void EnvioCorreo(string Mail, string Nombre, string Asunto, string Mensaje, int ConAdjunto, string RutaAdjunto, string NombreArchivo)
        {
            ClTraductor = new Cl_Traductor();
            try
            {
                string Sitio = System.Configuration.ConfigurationManager.AppSettings["Sitio"].ToString();
                System.Net.Mail.MailMessage Correo = new System.Net.Mail.MailMessage();
                Correo.From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["Cuenta"], "Query Health APP");
                Correo.To.Add(Mail);
                //Correo.CC.Add("hhernandez@query.com.gt");
                Correo.Subject = Asunto;
                string Saludo = "<table><tr><td>" + ClTraductor.BuscaString(HttpContext.Current.Session["Idioma"].ToString(), "24") + " "  + Nombre + "</td></tr></table>";
                string Notificacion = "<table><tr><td><b>" + ClTraductor.BuscaString(HttpContext.Current.Session["Idioma"].ToString(), "23") + " </b></td></tr></table>";
                Mensaje = Notificacion + Saludo + Mensaje + "<table><tr><td>" + ClTraductor.BuscaString(HttpContext.Current.Session["Idioma"].ToString(), "25") + " " + Sitio + " " + ClTraductor.BuscaString(HttpContext.Current.Session["Idioma"].ToString(), "26")  + "</td></tr><tr><td></td></tr><tr><td><b>Query</b></td></tr<tr><td></td></tr><tr><td> <font color=#FF0000>" + ClTraductor.BuscaString(HttpContext.Current.Session["Idioma"].ToString(), "27")  + "</font></td></tr></table>";
                Mensaje = Mensaje + "<table><tr><td></td></tr><tr><td>" + ClTraductor.BuscaString(HttpContext.Current.Session["Idioma"].ToString(), "28")  + " " + Nombre + " " + ClTraductor.BuscaString(HttpContext.Current.Session["Idioma"].ToString(), "29")  + "</td></tr></table></body>";
                AlternateView HTMLConImagenes = default(AlternateView);
                HTMLConImagenes = AlternateView.CreateAlternateViewFromString(Mensaje, null, "text/html");
                Correo.AlternateViews.Add(HTMLConImagenes);
                Correo.IsBodyHtml = true;
                if (ConAdjunto == 1)
                {
                    Attachment File = new Attachment(RutaAdjunto);
                    File.Name = NombreArchivo;
                    Correo.Attachments.Add(File);
                }
                Correo.Priority = System.Net.Mail.MailPriority.High;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationManager.AppSettings["Host"].ToString(), Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Puerto"]));
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["Cuenta"], System.Configuration.ConfigurationManager.AppSettings["Clave"]);

                smtp.Send(Correo);
            }
            catch (Exception ex)
            {
                string Err = ex.Message;
            }

        }

        public void Fill_Select(DataSet ds, System.Web.UI.HtmlControls.HtmlSelect select, string Llave, string Descripcion)
        {
            select.DataSource = ds;
            select.DataTextField = Descripcion;
            select.DataValueField = Llave;
            select.DataBind();
            ds.Tables.Remove("DATOS");
        }

        public void Fill_DropDownAsp(DataSet ds,  System.Web.UI.WebControls.DropDownList DropDownList, string Llave, string Descripcion)
        {
            DropDownList.DataSource = ds;
            DropDownList.DataTextField = Descripcion;
            DropDownList.DataValueField = Llave;
            DropDownList.DataBind();
            ds.Tables.Remove("DATOS");
        }

        public void AgregarSeleccioneCombo(System.Web.UI.WebControls.DropDownList DropDownList, string Descripcion, string Idioma)
        {
            string Texto = "";
            if (Idioma == "es-GT")
                Texto = "Seleccione " + Descripcion;
            else if (Idioma == "es-GT")
                Texto = "Select " + Descripcion;
            DropDownList.Items.Insert(0, new ListItem(Texto));
        }

        public void LlenaGrid(DataSet ds, Telerik.Web.UI.RadGrid Grid, string Idioma)
        {
            if (Idioma == "es-GT")
                Grid.Culture = new CultureInfo("es-PE");
            else if (Idioma == "en-US")
                Grid.Culture = new CultureInfo("en-US");
            Grid.DataSource = ds;
        }

        

    }
}
