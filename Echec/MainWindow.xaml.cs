using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Echec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Garde en mémoire l'existance un tableau de 64 cases
        Case[,] mesCases = new Case[8, 8];

        //Garde en mémoire l'existance de la grille
        Border[,] mesGrilles = new Border[8, 8];

        Case caseSelectionnee;












        public MainWindow()
        {
            InitializeComponent();

        }
        //Méthode qui permet de charger l'échiquier
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Boucle pour les lignes
            for (int i = 0; i <= 7; i++)
            {
                //boucle pour les colonnes
                for (int c = 0; c <= 7; c++)
                {
                    //Création de l'échiquier
                    Border Grille = new Border();
                    Grid.SetRow(Grille, i);
                    Grid.SetColumn(Grille, c);

                    //Création des cases
                    Case maCase = new Case();
                    maCase.Ligne = i;
                    maCase.Colonne = c;

                    //Identifie chaque case
                    mesCases[i,c] = maCase;


                    



                    mesGrilles[i, c] = Grille; 


                    //Isolement des cases
                    Grille.Tag = maCase;
                    Grille.MouseLeftButtonDown += Grille_MouseLeftButtonDown;



                    //Condition pour les couleurs des cases de l'échiquier
                    if ((i + c) % 2 == 0)
                    {
                        Grille.Background = Brushes.Black;
                    }
                    else
                    {
                        Grille.Background = Brushes.White;
                    }



                    //Chargement de l'échiquier dans l'interface
                    Echiquier.Children.Add(Grille);
                }
            }
        }

        private void Grille_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border variable = (Border)sender;
            Case CaseChoisie = (Case)variable.Tag;
            //Condition pour la couleur remettre la couleur
            if (caseSelectionnee != null)
            {


                if (CaseChoisie.Ligne == caseSelectionnee.Ligne && CaseChoisie.Colonne == caseSelectionnee.Colonne)
                {
                    if ((caseSelectionnee.Ligne + caseSelectionnee.Colonne) % 2 == 0)
                    {
                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Black;
                        caseSelectionnee = null;
                        return;
                    }
                    else
                    {
                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.White;
                        caseSelectionnee = null;
                        return;
                    }
                }
                else
                {
                    if ((caseSelectionnee.Ligne + caseSelectionnee.Colonne) % 2 == 0)
                    {
                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Black;
                    }
                    else
                    {
                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.White;
                        
                    }

                }
            }
            //Mémorisation de la case choisie
            caseSelectionnee = CaseChoisie;

            //Permet de changer la couleur de la case choisie
            mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Green;

        }

        private void Echiquier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
