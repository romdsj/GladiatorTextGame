using System;

namespace jeuCombatGlad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Bienvenue dans ce nouveau tournoi.");

			Joueur j1 = new Joueur("Dupont","Bernard","Dupard");
			Joueur j2 = new Joueur ("Durand", "Phillipe", "Dulippe");

			Console.WriteLine ("Creez votre équipe pour le joueur : " + j1.nom);
			creerEquipe (j1);
			Console.WriteLine ("Creez votre équipe pour le joueur : " + j2.nom);
			creerEquipe (j2);

			Console.WriteLine ("Liste des joueurs :");
			Console.WriteLine (j1.ToString());
			Console.WriteLine (j2.ToString());

			Tournoi t = new Tournoi ();
			t.inscrire (j1, j1.equipes[0]);
			t.inscrire (j2, j2.equipes[0]);

			foreach (Equipe eq in t.equipes) {
				Console.WriteLine(eq.ToString());
			}

			t.matchmaking ();

			Console.ReadLine ();
		}

		public static void creerEquipe(Joueur j)
		{
			Console.WriteLine ("Voici votre joueur :\n");
			Console.WriteLine (j.ToString());

			String nomEquipe = "";
			String descEquipe = "";

			while (nomEquipe == "")
			{
				Console.WriteLine ("Entrez le nom de votre equipe.");
				nomEquipe = Console.ReadLine ();
			}

			while (descEquipe == "")
			{
				Console.WriteLine ("Entrez la description  de votre equipe.");
				descEquipe = Console.ReadLine ();
			}

			Console.WriteLine("Votre équipe : " + nomEquipe + " a bien été créée.\nVous avez automatiquement 3 gladiateur dans votre équipe.");
			Console.WriteLine ("1er gladiateur");
			Gladiateur glad1 = creerGladiateur (1);
			Console.WriteLine ("2eme gladiateur");
			Gladiateur glad2 = creerGladiateur (2);
			Console.WriteLine ("3eme gladiateur");
			Gladiateur glad3 = creerGladiateur (3);
			Gladiateur[] gladTab = new Gladiateur[3];
			gladTab [0] = glad1;
			gladTab [1] = glad2;
			gladTab [2] = glad3;
			j.creerEquipe(nomEquipe, descEquipe, gladTab);


		}

		public static Gladiateur creerGladiateur(int nb)
		{
			String nomGlad = "";

			while (nomGlad == "")
			{
				Console.WriteLine ("Entrez le nom du gladiateur n°" + nb + ".");
				nomGlad = Console.ReadLine ();
			}

			Gladiateur glad = new Gladiateur (nomGlad);

			ajouterEquipement (glad);

			return glad;
		}

		public static void ajouterEquipement(Gladiateur glad)
		{
			Equipements[] EquipDef = new Equipements[4];
			Equipements[] EquipAtt = new Equipements[5];

			EquipDef[0] = new Armure(5,20,"Petit bouclier rond");
			EquipDef[1] = new Armure(8,30,"Bouclier rectangulaire");
			EquipDef[2] = new Armure(2,10,"Casque");
			EquipDef[3] = new Armure(7,10,"Trident");

			EquipAtt[0] = new Arme(2,60,"Dague");
			EquipAtt[1] = new Arme(5,70,"Epée");
			EquipAtt[2] = new Arme(7,50,"Lance");
			EquipAtt[3] = new Arme(7,40,"Trident");
			EquipAtt[4] = new Arme(3,30,"Filet");

			Console.WriteLine ("Tu peux avoir jusqu'à 10 points d'équipements (Attaque + Defense).");

			bool test = true;

			while (test) {
				Console.WriteLine ("1. Equipements d'attaque");
				Console.WriteLine ("2. Equipements de defense");
				Console.WriteLine ("0. Quitter");

				int choixAOrD = Convert.ToInt32(Console.ReadLine ());

				if (choixAOrD == 1) {

					bool test2 = true;

					while (test2) {

						for (int i = 0; i < EquipAtt.Length; i++) {
							Console.WriteLine ((i + 1) + ". " + EquipAtt [i].nom + " (Attaque) : " + EquipAtt [i].nbPoints + " points.");
						}
						Console.WriteLine ("0. Quitter");
						int choixD = Convert.ToInt32(Console.ReadLine ());

						if (choixD <= EquipAtt.Length && choixD > 0) {

							if (glad.nbPoints () + EquipAtt [choixD - 1].nbPoints <= 10) {
								Console.WriteLine ("L'équipement a bien été ajouté.");
								glad.ajouterEquipement (EquipAtt [choixD - 1]);
							} else {
								Console.WriteLine ("L'équipements a trop de points.");
							}

						} else if (choixD == 0) {
							test2 = false;
						} else {
							Console.WriteLine ("Veuillez choisir un equipement.");
						}
					}

				} else if (choixAOrD == 2) {

					bool test2 = true;

					while (test2) {

						for (int i = 0; i < EquipDef.Length; i++) {
							Console.WriteLine ((i + 1) + ". " + EquipDef [i].nom + " (Defense) : " + EquipDef [i].nbPoints + " points.");
						}
						Console.WriteLine ("0. Quitter");
						int choixD = Convert.ToInt32(Console.ReadLine ());

						if (choixD <= EquipDef.Length && choixD > 0) {

							if (glad.nbPoints () + EquipDef [choixD - 1].nbPoints <= 10) {
								Console.WriteLine ("L'équipement a bien été ajouté.");
								glad.ajouterEquipement (EquipDef [choixD - 1]);

							} else {
								Console.WriteLine ("L'équipements a trop de points.");
							}

						} else if (choixD == 0) {
							test2 = false;
						} else {
							Console.WriteLine ("Veuillez choisir un equipement.");
						}
					}

				} else if (choixAOrD == 0) {
					test = false;
				} else {
					Console.WriteLine ("Aucun menu ce correspond");
				}

			}

		}
	}
}
