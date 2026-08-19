using System.ComponentModel.DataAnnotations;
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
                    mesCases[i, c] = maCase;


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

                    //Liaison pour les images
                   /* BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(@"Image_Piece/TourB.png",UriKind.Relative);
                    bitmapImage.EndInit();

                    //Association image
                    Image imagePiece = new Image();
                    imagePiece.Source = bitmapImage;

                    Grille.Child = imagePiece;*/
                }
            }
            //Création des Pièces
            for (int c = 0; c <= 7; c++)
            {
                //Création des Pièces Blanches
                Piece maPieceN = new Piece();
                Piece maPieceB = new Piece();
                switch (c)
                {
                    case 0:
                        maPieceB.Type = TypePiece.Tour;
                        maPieceB.Couleur = CouleurPiece.Blanc;
                        mesCases[0, 0].Piece = maPieceB;
                        break;

                    case 1:
                        maPieceB.Type = TypePiece.Cavalier;
                        maPieceB.Couleur = CouleurPiece.Blanc;
                        mesCases[0, 1].Piece = maPieceB;
                        break;

                    case 2:
                        maPieceB.Type = TypePiece.Fou;
                        maPieceB.Couleur = CouleurPiece.Blanc;

                        mesCases[0, 2].Piece = maPieceB;
                        break;

                    case 3:
                        maPieceB.Type = TypePiece.Dame;
                        maPieceB.Couleur = CouleurPiece.Blanc;
                        mesCases[0, 3].Piece = maPieceB;
                        break;

                    case 4:
                        maPieceB.Type = TypePiece.Roi;
                        maPieceB.Couleur = CouleurPiece.Blanc;
                        mesCases[0, 4].Piece = maPieceB;
                        break;
                    case 5:
                        maPieceB.Type = TypePiece.Fou;
                        maPieceB.Couleur = CouleurPiece.Blanc;
                        mesCases[0, 5].Piece = maPieceB;
                        break;
                    case 6:
                        maPieceB.Type = TypePiece.Cavalier;
                        maPieceB.Couleur = CouleurPiece.Blanc;
                        mesCases[0, 6].Piece = maPieceB;
                        break;
                    case 7:
                        maPieceB.Type = TypePiece.Tour;
                        maPieceB.Couleur = CouleurPiece.Blanc;
                        mesCases[0, 7].Piece = maPieceB;
                        break;
                }

                //Création des pions blancs

                Piece pionB = new Piece();
                pionB.Type = TypePiece.Pion;
                pionB.Couleur = CouleurPiece.Blanc;
                mesCases[1, c].Piece = pionB;

                //Création des Pièces Noirs
                switch (c)
                {
                    case 0:
                        maPieceN.Type = TypePiece.Tour;
                        maPieceN.Couleur = CouleurPiece.Noir;
                        mesCases[7, 0].Piece = maPieceN;
                        break;

                    case 1:
                        maPieceN.Type = TypePiece.Cavalier;
                        maPieceN.Couleur = CouleurPiece.Noir;
                        mesCases[7, 1].Piece = maPieceN;
                        break;

                    case 2:
                        maPieceN.Type = TypePiece.Fou;
                        maPieceN.Couleur = CouleurPiece.Noir;
                        mesCases[7, 2].Piece = maPieceN;
                        break;

                    case 3:
                        maPieceN.Type = TypePiece.Dame;
                        maPieceN.Couleur = CouleurPiece.Noir;
                        mesCases[7, 3].Piece = maPieceN;
                        break;

                    case 4:
                        maPieceN.Type = TypePiece.Roi;
                        maPieceN.Couleur = CouleurPiece.Noir;
                        mesCases[7, 4].Piece = maPieceN;
                        break;
                    case 5:
                        maPieceN.Type = TypePiece.Fou;
                        maPieceN.Couleur = CouleurPiece.Noir;
                        mesCases[7, 5].Piece = maPieceN;
                        break;
                    case 6:
                        maPieceN.Type = TypePiece.Cavalier;
                        maPieceN.Couleur = CouleurPiece.Noir;
                        mesCases[7, 6].Piece = maPieceN;
                        break;
                    case 7:
                        maPieceN.Type = TypePiece.Tour;
                        maPieceN.Couleur = CouleurPiece.Noir;
                        mesCases[7, 7].Piece = maPieceN;
                        break;
                }


                //Création des pions noirs
                Piece pionN = new Piece();
                pionN.Type = TypePiece.Pion;
                pionN.Couleur = CouleurPiece.Noir;
                mesCases[6, c].Piece = pionN;

            }
            for (int i = 0; i <= 7; i++) 
            { 
                for (int c = 0; c <= 7; c++) 
                { 
                    if (mesCases[i, c].Piece is not null) 
                    {
                        switch(mesCases[i,c].Piece.Type)
                        {
                            case TypePiece.Pion:
                                if (mesCases[i, c].Piece.Couleur == CouleurPiece.Blanc)
                                {
                                    BitmapImage ImagePion = new BitmapImage();
                                    ImagePion.BeginInit();
                                    ImagePion.UriSource = new Uri(@"Image_Piece/PionB.png", UriKind.Relative);
                                    ImagePion.EndInit();

                                    Image imageP = new Image();
                                    imageP.Source = ImagePion;

                                    mesGrilles[i, c].Child = imageP;
                                }
                                else
                                {
                                    BitmapImage ImagePion = new BitmapImage();
                                    ImagePion.BeginInit();
                                    ImagePion.UriSource = new Uri(@"Image_Piece/PionN.png", UriKind.Relative);
                                    ImagePion.EndInit();

                                    Image imageP = new Image();
                                    imageP.Source = ImagePion;

                                    mesGrilles[i, c].Child = imageP;
                                }
                                break;
                        }
                            
                    } 
                } 
            }
        }


        private void Grille_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border variable = (Border)sender;
            Case CaseChoisie = (Case)variable.Tag;

            // Une case est-elle déjà sélectionnée ?
            if (caseSelectionnee != null)
            {
                // Est-ce que je clique sur la même case ?
                if (CaseChoisie.Ligne == caseSelectionnee.Ligne &&
                    CaseChoisie.Colonne == caseSelectionnee.Colonne)
                {
                    // Remettre la couleur originale
                    if ((caseSelectionnee.Ligne + caseSelectionnee.Colonne) % 2 == 0)
                    {
                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Black;
                    }
                    else
                    {
                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.White;
                    }

                    // Désélectionner
                    caseSelectionnee = null;

                    // Arrêter ici
                    return;
                }
                else
                {
                    // Je clique sur une AUTRE case :
                    // remettre l'ancienne case dans sa couleur originale
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

            // Mémorisation de la nouvelle case choisie
            caseSelectionnee = CaseChoisie;

            // Mettre la nouvelle case en vert
            mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Green;
        }

        private void Echiquier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
