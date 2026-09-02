using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
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
        //Variable
        //Garde en mémoire l'existance un tableau de 64 cases
        Case[,] mesCases = new Case[8, 8];

        //Garde en mémoire l'existance de la grille
        Border[,] mesGrilles = new Border[8, 8];

        Case caseSelectionnee;
        Case dernierPionDeuxCases = null;












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


            // Conditions permettant de changer la couleur de la case sélectionnée
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

                        if (caseSelectionnee.Piece is not null)
                        {
                            //Condition qui vérifie la pièce cliqué est un pion
                            if (caseSelectionnee.Piece.Type == TypePiece.Pion)
                            {
                                //Vérifie si c'est un pion blanc
                                if (caseSelectionnee.Piece.Couleur == CouleurPiece.Blanc)
                                {
                                    //Vérifie si le pion blanc a le droit de se déplacer
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
                                        dernierPionDeuxCases = null;
                                        //Réinitialise la case selectionnée
                                        caseSelectionnee = null;
                                    }

                                    //Conditions pour manger une pièce
                                    else if (CaseChoisie.Ligne == caseSelectionnee.Ligne + 1 && (CaseChoisie.Colonne == caseSelectionnee.Colonne + 1 || CaseChoisie.Colonne == caseSelectionnee.Colonne - 1) && CaseChoisie.Piece is not null && CaseChoisie.Piece.Couleur == CouleurPiece.Noir)
                                    {

                                        //Récupère l'image de la pièce
                                        Image imagePion = (Image)mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child;

                                        //Enleve l'image de la pièce
                                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child = null;

                                        //Remplace l'image de la pièce manger
                                        mesGrilles[CaseChoisie.Ligne, CaseChoisie.Colonne].Child = imagePion;

                                        //Déplacement de la pièce
                                        CaseChoisie.Piece = caseSelectionnee.Piece;
                                        caseSelectionnee.Piece = null;

                                        //Conditions pour remettre la couleur des pièces
                                        if ((caseSelectionnee.Ligne + caseSelectionnee.Colonne) % 2 == 0)
                                        {
                                            mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Black;
                                        }
                                        else
                                        {
                                            mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.White;
                                        }

                                        dernierPionDeuxCases = null;
                                        //Réinitialise la case selectionnée
                                        caseSelectionnee = null;
                                    }

                                    //Conditions pour permettre l'avancement de 2 cases d'un pion
                                    else if (caseSelectionnee.Ligne == 1 && CaseChoisie.Ligne == caseSelectionnee.Ligne + 2 && CaseChoisie.Colonne == caseSelectionnee.Colonne && CaseChoisie.Piece == null && mesCases[caseSelectionnee.Ligne + 1, caseSelectionnee.Colonne].Piece == null)
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
                                        //Enregistre la dernière pièces ayant fait un avancement de deux cases
                                        dernierPionDeuxCases = mesCases[CaseChoisie.Ligne, CaseChoisie.Colonne];
                                        //Réinitialise la case selectionnée
                                        caseSelectionnee = null;

                                    }

                                    //Conditions pour la prise en passant
                                    else if (CaseChoisie.Ligne == caseSelectionnee.Ligne + 1
                                        && (CaseChoisie.Colonne == caseSelectionnee.Colonne + 1 || CaseChoisie.Colonne == caseSelectionnee.Colonne - 1)
                                        && CaseChoisie.Piece is null
                                        && dernierPionDeuxCases is not null
                                        && caseSelectionnee.Ligne == dernierPionDeuxCases.Ligne
                                        && dernierPionDeuxCases.Piece.Couleur == CouleurPiece.Noir
                                        && dernierPionDeuxCases.Piece.Type == TypePiece.Pion
                                        && (dernierPionDeuxCases.Colonne == caseSelectionnee.Colonne + 1 || dernierPionDeuxCases.Colonne == caseSelectionnee.Colonne - 1))
                                    {
                                        //Récupère l'image de la pièce
                                        Image imagePieceDeplacement = (Image)mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child;

                                        //Enleve l'image de la pièce
                                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child = null;
                                        mesGrilles[dernierPionDeuxCases.Ligne, dernierPionDeuxCases.Colonne].Child = null;

                                        dernierPionDeuxCases.Piece = null;

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

                                        dernierPionDeuxCases = null;
                                        //Réinitialise la case selectionnée
                                        caseSelectionnee = null;

                                    }

                                }
                                //Pion noir
                                else
                                {
                                    //Vérifie si le pion noir a le droit de se déplacer
                                    if (CaseChoisie.Ligne == caseSelectionnee.Ligne - 1 && CaseChoisie.Colonne == caseSelectionnee.Colonne && CaseChoisie.Piece == null)
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
                                        dernierPionDeuxCases = null;
                                        //Réinitialise la case selectionnée
                                        caseSelectionnee = null;
                                    }
                                    //Conditions pour manger une pièce
                                    else if (CaseChoisie.Ligne == caseSelectionnee.Ligne - 1 && (CaseChoisie.Colonne == caseSelectionnee.Colonne + 1 || CaseChoisie.Colonne == caseSelectionnee.Colonne - 1) && CaseChoisie.Piece is not null && CaseChoisie.Piece.Couleur == CouleurPiece.Blanc)
                                    {
                                        //Récupère l'image de la pièce
                                        Image imagePion = (Image)mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child;


                                        //Enleve l'image de la pièce
                                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child = null;

                                        mesGrilles[CaseChoisie.Ligne, CaseChoisie.Colonne].Child = imagePion;

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
                                        dernierPionDeuxCases = null;
                                        //Réinitialise la case selectionnée
                                        caseSelectionnee = null;
                                    }
                                    //Conditions pour vérifier l'avancement de 2 cases d'un pion
                                    else if (caseSelectionnee.Ligne == 6 && CaseChoisie.Ligne == caseSelectionnee.Ligne - 2 && CaseChoisie.Colonne == caseSelectionnee.Colonne && CaseChoisie.Piece == null && mesCases[caseSelectionnee.Ligne - 1, caseSelectionnee.Colonne].Piece == null)
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
                                        //Enregistre la dernière pièces ayant fait un avancement de deux cases
                                        dernierPionDeuxCases = mesCases[CaseChoisie.Ligne, CaseChoisie.Colonne];
                                        //Réinitialise la case selectionnée
                                        caseSelectionnee = null;

                                    }
                                    //Conditions pour la prise en passant
                                    else if (CaseChoisie.Ligne == caseSelectionnee.Ligne - 1
                                        && (CaseChoisie.Colonne == caseSelectionnee.Colonne + 1 || CaseChoisie.Colonne == caseSelectionnee.Colonne - 1)
                                        && CaseChoisie.Piece is null
                                        && dernierPionDeuxCases is not null
                                        && caseSelectionnee.Ligne == dernierPionDeuxCases.Ligne
                                        && dernierPionDeuxCases.Piece.Couleur == CouleurPiece.Blanc
                                        && dernierPionDeuxCases.Piece.Type == TypePiece.Pion
                                        && (dernierPionDeuxCases.Colonne == caseSelectionnee.Colonne + 1 || dernierPionDeuxCases.Colonne == caseSelectionnee.Colonne - 1))
                                    {
                                        //Récupère l'image de la pièce
                                        Image imagePieceDeplacement = (Image)mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child;

                                        //Enleve l'image de la pièce
                                        mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Child = null;
                                        mesGrilles[dernierPionDeuxCases.Ligne, dernierPionDeuxCases.Colonne].Child = null;

                                        dernierPionDeuxCases.Piece = null;

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

                                        dernierPionDeuxCases = null;
                                        //Réinitialise la case selectionnée
                                        caseSelectionnee = null;

                                    }
                                }

                            }
                            //Condition qui vérifie la pièce cliqué est une tour
                            else if (caseSelectionnee.Piece.Type == TypePiece.Tour)
                            {
                                // Vérifie si la tour peut se déplacer
                                if ((CaseChoisie.Ligne != caseSelectionnee.Ligne && CaseChoisie.Colonne == caseSelectionnee.Colonne || CaseChoisie.Colonne != caseSelectionnee.Colonne && CaseChoisie.Ligne == caseSelectionnee.Ligne) && (CaseChoisie.Piece == null || CaseChoisie.Piece.Couleur != caseSelectionnee.Piece.Couleur))
                                {
                                    bool cheminLibre = true;

                                    // Déplacement horizontal
                                    if (caseSelectionnee.Ligne == CaseChoisie.Ligne)
                                    {
                                        // Vers la droite
                                        if (caseSelectionnee.Colonne < CaseChoisie.Colonne)
                                        {
                                            for (int i = caseSelectionnee.Colonne + 1; i < CaseChoisie.Colonne; i++)
                                            {
                                                if (mesCases[caseSelectionnee.Ligne, i].Piece is not null)
                                                {
                                                    cheminLibre = false;
                                                }
                                            }
                                        }
                                        // Vers la gauche
                                        else
                                        {
                                            for (int i = caseSelectionnee.Colonne - 1; i > CaseChoisie.Colonne; i--)
                                            {
                                                if (mesCases[caseSelectionnee.Ligne, i].Piece is not null)
                                                {
                                                    cheminLibre = false;
                                                }
                                            }
                                        }
                                    }
                                    // Déplacement vertical
                                    else
                                    {
                                        // Vers le bas
                                        if (caseSelectionnee.Ligne < CaseChoisie.Ligne)
                                        {
                                            for (int i = caseSelectionnee.Ligne + 1; i < CaseChoisie.Ligne; i++)
                                            {
                                                if (mesCases[i, caseSelectionnee.Colonne].Piece is not null)
                                                {
                                                    cheminLibre = false;
                                                }
                                            }
                                        }
                                        // Vers le haut
                                        else
                                        {
                                            for (int i = caseSelectionnee.Ligne - 1; i > CaseChoisie.Ligne; i--)
                                            {
                                                if (mesCases[i, caseSelectionnee.Colonne].Piece is not null)
                                                {
                                                    cheminLibre = false;
                                                }
                                            }
                                        }
                                    }

                                    // Déplacement si le chemin est libre
                                    if (cheminLibre == true)
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

                                        //Condition qui remet les couleurs sur l'échiquier
                                        if ((caseSelectionnee.Ligne + caseSelectionnee.Colonne) % 2 == 0)
                                        {
                                            mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Black;
                                        }
                                        else
                                        {
                                            mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.White;
                                        }

                                        //Oublie si un pion à avancer de deux cases
                                        dernierPionDeuxCases = null;

                                        //Oublie la derniere piece bouger
                                        caseSelectionnee = null;
                                    }
                                }
                            }
                            //Condition qui vérifie la pièce cliqué est un fou
                            else if (caseSelectionnee.Piece.Type == TypePiece.Fou)
                            {
                                // Vérifie si le fou peut se déplacer
                                if ((Math.Abs(CaseChoisie.Ligne - caseSelectionnee.Ligne)) == (Math.Abs(CaseChoisie.Colonne - caseSelectionnee.Colonne))&& Math.Abs(CaseChoisie.Ligne - caseSelectionnee.Ligne) !=0 && (CaseChoisie.Piece == null || CaseChoisie.Piece.Couleur != caseSelectionnee.Piece.Couleur))
                                {
                                    bool cheminLibre = true;
                                    //Dépacement Diagonale
                                    if (caseSelectionnee.Ligne < CaseChoisie.Ligne && caseSelectionnee.Colonne < CaseChoisie.Colonne)
                                    {
                                        for (int i = 0; i < Math.Abs(CaseChoisie.Ligne - caseSelectionnee.Ligne) - 1; i++)
                                        {
                                            int LigneVerif = caseSelectionnee.Ligne + i + 1;
                                            int ColonneVerif = caseSelectionnee.Colonne + i + 1;
                                            if (mesCases[LigneVerif, ColonneVerif].Piece is not null)
                                            {
                                                cheminLibre = false;
                                            }

                                        }
                                    }
                                    else if(caseSelectionnee.Ligne < CaseChoisie.Ligne && caseSelectionnee.Colonne > CaseChoisie.Colonne)
                                    {
                                        for (int i = 0; i < Math.Abs(CaseChoisie.Ligne - caseSelectionnee.Ligne) - 1; i++)
                                        {
                                            int LigneVerif = caseSelectionnee.Ligne + i + 1;
                                            int ColonneVerif = caseSelectionnee.Colonne - i - 1;
                                            if (mesCases[LigneVerif, ColonneVerif].Piece is not null)
                                            {
                                                cheminLibre = false;
                                            }

                                        }
                                    }
                                    else if (caseSelectionnee.Ligne > CaseChoisie.Ligne && caseSelectionnee.Colonne < CaseChoisie.Colonne)
                                    {
                                        for (int i = 0; i < Math.Abs(CaseChoisie.Ligne - caseSelectionnee.Ligne) - 1; i++)
                                        {
                                            int LigneVerif = caseSelectionnee.Ligne - i - 1;
                                            int ColonneVerif = caseSelectionnee.Colonne + i + 1;
                                            if (mesCases[LigneVerif, ColonneVerif].Piece is not null)
                                            {
                                                cheminLibre = false;
                                            }

                                        }
                                    }
                                    else if(caseSelectionnee.Ligne > CaseChoisie.Ligne && caseSelectionnee.Colonne > CaseChoisie.Colonne)
                                    {

                                        for (int i = 0; i < Math.Abs(CaseChoisie.Ligne - caseSelectionnee.Ligne) - 1; i++)
                                        {
                                            int LigneVerif = caseSelectionnee.Ligne - i - 1;
                                            int ColonneVerif = caseSelectionnee.Colonne - i - 1;
                                            if (mesCases[LigneVerif, ColonneVerif].Piece is not null)
                                            {
                                                cheminLibre = false;
                                            }

                                        }
                                    }
                                        // Déplacement si le chemin est libre
                                        if (cheminLibre == true)
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

                                            //Condition qui remet les couleurs sur l'échiquier
                                            if ((caseSelectionnee.Ligne + caseSelectionnee.Colonne) % 2 == 0)
                                            {
                                                mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.Black;
                                            }
                                            else
                                            {
                                                mesGrilles[caseSelectionnee.Ligne, caseSelectionnee.Colonne].Background = Brushes.White;
                                            }

                                            //Oublie si un pion à avancer de deux cases
                                            dernierPionDeuxCases = null;

                                            //Oublie la derniere piece bouger
                                            caseSelectionnee = null;
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
