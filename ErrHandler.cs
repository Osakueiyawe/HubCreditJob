using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;


    class ErrHandler
    {
        public static void LogError(string errorMessage)
        {
            try
            {
            //fff
                string path = "Error/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";     
                //Check for the file exists, or create a new file     
                if (!File.Exists(System.IO.Path.GetFullPath(path)))     
                {       
                    File.Create(System.IO.Path.GetFullPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.IO.Path.GetFullPath(path)))
                {        // using the stream writer class write       
                    // log message in a file.        
                    w.WriteLine("\r\nLog Entry : ");        
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));        
                    string err = "Error Message:" + errorMessage;        
                    w.WriteLine(err);        
                    w.WriteLine    ("____________________________________________________________________");        
                    w.Flush();        
                    w.Close();     
                }
            }
            catch (Exception ex)
            {
                //LogError(ex.StackTrace);
            }
        }

        public static void LogErrorCbn(string errorMessage)
        {
            try
            {
                string path = "CBNError/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                //Check for the file exists, or create a new file     
                if (!File.Exists(System.IO.Path.GetFullPath(path)))
                {
                    File.Create(System.IO.Path.GetFullPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.IO.Path.GetFullPath(path)))
                {        // using the stream writer class write       
                    // log message in a file.        
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = "Error Message:" + errorMessage;
                    w.WriteLine(err);
                    w.WriteLine("____________________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                //LogError(ex.StackTrace);
            }
        }


        public static void LogChargeError(string errorMessage)
        {
            try
            {
                string path = "ChargeError/" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                //Check for the file exists, or create a new file     
                if (!File.Exists(System.IO.Path.GetFullPath(path)))
                {
                    File.Create(System.IO.Path.GetFullPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.IO.Path.GetFullPath(path)))
                {        // using the stream writer class write       
                    // log message in a file.        
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = "Error Message:" + errorMessage;
                    w.WriteLine(err);
                    w.WriteLine("____________________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                //LogError(ex.StackTrace);
            }
        }

        public static void LogUnequalAmount(string errorMessage)
        {
            try
            {
                string path = "Error/LogUnequalAmount" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                //Check for the file exists, or create a new file     
                if (!File.Exists(System.IO.Path.GetFullPath(path)))
                {
                    File.Create(System.IO.Path.GetFullPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.IO.Path.GetFullPath(path)))
                {        // using the stream writer class write       
                    // log message in a file.        
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = "Error Message:" + errorMessage;
                    w.WriteLine(err);
                    w.WriteLine("____________________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                LogError(ex.StackTrace);
            }
        }

    }

