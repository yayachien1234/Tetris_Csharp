using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class BlockDesign
    {
        private Label[,] grids; //儲存傳入的grids陣列

        public BlockDesign(Label[,] grids)
        {
            this.grids = grids;
        }

        public void DrawBlock(uint i, uint j, uint type)//i是直的, j是橫的, I, O, L, J, S, Z, T
        {
            switch (type)
            {
                case 1://I-Green
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i + 2, j].BackColor = grids[i + 3, j].BackColor = Color.Green; 
                    break;
                case 11://I-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i, j + 1].BackColor = grids[i, j + 2].BackColor = grids[i, j + 3].BackColor = Color.Green; 
                    break;
                case 2://O-blue
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i, j+1].BackColor = grids[i+1, j+1].BackColor = Color.Blue;
                    break;
                case 3://Z-yellow
                    grids[i, j].BackColor = Color.White;
                    grids[i+1, j].BackColor = grids[i+1, j-1].BackColor = grids[i, j+1].BackColor = Color.Yellow;
                    break;
                case 13://Z-spin
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i , j + 1].BackColor = grids[i - 1, j + 1].BackColor = Color.Yellow;
                    break;
                case 4://S-red
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i + 1, j + 1].BackColor = grids[i, j - 1].BackColor = Color.Red;
                    break;
                case 14://S-spin
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i - 1, j + 1].BackColor = Color.Red;
                    break;
                case 5://J-Gray
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i + 1, j - 1].BackColor = grids[i+1, j - 2].BackColor = Color.Gray;
                    break;
                case 15://J-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i , j+1].BackColor = grids[i + 1, j + 1].BackColor = grids[i+2, j + 1].BackColor = Color.Gray;
                    break;
                case 25://J-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i-1, j].BackColor = grids[i - 1, j+1].BackColor = grids[i-1, j + 2].BackColor = Color.Gray;
                    break;
                case 35://J-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i, j-1].BackColor = grids[i-1, j-1].BackColor = grids[i - 2, j - 1].BackColor = Color.Gray;
                    break;
                case 6://L-Orange
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i + 1, j + 1].BackColor = grids[i + 1, j + 2].BackColor = Color.Orange;
                    break;
                case 16://L-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i, j - 1].BackColor = grids[i + 1, j - 1].BackColor = grids[i+2, j-1].BackColor = Color.Orange;
                    break;
                case 26://L-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i-1, j].BackColor = grids[i - 1, j - 1].BackColor = grids[i - 1, j - 2].BackColor = Color.Orange;
                    break;
                case 36://L-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i, j + 1].BackColor = grids[i - 1, j + 1].BackColor = grids[i - 2, j + 1].BackColor = Color.Orange;
                    break;
                case 7://T-Purple
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i, j - 1].BackColor = Color.Purple;
                    break;
                case 17://T-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i-1, j].BackColor = Color.Purple;
                    break;
                case 27://T-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i - 1, j].BackColor = grids[i, j + 1].BackColor = grids[i, j-1].BackColor = Color.Purple;
                    break;
                case 37://T-Spin
                    grids[i, j].BackColor = Color.White;
                    grids[i + 1, j].BackColor = grids[i, j - 1].BackColor = grids[i - 1, j].BackColor = Color.Purple;
                    break;

            }
        }
    }
}
