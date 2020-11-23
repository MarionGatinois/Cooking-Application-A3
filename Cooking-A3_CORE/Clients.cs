using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace Test1
{
    class Clients
    {
        MySqlConnection maConnexion;
        public Clients(MySqlConnection maConnexion)
        {
            this.maConnexion = maConnexion;
            Console.WriteLine("avez-vous déjà un compte? (oui-non)");
            string compte = Console.ReadLine().ToLower();
            if (compte == "oui")
            {
                Console.WriteLine("\n" + "Entrez votre nom : ");
                string nom = Console.ReadLine().ToLower();
                Console.WriteLine("\n" + "Entrez votre numéro de téléphone : ");
                string phone = Console.ReadLine();
                Console.Clear();

                //on vérifie que le compte client existe
                string requete = $"Select nom_client from client where telephone ='{phone}';";
                MySqlCommand command = maConnexion.CreateCommand();
                command.CommandText = requete;
                MySqlDataReader reader = command.ExecuteReader();
                string[] valueString = new string[reader.FieldCount];
                bool exist = false;

                //on recherche si le compte est dans la base de données
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        valueString[i] = reader.GetValue(i).ToString();
                        if (valueString[i] == nom)
                        {
                            exist = true;
                        }
                    }
                    Console.WriteLine();
                }
                reader.Close();
                command.Dispose();

                //si le compte existe, on continue
                if (exist == true)

                {
                    Console.Clear();
                    Console.WriteLine("\n" + "Bienvenue sur l'application Cooking ! ");
                    while (true)

                    {
                        Console.WriteLine("\n" + "Que voulez-vous faire?");
                        Console.WriteLine("1- Passer une commande");
                        Console.WriteLine("2- Parcourir la liste des recettes proposées ");
                        Console.WriteLine("3- Me connecter en tant que créateur de recettes");
                        Console.WriteLine("return to stop");

                        string reponse = Console.ReadLine().ToLower();
                        Console.Clear();


                        if (reponse != "")
                        {

                            if (reponse == "1")
                            {
                                Console.Clear();
                                Console.WriteLine("Entrez paiement pour finir votre commande" + "\n");
                                string commande = "";
                                string panier = "";
                                int prixPanier = 0;
                                while (commande != "paiement")
                                {

                                    //affichage de tous les plats
                                    Console.WriteLine("\n" + "Voici les différents plats : ");
                                    string requete3 = $"Select * from recette;";
                                    MySqlCommand command3 = maConnexion.CreateCommand();
                                    command3.CommandText = requete3;
                                    MySqlDataReader reader3 = command3.ExecuteReader();

                                    while (reader3.Read())
                                    {
                                        string nom_recette = (string)reader3["nom_recette"];
                                        Console.Write(nom_recette + " | ");
                                    }
                                    reader3.Close();
                                    command3.Dispose();

                                    Console.WriteLine("\n" + "\n" + "Choisissez votre recette");
                                    commande = Console.ReadLine();

                                    //on vérifie si on a assez de stock
                                    string requete6 = $"Select liste_ingredient.quantité, produits.stock_actuel from produits, liste_ingredient where liste_ingredient.nom_recette = '{commande}' and produits.nom_ingredients = liste_ingredient.nom_ingredients; ";
                                    MySqlCommand command6 = maConnexion.CreateCommand();
                                    command6.CommandText = requete6;
                                    MySqlDataReader reader6 = command6.ExecuteReader();
                                    bool stock = false;
                                    int nv_stock = 0;
                                    while (reader6.Read())
                                    {
                                        int stock_actuel = (int)reader6["stock_actuel"];
                                        int quantité = (int)reader6["quantité"];
                                        if (stock_actuel > quantité)
                                        {
                                            nv_stock = stock_actuel - quantité;
                                        }
                                        else
                                        {
                                            stock = true;
                                        }
                                    }
                                    reader6.Close();
                                    command6.Dispose();

                                    if (stock == true)
                                    {
                                        Console.WriteLine("Desolé, vous ne pouvez pas commander cette recette.");
                                        Console.ReadKey();

                                    }
                                    Console.Clear();
                                    Console.WriteLine("\n"+ "Entrez paiement pour finir votre commande" + "\n");

                                    if (stock == false)
                                    {
                                        if (commande != "paiement")
                                        {
                                            panier = panier + commande + " | ";
                                        }

                                        //modifications du stock de la recette demandée
                                        string requete7 = $"UPDATE produits,liste_ingredient SET stock_actuel=stock_actuel-liste_ingredient.quantité, derniere_commande=NOW() where liste_ingredient.nom_recette = '{commande}' and produits.nom_ingredients = liste_ingredient.nom_ingredients;";
                                        MySqlCommand command7 = maConnexion.CreateCommand();
                                        command7.CommandText = requete7;
                                        MySqlDataReader reader7 = command7.ExecuteReader();
                                        reader7.Close();
                                        command7.Dispose();


                                        //compteur de recette s'incrémente et modification du prix de vente
                                        //on récupère le prix et le compteur
                                        string requete11 = $"Select * from recette where nom_recette='{commande}';";
                                        MySqlCommand command11 = maConnexion.CreateCommand();
                                        command11.CommandText = requete11;

                                        MySqlDataReader reader11 = command11.ExecuteReader();
                                        int nouveauChiffre = 0;
                                        int nouveauPrix = 0;
                                        int nouvelleRem = 0;
                                        string codeCdR = "";
                                        while (reader11.Read())
                                        {
                                            nouveauChiffre = (int)reader11["nb_Commande"] + 1;
                                            int prix = (int)reader11["prix"];
                                            prixPanier = prixPanier + prix;
                                            nouvelleRem = (int)reader11["remuneration"];
                                            codeCdR = (string)reader11["codeCuisinier"];

                                            if (nouveauChiffre == 11)
                                            {
                                                nouveauPrix = prix + 2;
                                            }
                                            else if (nouveauChiffre == 51)
                                            {
                                                nouveauPrix = prix + 4;
                                                nouvelleRem = 4;
                                            }
                                            else
                                            {
                                                nouveauPrix = prix;
                                            }

                                        }
                                        reader11.Close();
                                        command11.Dispose();
                                        //modifications des informations de la recttte : nb de commandes, rémnuration, prix
                                        string requete1 = $"UPDATE recette SET nb_Commande='{nouveauChiffre}', remuneration = '{nouvelleRem}',prix='{nouveauPrix}' where nom_recette = '{commande}';";
                                        MySqlCommand command1 = maConnexion.CreateCommand();
                                        command1.CommandText = requete1;
                                        MySqlDataReader reader1 = command1.ExecuteReader();
                                        reader1.Close();
                                        command1.Dispose();


                                        //remuneration cdr
                                        string requete2 = $"Select * from cdr where codeCuisinier = '{codeCdR}';;";
                                        MySqlCommand command2 = maConnexion.CreateCommand();
                                        command2.CommandText = requete2;
                                        MySqlDataReader reader2 = command2.ExecuteReader();
                                        int AncienSolde = 0;
                                        while (reader2.Read())
                                        {
                                            AncienSolde = (int)reader2["soldeCook"];
                                        }
                                        reader2.Close();
                                        command2.Dispose();

                                        //mise a jour du soldeCook du Cdr de la recette 
                                        int nouveauSolde = AncienSolde + nouvelleRem;
                                        string requete4 = $"UPDATE cdr SET soldeCook='{nouveauSolde}' where codeCuisinier = '{codeCdR}';";
                                        MySqlCommand command5 = maConnexion.CreateCommand();
                                        command5.CommandText = requete4;
                                        MySqlDataReader reader4 = command5.ExecuteReader();
                                        reader4.Close();
                                        command5.Dispose();
                                    }

                                }
                                //lorsque le client a ecrit "paiement" 
                                Console.Clear();
                                //si la commande est vide 
                                if (panier == "")
                                {
                                    Console.WriteLine("Votre panier est vide !");
                                }
                                //si le panier comporte une ou plusieurs recettes
                                else
                                {
                                    //on récupère le numéro de commande de la commande précédente
                                    string requete111 = $"Select num_commande from commande order by commande.last_update DESC;";
                                    MySqlCommand command111 = maConnexion.CreateCommand();
                                    command111.CommandText = requete111;
                                    MySqlDataReader reader111 = command111.ExecuteReader();
                                    string count2 = "";
                                    string num = "";
                                    reader111.Read();
                                    
                                    num = (string)reader111["num_commande"];
                                    
                                    if (num != "")
                                    {
                                        int count = Convert.ToInt32(num) + 1;
                                        count2 = Convert.ToString(count);

                                    }
                                    else
                                    {
                                        count2 = "1";
                                    }
                                    reader111.Close();
                                    command111.Dispose();

                                    //ajout de la commande dans la table commande
                                    string insertTable = $" insert into commande Values ('{count2}','{panier}',NOW());";
                                    MySqlCommand command4 = maConnexion.CreateCommand();
                                    command4.CommandText = insertTable;
                                    try
                                    {
                                        command4.ExecuteNonQuery();
                                    }
                                    catch (MySqlException e)
                                    {
                                        Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                        Console.ReadLine();
                                        return;
                                    }
                                    command4.Dispose();

                                    //paiement de la commande
                                    Console.WriteLine("Voici le récapitulatif de votre commande : ");
                                    Console.WriteLine("Vous avez commandé : ");
                                    Console.WriteLine(panier);
                                    Console.WriteLine("Le prix total de votre commande est de " + prixPanier + " cooks");

                                    //si compte cdr, on paye alors avec le solde cook
                                    Console.WriteLine("\n" + "Avez-vous un compte CdR ?");
                                    string rep = Console.ReadLine().ToLower() ;
                                    string code = "";
                                    if (rep == "oui")
                                    {
                                        Console.WriteLine("Quel est votre code CdR ?");
                                        code = Console.ReadLine();
                                    }

                                    if (code != "")
                                    {
                                        string req1 = $"Select * from cdr where codeCuisinier ='{code}';";
                                        MySqlCommand com1 = maConnexion.CreateCommand();
                                        com1.CommandText = req1;

                                        MySqlDataReader read1 = com1.ExecuteReader();
                                        int nouveauSolde = 0;

                                        while (read1.Read())
                                        {
                                            int soldeActuel = (int)read1["soldeCook"] + 1;

                                            if (soldeActuel >= prixPanier)
                                            {
                                                nouveauSolde = soldeActuel - prixPanier;
                                                Console.WriteLine("C'est payé !");
                                            }
                                            else
                                            {
                                                nouveauSolde = soldeActuel;
                                                Console.WriteLine("Vous n'avez pas assez de Cook sur votre compte, il faudra payer autrement ");
                                            }

                                        }
                                        read1.Close();
                                        com1.Dispose();

                                        //si le client a un code cdr avec assez de cook
                                        string req = $"UPDATE cdr SET soldeCook ='{nouveauSolde}' where codeCuisinier = '{code}';";
                                        MySqlCommand com = maConnexion.CreateCommand();
                                        com.CommandText = req;
                                        MySqlDataReader read = com.ExecuteReader();
                                        read.Close();
                                        com.Dispose();
                                        Console.ReadKey();
                                    }

                                    else
                                    {
                                        Console.WriteLine("Autre paiement");
                                        Console.ReadKey();

                                    }

                                }
                            }
                            if (reponse == "2")
                            {
                                //affichage de toutes les recettes de tous les cdr
                                Console.Clear();
                                string requete2 = "Select * from recette order by type DESC;";
                                MySqlCommand command2 = maConnexion.CreateCommand();
                                command2.CommandText = requete2;

                                MySqlDataReader reader2 = command2.ExecuteReader();
                                while (reader2.Read())
                                {
                                    string nom_recette = (string)reader2["nom_recette"];
                                    string type = (string)reader2["type"];
                                    string descriptif = (string)reader2["descriptif"];
                                    int prix = (int)reader2["prix"];
                                    Console.WriteLine(nom_recette + " est un " + type + " proposé à " + prix + " cooks. Description : " + descriptif);
                                }
                                reader2.Close();
                                command2.Dispose();
                            }
                            if (reponse == "3")
                            {
                                //envoie vers la classe cdr 
                                Console.Clear();
                                CdR cuisinier = new CdR(maConnexion, nom);

                            }

                            if (reponse == "return")
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("////////////////");
                            Console.WriteLine("Erreur !");
                            Console.WriteLine("////////////////");
                        }
                    }
                } 
                // si le compte n'existe pas 
                else
                {
                    Console.WriteLine("Erreur d'identification");
                }

                Console.ReadKey();
            }
            //creation du compte client 
            if (compte == "non")
            {
                Console.WriteLine("Quel est votre nom?");
                string reponse = Console.ReadLine().ToLower();
                Console.WriteLine("Quel est votre numéro de téléphone?");
                string reponse2 = Console.ReadLine();
                //fonction qui crée le client dans la base de données avec les valeurs entrées par le client 
                Insertion(maConnexion, reponse, reponse2);
            }
        }

        //fonction qui crée le client dans la base de données avec les valeurs entrées par le client 
        static void Insertion(MySqlConnection maConnexion, string reponse, string reponse2)
        {
            string insertTable = $" insert into client  Values ('{reponse}', '{reponse2}');";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = insertTable;
            try
            {
                command3.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            command3.Dispose();
        }
    }
}
