using DevTeams_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperTeamRepository
    {
        private readonly List<DevTeam> _devTeamContext = new List<DevTeam>();
        private DeveloperRepository _devRepo;
        private int _count;

        public DeveloperTeamRepository(DeveloperRepository devRepo)
        {
            _devRepo = devRepo;
        }

        // Create
        public bool AddContentToDirectory(DevTeam content)
        {
            if (content is null)
            {
                return false;
            }
            else
            {
                _count++;
                content.ID = _count;
                _devTeamContext.Add(content);
                return true;
            }
        }

        // Read
        public List<DevTeam> GetAllTeams()
        {
            return _devTeamContext;
        }


        // Read Helper Unique Identifier
        public DevTeam GetDevTeamByID(int id)
        {
            foreach (DevTeam team in _devTeamContext)
            {
                if (team.ID == id)
                {
                    return team;
                }
            }
            return null;
        }   

        // Update
        public bool UpdateDevTeam(int id, DevTeam team)
        {
            DevTeam devTeam = GetDevTeamByID(id);

            if (devTeam != null)
            {
                devTeam.TeamName = team.TeamName;
                devTeam.Developers = team.Developers;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool DeleteDevTeam(int id)
        {
            DevTeam devTeam = GetDevTeamByID(id);

            if (devTeam != null)
            {
                _devTeamContext.Remove(devTeam);
                return true;
            }
            return false;
        }

        public bool AddDevToTeam(int teamID, int devID)
        {
            DevTeam devTeam = GetDevTeamByID(teamID);

            if (devTeam == null)
            {
                return false;
            }
            Developer developer = _devRepo.GetDeveloperByID(devID);
            if (developer == null)
            {
                return false;
            }
            devTeam.Developers.Add(developer);
            return true;

        }
        public bool AddMultipleDevsToTeam(int teamID, List<Developer> developers)
        {
            DevTeam devTeam = GetDevTeamByID(teamID);

            if (devTeam == null)
            {
                return false;
            }
            devTeam.Developers.AddRange(developers);
            return true;

        }
    }
}
