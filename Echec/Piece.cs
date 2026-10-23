using System;
using System.Collections.Generic;
using System.Text;

namespace Echec
{
    public enum TypePiece
    {
        Pion,
        Tour,
        Cavalier,
        Fou,
        Dame,
        Roi
    }


    public enum CouleurPiece
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
