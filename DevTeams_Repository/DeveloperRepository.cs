using DevTeams_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperRepository
    {
        private readonly List<Developer> _developerContent = new List<Developer>();
        private int _count;
        // Create
        public bool AddContentToDirectory(Developer content)
        {
            if (content is null)
            {
                return false;
            }
            else
            {
                _count++;
                content.ID = _count;
                _developerContent.Add(content);
                return true;

            }
        }

        // Read
        public List<Developer> GetAllContents()
        {
            return _developerContent;
        }

        public List<Developer> GetAllDevelopersByHasPluralSight()
        {
            List<Developer> hasPluralSight = new List<Developer>();
            foreach (Developer content in _developerContent)
            {
                if (content.HasPluralSight)
                {
                    hasPluralSight.Add(content);
                }
            }
            return hasPluralSight;
        }

        // Read Helper Method
        public Developer GetDeveloperByID(int id)
        {
            foreach (Developer content in _developerContent)
            {
                if (content.ID == id)

                {
                    return content;
                }                    
            }
            return null;
        }
        // Update
        public bool UpdateDeveloper(int id, Developer content)
        {
            Developer developer = GetDeveloperByID(id);

            if (developer != null)
            {
                developer.FirstName = content.FirstName;
                developer.LastName = content.LastName;
                developer.HasPluralSight = content.HasPluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete
        public bool DeleteDeveloper(int id)
        {
            Developer developer = GetDeveloperByID(id);

            if (developer != null)
            {
                _developerContent.Remove(developer);
                return true;
            }
            return false;
        }
    }

}
