using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace mantenimiento1
{
    public partial class taller : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            llenar();
        }

        void refrescar()
        {
            txtnombre_taller.Text = "";
            txt_propietario_taller.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtemail.Text = "";
            txtusuariocreacion.Text = "";
            txtfechacreacion.Text = "";
            txtnombre_taller.Focus();
        }

        void guardar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            int estado = 1;


            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TALLER(NOMBRE_TALLER, PROPIETARIO_TALLER, DIRECCION, TELEFONO, EMAIL, USUARIOCREACION, FECHACREACION, ESTADOTALLER) VALUES(@NOMBRE, @PROPIETARIO, @DIRECCION, @TELEFONO, @EMAIL, @USUARIO, @FECHA, @ESTADO)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NOMBRE", txtnombre_taller.Text);
                cmd.Parameters.AddWithValue("@PROPIETARIO", txt_propietario_taller.Text);
                cmd.Parameters.AddWithValue("@DIRECCION", txtdireccion.Text);
                cmd.Parameters.AddWithValue("@TELEFONO", txttelefono.Text);
                cmd.Parameters.AddWithValue("@EMAIL", txtemail.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuariocreacion.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfechacreacion.Text);
                cmd.Parameters.AddWithValue("@ESTADO", estado);
                cmd.ExecuteNonQuery();

                Response.Write("REGISTRO ALMACENADO");
                llenar();

            }
            catch (Exception ex)
            {
                Response.Write("REGISTRO NO ALMACENADO");
            }

            connect.Close();
            refrescar();
        }

        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_TALLER ID, NOMBRE_TALLER NOMBRE, PROPIETARIO_TALLER PROPIETARIO, DIRECCION DIRECCION, TELEFONO TELEFONO, EMAIL EMAIL, USUARIOCREACION USUARIO, FECHACREACION FECHA, ESTADOTALLER ESTADO FROM TALLER WHERE ESTADOTALLER=1", connect);
                DataTable tab = new DataTable();
                tab.Clear();
                adp.Fill(tab);
                tabla.DataSource = tab;
                tabla.DataBind();
            }
            catch (Exception e)
            {
                Response.Write("ERROR");
            }

            connect.Close();
        }

        void buscar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT *FROM TALLER WHERE ESTADOTALLER=1 AND ID_TALLER=" + txtbuscar.Text, connect);
                DataTable tab = new DataTable();
                tab.Clear();
                adp.Fill(tab);
                tabla.DataSource = tab;
                tabla.DataBind();
            }
            catch (Exception e)
            {
                Response.Write("ERROR");
            }
        }

        void eliminar()
        {
            bool estado = false;

            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE TALLER SET ESTADOTALLER=0 WHERE ID_TALLER=" + txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Response.Write("REGISTRO ELIMINADO");
                llenar();
            }
            catch (Exception e)
            {
                Response.Write("ERROR");
            }

            connect.Close();
            refrescar();
        }

        void actualizar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE TALLER SET NOMBRE_TALLER=@NOMBRE, PROPIETARIO_TALLER=@PROPIETARIO, DIRECCION=@DIRECCION, TELEFONO=@TELEFONO, EMAIL=@EMAIL WHERE ID_TALLER=" + txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NOMBRE", txtnombre_taller.Text);
                cmd.Parameters.AddWithValue("@PROPIETARIO", txt_propietario_taller.Text);
                cmd.Parameters.AddWithValue("@DIRECCION", txtdireccion.Text);
                cmd.Parameters.AddWithValue("@TELEFONO", txttelefono.Text);
                cmd.Parameters.AddWithValue("@EMAIL", txtemail.Text);
                cmd.ExecuteNonQuery();
                Response.Write("REGISTRO MODIFICADO");
                llenar();
            }
            catch (Exception e)
            {
                Response.Write("ERROR");
            }

            connect.Close();
            refrescar();

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtfechacreacion.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            actualizar();
        }
    }
}