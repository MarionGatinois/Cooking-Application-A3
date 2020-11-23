using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using System.Xml;

namespace Test1
{
    class Gestionnaire //code Gestionnaire : 0000
    {
        MySqlConnection maConnexion;
        public Gestionnaire(MySqlConnection maConnexion)
        {
            this.maConnexion = maConnexion;
            Console.WriteLine("Entrez le code Gestionnaire");
            string code = Console.ReadLine();

            //si le code est correct
            if (code == "0000")
            {
                Console.Clear();
                Console.WriteLine("\n" + "Bienvenue sur l'application Cooking ! ");
                while (true)

                {
                    Console.WriteLine("\n" + "Que voulez-vous faire?");
                    Console.WriteLine("\n" + "1- Voir le tableau de bord de la semaine");
                    Console.WriteLine("2- Faire le réapprovisionnement hebdomadaire des produits ");
                    Console.WriteLine("3- Supprimer une recette");
                    Console.WriteLine("4- Supprimer un Créateur de Recettes");
                    Console.WriteLine("return to stop");

                    string reponse = Console.ReadLine().ToLower();
                    Console.Clear();


                    if (reponse != "")
                    {
                        if (reponse == "1")
                        {
                            //affichage du cdr de la semaine , nécessaire d'utiliser les dates des commandes 
                            string requete = $"Select * from cdr,recette, commande where recette.codeCuisinier=cdr.codeCuisinier AND commande.last_update > DATE_SUB(NOW(), INTERVAL 7 DAY)";
                            MySqlCommand command = maConnexion.CreateCommand();
                            command.CommandText = requete;
                            MySqlDataReader reader = command.ExecuteReader();
                            reader.Read();
                            string nom1;
                            string nom_recette1 = "";
                            string nom_recette2 = (string)reader["nom_recette"];
                            int cdr_semaine=0;
                            string nom_cdr="";
                            while (nom_recette1 != nom_recette2)
                            {
                                string nom2 = (string)reader["nom_cdr"];
                                nom1 = nom2;
                                int nb_commande = 0;
                                while (nom2 == nom1 && nom_recette1 != nom_recette2)
                                {
                                    nb_commande = nb_commande + (int)reader["nb_Commande"];
                                    nom_recette1 = nom_recette2;
                                    reader.Read();
                                    nom_recette2 = (string)reader["nom_recette"];
                                    nom2 = (string)reader["nom_cdr"];                                    
                                }
                                if (nb_commande > cdr_semaine)
                                {
                                    cdr_semaine = nb_commande;
                                    nom_cdr = nom1;
                                }
                            }
                            Console.WriteLine("\n" + "Le Cdr de la semaine est " + nom_cdr);

                            reader.Close();
                            command.Dispose();
                           
                            

                            ///top 5 recettes
                            Console.WriteLine("\n"+"Le top 5 recettes :");
                            string requete2 = $"Select * from recette, cdr where recette.codeCuisinier=cdr.codeCuisinier order by recette.nb_Commande DESC";
                            MySqlCommand command2 = maConnexion.CreateCommand();
                            command2.CommandText = requete2;
                            MySqlDataReader reader2 = command2.ExecuteReader();

                            for (int i = 1; i < 6; i++)
                            {
                                reader2.Read();
                                string nom_recette = (string)reader2["nom_recette"];
                                int commande = (int)reader2["nb_Commande"];
                                string nom_cuisinier = (string)reader2["nom_cdr"];
                                string type = (string)reader2["type"];

                                Console.WriteLine("N°" + i + " : " + nom_recette + " avec " + commande + " commandes ! C'est un " + type + " créé par " + nom_cuisinier);
                            }

                            reader2.Close();
                            command2.Dispose();

                            ///CdR  d'Or
                            string requete1 = $"Select * from cdr, recette  where cdr.codeCuisinier=recette.CodeCuisinier;";
                            MySqlCommand command1 = maConnexion.CreateCommand();
                            command1.CommandText = requete1;
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            int count_nb = 0;
                            string nom3;
                            reader1.Read();
                            string nom_recette3 = "";
                            string nom_recette4 = (string)reader1["nom_recette"];
                            while (nom_recette3 != nom_recette4)
                            {
                                string nom2 = (string)reader1["nom_cdr"];
                                nom3 = nom2;
                                int nb_commande = 0;
                                count_nb++;

                                while (nom2 == nom3 && nom_recette3 != nom_recette4)
                                {
                                    nb_commande = nb_commande + (int)reader1["nb_Commande"];
                                    nom_recette3 = nom_recette4;
                                    reader1.Read();
                                    nom_recette4 = (string)reader1["nom_recette"];
                                    nom2 = (string)reader1["nom_cdr"];
                                }
                                if (nb_commande > cdr_semaine)
                                {
                                    cdr_semaine = nb_commande;
                                    nom_cdr = nom3;
                                }
                            }
                            Console.WriteLine("\n" + "Le Cdr d'or est " + nom_cdr + " avec " + cdr_semaine + " commandes !");

                            reader1.Close();
                            command1.Dispose();

                            ///Ses meilleures recettes 
                            Console.WriteLine("\n" + "Ses 5 meilleures recettes :");
                            string requete11 = $"Select recette.nom_recette, recette.nb_Commande from recette, cdr where recette.codeCuisinier=cdr.codeCuisinier and cdr.nom_cdr='{nom_cdr}' order by nb_Commande DESC";
                            MySqlCommand command11 = maConnexion.CreateCommand();
                            command11.CommandText = requete11;
                            MySqlDataReader reader11 = command11.ExecuteReader();
                            for (int i = 1; i < 6; i++)
                            {
                                reader11.Read();
                                string nom_recette = (string)reader11["nom_recette"];
                                int commande = (int)reader11["nb_Commande"];

                                Console.WriteLine("N°" + i + " : " + nom_recette + " avec " + commande + " commandes !");
                            }
                            reader11.Close();
                            command11.Dispose();

                            Console.ReadLine();
                        }
                        if (reponse == "2")
                        {
                            //Mise à jour des quantités pas utilisé depuis 30 jours 
                            string requete7 = $"UPDATE produits SET stock_max=stock_max/2, stock_min=stock_min/2 where derniere_commande = DATE_SUB(NOW(), INTERVAL 30 DAY);";
                            MySqlCommand command7 = maConnexion.CreateCommand();
                            command7.CommandText = requete7;
                            MySqlDataReader reader7 = command7.ExecuteReader();
                            reader7.Close();
                            command7.Dispose();


                            //Liste des  produits ayant quantité < quantité min
                            string requete = $"Select * from produits where stock_actuel <= stock_min";
                            MySqlCommand command = maConnexion.CreateCommand();
                            command.CommandText = requete;
                            MySqlDataReader reader = command.ExecuteReader();
                            Console.WriteLine("Les produits qui ont un trop petit stock sont : ");

                            while (reader.Read())
                            {
                                string nom = (string)reader["nom_ingredients"];
                                int stock = (int)reader["stock_actuel"];
                                Console.WriteLine("Produits : " + nom + " avec un stock actuel de " + stock);
                            }
                            reader.Close();
                            command.Dispose();

                            //approviosnnement : les commandes
                            Console.WriteLine("Voulez-vous faire l'approvisionnement des produits ?");
                            reponse = Console.ReadLine();
                            if (reponse == "oui")
                            {
                                //Creation du fichier XML

                                FileStream myFileStream = new FileStream("C:/Users/mario/Desktop/ProjetInfo/commandes.xml", FileMode.OpenOrCreate);
                                XmlTextWriter myXmlTextWriter = new XmlTextWriter(myFileStream, System.Text.Encoding.UTF8);
                                myXmlTextWriter.Formatting = Formatting.Indented;
                                myXmlTextWriter.WriteStartDocument(false);
                                DateTime date = DateTime.Now;
                                myXmlTextWriter.WriteComment("Commandes du Gestionnaire : ");
                                myXmlTextWriter.WriteComment("A la date de "+date+ ": ");
                                myXmlTextWriter.WriteStartElement("Commande");

                                //selection des produits à commander 
                                string requete1 = $"Select * from produits order by num_fournisseur";
                                MySqlCommand command1 = maConnexion.CreateCommand();
                                command1.CommandText = requete1;
                                MySqlDataReader reader1 = command1.ExecuteReader();
                                while (reader1.Read())
                                {
                                    string nom = (string)reader1["nom_ingredients"];
                                    int stock_max = (int)reader1["stock_max"];
                                    int stock_actuel = (int)reader1["stock_actuel"];
                                    int stock_commandé = stock_max - stock_actuel;
                                    string fournisseur = (string)reader1["num_fournisseur"];
                                    myXmlTextWriter.WriteStartElement("Produits : ");
                                    myXmlTextWriter.WriteStartElement("Référence fournisseur : ");
                                    myXmlTextWriter.WriteAttributeString("",$"{fournisseur}");
                                    myXmlTextWriter.WriteStartElement("ingrédient : ");
                                    myXmlTextWriter.WriteAttributeString("", $"{nom}");
                                    myXmlTextWriter.WriteStartElement("quantité commandé : ");
                                    myXmlTextWriter.WriteAttributeString("",$"{stock_commandé}");
                                    myXmlTextWriter.WriteEndElement();
                                    myXmlTextWriter.WriteEndElement();
                                    myXmlTextWriter.WriteEndElement();
                                    myXmlTextWriter.WriteEndElement();


                                }
                                myXmlTextWriter.WriteEndElement();
                                reader1.Close();
                                command1.Dispose();

                                myXmlTextWriter.Flush();
                                myXmlTextWriter.Close();

                                //modification des stocks suite à la commande
                                string requete2 = $"UPDATE produits SET stock_actuel=stock_max;";
                                MySqlCommand command2 = maConnexion.CreateCommand();
                                command2.CommandText = requete2;
                                MySqlDataReader reader2 = command2.ExecuteReader();
                                reader2.Close();
                                command2.Dispose();

                                Console.WriteLine("Le fichier de commande a bien été créé.");

                            }
                        }
                   
        
                        if (reponse == "3")
                        {
                            //supprime une recette grâce à son nom
                            Console.WriteLine("Entrez le nom de la recette à supprimer");
                            string nom_recette = Console.ReadLine();
                            string requete3 = $"Delete from recette where nom_recette ='{nom_recette}';";
                            MySqlCommand command3 = maConnexion.CreateCommand();
                            command3.CommandText = requete3;
                            MySqlDataReader reader3 = command3.ExecuteReader();
                            reader3.Close();
                            command3.Dispose();
                            string requete7 = $"Delete from liste_ingredient where nom_recette ='{nom_recette}';";
                            MySqlCommand command7 = maConnexion.CreateCommand();
                            command7.CommandText = requete7;
                            MySqlDataReader reader7 = command7.ExecuteReader();
                            reader7.Close();
                            command7.Dispose();
                            Console.WriteLine("La recette a bien été supprimée!");

                        }
                        if (reponse == "4")
                        {
                            //supprime un cdr grâce à son nom et code 
                            Console.WriteLine("Entrez le nom du Cdr à supprimer");
                            string nom_CdR = Console.ReadLine();
                            Console.WriteLine("Entrez le code_Cuisinier du CdR à supprimer");
                            string code_Cuisinier = Console.ReadLine();

                            string requete4 = $"Delete from cdr where nom_cdr ='{nom_CdR}' and codeCuisinier = '{code_Cuisinier}';";
                            MySqlCommand command4 = maConnexion.CreateCommand();
                            command4.CommandText = requete4;
                            MySqlDataReader reader4 = command4.ExecuteReader();
                            reader4.Close();
                            command4.Dispose();
                            Console.WriteLine("Le Cdr a bien été supprimé!");

                            //on supprime aussi toutes les recettes du cdr supprimé 
                            string requete5 = $"Delete from recette where codeCuisinier = '{code_Cuisinier}';";
                            MySqlCommand command5 = maConnexion.CreateCommand();
                            command5.CommandText = requete5;
                            MySqlDataReader reader5 = command5.ExecuteReader();
                            reader5.Close();
                            command5.Dispose();
                            Console.WriteLine("Le Cdr a bien été supprimé!");

                        }
                        if (reponse == "return")
                        {
                            break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Erreur d'identification");
            }

            Console.ReadKey();
        }
    }
}

