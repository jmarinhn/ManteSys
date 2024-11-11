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
    public partial class salidas : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        void refrescar()
        {
            txtlsalida.Text = "";
            txtldestino.Text = "";
            txtnpersonas.Text = "";
            txtcosto.Text = "";
            txtasunto.Text = "";
            txtfsalida.Text = "";
            txtfretorno.Text = "";
            txtid_conductor.Text = "";
            txtid_vehiculo.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txtlsalida.Focus();
        }

        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT NUMSALIDA AS 'NUMERO DE SALIDA',LSALIDA AS 'LUGAR DE SALIDA', LDESTINO AS 'LUGAR DE DESTINO', NPERSONAS AS 'NUMERO DE PERSONAS', COSTO AS 'COSTO', ASUNTO AS 'ASUNTO', FSALIDA AS 'FECHA DE SALIDA', FRETORNO AS 'FECHA DE RETORNO', ID_COND AS 'ID CONDUCTOR',  ID_VEHICULO AS 'ID VEHICULO', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM SALIDAS WHERE ESTADOSAL=1", connect);
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT NUMSALIDA AS 'NUMERO DE SALIDA',LSALIDA AS 'LUGAR DE SALIDA', LDESTINO AS 'LUGAR DE DESTINO', NPERSONAS AS 'NUMERO DE PERSONAS', COSTO AS 'COSTO', ASUNTO AS 'ASUNTO', FSALIDA AS 'FECHA DE SALIDA', FRETORNO AS 'FECHA DE RETORNO', ID_COND AS 'ID CONDUCTOR',  ID_VEHICULO AS 'ID VEHICULO', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM SALIDAS WHERE ESTADOSAL=1 AND NUMSALIDA="+txtbuscar.Text, connect);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO SALIDAS(LSALIDA, LDESTINO, NPERSONAS, COSTO, ASUNTO, FSALIDA, FRETORNO, ID_COND, ID_VEHICULO, USUARIOCREACION, FECHACREACION, ESTADOSAL) VALUES(@LSALIDA, @LDESTINO, @NPERSONAS, @COSTO, @ASUNTO, @FSALIDA, @FRETORNO, @IDCOND, @IDVEHICULO, @USUARIO, @FECHA, @ESTADOSAL)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@LSALIDA", txtlsalida.Text);
                cmd.Parameters.AddWithValue("@LDESTINO", txtldestino.Text);
                cmd.Parameters.AddWithValue("@NPERSONAS", txtnpersonas.Text);
                cmd.Parameters.AddWithValue("@COSTO", txtcosto.Text);
                cmd.Parameters.AddWithValue("@ASUNTO", txtasunto.Text);
                cmd.Parameters.AddWithValue("@FSALIDA", txtfsalida.Text);
                cmd.Parameters.AddWithValue("@FRETORNO", txtfretorno.Text);
                cmd.Parameters.AddWithValue("@IDCOND", txtid_conductor.Text);
                cmd.Parameters.AddWithValue("@IDVEHICULO", txtid_vehiculo.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);
                cmd.Parameters.AddWithValue("@ESTADOSAL", estado);

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
                SqlCommand cmd = new SqlCommand("UPDATE SALIDAS SET LSALIDA=@LSALIDA, LDESTINO=@LDESTINO, NPERSONAS=@NPERSONAS, COSTO=@COSTO, ASUNTO=@ASUNTO, FSALIDA=@FSALIDA, FRETORNO=@FRETORNO, ID_COND=@IDCOND, ID_VEHICULO=@IDVEHICULO, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE NUMSALIDA=" + txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@LSALIDA", txtlsalida.Text);
                cmd.Parameters.AddWithValue("@LDESTINO", txtldestino.Text);
                cmd.Parameters.AddWithValue("@NPERSONAS", txtnpersonas.Text);
                cmd.Parameters.AddWithValue("@COSTO", txtcosto.Text);
                cmd.Parameters.AddWithValue("@ASUNTO", txtasunto.Text);
                cmd.Parameters.AddWithValue("@FSALIDA", txtfsalida.Text);
                cmd.Parameters.AddWithValue("@FRETORNO", txtfretorno.Text);
                cmd.Parameters.AddWithValue("@IDCOND", txtid_conductor.Text);
                cmd.Parameters.AddWithValue("@IDVEHICULO", txtid_vehiculo.Text);
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
                SqlCommand cmd = new SqlCommand("UPDATE SALIDAS SET ESTADOSAL=0 WHERE NUMSALIDA=" + txtbuscar.Text, connect);
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
            txtfsalida.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtfretorno.Text = Calendar2.SelectedDate.ToShortDateString();
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            txtfecha.Text = Calendar3.SelectedDate.ToShortDateString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = Visible;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = Visible;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Calendar3.Visible = Visible;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            guardar();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            eliminar();
        }
    }
}