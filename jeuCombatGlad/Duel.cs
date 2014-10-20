using System;

namespace jeuCombatGlad
{
	public class Duel
	{

		private Gladiateur[] _gladiateurs;
		public Gladiateur[] gladiateurs { get; set; }

		public Duel (Gladiateur g1, Gladiateur g2)
		{
			this.gladiateurs = new Gladiateur[2] { g1, g2 };
		}

		public Gladiateur commencerDuel()
		{
			Console.WriteLine ("Le duel entre le gladiateur " + gladiateurs[0].nom + " et " + gladiateurs[1].nom + " commencer.");
			Gladiateur glad = new Gladiateur ();
			while (glad.nom == "") {
				glad = passeDarme (random ());
			}
			Console.WriteLine ("Le gladiateur " + glad.nom + " a gagné le duel.");
			return glad;
		}

		public Gladiateur passeDarme(int nb)
		{

			gladiateurs [0].trierEquipement ();
			gladiateurs [1].trierEquipement ();
			Console.WriteLine ("Le gladiateur " + gladiateurs[nb].nom + " attaque.");
			if (toucher (nb)) {
				Console.WriteLine ("Il élimine son adversaire.");
				return gladiateurs [nb];
			} else {
				Console.WriteLine ("Il n'élimine pas son adversaire.");
				if (nb == 0) {
					Console.WriteLine ("Le gladiateur " + gladiateurs[1].nom + " attaque.");
					if (toucher (1)) {
						Console.WriteLine ("Il élimine son adversaire.");
						return gladiateurs [1];
					} else {
						Console.WriteLine ("Il n'elimine pas son adversaire.");
						return new Gladiateur ();
					}
				} else {
					Console.WriteLine ("Le gladiateur " + gladiateurs[0].nom + " attaque.");
					if (toucher (0)) {
						Console.WriteLine ("Il élimine son adversaire.");
						return gladiateurs [0];
					} else {
						Console.WriteLine ("Il n'elimine pas son adversaire.");
						return new Gladiateur ();
					}
				}
			}
		}

		public bool toucher(int nb)
		{
			Arme equipToucher = gladiateurs [nb].attaquer ();

			if (equipToucher.nom == "Filet") {
				gladiateurs [nb].equipement.Remove (equipToucher);
				if (nb == 0) {
					foreach (Equipements eq in gladiateurs[1].equipement) {
						eq.pourcentage = eq.pourcentage / 2;
					}
				} else {
					foreach (Equipements eq in gladiateurs[0].equipement) {
						eq.pourcentage = eq.pourcentage / 2;
					}
				}
				return true;
			} else if (equipToucher.nom == "") {
				return false;
			} else {
				Console.WriteLine ("");
				if (nb == 0) {
					if (!(gladiateurs [1].defendre ())) {
						return true;
					} else {
						return false;
					}
				} else {
					if (gladiateurs [0].defendre ()) {
						return false;
					} else {
						return true;
					}
				}
			}
		}

		public int random()
		{
			Random rd = new Random ();
			return rd.Next (2);
		}
	}
}

