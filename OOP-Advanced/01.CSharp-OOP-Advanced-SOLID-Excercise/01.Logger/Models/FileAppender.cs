using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models
{
    internal class FileAppender : IAppender
    {
        //  private ILayout layout;
        //  private ErrorLevel errorLevel;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }

        public ErrorLevel Level { get; }
        public ILayout Layout { get; }
        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formatError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formatError);
            this.MessagesAppended++;
        }
        public override string ToString()
        {
            string appendType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();
            string result = $"Appender type: {appendType}, Layout type: {layoutType}, Report level: {level}, Messages appended: {this.MessagesAppended} File size: {this.logFile.Size}";
            return result;
        }
    }
}
