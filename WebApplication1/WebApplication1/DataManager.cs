﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DataManager
    {
        static DataSet SQLdset;
        static SqlCeDataAdapter SQLAdp;
     
        static SqlCeConnection SQLCon;
            
            public DataManager()
        {
            
                        

                

     
           
        }



            public static Journal[] GetJournalData()
            {
                Journal[] journalData = new Journal[1]; // sample declaration to prevent compile time error

                SQLCon = new SqlCeConnection();

                string tableName = "Journal_Data";
                string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";

                 SQLCon.ConnectionString = ConString; 

              
               
                SQLCon.Open();

                string Comm = "SELECT * FROM ";

                SQLAdp.Fill(SQLdset,tableName);

                SQLCon.Close();


                if (SQLdset != null)
                {
                    ;
                    int j = SQLdset.Tables[tableName].Rows.Count;
                   

                 journalData = new Journal[j];
                    ;

                    for (int i = 0; i < j ; i++)
                    {
                        journalData[i] = new Journal();

                        journalData[i].Name = SQLdset.Tables[tableName].Rows[i]["JournalName"].ToString();
                        journalData[i].Link = SQLdset.Tables[tableName].Rows[i]["JournalLink"].ToString();
                        journalData[i].Website = SQLdset.Tables[tableName].Rows[i]["Website"].ToString();
                        journalData[i].Keywords = SQLdset.Tables[tableName].Rows[i]["Keywords"].ToString();
                       
                        
                    }
                }
                return journalData;

            }



            public static void SetJournalData(Journal[] journalDataList)
            {
                string tableName = "Journal_Data";
                
                SQLCon = new SqlCeConnection();

                string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";
                
                SQLCon.ConnectionString = ConString;




                if (SQLCon != null)
                {
                    SQLCon.Open();

                    if (DeleteOnUpdate(tableName))
                    {
                        string sql;


                        SqlCeCommand comm = new SqlCeCommand();

                        comm.CommandType = CommandType.Text;
                        comm.Connection = SQLCon;



                        foreach (Journal journal in journalDataList)
                        {
                           
                            sql = "INSERT INTO " + tableName + "(JournalName, JournalLink, Website, Keywords) VALUES('" + journal.Name + "','" + journal.Link + "','" + journal.Website + "','" + journal.Keywords.ToLower() + "');";
                            comm.CommandText = sql;

                            try
                            {



                                comm.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                            finally
                            {


                            }
                        }
                        SQLCon.Close();
                    }
                }
               

                
            
            }


            static bool DeleteOnUpdate(string tableName)
            {

                 SQLCon = new SqlCeConnection();

                string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";
                
                SQLCon.ConnectionString = ConString;

                bool status = false;


                if (SQLCon != null)
                {
                    SQLCon.Open();
                    string sql;

                     sql = "DELETE " + tableName;

                    SqlCeCommand comm = new SqlCeCommand();
                    comm.CommandText = sql;
                    comm.CommandType = CommandType.Text;
                    comm.Connection = SQLCon;


                    try
                    {



                        comm.ExecuteNonQuery();
                        status = true;
                       

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        status = false;
                       
                    }
                }
                return status;

               
            }
    }
}