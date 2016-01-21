using System;
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

                string Comm = "SELECT * FROM Journal_Data;";

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
                        journalData[i].Submit = SQLdset.Tables[tableName].Rows[i]["SubmitLink"].ToString();
                       
                        
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

                   
                        string sql;


                        SqlCeCommand comm = new SqlCeCommand();

                        comm.CommandType = CommandType.Text;
                        comm.Connection = SQLCon;


                        int count = journalDataList.Length;


                        for (int i = 0; i < count; i++ )
                        {
                            

                           
                                sql = "INSERT INTO " + tableName + "(JournalName, JournalLink, Keywords, Website, SubmitLink) VALUES('" + journalDataList[i].Name + "','" + journalDataList[i].Link + "','" + journalDataList[i].Keywords.ToLower() + "','" + journalDataList[i].Website + "','" + journalDataList[i].Submit + "');";

                           

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