using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Game game = new Game();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        //                                                     ^ 存放事件相關的參數(e.g 滑鼠按點下去的座標)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece); // 放下棋子

                // 每次放完棋子後，檢查是否有人獲勝
                if (game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("黑棋勝利", "遊戲結束", MessageBoxButtons.OK);
                }
                else if (game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("白棋勝利", "遊戲結束", MessageBoxButtons.OK);
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        //                                                         ^ 存放事件相關的參數(e.g 滑鼠目前的座標)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand; // 當滑鼠移動到可以放置棋子的位置時，游標變成"手指"
            }
            else
            {
                this.Cursor= Cursors.Default; // 不能放置的位置維持預設樣式
            }
        }
    }
}
