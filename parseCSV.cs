using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace AdvicentCalc
{
    public class parseCSV
    {
        DataTable collegeDB = new DataTable();
        protected DataTable parseCSVMain(string mockFileName)//parse CSV file into DataTable - helper method that became obsolete
        {


            collegeDB.Columns.AddRange(new DataColumn[4]//define columns for each data category
            {
                new DataColumn("Name", typeof(string)),
                new DataColumn("InState", typeof(int)),
                new DataColumn("OutState", typeof(int)),
                new DataColumn("Lodging", typeof(int))
            });


           // string mockFileName = System.IO.Path.Combine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cost_mock.csv"));//get relative path to CSV file
            string mockData = File.ReadAllText(mockFileName);//parse data from CSV into String

            DataRow nRow = collegeDB.NewRow();//add blank row to start us off
            nRow["Name"] = "Please choose...";//dummy data
            nRow["InState"] = 0;
            nRow["OutState"] = 0;
            nRow["Lodging"] = 0;
            collegeDB.Rows.Add(nRow);

            foreach (string row in mockData.Split('\n'))
            {//split apart mockData string on newline char
                if (!string.IsNullOrEmpty(row))//if it's not empty (safety check)
                {
                    String[] columny = row.Split(',');


                    nRow = collegeDB.NewRow();//row builder
                    nRow["Name"] = columny[0];//store data in row 

                    if (string.IsNullOrEmpty(columny[1]))
                    {//some schools do not have different out of state tuition
                        nRow["InState"] = 0;//in this case, set equal to zero
                    }
                    else
                    {
                        nRow["InState"] = int.Parse(columny[1]);//otherwise, store parsed value
                    }


                    if (string.IsNullOrEmpty(columny[2]))
                    {//some schools do not have different out of state tuition
                        nRow["OutState"] = 0;//in this case, set equal to zero
                    }
                    else
                    {
                        nRow["OutState"] = int.Parse(columny[2]);//otherwise, store parsed value
                    }

                    if (string.IsNullOrEmpty(columny[3]))
                    {//some schools do not have boarding costs
                        nRow["Lodging"] = 0;//in this case, set equal to zero
                    }
                    else
                    {
                        nRow["Lodging"] = int.Parse(columny[3]);//otherwise, store parsed value
                    }
                    collegeDB.Rows.Add(nRow);

                    
                }

            }return collegeDB;
            }

        } 
    }