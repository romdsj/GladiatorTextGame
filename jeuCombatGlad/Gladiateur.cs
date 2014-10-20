using System;
using System.Collections.Generic;

namespace jeuCombatGlad
{
	public class Gladiateur
	{

		private String _nom;
		public String nom { get; set; }
		private List<Equipements> _equipement;
		public List<Equipements> equipement { get; set; }
		private int _nbDuelJoue;
		public int nbDuelJoue { get; set; }
		private int _nbDuelGagne;
		public int nbDuelGagne { get; set; }

		public Gladiateur()
		{
			this.nom = "";
			this.equipement = new List<Equipements> ();
			this.nbDuelJoue = 0;
			this.nbDuelGagne = 0;
		}

		public Gladiateur (String nom)
		{
			this.nom = nom;
			this.equipement = new List<Equipements> ();
			this.nbDuelJoue = 0;
			this.nbDuelGagne = 0;
		}

		public int nbPoints()
		{
			int nbPoints = 0;

			foreach(Equipements elem in equipement)
			{
				nbPoints += elem.nbPoints;
			}

			return nbPoints;
		}


		public void trierEquipement ()
		{
			Equipements Equip1 = new Equipements(2,60,"Dague");
			Equipements Equip2 = new Equipements(5,70,"Epée");
			Equipements Equip3 = new Equipements(7,50,"Lance");
			Equipements Equip4 = new Equipements(7,40,"Trident");
			Equipements Equip5 = new Equipements(3,30,"Filet");

			if (equipement.Contains (Equip5)) {
				equipement.Remove (Equip5);
				equipement.Add (Equip5);
			}

			if (equipement.Contains (Equip3)) {
				equipement.Remove (Equip3);
				equipement.Add (Equip3);
			}

			if (equipement.Contains (Equip4)) {
				equipement.Remove (Equip4);
				equipement.Add (Equip4);
			}

			if (equipement.Contains (Equip2)) {
				equipement.Remove (Equip2);
				equipement.Add (Equip2);
			}

			if (equipement.Contains (Equip1)) {
				equipement.Remove (Equip1);
				equipement.Add (Equip1);
			}
		}

		public Arme attaquer()
		{
			foreach(Equipements eq in this.equipement)
			{
				if (eq is Arme) 
				{
					Arme ar = (Arme) eq;
					Console.WriteLine ("Il donne un coup de " + eq.nom + ".");
					if (ar.toucher()) 
					{
						Console.WriteLine ("Le coup porte.");
						return ar;
					}
					Console.WriteLine ("Le coup n'est pas porté.");
				}
			}
			return new Arme ();
		}

		public Boolean defendre()
		{
			foreach(Equipements eq in this.equipement)
			{
				if (eq is Armure) 
				{
					Armure ar = (Armure) eq;
					if (ar.parer()) 
					{
						Console.WriteLine ("L'armure de " + this.nom + " bloque le coup.");
						return true;
					}
				}
			}
			Console.WriteLine ("Aucune armure n'a bloqué le coup, " + this.nom + " est éliminé.");
			return false;
		}

		public Boolean ajouterEquipement(Equipements e)
		{
			this.equipement.Add (e);
			return true;
		}

		public override String ToString ()
		{
			String strEquipement = "\n\t\t\tEquipements : ";
			foreach (Equipements e in this.equipement) 
			{
				strEquipement += "\n\t\t" + e.ToString ();
			}
			return "\tnom : " + this.nom + "\n\t\t\tNombre de duel joue : " + this.nbDuelJoue + "\n\t\t\tNombre de duel gagne : "  + this.nbDuelGagne + strEquipement + "\n";
		}
	}
}

