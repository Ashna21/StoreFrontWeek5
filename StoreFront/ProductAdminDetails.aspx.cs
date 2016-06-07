using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace StoreFront
{
    public partial class ProductAdminDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ProductID = Request.QueryString[0];
            string MyConnectionString = ConfigurationManager.ConnectionStrings["StoreFrontConnectionString1"].ConnectionString;
            using (SqlConnection myConnection = new SqlConnection(MyConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spDeleteProduct", myConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID;

                    myConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}