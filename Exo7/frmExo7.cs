using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exo6;

namespace Exo7
{
    public partial class frmExo7 : Form
    {
        public frmExo7()
        {
            InitializeComponent();
            this.afficheStagiaire();
        }


        private void afficheStagiaire()
        {
            DataTable dt = new DataTable();
            DataRow dr;

            //on ajoute 3 colonnes à la dataTable
            dt.Columns.Add("Numero Osia", typeof(System.Int32));
            dt.Columns.Add("Nom", typeof(System.String));
            dt.Columns.Add("prenom", typeof(System.String));

            foreach (TableStagiaire stagiaireEF in Donnees.Db.TableStagiaire.ToList())
            {
                dr = dt.NewRow(); //instanciation datarow = ligne
                dr[0] = stagiaireEF.NumOsiaStagiaire; //affectation des 3 colonne
                dr[1] = stagiaireEF.NomStagiaire;
                dr[2] = stagiaireEF.PrenomStagiaire;

                dt.Rows.Add(dr); // ajjout d'unne nouvelle ligne, Rows est une collection
            }

            this.grdStagiaire.DataSource = dt.DefaultView; // on affecte la source de la datagrid est dt
            this.grdStagiaire.Refresh();
            dt = null;
            dr = null;



        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            frmAjoutStagiaire frmAjout = new frmAjoutStagiaire(); //instancie un form Ajout Stagiaire

            if (frmAjout.ShowDialog() == DialogResult.OK) afficheStagiaire(); //si on sort des controles de frmAjout positivement on affiche la table
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //On ouvre le stagiaire correspondant au double click
            int iStag; // rang du stagiaire dans le tableau
            iStag = (int)this.grdStagiaire.CurrentRow.Cells[0].Value; // 

            TableStagiaire stagiaireEF = Donnees.Db.TableStagiaire.Find(iStag);

            MStagiaire leStagiaire = new MStagiaire();
            leStagiaire.NumOsiaStagiaire = stagiaireEF.NumOsiaStagiaire;
            leStagiaire.NomStagiaire = stagiaireEF.NomStagiaire;
            leStagiaire.PrenomStagiaire = stagiaireEF.PrenomStagiaire;
            leStagiaire.RueStagiaire = stagiaireEF.RueStagiaire;     
            leStagiaire.VilleStagiaire = stagiaireEF.VilleStagiaire;
            leStagiaire.CodePostalStagiaire = stagiaireEF.CodePostalStagiaire;

            frmVisuStagiaire frmVisu = new frmVisuStagiaire(leStagiaire);

            frmVisu.ShowDialog();

            stagiaireEF.NumOsiaStagiaire = leStagiaire.NumOsiaStagiaire;
            stagiaireEF.NomStagiaire = leStagiaire.NomStagiaire;
            stagiaireEF.PrenomStagiaire = leStagiaire.PrenomStagiaire;
            stagiaireEF.RueStagiaire = leStagiaire.RueStagiaire;         // avec conversion en MAJ     
            stagiaireEF.VilleStagiaire = leStagiaire.VilleStagiaire;
            stagiaireEF.CodePostalStagiaire = leStagiaire.CodePostalStagiaire;

            Donnees.Db.SaveChanges();

            this.afficheStagiaire();
        }





        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int iStag = (int)this.grdStagiaire.CurrentRow.Cells[0].Value; // n° de stagiaire = n° de la ligne
            TableStagiaire StagiaireEF = Donnees.Db.TableStagiaire.Find(iStag);

            if ( MessageBox.Show("suppression?" + StagiaireEF.NomStagiaire.Trim(),"suppression") == DialogResult.OK)
            {

                // Donnees.ArrayStag.RemoveAt(iStag);
                Donnees.Db.TableStagiaire.Remove(StagiaireEF);
                Donnees.Db.SaveChanges();
            }

            this.afficheStagiaire();
        }

        private void grdStagiaire_Click(object sender, EventArgs e)
        {
            this.btnSupprimer.Enabled = true;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnRechercher_Click(object sender, EventArgs e)
        {
            if (this.txtRecherche.Text != null)
            {
                ((DataView)(this.grdStagiaire.DataSource)).RowFilter = "Nom like'%" + this.txtRecherche.Text + "%'";
            }
        }

        private void btnTous_Click(object sender, EventArgs e)
        {
            this.txtRecherche.Text = null;
            ((DataView)(this.grdStagiaire.DataSource)).RowFilter = null;
        }
    }
}
