using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace Test1
{
    class CdR
    {
        MySqlConnection maConnexion;
        public CdR(MySqlConnection maConnexion, string nom)
        {
            this.maConnexion = maConnexion;
            Console.WriteLine("avez-vous déjà un compte? (oui-non)");
            string compte = Console.ReadLine().ToLower();

            if (compte == "oui")
            {
                Console.WriteLine("\n" + "Entrez votre code Cuisinier : ");
                string code = Console.ReadLine();
                Console.Clear();

                //on vérifie que le cdr existe dans la base de données
                string requete = $"Select nom_cdr from cdr where codeCuisinier ='{code}';";
                MySqlCommand command1 = maConnexion.CreateCommand();
                command1.CommandText = requete;
                MySqlDataReader reader = command1.ExecuteReader();
                string[] valueString = new string[reader.FieldCount];
                bool exist = false;
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
                command1.Dispose();

                //si le cdr existe bien
                if (exist == true)

                {
                    Console.Clear();
                    Console.WriteLine("\n" + "Bienvenue sur l'application Cooking ! ");
                    while (true)

                    {
                        Console.WriteLine("\n" + "Que voulez-vous faire?");
                        Console.WriteLine("\n" + "1- Saisir une recette");
                        Console.WriteLine("2- Consulter votre solde de cook ");
                        Console.WriteLine("3- Afficher la liste de ses recettes");
                        Console.WriteLine("return to stop");

                        string reponse = Console.ReadLine().ToLower();
                        Console.Clear();


                        if (reponse != "")
                        {

                            if (reponse == "1")
                            {
                                //creation de la recette 
                                Console.WriteLine("Quel est le nom de la recette?");
                                string nom_recette = Console.ReadLine();
                                Console.WriteLine("Quel est le type de la recette?");
                                string type = Console.ReadLine();
                                List<string> ingredient_quantite = new List<string>();
                                string ingredient = "";
                                Console.WriteLine("'fin' quand tous les ingrédients sont entrés");
                                string requete2 = $"Select * from produits;";
                                MySqlCommand command2 = maConnexion.CreateCommand();
                                command2.CommandText = requete2;
                                MySqlDataReader reader2 = command2.ExecuteReader();
                                Console.WriteLine("\n" + "Voici les ingrédients déjà disponibles (vous pouvez en ajouter d'autres: )"+"\n");
                                while (reader2.Read())
                                {
                                    string ingredients = (string)reader2["nom_ingredients"];

                                    Console.Write(ingredients+ " | ");
                                }
                                Console.WriteLine(" ");
                                reader2.Close();
                                command2.Dispose();
                                //on ajoute les ingrédients
                                while (ingredient != "fin")
                                {
                                    Console.WriteLine("\n"+"Quel est l'ingrédient de la recette?");
                                    ingredient = Console.ReadLine();
                                    if (ingredient == "fin")
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Quel est la quantité de cet ingrédient?");
                                    string quantité = Console.ReadLine();
                                    ingredient_quantite.Add(ingredient);
                                    ingredient_quantite.Add(quantité);
                                }

                                Console.WriteLine("Quel est le descriptif de la recette?");
                                string descriptif = Console.ReadLine();
                                Console.WriteLine("Quel est le prix de la recette?");
                                string prix = Console.ReadLine();

                                //on crée la recette grâce à la fonction suivante 
                                CreationRecette(maConnexion, nom_recette, type, descriptif, prix, code);
                                //on mets à jour la table ingrédients 
                                TableIngrédients(maConnexion, nom_recette, ingredient_quantite);

                            }
                            if (reponse == "2")
                            {
                                //on affiche le solde du cdr avec son code précédemment entré 
                                string requete2 = $"Select * from cdr where codeCuisinier ='{code}';";
                                MySqlCommand command2 = maConnexion.CreateCommand();
                                command2.CommandText = requete2;
                                MySqlDataReader reader2 = command2.ExecuteReader();

                                while (reader2.Read())
                                {
                                    int solde = (int)reader2["soldeCook"];

                                    Console.WriteLine("Votre solde Cook est de : " + solde);
                                }
                                reader2.Close();
                                command2.Dispose();
                            }
                            if (reponse == "3")
                            {
                                //on affiche les recettes du cdr avec son code précédemment entré 
                                string requete3 = $"Select * from recette where codeCuisinier ='{code}';";
                                MySqlCommand command3 = maConnexion.CreateCommand();
                                command3.CommandText = requete3;
                                MySqlDataReader reader3 = command3.ExecuteReader();

                                while (reader3.Read())
                                {
                                    string nom_recette = (string)reader3["nom_recette"];
                                    int nb_commande = (int)reader3["nb_Commande"];

                                    Console.WriteLine("nom de la recette: " + nom_recette + " /// nombre de commandes : " + nb_commande);
                                }
                                reader3.Close();
                                command3.Dispose();
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
                else
                {
                    Console.WriteLine("Erreur d'identification");
                }

                Console.ReadKey();
            }
            // si le compte cdr n'existe pas
            if (compte == "non")
            {
                string reponse = nom;
                Console.WriteLine("Choisissez votre code cuisinier?");
                string reponse2 = Console.ReadLine();
                Insertion(maConnexion, reponse, reponse2);
            }
        }

        //creation du compte cdr avec les valeurs entrés
        static void Insertion(MySqlConnection maConnexion, string reponse, string reponse2)
        {

            string insertTable = $" insert into cdr  Values ('{reponse}', '{reponse2}','0');";
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
        // on crée la recette suite aux infos demandés
        static void CreationRecette(MySqlConnection maConnexion, string nom, string type, string descriptif, string prix, string codeCuisinier)
        {
            string insertTable = $" insert into recette  Values ('{nom}', '{type}','{descriptif}','{prix}','2','{codeCuisinier}','0');"; //2 cook de rémunération au début//0 commande à la création
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
            Console.WriteLine("La recette est créée ! ");
        }


        static void TableIngrédients(MySqlConnection maConnexion, string nom, List<string> list) //+création produit s'il n'existe pas 
        {
            //on parcourt tous les ingrédients de la nouvelle recette 
            for (int i = 0; i < list.Count; i = i + 2)
            {
                string ingredient = list[i];
                int quantite = Convert.ToInt32(list[i + 1]);

                string insertTable = $" insert into liste_ingredient Values ('{nom}','{ingredient}','{quantite}' );";
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

                //on regarde si le produit existe déjà
                string requete11 = $"Select * from produits where nom_ingredients='{ingredient}';";
                MySqlCommand command11 = maConnexion.CreateCommand();
                command11.CommandText = requete11;

                MySqlDataReader reader11 = command11.ExecuteReader();
                int nv_stock_min = 0;
                int nv_stock_max = 0;
                int nv_quantite = 0;
                string count = "";
                while (reader11.Read())
                {
                    count = (string)reader11["nom_ingredients"];
                    nv_quantite = (int)reader11["quantité"] + quantite;
                    nv_stock_min = ((int)reader11["stock_min"]) + 2 *quantite;
                    nv_stock_max = ((int)reader11["stock_max"]) + 3 * quantite;

                }
                reader11.Close();
                command11.Dispose(); 

                //si le produit existe déjà, on mets à jour sa quantité nécessaire
                if (count != "")
                {
                    string requete1 = $"UPDATE produits SET quantité ='{nv_quantite}', stock_min='{nv_stock_min}', stock_max = '{nv_stock_max}' where nom_ingredients = '{ingredient}';";
                    MySqlCommand command1 = maConnexion.CreateCommand();
                    command1.CommandText = requete1;
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    reader1.Close();
                    command1.Dispose();
                }
                //creation si le produit n'existe pas
                else
                {
                    Console.WriteLine($"Quelle est la catégorie d'achat du produit :{ingredient} (primeur, poissonnier, boucher, epicerie, caviste, autre ?");
                    string categorie = Console.ReadLine();
                    string ref_Fournisseur = $"fourn_{categorie}";
                    int stock_min = 2 * quantite;
                    int stock_max = 3 * quantite;

                    //creation produit
                    string requete = $" insert into produits Values ('{ingredient}','{categorie}','{quantite}','0', '{stock_min}','{stock_max}','{ref_Fournisseur}',0);";
                    MySqlCommand command = maConnexion.CreateCommand();
                    command.CommandText = requete;
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine(" ErreurConnexion : " + e.ToString());
                        Console.ReadLine();
                        return;
                    }
                    command.Dispose();

                    //on vérifie si le frounisseur du nouveau produit existe déjà
                    string req = $"Select * from fournisseur where num_fournisseur='{ref_Fournisseur}';";
                    MySqlCommand com = maConnexion.CreateCommand();
                    com.CommandText = req;

                    MySqlDataReader reader = com.ExecuteReader();
                    string count2 = "";
                    while (reader.Read())
                    {
                        count2 = (string)reader["num_fournisseur"];
                    }
                    reader.Close();
                    com.Dispose();

                    //si le fournisseur n'existe pas, on en créé un nouveau:  si le produit n'existait pas
                    if (count2 == "")
                    {
                        string requete4 = $" insert into fournisseur Values ('{ref_Fournisseur}','caroline');";
                        MySqlCommand command4 = maConnexion.CreateCommand();
                        command4.CommandText = requete4;
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
                    }
                }
            }
        }

    }
}

