using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Agent
    {
        string agentName;
         string agentImage;
         string password;

        public Agent()
        { }
        public Agent(string agentName, string agentImage, string password)
        {
            AgentName = agentName;
            AgentImage = agentImage;
            Password = password;
        }

        public string AgentName { get => agentName; set => agentName = value; }
        public string AgentImage { get => agentImage; set => agentImage = value; }
        public string Password { get => password; set => password = value; }

        public void register()
        {

            DBservices db = new DBservices();
            db.registerAgent(this);

        }

    }
}