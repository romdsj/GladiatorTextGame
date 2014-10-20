using System;

namespace jeuCombatGlad
{
	public class Equipe
	{

		private String _nom;
		public String nom { get; set; }
		private String _descriptif;
		public String descriptif { get; set; }
		private int _nbMatchJoue;
		public int nbMatchJoue { get; set; }
		private int _nbMatchGagne;
		public int nbMatchGagne { get; set; }
		private Gladiateur[] _gladiateurs;
		public Gladiateur[] gladiateurs { get; set; }

		public Equipe()
		{
			this.nom = "";
			this.descriptif = "";
			this.nbMatchJoue = 0;
			this.nbMatchGagne = 0;
			this.gladiateurs = new Gladiateur[3];
		}

		public Equipe (String nom, String descriptif)
		{
			this.nom = nom;
			this.descriptif = descriptif;
			this.nbMatchJoue = 0;
			this.nbMatchGagne = 0;
			this.gladiateurs = new Gladiateur[3];
		}

		public Equipe (String nom, String descriptif, Gladiateur[] glads)
		{
			this.nom = nom;
			this.descriptif = descriptif;
			this.nbMatchJoue = 0;
			this.nbMatchGagne = 0;
			this.gladiateurs = glads;
		}

		public String ordreApparition(Gladiateur glad1, Gladiateur glad2, Gladiateur glad3)
		{
			this.gladiateurs [0] = glad1;
			this.gladiateurs [1] = glad2;
			this.gladiateurs [2] = glad3;

			return "L'ordre des gladiateurs à été mis à jour.";
		}

		public float ratio()
		{
			return (float)nbMatchGagne / (float)nbMatchJoue;
		}

		public override String ToString ()
		{
			String strGlad = "";
			if (this.gladiateurs.Length != 0)
			{
				strGlad += "\t\tGladiateurs : " + strGlad + "\n";
				foreach (Gladiateur e in this.gladiateurs) {
					strGlad += "\n\t\t" + e.ToString ();
				}
			}
			return "nom : " + this.nom + "\n\t\tdescription : " + this.descriptif + "\n\t\tNombre de match joue : " + this.nbMatchJoue + "\n\t\tNombre de match gagne : "  + this.nbMatchGagne + "\n" + strGlad + "\n";
		}
	}
}

