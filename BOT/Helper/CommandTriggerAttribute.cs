using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Helper
{
    public class CommandTriggerAttribute : Attribute
    {
        public static string Prefix { get; set; }

        public static string Name { get; set; }

        public static string ArgsSeparator { get; set; }

        public static bool EqualName { get; set; }

        public CommandTriggerAttribute(string name, string prefix = "/", string argsSeparator = "-", bool equalName = false)
        {
            Prefix = prefix;
            Name = name;
            ArgsSeparator = argsSeparator;
            EqualName = equalName;
        }
    }
}
