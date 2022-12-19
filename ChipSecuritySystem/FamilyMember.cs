using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public class FamilyMember
    {

        //  Properties 
        public string Name { get; set; }
        public int NumberOfChips { get; set; }
        private List<KeyValuePair<Color, Color>> Chips { get; set; }



        //  Constructors
        public FamilyMember(string name, int numberOfChips)
        {
            Name = name;
            NumberOfChips = numberOfChips;
            Chips = new List<KeyValuePair<Color, Color>>();
        }

        public static List<FamilyMember> famMember = new List<FamilyMember>()
        {
            new FamilyMember("Mom", 0),
            new FamilyMember("Dad", 0),
            new FamilyMember("Brother", 0),
            new FamilyMember("Sister", 0)
        };

        private static List<KeyValuePair<Color, Color>> familyMemberChips = new List<KeyValuePair<Color, Color>>();


        public static void AssignChipsAndColors()
        {
            Random rand = new Random();

            foreach (FamilyMember famMember in famMember)
            {
                famMember.NumberOfChips = rand.Next(1, 5);
                Console.WriteLine($"Name: {famMember.Name}\nNumber of Chips:  {famMember.NumberOfChips}");

                for (int i = 0; i < famMember.NumberOfChips; i++)
                {
                    famMember.Chips.Add(RandomColorGenerator());
                }

                Console.WriteLine();
                IsTaskSuccessful();
            }

        }

        private static KeyValuePair<Color, Color> RandomColorGenerator()
        {
            Random rand = new Random();

            List<KeyValuePair<Color, Color>> colorCombo = new List<KeyValuePair<Color, Color>>();
            colorCombo.Add(new KeyValuePair<Color, Color>(Color.Blue, Color.Yellow));
            colorCombo.Add(new KeyValuePair<Color, Color>(Color.Red, Color.Green));
            colorCombo.Add(new KeyValuePair<Color, Color>(Color.Yellow, Color.Red));
            colorCombo.Add(new KeyValuePair<Color, Color>(Color.Orange, Color.Purple));

            int index = rand.Next(colorCombo.Count);

            KeyValuePair<Color, Color> kvp = colorCombo.ElementAt(index);

            Console.WriteLine(kvp);
            familyMemberChips.Add(kvp);

            return kvp;
        }


        public static void AddChipsToPile()
        {
            List<KeyValuePair<Color, Color>> generatedList = new List<KeyValuePair<Color, Color>>();

            List<KeyValuePair<Color, Color>> colorCombo = new List<KeyValuePair<Color, Color>>();
            colorCombo.Add(new KeyValuePair<Color, Color>(Color.Blue, Color.Yellow));
            colorCombo.Add(new KeyValuePair<Color, Color>(Color.Red, Color.Green));
            colorCombo.Add(new KeyValuePair<Color, Color>(Color.Yellow, Color.Red));
            colorCombo.Add(new KeyValuePair<Color, Color>(Color.Orange, Color.Purple));

            Console.WriteLine("list of chips");
            foreach (KeyValuePair<Color, Color> kvp2 in generatedList)
            {

                Console.WriteLine($"{kvp2.Key} {kvp2.Value}");
            }
        }

        public static void IsTaskSuccessful()
        {
            var blueYellow = new KeyValuePair<Color, Color>(Color.Blue, Color.Yellow);
            var yellowRed = new KeyValuePair<Color, Color>(Color.Yellow, Color.Red);
            var redGreen = new KeyValuePair<Color, Color>(Color.Red, Color.Green);

            if (familyMemberChips.Contains(blueYellow) && familyMemberChips.Contains(yellowRed) && familyMemberChips.Contains(redGreen) && FamilyMember.famMember.Count == 4)
            {
                Console.WriteLine("Task Completed Successfully");
            }else
            {
                Console.WriteLine(Constraints.ErrorMessage);
            }
        }
    }
}




