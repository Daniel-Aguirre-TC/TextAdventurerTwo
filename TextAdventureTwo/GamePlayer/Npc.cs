using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureTwo.GameMessages;

namespace TextAdventureTwo.GamePlayer
{
    public class Npc
    {
        public string Name { get; set; }
        public Dictionary<string, string[]> Dialog { get; set; }
        public List<string> AvailableDialog { get; set; }
        
        public Npc(string name, Dictionary<string, string[]> dialog )
        {
            Name = name;
            Dialog = dialog;
            AvailableDialog = new List<string>()
            {
                "Introduction"
            };

        }

        /// <summary>
        /// Display Npc "Greeting", and then display the AvailableDialog strings. These should be formatted to match a key for the  Npc Dialog Dictionary.
        /// </summary>
        /// <returns></returns>
        public string[] ApproachNpc()
        {
            MessageController.AddMessage(Dialog["Greeting"]);
            var options = new string[AvailableDialog.Count() + 1];
            AvailableDialog.Select((x, i) => options[i] = "Discuss " + x).ToList();
            options[options.Count() - 1] = "Return to Town";
            return options;
        }

        /// <summary>
        /// Takes the provided messageKey and adds it to the AvailableDialog list so that the Npc can display it. Must match a key from Dialog
        /// </summary>
        /// <param name="messageKey"></param>
        public void UnlockMessage(string messageKey)
        {
            if(Dialog.ContainsKey(messageKey))
            {
                AvailableDialog.Add(messageKey);
            }
        }

        public string[] PullDialog(string messageKey)
        {
            if (AvailableDialog.Contains(messageKey))
            {
                return Dialog[messageKey];
            }
            //TODO: take another look at this
            else return null;
        }

    }
}
