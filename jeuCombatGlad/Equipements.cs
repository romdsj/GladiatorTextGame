using System;

namespace jeuCombatGlad
{
	public class Equipements
	{

		protected int _nbPoints;
		public int nbPoints { get; set; }
		protected int _pourcentage;
		public int pourcentage { get; set;}
		protected String _nom;
		public String nom { get; set; }

		public Equipements()
		{
			this.nbPoints = 0;
			this.pourcentage = 0;
			this._nom = "";
		}

		public Equipements (int nbPoints, int pourcentage, String nom)
		{
			this.nbPoints = nbPoints;
			this.pourcentage = pourcentage;
			this.nom = nom;
		}
	}
}

