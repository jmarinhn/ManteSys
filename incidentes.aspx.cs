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
    public partial class incidentes : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        void refrescar()
        {
            txttipo.Text = "";
            txtdescripcion.Text = "";
            txtgasto.Text = "";
            txtfincidente.Text = "";
            txtidcond.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txttipo.Focus();
        }

        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT IDINCIDENTE AS 'ID DE INCIDENTE', TIPO_INCIDENTE AS'TIPO DE INCIDENTE', DESCRIPCION AS 'DESCRIPCION', GASTO_INCIDENTE AS 'GASTO DE INCIDENTE', FINCIDENTE AS 'FECHA DE INCIDENTE', ID_COND AS 'ID DEL CONDUCTOR', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM INCIDENTES WHERE ESTADOINCID=1", connect);
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT IDINCIDENTE AS 'ID DE INCIDENTE', TIPO_INCIDENTE AS'TIPO DE INCIDENTE', DESCRIPCION AS 'DESCRIPCION', GASTO_INCIDENTE AS 'GASTO DE INCIDENTE', FINCIDENTE AS 'FECHA DE INCIDENTE', ID_COND AS 'ID DEL CONDUCTOR', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM INCIDENTES WHERE ESTADOINCID=1 AND IDINCIDENTE="+txtbuscar.Text, connect);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO INCIDENTES(TIPO_INCIDENTE, DESCRIPCION, GASTO_INCIDENTE, FINCIDENTE, ID_COND, USUARIOCREACION, FECHACREACION, ESTADOINCID) VALUES(@TIPO, @DESCRIPCION, @GASTO, @FINCIDENTE, @IDCOND, @USUARIO, @FECHA, @ESTADO)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@TIPO", txttipo.Text);
                cmd.Parameters.AddWithValue("@DESCRIPCION", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@GASTO", txtgasto.Text);
                cmd.Parameters.AddWithValue("@FINCIDENTE", txtfincidente.Text);
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
                SqlCommand cmd = new SqlCommand("UPDATE INCIDENTES SET TIPO_INCIDENTE=@TIPO, DESCRIPCION=@DESCRIPCION, GASTO_INCIDENTE=@GASTO, FINCIDENTE=@FINCIDENTE, ID_COND=@IDCOND, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE IDINCIDENTE="+txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@TIPO", txttipo.Text);
                cmd.Parameters.AddWithValue("@DESCRIPCION", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@GASTO", txtgasto.Text);
                cmd.Parameters.AddWithValue("@FINCIDENTE", txtfincidente.Text);
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
                SqlCommand cmd = new SqlCommand("UPDATE INCIDENTES SET ESTADOINCID=0 WHERE IDINCIDENTE=" + txtbuscar.Text, connect);
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
            txtfincidente.Text = Calendar1.SelectedDate.ToShortDateString();
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