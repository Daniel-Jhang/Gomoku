using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // for use picture box
using System.Drawing; // for use PictureBox property: BackColor and Point

namespace Gomoku
{
    // 讓棋子繼承PictureBox，使棋子可以顯示在Form上;
    internal abstract class Piece : PictureBox  // 加上abstract避免不小心生成Piece(還沒決定黑棋或白棋)的物件
    {
        // 宣告一個static的唯讀變數，存放棋子圖片的寬度(for調整棋子生成的座標)
        private static readonly int IMAGE_WIDTH = 50; // 棋子圖片的寬度

        // constructor
        public Piece(int x, int y)
        {
            // 讓生成的棋子物件具有特定的PictureBox屬性
            this.BackColor = Color.Transparent; // 背景透明
            this.Location = new Point(x - (IMAGE_WIDTH / 2), y - (IMAGE_WIDTH / 2)); // 將 Location 控制項的屬性設定為 Point
                                                                                     // Point 表示整數 X 和 Y 座標之已排序的配對，此配對會定義二維平面中的點
                                                                                     // IMAGE_WIDTH / 2 讓棋子生成時，有適當的位移，讓圖片正中心位於滑鼠點的座標
            this.Size = new Size(50, 50); // 設定棋子圖片(PictureBox)的寬跟高

        }

        public abstract PieceType GetPieceType();
    }
}
