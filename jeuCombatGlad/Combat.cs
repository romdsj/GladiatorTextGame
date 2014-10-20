using System;

namespace jeuCombatGlad
{
	public class Combat
	{

		private Equipe[] _equipes;
		public Equipe[] equipes { get; set; }

		public Combat(Equipe eq1, Equipe eq2)
		{
			equipes = new Equipe[2] { eq1, eq2 };
		}

		public Equipe commencerCombat()
		{
			int gladDuelEquipe1 = 0;
			int gladDuelEquipe2 = 0;
			int scoreEquipe1 = 0;
			int scoreEquipe2 = 0;

			Console.WriteLine ("Le combat entre " + equipes [0].nom + " et " + equipes [1].nom + " commence.");

			while (equipes [0].gladiateurs.Length > gladDuelEquipe1 && equipes [1].gladiateurs.Length > gladDuelEquipe2) {

				Duel d = new Duel (equipes [0].gladiateurs [gladDuelEquipe1], equipes [1].gladiateurs [gladDuelEquipe2]);
				Gladiateur gladWin = d.commencerDuel ();
				if (equipes [0].gladiateurs [0].Equals (gladWin) || equipes [0].gladiateurs [1].Equals (gladWin) || equipes [0].gladiateurs [2].Equals (gladWin)) {
					gladDuelEquipe2 += 1;
					scoreEquipe1 += 1;
				} else {
					gladDuelEquipe1 += 1;
					scoreEquipe2 += 1;
				}
			}
			if (scoreEquipe1 > scoreEquipe2) {
				Console.WriteLine ("L'équipe " + equipes[0].nom  + " a gagné le combat.");
				return equipes [0];
			} else {
				return equipes [1];
			}
		}
	}
}

