using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;


namespace mantenimiento1
{
    public partial class reportes : System.Web.UI.Page
    {
        string connectSQL = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        void Load_rptDetCon()
        {
            SqlConnection con = new SqlConnection(connectSQL);
            SqlCommand cmd = new SqlCommand("SELECT * FROM DETALLECONSUMO", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("Reportes/rptDetCon.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            crDetCon.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Detalle Consumo");
 
        }

        void Load_rptIncidents()
        {
            SqlConnection con = new SqlConnection(connectSQL);
            SqlCommand cmd = new SqlCommand("SELECT * FROM INCIDENTES", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("Reportes/rptIncidents.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            crIncidents.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Reporte de Incidentes");

        }

        void Load_rptMant()
        {
            SqlConnection con = new SqlConnection(connectSQL);
            SqlCommand cmd = new SqlCommand("SELECT * FROM MANTENIMIENTO", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("Reportes/rptMant.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            crMant.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Reporte de Mantenimientos");

        }

        void Load_rptSalida()
        {
            SqlConnection con = new SqlConnection(connectSQL);
            SqlCommand cmd = new SqlCommand("SELECT * FROM SALIDAS", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("Reportes/rptSalida.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            crSalidas.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Reporte de Salidas");

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDetCon_Click(object sender, EventArgs e)
        {
            Load_rptDetCon();
        } 
        
        protected void btnIncidents_Click(object sender, EventArgs e)
        {
            Load_rptIncidents();
        }
        protected void btnMant_Click(object sender, EventArgs e)
        {
            Load_rptMant();
        }
        protected void btnSalida_Click(object sender, EventArgs e)
        {
            Load_rptSalida();
        }
    }
}