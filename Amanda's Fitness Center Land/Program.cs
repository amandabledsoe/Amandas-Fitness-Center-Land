using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Amanda_s_Fitness_Center_Land
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Fitness Center Program
            //Register Screen - optional
            //Select A Club Screen - optional

            bool runningProgram = true;
            while(runningProgram)
            {
                string textFilePath = @"C:\Users\xando\OneDrive\Desktop\Amanda's Fitness Center Land\Amanda's Fitness Center Land\Members.txt";

                Console.WriteLine("What would you like to do? Select the Appropriate Number Below:");
                PrintProgramMenu();

                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch(choice)
                {
                    #region Option 1: Check Member In
                    case 1: //Check Member In
                    #endregion
                        continue;

                    #region Option 2: Add A New Member
                    case 2: //Add New Member
                        bool addingNewMembers = true;
                        while(addingNewMembers)
                        {
                            if (new FileInfo(textFilePath).Length == 0)
                            {
                                string header = string.Format("{0, -10}{1, -20}{2, -20}{3, -20}{4}", "MemID#", "Active Status", "First Name", "Last Name", "Club Name");
                                string border = "--------------------------------------------------------------------------------";
                                AddHeaderToMemberDocument(header, textFilePath);
                                AddHeaderToMemberDocument(border, textFilePath);

                                //prompt for member details
                                Console.WriteLine("");
                                Console.Write("Enter the Member's First Name: ");
                                string firstNameEntry = Console.ReadLine();
                                Console.Write("Enter the Member's Last Name: ");
                                string lastNameEntry = Console.ReadLine();
                                Console.Write("Enter the Club Name they belong to: ");
                                string clubNameEntry = Console.ReadLine();

                                //discover text document length and assign associated member number
                                int id = CountListAndAssignMemberNumber(textFilePath) -1;

                                //create the new member & convert it to a string
                                string newMemberString = ConvertMemberToString(new Member(id, true, firstNameEntry, lastNameEntry, clubNameEntry));

                                //add string to document
                                AddMemberToMemberDocument(newMemberString, textFilePath);

                                Console.WriteLine("");
                                Console.WriteLine("Your New Member Has Been Added Succesfully!");
                                Console.WriteLine("");
                                Console.WriteLine("Would you like to add another new member?");
                                string goAgainChoice = Console.ReadLine().ToLower();
                                if (goAgainChoice == "y")
                                {
                                    addingNewMembers = true;
                                }
                                else if (goAgainChoice == "n")
                                {
                                    addingNewMembers = false;
                                }
                                Console.Clear();
                            }
                            else
                            {
                                //prompt for member details
                                Console.WriteLine("");
                                Console.Write("Enter the Member's First Name: ");
                                string firstNameEntry = Console.ReadLine();
                                Console.Write("Enter the Member's Last Name: ");
                                string lastNameEntry = Console.ReadLine();
                                Console.Write("Enter the Club Name they belong to: ");
                                string clubNameEntry = Console.ReadLine();

                                //discover text document length and assign associated member number
                                int id = CountListAndAssignMemberNumber(textFilePath) -1;

                                //create the new member & convert it to a string
                                string newMemberString = ConvertMemberToString(new Member(id, true, firstNameEntry, lastNameEntry, clubNameEntry));

                                //add string to document
                                AddMemberToMemberDocument(newMemberString, textFilePath);

                                Console.WriteLine("");
                                Console.WriteLine("Your New Member Has Been Added Succesfully!");
                                Console.WriteLine("");
                                Console.WriteLine("Would you like to add another new member?");
                                string goAgainChoice = Console.ReadLine().ToLower();
                                if (goAgainChoice == "y")
                                {
                                    addingNewMembers = true;
                                }
                                else if (goAgainChoice == "n")
                                {
                                    addingNewMembers = false;
                                }
                                Console.Clear();
                            }
                        }
                        #endregion
                        continue;

                    #region Option 3: Update Member Information
                    case 3: //Update Member Information
                        #endregion
                        continue;

                    #region Option 4: Remove A Member
                    case 4: //Remove Member
                        #endregion
                        continue;

                    #region Option 5: Print Member Roster
                    case 5:

                        if (new FileInfo(textFilePath).Length == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No Members Added Yet!");
                            Console.WriteLine("Select Option 2 from the main menu to add new members");
                            Console.WriteLine("");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            int counter = 0;
                            string line;

                            Console.WriteLine("");
                            StreamReader file = new StreamReader(textFilePath, true);
                            while ((line = file.ReadLine()) != null)
                            {
                                Console.WriteLine(line, true);
                                counter++;
                            }

                            file.Close();
                            Console.WriteLine("");
                            Console.WriteLine("There are {0} total pets registered.", counter - 2);
                            Console.WriteLine("");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        #endregion
                        continue;

                    case 6: //Exit Program
                        break;
                }
                runningProgram = false;
                Console.Clear();
            }
            Console.WriteLine("You have successfully signed out. Thank you!");
            Environment.Exit(0);
            #endregion
        }
        public static void PrintProgramMenu()
        {
            List<string> menuOptions = new List<string>()
            {
                "Check Member In",
                "Add New Member",
                "Update Member Information",
                "Remove Member",
                "Print Member Roster",
                "Sign Out"
            };

            foreach(string option in menuOptions)
            {
                Console.WriteLine("{0, -4}{1}", $"{menuOptions.IndexOf(option)+1}", $"{option}");
            }
            Console.WriteLine("");
        }
        public static int CountListAndAssignMemberNumber(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }
        public static void AddHeaderToMemberDocument(string memberString, string textFile)
        {
            StreamWriter writer = new StreamWriter(textFile, true);
            writer.WriteLine(memberString, true);
            writer.Close();
        }
        public static void AddMemberToMemberDocument(string memberString, string textFile)
        {
            StreamWriter writer = new StreamWriter(textFile, true);
            writer.WriteLine(memberString, true);
            writer.Close();
        }
        public static string ConvertMemberToString(Member member)
        {
            return string.Format("{0, -10}{1, -20}{2, -20}{3, -20}{4}", $"{member.MemberID}", $"{member.Status}", $"{member.FirstName}", $"{member.LastName}", $"{member.ClubName}");
        }
    }
}
