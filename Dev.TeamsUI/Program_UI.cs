using DevTeams_POCOs;
using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.TeamsUI
{
    class Program_UI
    {
        private readonly DeveloperRepository _devRepo;
        private readonly DeveloperTeamRepository _devTeamRepo;

        public Program_UI()
        {
            _devRepo = new DeveloperRepository();
            _devTeamRepo = new DeveloperTeamRepository(_devRepo);
        }

        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to dev Teams\n" +
                    " 1. Add A Developer\n" +
                    " 2. View All Existing Developers\n" +
                    " 3. View Existing Developers with PluralSight\n" +
                    " 4. View Developer By ID\n" +
                    " 5. Update An Existing Developer by ID\n" +
                    " 6. Delete An Existing Developer by ID\n" +
                    " 7. Add a DevTeam\n" +
                    " 8. View List of DevTeams\n" +
                    " 9. View DevTeams by ID\n" +
                    "10. Add a Developer to a DevTeam\n" +
                    "11. Add Developers to a DevTeam\n" +
                    "12. Update DevTeam by ID\n" +
                    "13. Delete DevTeam by ID\n" +
                    "14. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        ViewAllExistingDevelopers();
                        break;
                    case "3":
                        ViewAnExistingDeveloperByPluralSight();
                        break;
                    case "4":
                        ViewDeveloperByID();
                        break;
                    case "5":
                        UpdateAnExistingDeveloper();
                        break;
                    case "6":
                        DeleteAnExistingDeveloper();
                        break; 
                    case "7":
                        AddADevTeam();
                        break;
                    case "8":
                        ViewDevTeams();
                        break;
                    case "9":
                        ViewDevTeamsByID();
                        break;
                    case "10":
                        //AddADeveloperToADevTeam();
                        break;
                    case"11":
                        //AddDevelopersToADevTeam();
                        break;
                    case "12":
                        UpdateDevTeamByID();
                        break;
                    case "13":
                        DeleteADevTeamByID();
                        break;
                    case "14":
                        Console.WriteLine("Goodbye!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            // First Name
            Console.WriteLine("Enter the developer's first name:");
            newDeveloper.FirstName = Console.ReadLine();

            // Last Name
            Console.WriteLine("Enter the developer's last name:");
            newDeveloper.LastName = Console.ReadLine();
            
            // Has PluralSight
            Console.WriteLine("Does the developer have PluralSight? (y/n)");
            string pluralSightString = Console.ReadLine().ToLower();

            if (pluralSightString == "y")
            {
                newDeveloper.HasPluralSight = true;
            }
            else
            {
                newDeveloper.HasPluralSight = false;
            }

            _devRepo.AddContentToDirectory(newDeveloper);
        }

        private void ViewAllExistingDevelopers()
        {
            Console.Clear();

            List<Developer> developerContent = _devRepo.GetAllContents();

            foreach (Developer developer in developerContent)
            {
                Console.WriteLine($"Developer: {developer.FullName}");
            }
        }

        private void ViewAnExistingDeveloperByPluralSight()
        {
            Console.Clear();

            List<Developer> hasPluralSIght = _devRepo.GetAllDevelopersByHasPluralSight();

            foreach (Developer content in hasPluralSIght)
            {
                Console.WriteLine($"Developer {content.FullName} has PluralSight.");
            }
        }

        private void ViewDeveloperByID()
        {
            Console.Clear();

            List<Developer> developers = _devRepo.GetAllContents();

            foreach (Developer developer in developers)
            {
                Console.WriteLine($"Developer: {developer.FullName}\n" +
                    $"ID: {developer.ID}");
            }
        }

        private void UpdateAnExistingDeveloper()
        {
            ViewDeveloperByID();

            Console.WriteLine("Enter the ID of the developer you would like to update:");

            string iDAsString = Console.ReadLine();
            int oldID = int.Parse(iDAsString);
            
            Developer newContent = new Developer();

            Console.WriteLine("Enter the developer's first name:");
            newContent.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the developer's last name:");
            newContent.LastName = Console.ReadLine();

            Console.WriteLine("Does the developer have PluralSight? (y/n)");
            string pluralSightString = Console.ReadLine().ToLower();

            if (pluralSightString == "y")
            {
                newContent.HasPluralSight = true;
            }
            else
            {
                newContent.HasPluralSight = false;
            }

            bool wasUpdated = _devRepo.UpdateDeveloper(oldID, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }

        }

        private void DeleteAnExistingDeveloper()
        {
            ViewDeveloperByID();

            Console.WriteLine("\nEnter the ID of the developer you would like removed:");
            string iDAsString = Console.ReadLine();
            int input = int.Parse(iDAsString);

            bool wasDeleted = _devRepo.DeleteDeveloper(input);

            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The developer could not be deleted.");
            }
        }

        private void AddADevTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("Enter DevTeam's name:");
            newDevTeam.TeamName = Console.ReadLine();

            _devTeamRepo.AddContentToDirectory(newDevTeam);
        }

        private void ViewDevTeams()
        {
            Console.Clear();

            List<DevTeam> listOfTeams = _devTeamRepo.GetAllTeams();

            foreach (DevTeam team in listOfTeams)
            {
                Console.WriteLine($"Name of DevTeam: {team.TeamName}\n" +
                    $"Developers: {team.Developers}");
            }
        }

        private void ViewDevTeamsByID()
        {
            Console.Clear();

            List<DevTeam> devTeams = _devTeamRepo.GetAllTeams();

            foreach (DevTeam devTeam in devTeams)
            {
                Console.WriteLine($"DevTeam: {devTeam.TeamName}\n" +
                    $"TeamID: {devTeam.ID}");
            }
        }

        /*private void AddADevevloperToDevTeam()
        {
            Console.Clear();
            List<DevTeam> devTeams = _devTeamRepo.GetDevTeamByID();

            Console.WriteLine();
        }
        */

        /*private void AddDevelopersToDevTeam()
         {

         }
         */

        private void UpdateDevTeamByID()
        {
            ViewDevTeamsByID();

            Console.WriteLine("Enter the ID of the DevTeam you would like to update:");

            string teamIDAsString = Console.ReadLine();
            int oldTeamID = int.Parse(teamIDAsString);

            DevTeam newInfo = new DevTeam();

            Console.WriteLine("Enter the DevTeam's team name:");
            newInfo.TeamName = Console.ReadLine();

            bool wasUpdated = _devTeamRepo.UpdateDevTeam(oldTeamID, newInfo);
            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }
        }
        
        private void DeleteADevTeamByID()
        {
            ViewDevTeamsByID();

            Console.WriteLine("Enter the ID of the DevTeam you would like to delete:");

            string teamIDAsString = Console.ReadLine();
            int input = int.Parse(teamIDAsString);

            bool wasDeleted = _devTeamRepo.DeleteDevTeam(input);

            if (wasDeleted)
            {
                Console.WriteLine("The DevTeam was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The DevTeam could not be deleted.");
            }
        }

        private void WaitForKey()
        {
            Console.ReadKey();
        }

        private void Seed()
        {
            Developer mario = new Developer("Mario", "Brothers", true);
            Developer luigi = new Developer("Luigi", "Brothers", false);
            Developer theo = new Developer("Theodore", "Nicholas", true);
            Developer peach = new Developer("Peach", "Princess", false);
            Developer sydney = new Developer("Sydney", "Saint", true);

            _devRepo.AddContentToDirectory(mario);
            _devRepo.AddContentToDirectory(luigi);
            _devRepo.AddContentToDirectory(theo);
            _devRepo.AddContentToDirectory(peach);
            _devRepo.AddContentToDirectory(sydney);
        }
    }
}

            
    
            

            
                

            














