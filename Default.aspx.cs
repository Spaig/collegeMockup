using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace AdvicentCalc
{
    public partial class Default : System.Web.UI.Page
    {
        
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;//SQL connection string

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {

            int baseCost = 0, inCost = 0, outCost = 0, boardCost = 0;
            int stateful = rdoStateful.SelectedIndex;//get the state of state - 0 is in, 1 is out
            int eyedee = ddlCollege.SelectedIndex;//get selected index
            List<Int32> costs = new List<Int32>();//list to store output

            string command = "SELECT [inCost] FROM [dbo].[collegeTable] WHERE ([Id] = "+eyedee+")";//query sql DB for in-state cost
            inCost = grabSQLInt(command);

            command = "SELECT [outCost] FROM [dbo].[collegeTable] WHERE ([Id] = " + eyedee + ")";//query sql DB for out of state costs
            outCost = grabSQLInt(command);

            command = "SELECT [boardCost] FROM [dbo].[collegeTable] WHERE ([Id] = " + eyedee + ")";//query sql DB for room and board costs
            boardCost = grabSQLInt(command);

            if (stateful == 0)
            {//if in-state tuition checked
                if (inCost > 0)
                {//and in-state tuition exists
                    baseCost = inCost;//use in-state tuition
                }
                else
                {
                    baseCost = outCost; //else use other tution
                }
            }
            else {//if out of state tuition checked 
                if (outCost > 0)
                {//and out-of-state tuition exists
                    baseCost = outCost;//use out-of-state tuition
                }
                else
                {
                    baseCost = inCost; //else use other tution
                }
            }




            if (chkBoxBoard.Checked) { baseCost = baseCost + boardCost; }//if room and board checked, add costs


            String result = baseCost.ToString("C0");
            lblTotal.Text = result;
        }

        private int grabSQLInt(string command)//helper method for getting int from SQL 
        {
            int input = 0;
            String temp = null;
            using (SqlConnection myConnection = new SqlConnection(connection))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand(command, myConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           temp = reader[0].ToString();
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(temp)) { input = int.Parse(temp); }//if value exists, pass it out
            return input;
        }

        protected void ddlCollege_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rdoStateful_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkBoxBoard_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void collegeSQLData_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

    }
}

//TODO get number values as int
//TODO display math