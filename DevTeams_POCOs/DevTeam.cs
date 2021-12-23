using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_POCOs
{
    // Plain Old C# Objects aka Domain
    /*
     * Developers have names and ID numbers;
     * we need to be able to identify one developer without mistaking them for another. 
     * We also need to know whether or not they have access to the online learning tool: Pluralsight.
     */
    public class DevTeam
    {
        public DevTeam() { }

        public DevTeam(string teamName, List<Developer> developers)
        {
            TeamName = teamName;
            Developers = developers;
        }
        public int ID { get; set; }
        public string TeamName { get; set; }

        public List<Developer> Developers { get; set; } = new List<Developer>();
    }
}

