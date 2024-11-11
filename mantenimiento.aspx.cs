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
    public partial class mantenimiento : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        void refrescar()
        {
            txtnombre.Text = "";
            txtfechamant.Text = "";
            txtproximo.Text = "";
            txtcosto.Text = "";
            txtobservaciones.Text = "";
            txtid_vehiculo.Text = "";
            txtid_taller.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txtnombre.Focus();
        }

        void guardar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();
            int estado = 1;

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO MANTENIMIENTO(NOMBRE_MANT, FMANT, FPROXIMANT, COSTO, OBSERVACIONES, ID_VEHICULO, ID_TALLER, USUARIOCREACION, FECHACREACION, ESTADOMANT) VALUES(@NOMBREMANT, @FMANT, @FPROXIMANT, @COSTO, @OBSERVACIONES, @IDVEHICULO, @IDTALLER, @USUARIO, @FECHA, @ESTADO)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NOMBREMANT", txtnombre.Text);
                cmd.Parameters.AddWithValue("@FMANT", txtfechamant.Text);
                cmd.Parameters.AddWithValue("@FPROXIMANT", txtproximo.Text);
                cmd.Parameters.AddWithValue("@COSTO", txtcosto.Text);
                cmd.Parameters.AddWithValue("@OBSERVACIONES", txtobservaciones.Text);
                cmd.Parameters.AddWithValue("@IDVEHICULO", txtid_vehiculo.Text);
                cmd.Parameters.AddWithValue("@IDTALLER", txtid_taller.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);
                cmd.Parameters.AddWithValue("@ESTADO", estado);
                cmd.ExecuteNonQuery();

                Response.Write("REGISTRO ALMACENADO");
                llenar();
            }
            catch (Exception e)
            {
                Response.Write("ERROR");
            }
            refrescar();
            connect.Close();
        }

        void actualizar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE MANTENIMIENTO SET NOMBRE_MANT=@NOMBREMANT, FMANT=@FMANT, FPROXIMANT=@FPROXIMANT, COSTO=@COSTO, OBSERVACIONES=@OBSERVACIONES, ID_VEHICULO=@IDVEHICULO, ID_TALLER=@IDTALLER, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE ID_MANT="+txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NOMBREMANT", txtnombre.Text);
                cmd.Parameters.AddWithValue("@FMANT", txtfechamant.Text);
                cmd.Parameters.AddWithValue("@FPROXIMANT", txtproximo.Text);
                cmd.Parameters.AddWithValue("@COSTO", txtcosto.Text);
                cmd.Parameters.AddWithValue("@OBSERVACIONES", txtobservaciones.Text);
                cmd.Parameters.AddWithValue("@IDVEHICULO", txtid_vehiculo.Text);
                cmd.Parameters.AddWithValue("@IDTALLER", txtid_taller.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);
                cmd.ExecuteNonQuery();

                Response.Write("REGISTRO ALMACENADO");
                llenar();
            }
            catch (Exception e)
            {
                Response.Write("ERROR");
            }
            refrescar();
            connect.Close();
        }

        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_MANT AS 'ID MANTENIMIENTO', NOMBRE_MANT AS 'TIPO DE MANTENIMIENTO', FMANT AS 'FECHA DE MANTENIMIENTO', FPROXIMANT AS 'PROXIMO MANTENIMINETO', COSTO, OBSERVACIONES, ID_VEHICULO, ID_TALLER FROM MANTENIMIENTO WHERE ESTADOMANT=1", connect);
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT *FROM MANTENIMIENTO WHERE ESTADOMANT=1 AND ID_MANT=" + txtbuscar.Text, connect);
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
                SqlCommand cmd = new SqlCommand("UPDATE MANTENIMIENTO SET ESTADOMANT=0 WHERE ID_MANT=" + txtbuscar.Text, connect);
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
        protected void Page_Load(object sender, EventArgs e)
        {
            llenar();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtfechamant.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtfecha.Text = Calendar2.SelectedDate.ToShortDateString();
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            txtproximo.Text = Calendar3.SelectedDate.ToShortDateString();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = Visible;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Calendar3.Visible = Visible;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = Visible;
        }
    }
}