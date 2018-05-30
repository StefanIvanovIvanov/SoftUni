using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class LogFile : ILogFile
    {
        private const string DefaultPath = "./data/";
        public string Path { get; }
        public int Size { get; private set; }

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            InitializeFile();
            this.Size = 0;
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, "");
        }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int addedSize = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }
            this.Size += addedSize;
        }
    }
}
