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
    public partial class dentregav : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        void refrescar()
        {
            txtfrecepcion.Text = "";
            txtidvehiculo.Text = "";
            txtidcond.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txtfrecepcion.Focus();
        }

        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT IDENTREGAV AS 'ID DE ENTREGA', FRECEPCION AS 'FECHA DE RECEPCION', ID_VEHICULO AS 'ID VEHICULO', ID_COND AS 'ID CONDUCTOR', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM DENTREGAV WHERE ESTADODENTRE=1", connect);
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT IDENTREGAV AS 'ID DE ENTREGA', FRECEPCION AS 'FECHA DE RECEPCION', ID_VEHICULO AS 'ID VEHICULO', ID_COND AS 'ID CONDUCTOR', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM DENTREGAV WHERE ESTADODENTRE=1 AND IDENTREGAV="+txtbuscar.Text, connect);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO DENTREGAV(FRECEPCION, ID_VEHICULO, ID_COND, USUARIOCREACION, FECHACREACION, ESTADODENTRE) VALUES(@FRECEPCION, @IDVEHICULO, @IDCOND, @USUARIO, @FECHA, @ESTADO)",connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FRECEPCION", txtfrecepcion.Text);
                cmd.Parameters.AddWithValue("@IDVEHICULO", txtidvehiculo.Text);
                cmd.Parameters.AddWithValue("@IDCOND", txtidcond.Text);
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
                SqlCommand cmd = new SqlCommand("UPDATE DENTREGAV SET FRECEPCION=@FRECEPCION, ID_VEHICULO=@IDVEHICULO, ID_COND=@IDCOND, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE IDENTREGAV="+txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FRECEPCION", txtfrecepcion.Text);
                cmd.Parameters.AddWithValue("@IDVEHICULO", txtidvehiculo.Text);
                cmd.Parameters.AddWithValue("@IDCOND", txtidcond.Text);
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
                SqlCommand cmd = new SqlCommand("UPDATE DENTREGAV SET ESTADODENTRE=0 WHERE IDENTREGAV=" + txtbuscar.Text, connect);
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
            txtfrecepcion.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtfecha.Text = Calendar2.SelectedDate.ToShortDateString();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            refrescar();
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