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
    public partial class repuestos : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        void refrescar()
        {
            txtcod.Text = "";
            txtnombre.Text = "";
            txtcosto.Text = "";
            txtgarantia.Text = "";
            txtestado.Text = "";
            txttipo.Text = "";
            txtprocedencia.Text = "";
            txtid_mant.Text = "";
            txtusuario.Text = "";
            txtfecha.Text = "";
            txtcod.Focus();
        }
        void llenar()
        {
            SqlConnection connect;
            connect = new SqlConnection(cs);
            connect.Open();

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("SELECT CODREPUESTO AS 'CODIGO', NOMBRE_REP AS 'NOMBRE REPUESTO', COSTO_REP AS 'COSTO', TIENEGARANTIA AS 'GARANTIA', ESTADO AS 'DISPONIBILIDAD', TIPOMATERIAL AS 'MATERIAL', PROCEDENCIA AS 'PROCEDENCIA', ID_MANT AS 'ID MANTENIMIENTO',  USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM REPUESTOS WHERE ESTADOREP=1", connect);
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
                SqlDataAdapter adp = new SqlDataAdapter("SELECT CODREPUESTO AS 'CODIGO', NOMBRE_REP AS 'NOMBRE REPUESTO', COSTO_REP AS 'COSTO', TIENEGARANTIA AS 'GARANTIA', ESTADO AS 'DISPONIBILIDAD', TIPOMATERIAL AS 'MATERIAL', PROCEDENCIA AS 'PROCEDENCIA', ID_MANT AS 'ID MANTENIMIENTO',  USUARIOCREACION AS 'USUARIO CREADOR', FECHACREACION AS 'FECHA CREACION', USUARIOMODIFICACION AS 'USUARIO MODIFICADOR', FECHAMODIFICACION AS 'FECHA MODIFICACION' FROM REPUESTOS WHERE ESTADOREP=1 AND CODREPUESTO=" + txtbuscar.Text, connect);
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

            if (rb_disponible.Checked)
            {
                txtestado.Text = "1";
            }
            else
            {
                txtestado.Text = "0";
            }

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO REPUESTOS(CODREPUESTO, NOMBRE_REP, COSTO_REP, TIENEGARANTIA, ESTADO, TIPOMATERIAL, PROCEDENCIA, ID_MANT, USUARIOCREACION, FECHACREACION, ESTADOREP) VALUES(@COD, @NOMBRE, @COSTO, @GARANTIA, @ESTADO, @MATERIAL, @PROCEDENCIA, @ID_MANT, @USUARIO, @FECHA, @ESTADOREP)", connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@COD", txtcod.Text);
                cmd.Parameters.AddWithValue("@NOMBRE", txtnombre.Text);
                cmd.Parameters.AddWithValue("@COSTO", txtcosto.Text);
                cmd.Parameters.AddWithValue("@GARANTIA", txtgarantia.Text);
                cmd.Parameters.AddWithValue("@ESTADO", txtestado.Text);
                cmd.Parameters.AddWithValue("@MATERIAL", txttipo.Text);
                cmd.Parameters.AddWithValue("@PROCEDENCIA", txtprocedencia.Text);
                cmd.Parameters.AddWithValue("@ID_MANT", txtid_mant.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);
                cmd.Parameters.AddWithValue("@ESTADOREP", estado);

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

            if (rb_disponible.Checked)
            {
                txtestado.Text = "1";
            }
            else
            {
                txtestado.Text = "0";
            }

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE REPUESTOS SET NOMBRE_REP=@NOMBRE, COSTO_REP=@COSTO, TIENEGARANTIA=@GARANTIA, ESTADO=@ESTADO, TIPOMATERIAL=@MATERIAL, PROCEDENCIA=@PROCEDENCIA, ID_MANT=@ID_MANT, USUARIOMODIFICACION=@USUARIO, FECHAMODIFICACION=@FECHA WHERE CODREPUESTO=" + txtbuscar.Text, connect);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NOMBRE", txtnombre.Text);
                cmd.Parameters.AddWithValue("@COSTO", txtcosto.Text);
                cmd.Parameters.AddWithValue("@GARANTIA", txtgarantia.Text);
                cmd.Parameters.AddWithValue("@ESTADO", txtestado.Text);
                cmd.Parameters.AddWithValue("@MATERIAL", txttipo.Text);
                cmd.Parameters.AddWithValue("@PROCEDENCIA", txtprocedencia.Text);
                cmd.Parameters.AddWithValue("@ID_MANT", txtid_mant.Text);
                cmd.Parameters.AddWithValue("@USUARIO", txtusuario.Text);
                cmd.Parameters.AddWithValue("@FECHA", txtfecha.Text);

                cmd.ExecuteNonQuery();
                Response.Write("REGISTRO MODIFICADO");
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
                SqlCommand cmd = new SqlCommand("UPDATE REPUESTOS SET ESTADOREP=0 WHERE CODREPUESTO=" + txtbuscar.Text, connect);
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


        protected void Button5_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = Visible;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtfecha.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            eliminar();
        }
    }
}