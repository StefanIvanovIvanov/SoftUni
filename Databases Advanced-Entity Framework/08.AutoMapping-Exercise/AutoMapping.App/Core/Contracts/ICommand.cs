﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapping.App.Core.Contracts
{
   public interface ICommand
   {
       string Execute(string[] args);
   }
}
