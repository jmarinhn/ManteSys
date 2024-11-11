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
    public partial class vehiculos : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            llenar();
        }
        void refrescar()
        {
            txtnplaca.Text = "";
            txtmarca.Text = "";
            txttipo.Text = "";
            txtmodelo.Text = "";
            txtcolor.Text = "";
            txtkilometraje.Text = "";
            txtcilindraje.Text = "";
            txtnumero.Text = "";
            txtneumaticos.Text = "";
            txtcapacidad.Text = "";
            txtconsumo.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txtnplaca.Focus();
        }

        void guardar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            int estado = 1;

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO VEHICULOS(NPLACA, MARCA_VEHICULO, TIPO_VEHICULO, MODELO_VEHICULO, COLOR_VEHICULO, KILOMETRAJE_VEHICULO, CILINDRAJE_VEHICULO, NUMERO_VEHICULO, NUMERONEUMATICOS, CAPGALONES, CONSUMO_CIUDAD, USUARIOCREACION, FECHACREACION, ESTADOVEHICULOS) VALUES(@PLACA, @MARCA, @TIPO, @MODELO, @COLOR, @KILOMETRAJE, @CILINDRAJE, @NUMERO, @NEUMATICOS, @GALONES, @CONSUMO, @USUARIO, @FECHA, @ESTADO)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PLACA", txtnplaca.Text);
                cmd.Parameters.AddWithValue("@MARCA", txtmarca.Text);
                cmd.Parameters.AddWithValue("@TIPO", txttipo.Text);
                cmd.Parameters.AddWithValue("@MODELO", txtmodelo.Text);
                cmd.Parameters.AddWithValue("@COLOR", txtcolor.Text);
                cmd.Parameters.AddWithValue("@KILOMETRAJE", txtkilometraje.Text);
                cmd.Parameters.AddWithValue("@CILINDRAJE", txtcilindraje.Text);
                cmd.Parameters.AddWithValue("@NUMERO", txtnumero.Text);
                cmd.Parameters.AddWithValue("@NEUMATICOS", txtneumaticos.Text);
                cmd.Parameters.AddWithValue("@GALONES", txtcapacidad.Text);
                cmd.Parameters.AddWithValue("@CONSUMO", txtconsumo.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);
                cmd.Parameters.AddWithValue("@ESTADO", estado);
                cmd.ExecuteNonQuery();

                Response.Write("REGISTRO ALMACENADO");
                llenar();

            } 
            catch (Exception e)
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_VEHICULO, NPLACA, MARCA_VEHICULO, TIPO_VEHICULO, MODELO_VEHICULO, COLOR_VEHICULO, KILOMETRAJE_VEHICULO, CILINDRAJE_VEHICULO, NUMERO_VEHICULO, NUMERONEUMATICOS, CAPGALONES, CONSUMO_CIUDAD, USUARIOCREACION, FECHACREACION, USUARIOMODIFICACION, FECHAMODIFICACION, ESTADOVEHICULOS FROM VEHICULOS WHERE ESTADOVEHICULOS=1", connect);
                DataTable tab = new DataTable();
                tab.Clear();
                adp.Fill(tab);
                tabla.DataSource = tab;
                tabla.DataBind();
            }
            catch(Exception e)
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_VEHICULO, NPLACA, MARCA_VEHICULO, TIPO_VEHICULO, MODELO_VEHICULO, COLOR_VEHICULO, KILOMETRAJE_VEHICULO, CILINDRAJE_VEHICULO, NUMERO_VEHICULO, NUMERONEUMATICOS, CAPGALONES, CONSUMO_CIUDAD, USUARIOCREACION, FECHACREACION, USUARIOMODIFICACION, FECHAMODIFICACION, ESTADOVEHICULOS FROM VEHICULOS WHERE ESTADOVEHICULOS=1 AND ID_VEHICULO=" + txtbuscar.Text, connect);
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
                SqlCommand cmd = new SqlCommand("UPDATE VEHICULOS SET ESTADOVEHICULOS=0 WHERE ID_VEHICULO=" + txtbuscar.Text, connect);
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
                SqlCommand cmd = new SqlCommand("UPDATE VEHICULOS SET NPLACA=@PLACA, MARCA_VEHICULO=@MARCA, TIPO_VEHICULO=@TIPO, MODELO_VEHICULO=@MODELO, COLOR_VEHICULO=@COLOR, KILOMETRAJE_VEHICULO=@KILOMETRAJE, CILINDRAJE_VEHICULO=@CILINDRAJE, NUMERO_VEHICULO=@NUMERO, NUMERONEUMATICOS=@NEUMATICOS, CAPGALONES=@GALONES, CONSUMO_CIUDAD=@CONSUMO, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE ID_VEHICULO="+txtbuscar.Text, connect);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@PLACA", txtnplaca.Text);
                cmd.Parameters.AddWithValue("@MARCA", txtmarca.Text);
                cmd.Parameters.AddWithValue("@TIPO", txttipo.Text);
                cmd.Parameters.AddWithValue("@MODELO", txtmodelo.Text);
                cmd.Parameters.AddWithValue("@COLOR", txtcolor.Text);
                cmd.Parameters.AddWithValue("@KILOMETRAJE", txtkilometraje.Text);
                cmd.Parameters.AddWithValue("@CILINDRAJE", txtcilindraje.Text);
                cmd.Parameters.AddWithValue("@NUMERO", txtnumero.Text);
                cmd.Parameters.AddWithValue("@NEUMATICOS", txtneumaticos.Text);
                cmd.Parameters.AddWithValue("@GALONES", txtcapacidad.Text);
                cmd.Parameters.AddWithValue("@CONSUMO", txtconsumo.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);

                cmd.ExecuteNonQuery();

                Response.Write("REGISTRO ACTUALIZADO");
                llenar();

            }
            catch (Exception e)
            {
                Response.Write("REGISTRO NO ALMACENADO");
            }

            connect.Close();
            refrescar();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtfecha.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            guardar();
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

        protected void Button6_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = Visible;
        }
    }
}