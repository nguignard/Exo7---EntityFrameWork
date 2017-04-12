using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo6;

namespace Exo7
{
    public class Outils
    {
        /// <summary>
        /// Controle si une string est un int32
        /// </summary>
        /// <param name="s">string à controler</param>
        /// <returns></returns>
        public static Boolean EstEntier(String s)
        {
            // on verifie:
            // - uniquementdes chiffres
            // - pas vide
            // - <9 chiffres : capa max des int32
            bool code = true;

            if (s.Length < 10 && s.Length > 0)
            {
                foreach (char c in s)
                {
                    if (!char.IsDigit(c))
                    {
                        code = false;
                    }
                }
            }
            else
            {
                code = false;
            }
            return code;
        }




    }
}
