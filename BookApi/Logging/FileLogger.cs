using BookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Logging
{
    public class FileLogger : ILogger
    {
        private string filePath = @"C:\Users\rkaruppaiah\Desktop\RaguWS\WebApiWs\BookApi\log.txt";
        public void Log(string message)
        {
            if (File.Exists(filePath))
            {
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }
}
