using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo
{
    public static class ConsoleUI
    {

        static Dictionary<string, string[]> UIStrings { get; }

        public static List<string> Options;


        static ConsoleUI()
        {

            Options = new List<string>();
            UIStrings = new Dictionary<string, string[]>()
            {
                {"Header", new string[]
                {
                    //"  __________________________________________________________________________________________________________________________________________________ ",
                    " |                                                                                                                                                  |",
                    " |                                                                       ,-.                                                                        |",
                    " |                                                  ___,---.__          /'|`\\          __,---,___                                                   |",
                    " |                                               ,-'    \\`    `-.____,-'  |  `-.____,-'    //    `-.                                                |",
                    " |                                             ,'        |           ~'\\     /`~           |        `.                                              |",
                    " |                                            /      ___//              `. ,'          ,  , \\___      \\                                             |",
                    " |                                           |    ,-'   `-.__   _         |        ,    __,-'   `-.    |                                            |",
                    " |                                           |   /          /\\_  `   .    |    ,      _/\\          \\   |                                            |",
                    " |                                           \\  |           \\ \\`-.___ \\   |   / ___,-'/ /           |  /                                            |",
                    " |                                            \\  \\           | `._ ()`\\\\  |  //'() _,' |           /  /                                             |",
                    " |                                             `-.\\         /'  _ `---'' , . ``---' _  `\\         /,-'                                              |",
                    " |                                                ``       /     \\    ,='/ \\`=.    /     \\       ''                                                 |",
                    " |                                                        |__   /|\\_,--.,-.--,--._/|\\   __|                                                         |",
                    " |                                                        /  `./  \\\\`\\ |  |  | /,//' \\,'  \\                                                         |",
                    " |                                                       /   /     ||--+--|--+-/-|     \\   \\                                                        |",
                    " |                                                      |   |     /'\\_\\_\\ | /_/_/`\\     |   |                                                       |",
                    " |                                                       \\   \\__, \\_     `~'     _/ .__/   /                                                        |",
                    " |                                                        `-._,-'   `-._______,-'   `-._,-'                                                         |",
                    //" |__________________________________________________________________________________________________________________________________________________|"
                } },

                { "NameAndCurrent", new string[] {

                    " |                                                                                                                                                  |",
                    " |      ___________________________________________          ________________________________________________________________________________       |",
                    " |     /   _____________________________________   \\        /   ___________________________________________________________________________  \\      |",
                    " |    /   /                                     \\   \\      /   /                                                                           \\  \\     |",
                    " |    |  |    ###############################    |  |      |  |    &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&    |  |     |",
                    " |    \\  \\______________________________________/  /       \\  \\____________________________________________________________________________/  /     |",
                    " |     \\__________________________________________/         \\________________________________________________________________________________/      |",
                    " |                                                                                                                                                  |",

                } },

                { "StatsAndMessages", new string[] {


                    " |      ___________________________________________          ________________________________________________________________________________       |",
                    " |     /   _____________________________________   \\        /   ___________________________________________________________________________  \\      |",
                    " |    /   /                                     \\   \\      /   /                                                                           \\  \\     |",
                    " |    |  |    Class: ##########   Level: &&&&    |  |      |  |    Line 0%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |                                       |  |      |  |                                                                            |  |     |",
                    " |    |  |    Exp: ##########################    |  |      |  |    Line 1%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    \\  \\______________________________________/  /       |  |                                                                            |  |     |",
                    " |     \\__________________________________________/        |  |    Line 2%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |                                                         |  |                                                                            |  |     |",
                    " |      ___________________________________________        |  |    Line 3%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |     /   _____________________________________   \\       |  |                                                                            |  |     |",
                    " |    /   /                                     \\   \\      |  |    Line 4%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |      Current Health: ###########      |  |      |  |                                                                            |  |     |",
                    " |    |  |                                       |  |      |  |    Line 5%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |        Current Mana: ###########      |  |      |  |                                                                            |  |     |",
                    " |    |  |                                       |  |      |  |    Line 6%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |  Strength: ######  Dexterity: &&&&&&  |  |      |  |                                                                            |  |     |",
                    " |    |  |                                       |  |      |  |    Line 7%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |  Vitality: ######     Energy: &&&&&&  |  |      |  |                                                                            |  |     |",
                    " |    |  |          __               __          |  |      |  |    Line 8%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |          \\/  Resistances  \\/          |  |      |  |                                                                            |  |     |",
                    " |    |  |                                       |  |      |  |    Line 9%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |      Fire: ######  Lightning: &&&&&&  |  |      |  |                                                                            |  |     |",
                    " |    |  |                                       |  |      |  |    Line 10%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |      Cold: ######     Poison: &&&&&&  |  |      |  |                                                                            |  |     |",
                    " |    \\  \\______________________________________/  /       |  |    Line 11%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |     \\__________________________________________/        |  |                                                                            |  |     |",
                    " |                                                         |  |    Line 12%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                } },

                {"ConstantOptions", new string[] {

                    " |      ___________________________________________        |  |                                                                            |  |     |",
                    " |     /   _____________________________________   \\       |  |    Line 13%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    /   /                                     \\   \\      |  |                                                                            |  |     |",
                    " |    |  |   {H}ealth Potion [##]  {I}nventory   |  |      |  |    Line 14%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    |  |                                       |  |      |  |                                                                            |  |     |",
                    " |    |  |     {M}ana Potion [##]  {Q}uest       |  |      |  |    Line 15%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    |  |     |",
                    " |    \\  \\______________________________________/  /       \\  \\____________________________________________________________________________/  /     |",
                    " |     \\__________________________________________/         \\________________________________________________________________________________/      |",
                    " |                                                                                                                                                  |",

                } },

                {"VariableOptions", new string[] {

                    " |      ______________________________________________________________________________________________________________________________________      |",
                    " |     /   ________________________________________________________________________________________________________________________________   \\     |",
                    " |    /   /                                                                                                                                \\  |     |",
                    " |    |  |                                                        Select an Option                                                         |  |     |",
                    " |    |  |                                                                                                                                 |  |     |",
                    " |    |  |    #########################################################################################################################    |  |     |",
                    " |    |  |                                                                                                                                 |  |     |",

                } },

                {"Footer", new string[] {

                    " |    |  |                                                    Created by Daniel Aguirre                                                    |  |     |",
                    " |    \\  \\_________________________________________________________________________________________________________________________________/  /     |",
                    " |     \\_____________________________________________________________________________________________________________________________________/      |",
                    " |                                                                                                                                                  |",
                    " |__________________________________________________________________________________________________________________________________________________|",

                } }

        };


        }

        public static void ClearOptions()
        {
            Options.Clear();
        }

        public static void AddOption(string[] option)
        {
            option.ToList().ForEach(Options.Add);
        }

        public static void AddOption(string option)
        {
            Options.Add(option);
        }

        static string GenerateOptionLine(int indexSelected)
        {
            string combined = OptionPadding(indexSelected, 0, 0);
            Options.Select((x, i) => combined += x + OptionPadding(indexSelected, i, ++i)).ToArray();
            return combined;
        }


        static string[] FormatOptions(int indexSelected)
        {
            var msg = new string[UIStrings["VariableOptions"].Length];
            UIStrings["VariableOptions"].Select((x, i) => msg[i] = x).ToArray();

            // index 5 is the index that options are displayed on.
            var line = new Regex(@".* (#+) .*").Match(msg[5]).Groups.Values.Select(x => x.ToString()).ToArray();
            // replace the option line with one generated based on Options List<string>
            msg[5] = line[0].Replace(line[1], MatchLengthCentered(GenerateOptionLine(indexSelected), line[1]));
            return msg;

        }

        static string[] FormatStatsSection(Player player)
        {

            var messages = new string[UIStrings["StatsAndMessages"].Length];
            UIStrings["StatsAndMessages"].Select((x, i) => messages[i] = x).ToArray();

            // messages[3] is where the class and level fields are located
            var classAndLevel = new Regex(@".* (#+).* (&+).*").Match(messages[3]).Groups.Values.Select(x => x.ToString()).ToArray();

            // replace class and level
            messages[3] = classAndLevel[0].Replace(classAndLevel[1], player.Class.PadRight(classAndLevel[1].Length))
                                              .Replace(classAndLevel[2], player.Level.ToString().PadRight(classAndLevel[2].Length));
            // messages[5] is where the exp field is
            var expField = new Regex(@".* (#+).*").Match(messages[5]).Groups.Values.Select(x => x.ToString()).ToArray();
            //TODO: Show exp to next level
            messages[5] = expField[0].Replace(expField[1], player.Experience.ToString().PadRight(expField[1].Length));

            // replace max/current health on index 12
            var healthField = new Regex(@".* (#+).*").Match(messages[12]).Groups.Values.Select(x => x.ToString()).ToArray();
            messages[12] = healthField[0].Replace(healthField[1], $"{player.CurrentHealth} / {player.MaxHealth}".PadRight(healthField[1].Length));

            // replace max/current mana on index 14
            var manaField = new Regex(@".* (#+).*").Match(messages[14]).Groups.Values.Select(x => x.ToString()).ToArray();
            messages[14] = manaField[0].Replace(manaField[1], $"{player.CurrentMana} / {player.MaxMana}".PadRight(manaField[1].Length));

            // replace str/dex on index 16
            var strDexField = new Regex(@".* (#+).* (&+).*").Match(messages[16]).Groups.Values.Select(x => x.ToString()).ToArray();
            messages[16] = strDexField[0].Replace(strDexField[1], player.Strength.ToString().PadRight(strDexField[1].Length))
                                              .Replace(strDexField[2], player.Dexterity.ToString().PadRight(strDexField[2].Length));
            // replace vit/energy on index 18
            var vitEnergyField = new Regex(@".* (#+).* (&+).*").Match(messages[18]).Groups.Values.Select(x => x.ToString()).ToArray();
            messages[18] = vitEnergyField[0].Replace(vitEnergyField[1], player.Vitality.ToString().PadRight(vitEnergyField[1].Length))
                                              .Replace(vitEnergyField[2], player.Energy.ToString().PadRight(vitEnergyField[2].Length));
            // replace fire/light resist on index 22
            var fireLightResist = new Regex(@".* (#+).* (&+).*").Match(messages[22]).Groups.Values.Select(x => x.ToString()).ToArray();
            messages[22] = fireLightResist[0].Replace(fireLightResist[1], player.FireResist.ToString().PadRight(fireLightResist[1].Length))
                                              .Replace(fireLightResist[2], player.LightResist.ToString().PadRight(fireLightResist[2].Length));
            // replace Cold/Posion resist on index 24
            var coldPoisonResist = new Regex(@".* (#+).* (&+).*").Match(messages[24]).Groups.Values.Select(x => x.ToString()).ToArray();
            messages[24] = coldPoisonResist[0].Replace(coldPoisonResist[1], player.ColdResist.ToString().PadRight(coldPoisonResist[1].Length))
                                              .Replace(coldPoisonResist[2], player.PoisonResist.ToString().PadRight(coldPoisonResist[2].Length));
            // return the final product
            return messages;
        }

        /// <summary>
        /// Return the Name/Current section of ConsoleUI with the provided name/current formatted in.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        static string[] FormatNameAndCurrentSection(string name, string current)
        {

            var msg = new string[UIStrings["NameAndCurrent"].Length];
            UIStrings["NameAndCurrent"].Select((x, i) => msg[i] = x).ToArray();

            // msg[4] is where the name and current are located in UIStrings["NameAndCurrent"];
            // capture the fields we're editing in fields
            var fields = new Regex(@".* (#+) .* (&+).*").Match(UIStrings["NameAndCurrent"][4]).Groups.Values.Select(x => x.ToString()).ToArray();
            // replace the name and current with the strings provided after formatting them to be centered.
            msg[4] = fields[0].Replace(fields[1], MatchLengthCentered(name, fields[1])).Replace(fields[2], MatchLengthCentered(current, fields[2]));
            // = msg[4].Replace(fields[0], replacement);


            return msg;
        }       

        /// <summary>
        /// Return the consoleui as a string[] with everything but the messages and option list formatted based on player passed in.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static string[] FormatPage(Player player, int indexSelected)
        {
            return UIStrings["Header"].Concat(FormatNameAndCurrentSection(player.Name, player.Current))
                                      .Concat(FormatStatsSection(player))
                                      .Concat(UIStrings["ConstantOptions"])
                                      .Concat(FormatOptions(indexSelected))
                                      .Concat(UIStrings["Footer"]).ToArray();
        }

        static string OptionPadding(int index, int currentIndex, int nextIndex)
        {
            switch (index)
            {
                case int num when num == nextIndex:
                    return "    ==> ";
                case int num when num == currentIndex:
                    return " <==    ";
                default:
                    return "    ";
            }            
        }

        static string MatchLengthCentered(string text, string targetLength)
        {
            return text.PadLeft(targetLength.Length / 2 + text.Length / 2).PadRight(targetLength.Length);
        }


    }
}
