using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsMGLT
{
    public class NumberHelper
    {
        /// <summary>
        /// Check the given string contains number
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool CheckIsNumber(string str)
        {
            return str.All(c => c >= '0' && c <= '9');
        }
    }
}
