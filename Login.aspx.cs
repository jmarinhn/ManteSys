using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace mantenimiento1
{
    public partial class Login : System.Web.UI.Page
    {

        string connectSQL = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public bool validated()
        {
            if (txtUsername.Value == String.Empty)
            {
                Response.Write("DIGITE EL USUARIO");
                return false;
            }
            else
            {
                if (txtPassword.Value == String.Empty)
                {
                    Response.Write("DIGITE LA CLAVE");
                    return false;
                }
            }
            return true;
        }
        void Getin()
        {
            SqlConnection connect;
            connect = new SqlConnection(connectSQL);
            connect.Open();

            try
            {
                if (validated())
                {
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT USERNAME, PASSWORDHASH FROM USUARIOS WHERE USERNAME='" + txtUsername.Value + "'AND PASSWORDHASH='" + txtPassword.Value + "'", connect);

                    DataSet data = new DataSet();
                    adapt.Fill(data, "dato");

                    if (data.Tables["dato"].Rows.Count > 0)
                    {
                        Response.Redirect("/reportes.aspx");
                    }
                    else
                    {
                        clear();
                        Response.Write("<script>alert('El usuario es incorrecto!')</script>");
                    }

                }
                else
                {
                    clear();
                    Response.Write("<script>alert('Ingrese los datos')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex + "!)</script>");
            }
        }

        void clear()
        {
            txtUsername.Value = String.Empty;
            txtPassword.Value = String.Empty;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Getin();
        }
    }
}