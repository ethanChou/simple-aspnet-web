using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;

namespace CometLib
{

    /// <summary>
    /// Log 的摘要说明
    /// </summary>
    public class Log
    {
        public Log()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// Writes debug information to console and logfile. Method is syncronized between threads
        /// </summary>
        /// <param name="text"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Write(string text)
        {
            try
            {
                text = string.Format("[{0}] {1}", DateTime.Now, text);
                string fileName = string.Format("Log\\HttpServer{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
                string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                string logDir = Path.GetDirectoryName(logFile);
                if (logDir != null && !Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                using (FileStream fileStream = new FileStream(logFile, FileMode.OpenOrCreate))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        streamWriter.AutoFlush = true;
                        streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                        streamWriter.WriteLine(text);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to logfile: " + ex.Message);
            }

        }
    }
}