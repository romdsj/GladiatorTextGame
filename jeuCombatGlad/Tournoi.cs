using System;
using System.Collections.Generic;
using System.Linq;

namespace jeuCombatGlad
{
	public class Tournoi
	{

		private List<Joueur> _joueurs;
		public List<Joueur> joueurs { get; set; }
		private List<Equipe> _equipes;
		public List<Equipe> equipes { get; set; }

		public Tournoi ()
		{
			this.joueurs = new List<Joueur> ();
			this.equipes = new List<Equipe> ();
		}

		public String inscrire(Joueur j, Equipe e)
		{
			if (!(testJoueur(j))) 
			{
				this.joueurs.Add (j);
				this.equipes.Add (e);
				return "Le joueur et son équipe ont bien été inscrit au tournoi.";
			} 
			else 
			{
				return "Le joueur existe déjà";
			}
		}

		public Boolean testJoueur(Joueur j)
		{
			return this.joueurs.Contains(j);
		}

		public void triEquipe()
		{
			this.equipes = this.equipes.OrderByDescending (Equipe => Equipe.ratio ()).ToList<Equipe>();
		}

		public Equipe matchmaking()
		{
			Console.WriteLine ("Le tournoi commence.");
			triEquipe();
			while (equipes.Count > 1) {
				for (int i = 0; i + 2 <= equipes.Count; i += 2) {
					Combat cmb = new Combat (equipes [i], equipes [i + 1]);
					equipes.Remove (cmb.commencerCombat ());
				}
			}

			Console.WriteLine ("L'equipe " + equipes[0].nom + " a gagné le tournoi.");
			return equipes [0];
		}
	}
}

