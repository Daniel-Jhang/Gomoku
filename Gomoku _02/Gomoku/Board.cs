using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // for use Point

namespace Gomoku
{
    internal class Board
    {
        public static readonly int BOARD_LIMIT = 13; //  大小為 13x13 的棋盤

        private static readonly Point NO_MATCH_NODE = new Point(-1, -1); // 

        private static readonly int OFFSET = 38; // 棋盤的邊寬
        private static readonly int NODE_DISTANCE = 77; // 2條線間隔的距離
        private static readonly int NODE_RADIUS = 10; // 可以放棋子的範圍的寬度(正方形)

        private Piece[,] pieces = new Piece[BOARD_LIMIT, BOARD_LIMIT]; // 宣告一個2維陣列，來紀錄目前棋盤上的棋子

        private Point lastPlacedNode = NO_MATCH_NODE;
        public Point LastPlacedNode { get { return lastPlacedNode; } }

        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
            {
                return PieceType.NONE;
            }
            else
            {
                return pieces[nodeIdX, nodeIdY].GetPieceType();
            }

        }
        public bool CanBePlaced(int x, int y)
        {
            // 找出最近的節點(Node)
            Point nodeId = findTheClosestNode(x, y);

            // 如果沒有的話，回傳 false
            if (nodeId == NO_MATCH_NODE)
            {
                return false;
            }
            // 如果有的話，檢查是否已經有棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)
            {
                return false;
            }

            return true;
        }

        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            // 找出最近的節點(Node)
            Point nodeId = findTheClosestNode(x, y);

            // 如果沒有的話，回傳 false
            if (nodeId == NO_MATCH_NODE)
            {
                return null;
            }
            // 如果有的話，檢查是否已經有棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)
            {
                return null;
            }

            // 根據 type 產生對應的棋子
            Point formPos = convertToFormPosition(nodeId);

            if (type == PieceType.BLACK)
            {
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            }
            else if (type == PieceType.WHITE)
            {
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);
            }

            // 紀錄最後下棋子的位置
            lastPlacedNode = nodeId;

            return pieces[nodeId.X, nodeId.Y];
        }

        private Point convertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = (nodeId.X * NODE_DISTANCE) + OFFSET;
            formPosition.Y = (nodeId.Y * NODE_DISTANCE) + OFFSET;
            return formPosition;
        }

        private Point findTheClosestNode(int x, int y) // two dimension(一維結合一維，產生二維的判斷條件)
        {
            int nodeIdX = findTheClosestNode(x);
            if (nodeIdX == -1 || nodeIdX >= BOARD_LIMIT)
            {
                return NO_MATCH_NODE; // 若沒有符合的Node
            }

            int nodeIdY = findTheClosestNode(y);
            if (nodeIdY == -1 || nodeIdX >= BOARD_LIMIT)
            {
                return NO_MATCH_NODE; // 若沒有符合的Node
            }

            return new Point(nodeIdX, nodeIdY); // 回傳符合條件的Node
        }

        private int findTheClosestNode(int pos) // one dimension (一維的判斷條件)
        {
            if (pos < (OFFSET - NODE_RADIUS)) // 避免最右上角可以放棋子
            {
                return -1;
            }

            pos = pos - OFFSET;

            int quotient = pos / NODE_DISTANCE; // 商數
            int remainder = pos % NODE_DISTANCE; // 餘數

            if (remainder <= NODE_RADIUS) // 如果滑鼠靠近左邊的Node
            {
                return quotient;
            }
            else if (remainder >= (NODE_DISTANCE - NODE_RADIUS)) // 如果滑鼠靠近右邊的Node
            {
                return quotient + 1;
            }
            else
            {
                return -1; // 若都不符合回傳 -1
            }
        }
    }
}
