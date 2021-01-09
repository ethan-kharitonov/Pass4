using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGameEngine
{
    static class ExtentionMethods
    {
        private static Dictionary<ConsoleKey, char> ConsoleKeyToChar = new Dictionary<ConsoleKey, char>()
        {
            { ConsoleKey.OemMinus, '-' },
            { ConsoleKey.OemPlus, '+' },
            { ConsoleKey.Backspace, ' '},
            { ConsoleKey.Oem4, '['},
            { ConsoleKey.Oem6, '['},
            { ConsoleKey.OemComma, '<'},
            { ConsoleKey.OemPeriod, '>'},
            { ConsoleKey.Oem2, '/'},
            { ConsoleKey.Oem5, '\\'},
            { ConsoleKey.Spacebar, ' '},
            { ConsoleKey.Oem3, '`'},
            { ConsoleKey.Oem102, '\\' },
            { ConsoleKey.Oem1, ';' },
            { ConsoleKey.Enter, '|' }



        };
        public static char ToChar(this ConsoleKey consoleKey)
        {
            if (consoleKey.ToString().Length > 1)
            {
                if (ExtentionMethods.ConsoleKeyToChar.Keys.Contains(consoleKey))
                {
                    return ExtentionMethods.ConsoleKeyToChar[consoleKey];
                }

                if(consoleKey >= ConsoleKey.D0 || consoleKey <= ConsoleKey.D9)
                {
                    return (consoleKey - ConsoleKey.D0).ToString()[0];
                }

                return '?';
            }

            return consoleKey.ToString()[0];
        }
    }
}
