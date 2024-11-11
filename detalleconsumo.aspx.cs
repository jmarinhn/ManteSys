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
    public partial class detalleconsumo : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        void refrescar()
        {
            txtidvehiculo.Text = "";
            txtidconductor.Text = "";
            txtnombrecomb.Text = "";
            txtcantidad.Text = "";
            txtfechaconsumo.Text = "";
            txtnombreestacion.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txtidvehiculo.Focus();
        }

        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT IDCONSUMO AS 'ID DE CONSUMO', ID_VEHICULO AS 'ID DE VEHICULO', ID_COND AS 'ID CONDUCTOR', NOMBRECOMB AS 'NOMBRE COMB', CANTIDAD AS 'CANTIDAD', FECHACONSUMO AS 'FECHA DE CONSUMO', NOMBREESTACION AS 'NOMBRE DE LA ESTACION', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM DETALLECONSUMO WHERE ESTADOCONSUM=1", connect);
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT IDCONSUMO AS 'ID DE CONSUMO', ID_VEHICULO AS 'ID DE VEHICULO', ID_COND AS 'ID CONDUCTOR', NOMBRECOMB AS 'NOMBRE COMB', CANTIDAD AS 'CANTIDAD', FECHACONSUMO AS 'FECHA DE CONSUMO', NOMBREESTACION AS 'NOMBRE DE LA ESTACION', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM DETALLECONSUMO WHERE ESTADOCONSUM=1 AND IDCONSUMO="+txtbuscar.Text, connect);
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

        void guardar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();
            int estado = 1;

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO DETALLECONSUMO(ID_VEHICULO, ID_COND, NOMBRECOMB, CANTIDAD, FECHACONSUMO, NOMBREESTACION, USUARIOCREACION, FECHACREACION, ESTADOCONSUM) VALUES(@IDVEHICULO, @IDCOND, @NOMBRECOMB, @CANTIDAD, @FECHACONSUMO, @NOMBREESTACION, @USUARIO, @FECHA, @ESTADO)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IDVEHICULO", txtidvehiculo.Text);
                cmd.Parameters.AddWithValue("@IDCOND", txtidconductor.Text);
                cmd.Parameters.AddWithValue("@NOMBRECOMB", txtnombrecomb.Text);
                cmd.Parameters.AddWithValue("@CANTIDAD", txtcantidad.Text);
                cmd.Parameters.AddWithValue("@FECHACONSUMO", txtfechaconsumo.Text);
                cmd.Parameters.AddWithValue("@NOMBREESTACION", txtnombreestacion.Text);
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
                SqlCommand cmd = new SqlCommand("UPDATE DETALLECONSUMO SET ID_VEHICULO=@IDVEHICULO, ID_COND=@IDCOND, NOMBRECOMB=@NOMBRECOMB, CANTIDAD=@CANTIDAD, FECHACONSUMO=@FECHACONSUMO, NOMBREESTACION=@NOMBREESTACION, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE IDCONSUMO="+txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IDVEHICULO", txtidvehiculo.Text);
                cmd.Parameters.AddWithValue("@IDCOND", txtidconductor.Text);
                cmd.Parameters.AddWithValue("@NOMBRECOMB", txtnombrecomb.Text);
                cmd.Parameters.AddWithValue("@CANTIDAD", txtcantidad.Text);
                cmd.Parameters.AddWithValue("@FECHACONSUMO", txtfechaconsumo.Text);
                cmd.Parameters.AddWithValue("@NOMBREESTACION", txtnombreestacion.Text);
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

        void eliminar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE DETALLECONSUMO SET ESTADOCONSUM=0 WHERE IDCONSUMO=" + txtbuscar.Text, connect);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = Visible;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = Visible;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtfechaconsumo.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtfecha.Text = Calendar2.SelectedDate.ToShortDateString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            guardar();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            eliminar();
        }
    }
}