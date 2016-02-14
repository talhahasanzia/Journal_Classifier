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
       
            
            public DataManager()
        {
            
                        

                

     
           
        }



            public static Journal[] GetSpringerData()
            {

                 DataSet SQLdset;
                 SqlCeDataAdapter SQLAdp;
     
                SqlCeConnection SQLCon;

                Journal[] journalData = new Journal[1]; // sample declaration to prevent compile time error

                try
                {
                    SQLCon = new SqlCeConnection();

                    string tableName = "Journal_Data";
                    string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";

                    SQLCon.ConnectionString = ConString;

                    SQLdset = new DataSet();
                    SQLAdp = new SqlCeDataAdapter();

                    SQLCon.Open();

                    string Comm = "SELECT DISTINCT JournalName FROM Journal_Data WHERE Website='Springer'";

                    SqlCeCommand command = new SqlCeCommand(Comm);
                    command.Connection = SQLCon;
                    SQLAdp.SelectCommand = command;

                    SQLAdp.Fill(SQLdset, tableName);


                    SQLCon.Close();


                    if (SQLdset != null)
                    {
                        ;
                        int j = SQLdset.Tables[tableName].Rows.Count;


                        journalData = new Journal[j];
                        ;

                        for (int i = 0; i < j; i++)
                        {
                            DataSet SQLdset2 = new DataSet();
                            SQLCon.Open();

                            Comm = "SELECT * FROM Journal_Data Where JournalName='" + SQLdset.Tables[tableName].Rows[i]["JournalName"].ToString() + "';"; ;

                            SqlCeDataAdapter SQLAdp2 = new SqlCeDataAdapter(); ;
                            SqlCeCommand command2 = new SqlCeCommand(Comm);
                            command2.Connection = SQLCon;
                            SQLAdp2.SelectCommand = command2;


                            SQLAdp2.Fill(SQLdset2, tableName);

                            SQLCon.Close();

                            journalData[i] = new Journal();

                            journalData[i].Name = SQLdset2.Tables[tableName].Rows[0]["JournalName"].ToString();
                            journalData[i].Link = SQLdset2.Tables[tableName].Rows[0]["JournalLink"].ToString();
                            journalData[i].Website = SQLdset2.Tables[tableName].Rows[0]["Website"].ToString();
                            journalData[i].Keywords = SQLdset2.Tables[tableName].Rows[0]["Keywords"].ToString();
                            journalData[i].Submit = SQLdset2.Tables[tableName].Rows[0]["SubmitLink"].ToString();


                        }
                    }
                }
                catch (Exception ec)
                { }
                return journalData;

            }

            public static Journal[] GetEmeraldData()
            {

                DataSet SQLdset;
                SqlCeDataAdapter SQLAdp;

                SqlCeConnection SQLCon;
                Journal[] journalData = new Journal[1]; // sample declaration to prevent compile time error
                try
                {
                    SQLCon = new SqlCeConnection();

                    string tableName = "Journal_Data";
                    string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";

                    SQLCon.ConnectionString = ConString;

                    SQLdset = new DataSet();
                    SQLAdp = new SqlCeDataAdapter();

                    SQLCon.Open();

                    string Comm = "SELECT DISTINCT JournalName FROM Journal_Data WHERE Website='Emerald'";

                    SqlCeCommand command = new SqlCeCommand(Comm);
                    command.Connection = SQLCon;
                    SQLAdp.SelectCommand = command;

                    SQLAdp.Fill(SQLdset, tableName);


                    SQLCon.Close();


                    if (SQLdset != null)
                    {
                        ;
                        int j = SQLdset.Tables[tableName].Rows.Count;


                        journalData = new Journal[j];
                        ;

                        for (int i = 0; i < j; i++)
                        {
                            DataSet SQLdset2 = new DataSet();
                            SQLCon.Open();

                            Comm = "SELECT * FROM Journal_Data Where JournalName='" + SQLdset.Tables[tableName].Rows[i]["JournalName"].ToString() + "';"; ;

                            SqlCeDataAdapter SQLAdp2 = new SqlCeDataAdapter(); ;
                            SqlCeCommand command2 = new SqlCeCommand(Comm);
                            command2.Connection = SQLCon;
                            SQLAdp2.SelectCommand = command2;


                            SQLAdp2.Fill(SQLdset2, tableName);

                            SQLCon.Close();

                            journalData[i] = new Journal();

                            journalData[i].Name = SQLdset2.Tables[tableName].Rows[0]["JournalName"].ToString();
                            journalData[i].Link = SQLdset2.Tables[tableName].Rows[0]["JournalLink"].ToString();
                            journalData[i].Website = SQLdset2.Tables[tableName].Rows[0]["Website"].ToString();
                            journalData[i].Keywords = SQLdset2.Tables[tableName].Rows[0]["Keywords"].ToString();
                            journalData[i].Submit = SQLdset2.Tables[tableName].Rows[0]["SubmitLink"].ToString();


                        }
                    }
                }
                catch (Exception ed)
                { }
                return journalData;

            }
            public static Journal[] GetACMData()
            {


                DataSet SQLdset;
                SqlCeDataAdapter SQLAdp;

                SqlCeConnection SQLCon;
                Journal[] journalData = new Journal[1]; // sample declaration to prevent compile time error
                try
                {
                    SQLCon = new SqlCeConnection();

                    string tableName = "Journal_Data";
                    string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";

                    SQLCon.ConnectionString = ConString;

                    SQLdset = new DataSet();
                    SQLAdp = new SqlCeDataAdapter();

                    SQLCon.Open();

                    string Comm = "SELECT DISTINCT JournalName FROM Journal_Data WHERE Website='ACM'";

                    SqlCeCommand command = new SqlCeCommand(Comm);
                    command.Connection = SQLCon;
                    SQLAdp.SelectCommand = command;

                    SQLAdp.Fill(SQLdset, tableName);


                    SQLCon.Close();


                    if (SQLdset != null)
                    {
                        ;
                        int j = SQLdset.Tables[tableName].Rows.Count;


                        journalData = new Journal[j];
                        ;

                        for (int i = 0; i < j; i++)
                        {
                            DataSet SQLdset2 = new DataSet();
                            SQLCon.Open();

                            Comm = "SELECT * FROM Journal_Data Where JournalName='" + SQLdset.Tables[tableName].Rows[i]["JournalName"].ToString() + "';"; ;

                            SqlCeDataAdapter SQLAdp2 = new SqlCeDataAdapter(); ;
                            SqlCeCommand command2 = new SqlCeCommand(Comm);
                            command2.Connection = SQLCon;
                            SQLAdp2.SelectCommand = command2;


                            SQLAdp2.Fill(SQLdset2, tableName);

                            SQLCon.Close();

                            journalData[i] = new Journal();

                            journalData[i].Name = SQLdset2.Tables[tableName].Rows[0]["JournalName"].ToString();
                            journalData[i].Link = SQLdset2.Tables[tableName].Rows[0]["JournalLink"].ToString();
                            journalData[i].Website = SQLdset2.Tables[tableName].Rows[0]["Website"].ToString();
                            journalData[i].Keywords = SQLdset2.Tables[tableName].Rows[0]["Keywords"].ToString();
                            journalData[i].Submit = SQLdset2.Tables[tableName].Rows[0]["SubmitLink"].ToString();


                        }
                    }
                }
                catch (Exception ef)
                { }
                return journalData;

            }


            public static Journal[] GetJournalData()
            {


                DataSet SQLdset;
                SqlCeDataAdapter SQLAdp;

                SqlCeConnection SQLCon;
                Journal[] journalData = new Journal[1]; // sample declaration to prevent compile time error
                try
                {
                    SQLCon = new SqlCeConnection();

                    string tableName = "Journal_Data";
                    string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";

                    SQLCon.ConnectionString = ConString;

                    SQLdset = new DataSet();
                    SQLAdp = new SqlCeDataAdapter();

                    SQLCon.Open();

                    string Comm = "SELECT DISTINCT JournalName FROM Journal_Data";

                    SqlCeCommand command = new SqlCeCommand(Comm);
                    command.Connection = SQLCon;
                    SQLAdp.SelectCommand = command;

                    SQLAdp.Fill(SQLdset, tableName);


                    SQLCon.Close();


                    if (SQLdset != null)
                    {
                        ;
                        int j = SQLdset.Tables[tableName].Rows.Count;


                        journalData = new Journal[j];
                        ;

                        for (int i = 0; i < j; i++)
                        {
                            DataSet SQLdset2 = new DataSet();
                            SQLCon.Open();

                            Comm = "SELECT * FROM Journal_Data Where JournalName='" + SQLdset.Tables[tableName].Rows[i]["JournalName"].ToString() + "';"; ;

                            SqlCeDataAdapter SQLAdp2 = new SqlCeDataAdapter(); ;
                            SqlCeCommand command2 = new SqlCeCommand(Comm);
                            command2.Connection = SQLCon;
                            SQLAdp2.SelectCommand = command2;


                            SQLAdp2.Fill(SQLdset2, tableName);

                            SQLCon.Close();

                            journalData[i] = new Journal();

                            journalData[i].Name = SQLdset2.Tables[tableName].Rows[0]["JournalName"].ToString();
                            journalData[i].Link = SQLdset2.Tables[tableName].Rows[0]["JournalLink"].ToString();
                            journalData[i].Website = SQLdset2.Tables[tableName].Rows[0]["Website"].ToString();
                            journalData[i].Keywords = SQLdset2.Tables[tableName].Rows[0]["Keywords"].ToString();
                            journalData[i].Submit = SQLdset2.Tables[tableName].Rows[0]["SubmitLink"].ToString();


                        }
                    }
                }
                catch (Exception ef)
                { }
                return journalData;

            }

            public static void SetJournalData(Journal[] journalDataList)
            {
                DataSet SQLdset;
                SqlCeDataAdapter SQLAdp;

                SqlCeConnection SQLCon;
                string tableName = "Journal_Data";

                SQLCon = new SqlCeConnection();

                string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";

                SQLCon.ConnectionString = ConString;



                try
                {
                    if (SQLCon != null)
                    {
                        SQLCon.Open();


                        string sql;


                        SqlCeCommand comm = new SqlCeCommand();

                        comm.CommandType = CommandType.Text;
                        comm.Connection = SQLCon;


                        int count = journalDataList.Length;


                        for (int i = 0; i < count; i++)
                        {



                            sql = "INSERT INTO Journal_Data(JournalName, JournalLink, Keywords, Website, SubmitLink) VALUES('" + journalDataList[i].Name + "','" + journalDataList[i].Link + "','" + journalDataList[i].Keywords.ToLower() + "','" + journalDataList[i].Website + "','" + journalDataList[i].Submit + "');";



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
                catch (Exception ec)
                { }




            }


            public static bool UpdateKeywords(string JournalName, string NewKeywords)
            {
                DataSet SQLdset;
                SqlCeDataAdapter SQLAdp;

                SqlCeConnection SQLCon;
                bool Done = true;

                string tableName = "Journal_Data";

                SQLCon = new SqlCeConnection();

                string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";

                SQLCon.ConnectionString = ConString;



                try
                {
                    if (SQLCon != null)
                    {
                        SQLCon.Open();


                        string sql;


                        SqlCeCommand comm = new SqlCeCommand();

                        comm.CommandType = CommandType.Text;
                        comm.Connection = SQLCon;





                        sql = "Update " + tableName + " Set Keywords='" + NewKeywords + "' WHERE JournalName='" + JournalName + "';";



                        comm.CommandText = sql;

                        try
                        {



                            comm.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                            Done = false;
                        }
                        finally
                        {


                        }

                        SQLCon.Close();

                    }
                }
                catch (Exception er)
                {

                    Done = false;
                }

                return Done;
            }

          
    }
}