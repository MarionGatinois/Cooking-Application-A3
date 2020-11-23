create database cooking_A3;
use cooking_A3;
USE `cooking_A3`;

CREATE TABLE `cooking_A3`.`recette` (
  `nom_recette` VARCHAR(25) NOT NULL,
  `type` VARCHAR(20) NOT NULL,
  `descriptif` TEXT NOT NULL,
  `prix` INT NOT NULL,
  `remuneration` INT NOT NULL,
  `codeCuisinier` VARCHAR(4) NOT NULL,
  `nb_Commande` INT,
  PRIMARY KEY (`nom_recette`) );
  
CREATE TABLE `cooking_A3`.`client` (
  `nom_client` VARCHAR(25) NOT NULL,
  `telephone` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`telephone`) );
  
CREATE TABLE `cooking_A3`.`cdr` (
  `nom_cdr` VARCHAR(25) NOT NULL,
  `codeCuisinier` VARCHAR(20) NOT NULL,
  `soldeCook` INT,
  PRIMARY KEY (`codeCuisinier`));
 
CREATE TABLE `cooking_A3`.`produits` (
  `nom_ingredients` VARCHAR(30) NOT NULL,
  `catégorie` VARCHAR(25) NOT NULL,
  `quantité` INT NOT NULL,
  `stock_actuel` INT,
  `stock_min` INT NOT NULL,
  `stock_max` INT NOT NULL,
  `num_fournisseur` VARCHAR(20) NOT NULL,
  `derniere_commande` DATETIME NOT NULL);
  
  CREATE TABLE `cooking_A3`.`liste_ingredient` (
  `nom_recette` VARCHAR(20) NOT NULL,
  `nom_ingredients` VARCHAR(30) NOT NULL,
  `quantité` INT NOT NULL);
  
   CREATE TABLE `cooking_A3`.`fournisseur` (
  `num_fournisseur` VARCHAR(20) NOT NULL,
  `nom_fournisseur` VARCHAR(20) NOT NULL);
  
   CREATE TABLE `cooking_A3`.`commande` (
  `num_commande` VARCHAR(20) NOT NULL,
  `nom_recette` TEXT NOT NULL,
  `last_update` DATETIME NOT NULL);
  
  --  insertion dans la table recette  
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('carottes rapées', 'entrée', 'carottes biologiques finement rapées', 10, 2, '1234', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('tomates mimosa', 'entrée', 'tomates farcies au thon', 15, 2, '4545', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('briques au chèvre', 'entrée', 'feuilles de briques remplies de fromage de chèvre', 13, 2, '9999', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('charcuterie', 'entrée', 'assortiment de charcutrie (saucisson sec, jambon sec et boucher de bison)', 16, 2, '9999', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('pates au saumon', 'plat', 'pates au samon de norvège et crème fraiche', 25, 2, '9999', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('pates carbonana', 'plat', '^pates au lardons, oignons et crème fraiche', 24, 2, '9999', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('lasagnes', 'plat', 'lasagnes traditionelles au boeuf', 26, 2, '4545', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('poulet au curry', 'plat', 'filet de poulet avec une sauce au curry accompagné de riz', 27, 2, '4545', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('carpacio de boeuf', 'plat', 'carpacio de boeuf francais accompagné de frites', 31, 2, '9999', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('burger', 'plat', 'burger à la boucher de boeuf, bacon et chedar accompagné de frites', 29, 2, '4545', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('cabillaux', 'plat', 'cabillaux servit avec une poelé de petits légumes', 33, 2, '1234', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('saumons', 'plat', 'saumon a la sauce soja accompagné de riz', 34, 2, '1234', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('salade césar', 'plat', 'salade verte, poulet, bacon et tomates', 28, 2, '4545', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('pizza margarita', 'plat', 'pizza sauce tomate, jambon et mozzarella', 26, 2, '1234', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('fondant au chocolat', 'dessert', 'gateau au chocolat au coeur coulant', 16, 2, '9999', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('glaces 3 boules', 'dessert', 'coupe de glace (fraise, chocolat, vanille)', 10, 2, '4545', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('salade de fruits', 'dessert', 'salade de fruits de saison', 18, 2, '1234', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('tarte aux pommes', 'dessert', 'tarte au pommes normandes servie avec une boule de glace', 18, 2, '1234', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('mojito', 'boisson', 'cooktail menthe et citron vert', 12, 2, '1234', 0);
INSERT INTO `cooking_A3`.`recette` (`nom_recette`, `type`, `descriptif`, `prix`, `remuneration`, `codeCuisinier`, `nb_Commande`) VALUES ('chardonnay', 'boisson', 'vin blanc', 10, 2, '9999', 0);

--  insertion dans la table client
INSERT INTO `cooking_A3`.`client` (`nom_client`, `telephone`) VALUES ('juliette', '0611111111');
INSERT INTO `cooking_A3`.`client` (`nom_client`, `telephone`) VALUES ('marion', '0612345678');
INSERT INTO `cooking_A3`.`client` (`nom_client`, `telephone`) VALUES ('hugo', '0645362718');
INSERT INTO `cooking_A3`.`client` (`nom_client`, `telephone`) VALUES ('camille', '0787965436');
INSERT INTO `cooking_A3`.`client` (`nom_client`, `telephone`) VALUES ('alexandre', '0612873940');
INSERT INTO `cooking_A3`.`client` (`nom_client`, `telephone`) VALUES ('louis', '0625940934');

--  insertion dans la table CDR
INSERT INTO `cooking_A3`.`cdr` (`nom_cdr`, `codeCuisinier`, `soldeCook`) VALUES ('juliette', '9999', 0);
INSERT INTO `cooking_A3`.`cdr` (`nom_cdr`, `codeCuisinier`, `soldeCook`) VALUES ('marion', '1234', 0);
INSERT INTO `cooking_A3`.`cdr` (`nom_cdr`, `codeCuisinier`, `soldeCook`) VALUES ('louis', '4545', 0);

--  insertion dans la table produits
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'carotte', 'primeur',4, 0, 8, 12, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`,`quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'tomate', 'primeur', 6, 0, 12, 18, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'menthe', 'primeur',3, 0, 6, 9, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'citron', 'primeur', 2, 0, 4, 6, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'rhum', 'caviste',1 , 0, 2, 3, 'fourn_caviste', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'chardonnay', 'caviste',3, 0, 6, 9, 'fourn_caviste', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'riz', 'epicerie',2 , 0, 4, 6, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'pates', 'epicerie',2 , 0, 4, 6, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`,`quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'courgette', 'primeur',3, 0, 6, 9, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'pates lasagnes', 'epicerie',1 , 0, 2, 3,'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'glace fraise', 'epicerie', 1 , 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'glace chocolat', 'epicerie', 1 , 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'glace vanille', 'epicerie', 2 , 0, 4, 6, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`,`quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'boeuf', 'boucher', 3, 0, 6, 9, 'fourn_boucher', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'saucisson', 'boucher', 2, 0, 4, 6, 'fourn_boucher', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'viande de bison', 'boucher', 2, 0, 4, 6, 'fourn_boucher', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`,`quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'jambon sec', 'boucher', 3, 0, 6, 9, 'fourn_boucher', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'poulet', 'boucher', 2, 0, 4, 6, 'fourn_boucher', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'lardons', 'boucher', 1, 0, 2, 3, 'fourn_boucher', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'saumon', 'poissonier', 2, 0, 4, 6, 'fourn_poissonier', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`,`quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'cabillaux', 'poissonier', 1, 0, 2, 3, 'fourn_poissonier',0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`,`quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'sauce soja', 'epicerie', 1, 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'curry', 'epicerie', 1, 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'farine', 'epicerie', 1, 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'beurre', 'epicerie', 2, 0, 4, 6,'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'sucre', 'epicerie', 1, 0, 1, 1, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'pomme', 'primeur', 7, 0, 14, 21, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'pate a tarte', 'epicerie', 1, 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'pate a pizza', 'epicerie', 1, 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'crème fraiche', 'epicerie', 2, 0, 4, 6, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'banane', 'primeur', 1, 0, 2, 4, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`,`quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'fraise', 'primeur', 3, 0, 6, 9, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'feuille de brique', 'epicerie', 2, 0, 4, 6, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'fromage de chèvre', 'epicerie', 1, 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'patate', 'primeur', 8, 0, 16, 24, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'salade', 'primeur', 1, 0, 2, 3, 'fourn_primeur', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'mozzarella', 'epicerie', 1, 0, 2, 3, 'fourn_epicerie', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'bacon', 'boucher', 1, 0, 2, 3, 'fourn_boucher', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'thon', 'poissonier', 1, 0, 2, 3, 'fourn_poissonier', 0);
INSERT INTO `cooking_A3`.`produits` (`nom_ingredients`, `catégorie`, `quantité`, `stock_actuel`, `stock_min`, `stock_max`,`num_fournisseur`, `derniere_commande`) VALUES ( 'oignon', 'primeur', 1, 0, 2, 3, 'fourn_primeur', 0);


--  insertion dans la table liste ingredient
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'carotte rapées', 'carotte',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'tomates mimosa', 'tomate',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'tomates mimosa', 'thon',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'briques au chèvre', 'feuille de brique',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'briques au chèvre', 'fromage de chèvre',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'charcuterie', 'saucisson',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'charcuterie', 'jambon sec',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'charcuterie', 'viande de bison',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pates au saumon', 'saumon',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pates au saumon', 'crème fraiche',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pates au saumon', 'pates',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pates carbonara', 'pates',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pates carbonara', 'oignon',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pates carbonara', 'creme fraiche',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pates carbonara', 'lardons',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'lasagnes', 'boeuf',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'lasagnes', 'pates lasagnes',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'lasagnes', 'tomate',3);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'poulet au curry', 'curry',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'poulet au curry', 'poulet',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'poulet au curry', 'riz',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'carpacio de boeuf', 'boeuf',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'carpacio de boeuf', 'patate',4);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'burger', 'patate',4);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'burger', 'tomate',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'burger', 'boeuf',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'cabillaux', 'cabillaux',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'cabillaux', 'carotte',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'cabillaux', 'courgette',3);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'saumons', 'saumon',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'saumons', 'sauce soja',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'saumons', 'riz',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'salade césar', 'poulet',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'salade césar', 'bacon',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'salade césar', 'salade',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'salade césar', 'tomate',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pizza margarita', 'pate a pizza',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pizza margarita', 'tomate',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pizza margarita', 'jambon sec',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'pizza margarita', 'mozzarella',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'fondant au chocolat', 'chocolat',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'fondant au chocolat', 'beurre',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'fondant au chocolat', 'farine',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'fondant au chocolat', 'sucre',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'glace 3 boules', 'glace chocolat',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'glace 3 boules', 'glace vanille',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'glace 3 boules', 'glace fraise',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'salade de fruit', 'pomme',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'salade de fruit', 'fraise',3);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'salade de fruit', 'banane',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'tarte aux pommes', 'pomme',5);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'tarte aux pommes', 'glace vanille',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'tarte aux pommes', 'pate a tarte',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'mojito', 'menthe',3);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'mojito', 'citron',2);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'mojito', 'rhum',1);
INSERT INTO `cooking_A3`.`liste_ingredient` (`nom_recette`, `nom_ingredients`, `quantité`) VALUES ( 'chardonnay', 'chardonnay',3);

--  insertion dans la table liste fournisseur
INSERT INTO `cooking_A3`.`fournisseur` (`num_fournisseur`, `nom_fournisseur`) VALUES ( 'fourn_primeur', 'jules');
INSERT INTO `cooking_A3`.`fournisseur` (`num_fournisseur`, `nom_fournisseur`) VALUES ( 'fourn_boucher', 'eric');
INSERT INTO `cooking_A3`.`fournisseur` (`num_fournisseur`, `nom_fournisseur`) VALUES ( 'fourn_poissonier', 'romain');
INSERT INTO `cooking_A3`.`fournisseur` (`num_fournisseur`, `nom_fournisseur`) VALUES ( 'fourn_epicerie', 'alex');
INSERT INTO `cooking_A3`.`fournisseur` (`num_fournisseur`, `nom_fournisseur`) VALUES ( 'fourn_caviste', 'hugo');

--  insertion dans la table commande
INSERT INTO `cooking_A3`.`commande` (`num_commande`, `nom_recette`,`last_update`) VALUES ( '1', 'test',0);

