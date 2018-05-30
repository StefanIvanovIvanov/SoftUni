using System;
using Logger.Models.Contracts;

namespace Logger.Models
{
    class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }

        public ErrorLevel Level { get; }

        public ILayout Layout { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appendType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();
            string result = $"Appender type: {appendType}, Layout type: {layoutType}, Report level: {level}, Messages appended: {this.MessagesAppended}";
            return result;
        }
    }
}
