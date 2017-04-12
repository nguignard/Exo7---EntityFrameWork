using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo6
{
    public class MStagiaire
    {

        
        private int numOsiaStagiaire;
        private string nomStagiaire;
        private string prenomStagiaire;
        private string rueStagiaire;
        private string villeStagiaire;
        private string codePostalStagiaire;
        private int nbreNotesStagiaire;
        private double pointsNotesStagiaire;

        public int NumOsiaStagiaire { get { return numOsiaStagiaire; } set { this.numOsiaStagiaire = value; } }
        public string NomStagiaire { get { return this.nomStagiaire; } set { this.nomStagiaire = value.Trim().ToUpper(); } }
        public string PrenomStagiaire { get { return this.prenomStagiaire; } set { this.prenomStagiaire = value.Trim().ToLower(); } }
        public string RueStagiaire { get { return this.rueStagiaire; } set { this.rueStagiaire = value; } }
        public string VilleStagiaire { get { return this.villeStagiaire; } set { this.villeStagiaire = value.Trim().ToUpper(); } }
        public string CodePostalStagiaire
        {
            get { return this.codePostalStagiaire; }
            set
            {
                // l'appelant doit fournir un code postal valide à 5 chiffres  
                Int32 i;               // variable de boucle  
                Boolean erreur = false; // indicateur erreur   
                if (value.Length == 5) // 5 car. attendus : OK ==> contrôler un à un          
                {
                    for (i = 0; i < value.Length; i++)  // controle chiffres par boucle          
                    {
                        if (!(Char.IsDigit(value[i]))) // charabia ??     
                        { erreur = true; }
                    } // fin de boucle controle chiffres          
                    if (erreur) //on a rencontre un non-chiffre     
                    {
                        throw new Exception(value.ToString() + "\n" + "n'est pas un code postal valide : uniquement des chiffres");
                    }
                            
                            
                                     
                    //{                 // première solution par simple messagebox         
                    //    System.Windows.Forms.MessageBox.Show(value.ToString() + "\n" + "n'est pas un code postal valide : uniquement des chiffres", "Erreur Classe MStagiaire", System.Windows.Forms.MessageBoxButtons.OK);
                    //}
                    else
                    {
                        codePostalStagiaire = value;  // tout est bon, on affecte la propriété           
                    }
                }
                else // il n'y a pas 5 caractères        
                {                 // première solution par simple messagebox           
                    throw new Exception(value.ToString() + "\n" + "n'est pas un code postal valide : 5 chiffres, pas plus, pas moins");
                }
            }
        }



        /// <summary>     /// alimente nbreNotesStagiaire et pointsNotesStagiaire     /// </summary>     /// <param name="laNote">la nouvelle note à prendre en compte</param>     
        public void RecevoirNote(float laNote) { this.nbreNotesStagiaire++; this.pointsNotesStagiaire += laNote; }

        /// <summary>     /// calcule et retourne la moyenne des notes     /// </summary>     /// <returns>nouvelle moyenne des notes</returns>    
        public Double DonnerMoyenne()
        { return this.pointsNotesStagiaire / this.nbreNotesStagiaire; }



    }
}
