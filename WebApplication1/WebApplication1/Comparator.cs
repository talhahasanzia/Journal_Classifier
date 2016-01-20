using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Comparator
    {
        #region declarations
        static List<string> savedDataFromSpringerComputerScience=new List<string>();
             static List<string> savedDataFromSpringerMathematics=new List<string>();
             static List<string> savedDataFromSpringerEN = new List<string>();
             static List<string> savedDataFromSpringerEngineering = new List<string>();
             static List<string> savedDataFromSpringerAI = new List<string>();
             static List<string> savedDataFromSpringerAlgebra = new List<string>();
             static List<string> savedDataFromSpringerCN = new List<string>();
             static List<string> savedDataFromSpringerIS = new List<string>();
             static List<string> savedDataFromSpringerMCP = new List<string>();
             static List<string> savedDataFromSpringerTCS = new List<string>();

            static List<string> savedDataFromACMAI = new List<string>();
            static List<string> savedDataFromACMSE = new List<string>();
            static List<string> savedDataFromACMTOCS = new List<string>();
            static List<string> savedDataFromACMCN = new List<string>();
            static List<string> savedDataFromACMCG = new List<string>();
            static List<string> savedDataFromACMCV = new List<string>();
            static List<string> savedDataFromACMCC = new List<string>();
            static List<string> savedDataFromACMDDB = new List<string>();
            static List<string> savedDataFromACMPC = new List<string>();

            static List<string> savedDataFromElsevierAI = new List<string>();
            static List<string> savedDataFromElsevierSE = new List<string>();
            static List<string> savedDataFromElsevierTOCS = new List<string>();
            static List<string> savedDataFromElsevierCN = new List<string>();
            static List<string> savedDataFromElsevierCG = new List<string>();
            static List<string> savedDataFromElsevierCV = new List<string>();
            static List<string> savedDataFromElsevierCC = new List<string>();
            static List<string> savedDataFromElsevierDDB = new List<string>();
            static List<string> savedDataFromElsevierPC = new List<string>();

        #endregion




            public Comparator()
        {

             
           
            
        
        }


            public static void RunAnalysis(string[] keywords)
            {


               // do all analysis code here
            
            
            }



        public static float matchSpringerCS(string[] keywords)
        {
            savedDataFromSpringerComputerScience = DataManager.GetData(TableNames.Springer.ComputerScience);
            float perc=0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerComputerScience.Contains(word))
                    matched++;
            
            }

            perc = ((float)matched / (float)totalKeywords) * 100f;
            return perc;
        }
        
        public static float matchSpringerMA(string[] keywords)
        {
            savedDataFromSpringerMathematics = DataManager.GetData(TableNames.Springer.Mathematics);
            float perc=0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerMathematics.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;

            return perc;
        }
       
        public static float matchSpringerAI(string[] keywords)
        {
            savedDataFromSpringerAI = DataManager.GetData(TableNames.Springer.AI);
            float perc=0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerAI.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;
        }
        public static float matchSpringerAlgebra(string[] keywords)
        {
            savedDataFromSpringerAlgebra = DataManager.GetData(TableNames.Springer.Algebra);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerAlgebra.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;
        }
        public static float matchSpringerCN(string[] keywords)
        {
            savedDataFromSpringerCN = DataManager.GetData(TableNames.Springer.ComputerNetworks);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerCN.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;
        }
        public static float matchSpringerIS(string[] keywords)
        {
            savedDataFromSpringerIS = DataManager.GetData(TableNames.Springer.InformationSystems);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerIS.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;
        }
        public static float matchSpringerMCP(string[] keywords)
        {
            savedDataFromSpringerMCP = DataManager.GetData(TableNames.Springer.MathematicalAndComputationalPhysics);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerMCP.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;
        }
        public static float matchSpringerTCS(string[] keywords)
        {
            savedDataFromSpringerTCS = DataManager.GetData(TableNames.Springer.TheoriticalComputerScience);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerTCS.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;
        }
        public static float matchSpringerEngineering(string[] keywords)
        {
            savedDataFromSpringerEngineering = DataManager.GetData(TableNames.Springer.Engineering);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromSpringerEngineering.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;
        }

        public static float matchACMArtificialIntelligence(string[] keywords) {
            savedDataFromACMAI = DataManager.GetData(TableNames.ACM.AI);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMAI.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }
        public static float matchACMSoftwareEngineering(string[] keywords)
        {
            savedDataFromACMSE = DataManager.GetData(TableNames.ACM.SoftwareEngineering);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMSE.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchACMComputerNetworks(string[] keywords)
        {
            savedDataFromACMCN = DataManager.GetData(TableNames.ACM.ComputerNetworks);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMCN.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchACMComputerVision(string[] keywords)
        {
            savedDataFromACMCV = DataManager.GetData(TableNames.ACM.ComputerVision);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMCV.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchACMTOCS(string[] keywords)
        {
            savedDataFromACMTOCS = DataManager.GetData(TableNames.ACM.TheoryOfComputerScience);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMTOCS.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;

            }

        public static float matchACMParallelComputing(string[] keywords)
        {
            savedDataFromACMPC = DataManager.GetData(TableNames.ACM.ParallelComputing);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMPC.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchACMCloudComputing(string[] keywords)
        {
            savedDataFromACMCC = DataManager.GetData(TableNames.ACM.CloudComputing);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMCC.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }
        public static float matchACMDistributedDatabase(string[] keywords)
        {
            savedDataFromACMDDB = DataManager.GetData(TableNames.ACM.DistributedDatabase);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMDDB.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchACMComputerGraphics(string[] keywords)
        {
            savedDataFromACMCG = DataManager.GetData(TableNames.ACM.ComputerGraphics);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromACMCG.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }
        public static float matchElsevierArtificialIntelligence(string[] keywords)
        {
            savedDataFromElsevierAI = DataManager.GetData(TableNames.Elsevier.AI);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierAI.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }
        public static float matchElsevierSoftwareEngineering(string[] keywords)
        {
            savedDataFromElsevierSE = DataManager.GetData(TableNames.Elsevier.SoftwareEngineering);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierSE.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchElsevierComputerNetworks(string[] keywords)
        {
            savedDataFromElsevierCN = DataManager.GetData(TableNames.Elsevier.ComputerNetworks);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierCN.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchElsevierComputerVision(string[] keywords)
        {
            savedDataFromElsevierCV = DataManager.GetData(TableNames.Elsevier.ComputerVision);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierCV.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchElsevierTOCS(string[] keywords)
        {
            savedDataFromElsevierTOCS = DataManager.GetData(TableNames.Elsevier.TheoryOfComputerScience);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierTOCS.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;

        }

        public static float matchElsevierParallelComputing(string[] keywords)
        {
            savedDataFromElsevierPC = DataManager.GetData(TableNames.Elsevier.ParallelComputing);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierPC.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchElsevierCloudComputing(string[] keywords)
        {
            savedDataFromElsevierCC = DataManager.GetData(TableNames.Elsevier.CloudComputing);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierCC.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }
        public static float matchElsevierDistributedDatabase(string[] keywords)
        {
            savedDataFromElsevierDDB = DataManager.GetData(TableNames.Elsevier.DistributedDatabase);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierDDB.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }

        public static float matchElsevierComputerGraphics(string[] keywords)
        {
            savedDataFromElsevierCG = DataManager.GetData(TableNames.Elsevier.ComputerGraphics);
            float perc = 0;

            int totalKeywords = keywords.Length;
            int matched = 0;

            foreach (string word in keywords)
            {

                if (savedDataFromElsevierCG.Contains(word))
                    matched++;

            }

            perc = ((float)matched / (float)totalKeywords) * 100f;


            return perc;


        }



    }
}