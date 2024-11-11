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
    public partial class neumaticos : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        void refrescar()
        {
            txtcodneu.Text = "";
            txtmarca.Text = "";
            txtprecio.Text = "";
            txtgarantia.Text = "";
            txtduracion.Text = "";
            txtconcar.Text = "";
            txtsincar.Text = "";
            txtcarga.Text = "";
            txtcantidad.Text = "";
            txtfechaentrega.Text = "";
            txtid_vehiculo.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txtcodneu.Focus();
        }
        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_NEU AS 'ID NEUMATICO',CODNEUMATICO AS 'CODIGO', MARCA AS 'MARCA', PRECIO AS 'PRECIO', TIENEGARANTIA AS 'GARANTIA', DURACION AS 'DURACION', PRES_INFLA_CONCAR AS 'PRESION CONCAR', PRES_INFLA_SINCAR AS 'PRESION SINCAR', CARGAMAX AS 'CARGA MAXIMA',  CANTIDAD AS 'CANTIDAD', FENTREGA AS 'FECHA DE ENTREGA', ID_VEHICULO AS 'ID VEHICULO', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM NEUMATICOS WHERE ESTADONEU=1", connect);
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_NEU AS 'ID NEUMATICO', CODNEUMATICO AS 'CODIGO', MARCA AS 'MARCA', PRECIO AS 'PRECIO', TIENEGARANTIA AS 'GARANTIA', DURACION AS 'DURACION', PRES_INFLA_CONCAR AS 'PRESION CONCAR', PRES_INFLA_SINCAR AS 'PRESION SINCAR', CARGAMAX AS 'CARGA MAXIMA',  CANTIDAD AS 'CANTIDAD', FENTREGA AS 'FECHA DE ENTREGA', ID_VEHICULO AS 'ID VEHICULO', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM NEUMATICOS WHERE ESTADONEU=1 AND ID_NEU=" + txtbuscar.Text, connect);
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

        void guardar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();
            int estado = 1;

            if (rb_si.Checked)
            {
                txtgarantia.Text = "1";
            }
            else
            {
                txtgarantia.Text = "0";
            }

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO NEUMATICOS(CODNEUMATICO, MARCA, PRECIO, TIENEGARANTIA, DURACION, PRES_INFLA_CONCAR, PRES_INFLA_SINCAR, CARGAMAX, CANTIDAD, FENTREGA, ID_VEHICULO, USUARIOCREACION, FECHACREACION, ESTADONEU) VALUES(@CODNEU, @MARCA, @PRECIO, @GARANTIA, @DURACION, @CONCAR, @SINCAR, @CARGA, @CANTIDAD, @FENTREGA, @ID_VEHICULO, @USUARIO, @FECHA, @ESTADONEU)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CODNEU", txtcodneu.Text);
                cmd.Parameters.AddWithValue("@MARCA", txtmarca.Text);
                cmd.Parameters.AddWithValue("@PRECIO", txtprecio.Text);
                cmd.Parameters.AddWithValue("@GARANTIA", txtgarantia.Text);
                cmd.Parameters.AddWithValue("@DURACION", txtduracion.Text);
                cmd.Parameters.AddWithValue("@CONCAR", txtconcar.Text);
                cmd.Parameters.AddWithValue("@SINCAR", txtsincar.Text);
                cmd.Parameters.AddWithValue("@CARGA", txtcarga.Text);
                cmd.Parameters.AddWithValue("@CANTIDAD", txtcantidad.Text);
                cmd.Parameters.AddWithValue("@FENTREGA", txtfechaentrega.Text);
                cmd.Parameters.AddWithValue("@ID_VEHICULO", txtid_vehiculo.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);
                cmd.Parameters.AddWithValue("@ESTADONEU", estado);

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

            if (rb_si.Checked)
            {
                txtgarantia.Text = "1";
            }
            else
            {
                txtgarantia.Text = "0";
            }

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE NEUMATICOS SET CODNEUMATICO=@CODNEU, MARCA=@MARCA, PRECIO=@PRECIO, TIENEGARANTIA=@GARANTIA, DURACION=@DURACION, PRES_INFLA_CONCAR=@CONCAR, PRES_INFLA_SINCAR=@SINCAR, CARGAMAX=@CARGA, CANTIDAD=@CANTIDAD, FENTREGA=@FENTREGA, ID_VEHICULO=@ID_VEHICULO, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE ID_NEU="+ txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CODNEU", txtcodneu.Text);
                cmd.Parameters.AddWithValue("@MARCA", txtmarca.Text);
                cmd.Parameters.AddWithValue("@PRECIO", txtprecio.Text);
                cmd.Parameters.AddWithValue("@GARANTIA", txtgarantia.Text);
                cmd.Parameters.AddWithValue("@DURACION", txtduracion.Text);
                cmd.Parameters.AddWithValue("@CONCAR", txtconcar.Text);
                cmd.Parameters.AddWithValue("@SINCAR", txtsincar.Text);
                cmd.Parameters.AddWithValue("@CARGA", txtcarga.Text);
                cmd.Parameters.AddWithValue("@CANTIDAD", txtcantidad.Text);
                cmd.Parameters.AddWithValue("@FENTREGA", txtfechaentrega.Text);
                cmd.Parameters.AddWithValue("@ID_VEHICULO", txtid_vehiculo.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);

                cmd.ExecuteNonQuery();
                Response.Write("REGISTRO ALMACENADO");
                llenar();

            }
            catch(Exception e)
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
                SqlCommand cmd = new SqlCommand("UPDATE NEUMATICOS SET ESTADONEU=0 WHERE ID_NEU=" + txtbuscar.Text, connect);
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
            txtfechaentrega.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtfecha.Text = Calendar2.SelectedDate.ToShortDateString();
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            eliminar();
        }
    }
}