using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreFront
{
    public partial class CustomerAdminDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            /* string UserID = Request.QueryString[0];
             string MyConnectionString = ConfigurationManager.ConnectionStrings["StoreFrontConnectionString1"].ConnectionString;
             SqlConnection MyConnection = new SqlConnection(MyConnectionString);
             SqlDataAdapter MyDataAdapter = new SqlDataAdapter("spDeleteUser", MyConnection);
             SqlCommand command = new SqlCommand("spDeleteUser " + UserID, MyConnection);
             command.CommandType = CommandType.Text;
             MyConnection.Open();
             command.ExecuteReader();
             MyConnection.Close();
         */
            

            string MyConnectionString = ConfigurationManager.ConnectionStrings["StoreFrontConnectionString1"].ConnectionString;
            using (SqlConnection myConnection = new SqlConnection(MyConnectionString))
            {
                using(SqlCommand command = new SqlCommand("spDeleteUser", myConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = DetailsView1.SelectedValue;

                    myConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
       
        }
    }

}