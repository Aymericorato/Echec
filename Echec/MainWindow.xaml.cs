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
            //Attribution des pieces aux images
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

                            case TypePiece.Tour:
                                if (mesCases[i,c].Piece.Couleur == CouleurPiece.Blanc)
                                {
                                    BitmapImage ImageTour = new BitmapImage();
                                    ImageTour.BeginInit();
                                    ImageTour.UriSource = new Uri(@"Image_Piece/TourB.png", UriKind.Relative);
                                    ImageTour.EndInit();

                                    Image ImageT = new Image();
                                    ImageT.Source = ImageTour;

                                    mesGrilles[i,c].Child = ImageT;
                                }
                                else
                                {
                                    BitmapImage ImageTour = new BitmapImage();
                                    ImageTour.BeginInit();
                                    ImageTour.UriSource = new Uri(@"Image_Piece/TourN.png", UriKind.Relative);
                                    ImageTour.EndInit();

                                    Image ImageT = new Image();
                                    ImageT.Source = ImageTour;

                                    mesGrilles[i, c].Child = ImageT;
                                }
                                break;

                            case TypePiece.Cavalier:
                                if (mesCases[i, c].Piece.Couleur == CouleurPiece.Blanc)
                                {
                                    BitmapImage ImageCavalier = new BitmapImage();
                                    ImageCavalier.BeginInit();
                                    ImageCavalier.UriSource = new Uri(@"Image_Piece/CavalierB.png", UriKind.Relative);
                                    ImageCavalier.EndInit();

                                    Image ImageC = new Image();
                                    ImageC.Source = ImageCavalier;

                                    mesGrilles[i, c].Child = ImageC;
                                }
                                else
                                {
                                    BitmapImage ImageCavalier = new BitmapImage();
                                    ImageCavalier.BeginInit();
                                    ImageCavalier.UriSource = new Uri(@"Image_Piece/CavalierN.png", UriKind.Relative);
                                    ImageCavalier.EndInit();

                                    Image ImageC = new Image();
                                    ImageC.Source = ImageCavalier;

                                    mesGrilles[i, c].Child = ImageC;
                                }
                                break;

                            case TypePiece.Fou:
                                if (mesCases[i, c].Piece.Couleur == CouleurPiece.Blanc)
                                {
                                    BitmapImage ImageFou = new BitmapImage();
                                    ImageFou.BeginInit();
                                    ImageFou.UriSource = new Uri(@"Image_Piece/FouB.png", UriKind.Relative);
                                    ImageFou.EndInit();

                                    Image ImageF = new Image();
                                    ImageF.Source = ImageFou;

                                    mesGrilles[i, c].Child = ImageF;
                                }
                                else
                                {
                                    BitmapImage ImageFou = new BitmapImage();
                                    ImageFou.BeginInit();
                                    ImageFou.UriSource = new Uri(@"Image_Piece/FouN.png", UriKind.Relative);
                                    ImageFou.EndInit();

                                    Image ImageF = new Image();
                                    ImageF.Source = ImageFou;

                                    mesGrilles[i, c].Child = ImageF;
                                }
                                break;

                            case TypePiece.Dame:
                                if (mesCases[i, c].Piece.Couleur == CouleurPiece.Blanc)
                                {
                                    BitmapImage ImageDame = new BitmapImage();
                                    ImageDame.BeginInit();
                                    ImageDame.UriSource = new Uri(@"Image_Piece/DameB.png", UriKind.Relative);
                                    ImageDame.EndInit();

                                    Image ImageD = new Image();
                                    ImageD.Source = ImageDame;

                                    mesGrilles[i, c].Child = ImageD;
                                }
                                else
                                {
                                    BitmapImage ImageDame = new BitmapImage();
                                    ImageDame.BeginInit();
                                    ImageDame.UriSource = new Uri(@"Image_Piece/DameN.png", UriKind.Relative);
                                    ImageDame.EndInit();

                                    Image ImageD = new Image();
                                    ImageD.Source = ImageDame;

                                    mesGrilles[i, c].Child = ImageD;
                                }
                                break;

                            case TypePiece.Roi:
                                if (mesCases[i, c].Piece.Couleur == CouleurPiece.Blanc)
                                {
                                    BitmapImage ImageRoi = new BitmapImage();
                                    ImageRoi.BeginInit();
                                    ImageRoi.UriSource = new Uri(@"Image_Piece/RoiB.png", UriKind.Relative);
                                    ImageRoi.EndInit();

                                    Image ImageR = new Image();
                                    ImageR.Source = ImageRoi;

                                    mesGrilles[i, c].Child = ImageR;
                                }
                                else
                                {
                                    BitmapImage ImageRoi = new BitmapImage();
                                    ImageRoi.BeginInit();
                                    ImageRoi.UriSource = new Uri(@"Image_Piece/RoiN.png", UriKind.Relative);
                                    ImageRoi.EndInit();

                                    Image ImageR = new Image();
                                    ImageR.Source = ImageRoi;

                                    mesGrilles[i, c].Child = ImageR;
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

            //caseSelectionnee est la case de départ
            //caseChoisie est la case d'arrivée


            // Si aucune case n'était sélectionnée
            if (caseSelectionnee == null)
            {
                if (CaseChoisie.Piece is not null)
                {
                    caseSelectionnee = CaseChoisie;

                    mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Green;
                }
                return;
            }

            // Une case est-elle déjà sélectionnée ?
            if (caseSelectionnee != null)
            {
                if (CaseChoisie is not null)
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

                        if (caseSelectionnee.Piece is not null)
                        {
                            if (caseSelectionnee.Piece.Type == TypePiece.Pion)
                            {
                                if (caseSelectionnee.Piece.Couleur == CouleurPiece.Blanc)
                                {
                                    //Vérifie si le pion a le droit de se déplacer
                                    if (CaseChoisie.Ligne == caseSelectionnee.Ligne + 1 && CaseChoisie.Colonne == caseSelectionnee.Colonne && CaseChoisie.Piece == null)
                                    {
                                        //Récupère l'image de la pièce
                                        Image imagePieceDeplacement = (Image)mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child;

                                        //Enleve l'image de la pièce
                                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child = null;
                                        //Mets l'image de la pièce sur la nouvelle case
                                        mesGrilles[CaseChoisie.Ligne, CaseChoisie.Colonne].Child = imagePieceDeplacement;

                                        // Déplacement de la pièce
                                        CaseChoisie.Piece = caseSelectionnee.Piece;
                                        caseSelectionnee.Piece = null;

                                        if ((caseSelectionnee.Ligne + caseSelectionnee.Colonne) % 2 == 0)
                                        {
                                            mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Black;


                                        }
                                        else
                                        {
                                            mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.White;
                                        }


                                        // La nouvelle case devient la case sélectionnée
                                        caseSelectionnee = CaseChoisie;

                                        // Mettre la nouvelle case en vert
                                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Green;


                                    }
                                }

                            }
                        }
                    }

                }
            }
        }

        private void Echiquier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
