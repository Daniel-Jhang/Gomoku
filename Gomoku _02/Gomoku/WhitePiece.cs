using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class WhitePiece : Piece // 繼承Piece(abstract class)
    {
        // constructor
        public WhitePiece (int x, int y) : base(x,y)// 將參數傳到base class(Piece)的constructor
        {
            this.Image = Properties.Resources.white; // 直接將Image屬性設定成素材資源(白棋)
        }

        public override PieceType GetPieceType()
        {
            return PieceType.WHITE;
        }
    }
}
