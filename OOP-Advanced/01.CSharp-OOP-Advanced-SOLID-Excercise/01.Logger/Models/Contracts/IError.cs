using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }
        string Message { get; }

        //ErrorLevel Level { get; }
    }
}
