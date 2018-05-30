using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IAppender : ILevelable
    {
        ILayout Layout { get; }

        // ErrorLevel Level { get; }

        void Append(IError error);
    }
}
