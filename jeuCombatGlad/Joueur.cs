using System;
using System.Collections.Generic;

namespace jeuCombatGlad
{
	public class Joueur
	{

		private String _nom;
		public String nom { get; set; }
		private String _prenom;
		public String prenom { get; set; }
		private String _alias;
		public String alias { get; set; }
		private DateTime _inscription;
		public DateTime inscription { get; set; }
		private Equipe[] _equipes;
		public Equipe[] equipes { get; set; }

		public Joueur (String nom, String prenom, String alias)
		{
			this.nom = nom;
			this.prenom = prenom;
			this.alias = alias;
			this.inscription = DateTime.Now;
			this.equipes = new Equipe[3];
		}

		public int creerEquipe(String nom, String desiptif, Gladiateur[] glads)
		{
			if (this._equipes == null || this.equipes.Length < 5) {
				Equipe e = new Equipe (nom, desiptif, glads);
				int index = ajouterEquipe (e);
				return index;
			} 
			else 
			{
				return -1;
			}

		}

		private int ajouterEquipe(Equipe e)
		{
			int i = 0;
			if (this.equipes != null) {
				foreach (Equipe eq in this.equipes) {
					if (eq == null) {
						this.equipes [i] = e;
						return i;
					}
					i++;
				}
			}
			return -1;
		}

		public override String ToString()
		{
			String strEquipe = "";
			strEquipe +="\tequipe : " + strEquipe + "\n";
			foreach (Equipe e in this.equipes) {
				if (e != null) {
					strEquipe += "\n\t\t" + e.ToString ();
				}
			}
			return "\tnom : " + this.nom + "\n\tprenom : " + this.prenom + "\n\talias : " + this.alias + "\n" + strEquipe;
		}
	}
}

