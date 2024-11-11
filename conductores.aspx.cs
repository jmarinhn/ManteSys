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
    public partial class conductores : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        void refrescar()
        {
            txtci.Text = "";
            txtnombre.Text = "";
            txtapaterno.Text = "";
            txtamaterno.Text = "";
            txtfingreso.Text = "";
            txtdireccion.Text = "";
            txtgenero.Text = "";
            txtnacionalidad.Text = "";
            txttelefono.Text = "";
            txtcelular.Text = "";
            txtestado.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txtci.Focus();
        }

        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_COND AS 'ID CONDUCTOR',CI AS 'IDENTIDAD', NOMBRE AS 'NOMBRE', APATERNO AS 'PRIMER APELLIDO', AMATERNO AS 'SEGUNDO APELLIDO', FINGRESO AS 'FECHA INGRESO', DIRECCION AS 'DIRECCION', ID_GENERO AS 'GENERO', NACIONALIDAD AS 'NACIONALIDAD',  TELEFONO AS 'TELEFONO', CELULAR AS 'CELULAR', ESTADO AS 'ESTADO', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM CONDUCTORES WHERE ESTADOCONDU=1", connect);
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT ID_COND AS 'ID CONDUCTOR',CI AS 'IDENTIDAD', NOMBRE AS 'NOMBRE', APATERNO AS 'PRIMER APELLIDO', AMATERNO AS 'SEGUNDO APELLIDO', FINGRESO AS 'FECHA INGRESO', DIRECCION AS 'DIRECCION', ID_GENERO AS 'GENERO', NACIONALIDAD AS 'NACIONALIDAD',  TELEFONO AS 'TELEFONO', CELULAR AS 'CELULAR', ESTADO AS 'ESTADO', USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM CONDUCTORES WHERE ESTADOCONDU=1 and ID_COND=" + txtbuscar.Text, connect);
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

            if (rb_activo.Checked)
            {
                txtestado.Text = "1";
            }
            else
            {
                txtestado.Text = "0";
            }

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO CONDUCTORES(CI, NOMBRE, APATERNO, AMATERNO, FINGRESO, DIRECCION, ID_GENERO, NACIONALIDAD, TELEFONO, CELULAR, ESTADO, USUARIOCREACION, FECHACREACION, ESTADOCONDU) VALUES(@IDENTIDAD, @NOMBRE, @APATERNO, @AMATERNO, @FINGRESO, @DIRECCION, @ID_GENERO, @NACIONALIDAD, @TELEFONO, @CELULAR, @ESTADO, @USUARIO, @FECHA, @ESTADOCONDU)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IDENTIDAD", txtci.Text);
                cmd.Parameters.AddWithValue("@NOMBRE", txtnombre.Text);
                cmd.Parameters.AddWithValue("@APATERNO", txtapaterno.Text);
                cmd.Parameters.AddWithValue("@AMATERNO", txtamaterno.Text);
                cmd.Parameters.AddWithValue("@FINGRESO", txtfingreso.Text);
                cmd.Parameters.AddWithValue("@DIRECCION", txtdireccion.Text);
                cmd.Parameters.AddWithValue("@ID_GENERO", txtgenero.Text);
                cmd.Parameters.AddWithValue("@NACIONALIDAD", txtnacionalidad.Text);
                cmd.Parameters.AddWithValue("@TELEFONO", txttelefono.Text);
                cmd.Parameters.AddWithValue("@CELULAR", txtcelular.Text);
                cmd.Parameters.AddWithValue("@ESTADO", txtestado.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);
                cmd.Parameters.AddWithValue("@ESTADOCONDU", estado);

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
            int estado = 1;

            if (rb_activo.Checked)
            {
                txtestado.Text = "1";
            }
            else
            {
                txtestado.Text = "0";
            }

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE CONDUCTORES SET CI=@IDENTIDAD, NOMBRE=@NOMBRE, APATERNO=@APATERNO, AMATERNO=@AMATERNO, FINGRESO=@FINGRESO, DIRECCION=@DIRECCION, ID_GENERO=@ID_GENERO, NACIONALIDAD=@NACIONALIDAD, TELEFONO=@TELEFONO, CELULAR=@CELULAR, ESTADO=@ESTADO, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE ID_COND="+ txtbuscar.Text, connect);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IDENTIDAD", txtci.Text);
                cmd.Parameters.AddWithValue("@NOMBRE", txtnombre.Text);
                cmd.Parameters.AddWithValue("@APATERNO", txtapaterno.Text);
                cmd.Parameters.AddWithValue("@AMATERNO", txtamaterno.Text);
                cmd.Parameters.AddWithValue("@FINGRESO", txtfingreso.Text);
                cmd.Parameters.AddWithValue("@DIRECCION", txtdireccion.Text);
                cmd.Parameters.AddWithValue("@ID_GENERO", txtgenero.Text);
                cmd.Parameters.AddWithValue("@NACIONALIDAD", txtnacionalidad.Text);
                cmd.Parameters.AddWithValue("@TELEFONO", txttelefono.Text);
                cmd.Parameters.AddWithValue("@CELULAR", txtcelular.Text);
                cmd.Parameters.AddWithValue("@ESTADO", txtestado.Text);
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
                SqlCommand cmd = new SqlCommand("UPDATE CONDUCTORES SET ESTADOCONDU=0 WHERE ID_COND=" + txtbuscar.Text, connect);
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
            txtfingreso.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtfecha.Text = Calendar2.SelectedDate.ToShortDateString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = Visible;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = Visible;
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