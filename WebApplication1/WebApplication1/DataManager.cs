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
            public static List<string> GetData(string tableName)
            {
                SQLCon = new SqlCeConnection();

                string ConString = @"Data Source=|DataDirectory|KeywordsDB.sdf;";
                    //@"Data Source=" + "F:\\Github\\JournalClassifier\\WebApplication1\\WebApplication1\\App_Data\\KeywordsDB.sdf;";
                SQLCon.ConnectionString = ConString; 

                List<string> WordList = new List<string>();
                SQLCon.Open();

                string Comm = "SELECT * FROM "+tableName;

                SQLAdp = new SqlCeDataAdapter(Comm, SQLCon);

                SQLAdp.SelectCommand = new SqlCeCommand(Comm, SQLCon);

                SQLdset = new DataSet();

                SQLAdp.Fill(SQLdset,tableName);




                SQLCon.Close();

                if (SQLdset != null)
                {
                    ;
                    int j = SQLdset.Tables[tableName].Rows.Count;
                   
                    ;

                    for (int i = 0; i < j ; i++)
                    {

                        string temp = SQLdset.Tables[tableName].Rows[i]["Keywords"].ToString();
                        WordList.Add(temp.ToLower());
                        
                    }
                }
                return WordList;
            }
            public static  void SetData(string tableName, List<string> keywordsList)
            {
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



                        foreach (string word in keywordsList)
                        {
                            sql = "INSERT INTO " + tableName + "(Keywords) VALUES('" + word.ToLower() + "');";
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