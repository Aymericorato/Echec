using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Echec
{

    /// <summary>
    /// Logique d'interaction pour PromotionWindow.xaml
    /// </summary>
    public partial class PromotionWindow : Window
    {
        public TypePiece PieceChoisiePromotion;
        public PromotionWindow()
        {
            InitializeComponent();   
        }

        public void DefinirCouleurPieces(CouleurPiece couleur)
        {
            string suffixe;

            if (couleur == CouleurPiece.Blanc)
            {
                suffixe = "B";
            }
            else
            {
                suffixe = "N";
            }

            imgDame.Source = new BitmapImage(new Uri("/Image_Piece/Dame" + suffixe + ".png", UriKind.Relative));
            imgTour.Source = new BitmapImage(new Uri("/Image_Piece/Tour" + suffixe + ".png", UriKind.Relative));
            imgFou.Source = new BitmapImage(new Uri("/Image_Piece/Fou" + suffixe + ".png", UriKind.Relative));
            imgCavalier.Source = new BitmapImage(new Uri("/Image_Piece/Cavalier" + suffixe + ".png", UriKind.Relative));
        }


        private void imgDame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PieceChoisiePromotion = TypePiece.Dame;
            Close();
        }
        private void imgTour_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PieceChoisiePromotion = TypePiece.Tour;
            Close();
        }
        private void imgFou_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PieceChoisiePromotion = TypePiece.Fou;
            Close();
        }
        private void imgCavalier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PieceChoisiePromotion = TypePiece.Cavalier;
            Close();
        }
    }
}
