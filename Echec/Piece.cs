using System;
using System.Collections.Generic;
using System.Text;

namespace Echec
{
    enum TypePiece
    {
        Pion,
        Tour,
        Cavalier,
        Fou,
        Dame,
        Roi
    }


    enum CouleurPiece
    {
        Blanc,
        Noir
    }



    internal class Piece
    {

        public TypePiece Type;
        public CouleurPiece Couleur;

        public bool ADejaBouge;

    }
}
