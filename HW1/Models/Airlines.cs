using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Airlines
    {

        int airlinesCode;
        string airlinesName;

        public Airlines(int airlinesCode, string airlinesName)
        {
            this.airlinesCode = airlinesCode;
            this.airlinesName = airlinesName;
        }

        public int AirlinesCode { get => airlinesCode; set => airlinesCode = value; }
        public string AirlinesName { get => airlinesName; set => airlinesName = value; }
    }
}