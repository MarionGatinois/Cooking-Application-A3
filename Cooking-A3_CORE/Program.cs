using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            //création de la connexion
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=dm_gatinois_gille;" +
                                         "UID=root;PASSWORD=Mama78.mysql";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }

            //creation des tables si nécessaire (test du code)
            //Console.WriteLine("Voulez-vous créer une table ?");
            //string reponse = Console.ReadLine().ToLower();
            string reponse = "non";
            if (reponse == "oui")
            {
                Console.WriteLine("Laquelle ?");
                Console.WriteLine("1-client 2-CdR 3-Recette 4-Produits 5-Liste_ingredient 6-Fournisseur 7-Commande");
                string reponse2 = Console.ReadLine();
                if (reponse2 == "1")
                {
                    string createTable = $" CREATE TABLE client (nom_client VARCHAR(25), telephone VARCHAR(20));";
                    MySqlCommand command1 = maConnexion.CreateCommand();
                    command1.CommandText = createTable;
                    try
                    {
                        command1.ExecuteNonQuery();

                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine(" ErreurConnexion : " + e.ToString());
                        Console.ReadLine();
                        return;
                    }
                    command1.Dispose();
                }
                if (reponse2 == "2")
                {
                    string createTable2 = $" CREATE TABLE CdR (nom_cdr VARCHAR(25), codeCuisinier VARCHAR(20), soldeCook INT);";
                    MySqlCommand command2 = maConnexion.CreateCommand();
                    command2.CommandText = createTable2;
                    try
                    {
                        command2.ExecuteNonQuery();

                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine(" ErreurConnexion : " + e.ToString());
                        Console.ReadLine();
                        return;
                    }
                    command2.Dispose();
                }
                if (reponse2 == "3")
                {
                    string createTable3 = $" CREATE TABLE recette (nom_recette VARCHAR(25), type VARCHAR(20), descriptif TEXT, prix INT, remuneration INT, codeCuisinier VARCHAR(10), nb_Commande INT)";
                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command3.CommandText = createTable3;
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
                if (reponse2 == "4")
                {
                    string createTable3 = $" CREATE TABLE produits (nom_ingredients VARCHAR(30), catégorie VARCHAR(25), quantité INT, stock_actuel INT, stock_min INT, stock_max INT, num_fournisseur VARCHAR(20),derniere_commande DATETIME)";
                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command3.CommandText = createTable3;
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
                if (reponse2 == "5")
                {
                    string createTable3 = $" CREATE TABLE liste_ingredient (nom_recette VARCHAR(20),nom_ingredients VARCHAR(30), quantité INT)";
                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command3.CommandText = createTable3;
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
                if (reponse2 == "6")
                {
                    string createTable3 = $" CREATE TABLE fournisseur (num_fournisseur VARCHAR(20),nom_fournisseur VARCHAR(20))";
                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command3.CommandText = createTable3;
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
                if (reponse2 == "7")
                {
                    string createTable3 = $" CREATE TABLE commande (num_commande VARCHAR(10), nom_recette TEXT, last_update DATETIME)";
                    MySqlCommand command3 = maConnexion.CreateCommand();
                    command3.CommandText = createTable3;
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

            //exécution du menu

            menu(maConnexion);
            
            //fermeture de la connexion 
            maConnexion.Close();
            Console.ReadLine();
        }

        //menu principal
        static void menu(MySqlConnection maConnexion)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n" + "   Bienvenue dans votre 'Cooking Application' ");
                Console.WriteLine("\n" + "               Qui êtes-vous ? ");
                Console.WriteLine(" 1- Un Client     2 - Un Gestionnaire Cooking  ");
                Console.WriteLine();
                Console.WriteLine("         Un mode 'demo' est disponible en tapant 'demo'");
                Console.WriteLine("\n" + "                                   'end' to stop");

                string reponse = Console.ReadLine().ToLower();
                if (reponse != "")
                {
                    if (reponse == "1")

                    {
                        Clients customer = new Clients(maConnexion);
                    }

                    if (reponse == "2")

                    {

                        Gestionnaire gestionnaire = new Gestionnaire(maConnexion);

                    }
                    if (reponse == "demo")

                    {
                        Console.Clear();
                        demo(maConnexion);

                    }

                    if (reponse == "end")
                    {
                        Console.WriteLine("Merci et appuyer sur entrée pour arréter");
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("//////////////////////////////////");
                    Console.WriteLine("Erreur, recommencez!");
                    Console.WriteLine("//////////////////////////////////");
                }
            }

            Console.ReadKey();
        }
        static void demo(MySqlConnection maConnexion)
        {
            Console.WriteLine("Bienvenue dans le mode demo, ci-dessous les informations sur le base de données :");
            Console.WriteLine("appuyer sur une touche du clavier pour continuer...");
            Console.ReadKey();
            Console.Clear();
            
            //NOMBRE DE CLIENTS
            string requete = $"Select * from client;";
            MySqlCommand command = maConnexion.CreateCommand();
            command.CommandText = requete;
            MySqlDataReader reader = command.ExecuteReader();
            int count=0;
            while (reader.Read())
            {
                count++;
            }
            reader.Close();
            command.Dispose();
            Console.WriteLine("Il y a "+count+" clients inscrits sur l'application.");
            Console.WriteLine("appuyer sur une touche du clavier pour continuer...");
            Console.ReadKey();
            Console.Clear();

            //NOMBRE, NOM, NOMBRE DE RECETTE COMMANDE DES CDR
            string requete1 = $"Select * from cdr, recette where cdr.codeCuisinier=recette.CodeCuisinier order by cdr.codeCuisinier;";
            MySqlCommand command1 = maConnexion.CreateCommand();
            command1.CommandText = requete1;
            MySqlDataReader reader1 = command1.ExecuteReader();
            int count_nb = 0;
            string nom1;
            Console.WriteLine("Voici la liste des CDR sur l'application : "+"\n");
            reader1.Read();
            string nom_recette1 = "";
            string nom_recette2 = (string)reader1["nom_recette"];
            while (nom_recette1!=nom_recette2)
            {
                string nom2 = (string)reader1["nom_cdr"];
                nom1 = nom2;
                int nb_commande = 0;
                count_nb++;

                while (nom2==nom1 && nom_recette1 != nom_recette2)
                {
                    nb_commande = nb_commande + (int)reader1["nb_Commande"];
                    nom_recette1 = nom_recette2;
                    reader1.Read();
                    nom_recette2 = (string)reader1["nom_recette"];
                    nom2 = (string)reader1["nom_cdr"];
                }
                Console.WriteLine("Le Cdr " +nom1+ " a un nombre total de recettes commandées de "+nb_commande);
            }
            Console.WriteLine("\n"+"Il y a donc " + count_nb + " cdr inscrits sur l'application.");
            reader1.Close();
            command1.Dispose();
            Console.WriteLine("appuyer sur une touche du clavier pour continuer...");
            Console.ReadKey();
            Console.Clear();

            //LISTE PRODUIT AVEC QUANTITE < 2* QUANTITE MIN
            string requete2 = $"Select * from produits where stock_actuel <= 2*stock_min order by nom_ingredients";
            MySqlCommand command2 = maConnexion.CreateCommand();
            command2.CommandText = requete2;
            MySqlDataReader reader2 = command2.ExecuteReader();
            Console.WriteLine("Les produits qui ont une quantité 2 fois plus petite que la quantité minimale sont : ");

            while (reader2.Read())
            {
                string nom = (string)reader2["nom_ingredients"];
                int stock = (int)reader2["stock_actuel"];
                int stock_min = (int)reader2["stock_min"];

                Console.WriteLine(nom + " avec un stock actuel de " + stock +" et dont le stock minimal est de "+stock_min);
            }
            reader2.Close();
            command2.Dispose();
            Console.WriteLine("appuyer sur une touche du clavier pour continuer...");
            Console.ReadKey();
            //Console.Clear();

            //LISTE DES RECETTES ET QUANTITE DU PRODUIT DEMANDE 
            Console.WriteLine("\n"+ "Saissisez un des produits précédents pour afficher les recettes utilisant ce produit et la quantité utilisée dans cette recette. " );
            string produit = Console.ReadLine();
            Console.Clear();
            string requete3 = $"Select * from liste_ingredient where nom_ingredients='{produit}';";
            MySqlCommand command3 = maConnexion.CreateCommand();
            command3.CommandText = requete3;
            MySqlDataReader reader3 = command3.ExecuteReader();
            Console.WriteLine("Le produit :" + produit + " est utilisé dans les recettes suivantes : ");
            while (reader3.Read())
            {
                string recette = (string)reader3["nom_recette"];
                int quantite = (int)reader3["quantité"];
                Console.WriteLine(recette + " en quantité : " + quantite);
            }
            reader3.Close();
            command3.Dispose();
            Console.WriteLine("appuyer sur une touche du clavier pour continuer...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Fin du mode demo, retour au menu principal...");
            Console.WriteLine("appuyer sur une touche du clavier pour continuer...");
            Console.ReadKey();

        }
    }
}
