using System;

namespace jeuCombatGlad
{
	public class Armure:Equipements
	{
		public Armure (int nbPoints, int pourcentage, String nom):base(nbPoints, pourcentage, nom)
		{

		}

		public Boolean parer()
		{
			Random rand = new Random ();
			int nbAl = rand.Next (100);
			if (nbAl < this.pourcentage) {
				return true;
			} 
			else 
			{
				return false;
			}
		}

		public override String ToString ()
		{
			return "\n\t\t\t\tnom : " + this.nom
				+ "\n\t\t\t\tNombre de points : " + this.nbPoints
				+ "\n\t\t\t\tPourcentage de chance de parer : " + this.pourcentage;
		}
	}
}

