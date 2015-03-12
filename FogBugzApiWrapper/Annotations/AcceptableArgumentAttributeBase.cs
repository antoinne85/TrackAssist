using System;
using System.Collections.Generic;
using System.Linq;
using FogBugzApiWrapper.Data;

namespace FogBugzApiWrapper.Annotations
{
    public class AcceptableArgumentAttributeBase : Attribute
    {
        public List<Argument> Arguments { get; set; }

        public AcceptableArgumentAttributeBase(params Argument[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                Arguments = new List<Argument>();
            }
            else
            {
                Arguments = arguments.ToList();
            }
        }
    }
}
