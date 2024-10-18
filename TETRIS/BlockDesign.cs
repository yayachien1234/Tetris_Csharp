using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TETRIS
{
    public class BlockDesign
    {
        private Label[,] grids; //儲存傳入的grids陣列
        private bool[,] signs;
        private Label[,] hint;

        public BlockDesign(Label[,] grids, bool[,] signs, Label[,] hint)
        {
            this.grids = grids;
            this.signs = signs;
            this.hint = hint;
        }

        public void DrawBlock(int i, int j, int type)//i是直的, j是橫的, I, O, L, J, S, Z, T
        {
            switch (type)
            {
                case 1://I-Green
                    signs[i , j] = signs[i + 1, j] = signs[i + 2, j] = signs[i + 3, j] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 2, j].BackColor = grids[i + 3, j].BackColor = Color.Green; 
                    break;

                case 11://I-Spin
                    signs[i, j] = signs[i, j + 1] = signs[i, j + 2] = signs[i, j + 3] = true;
                    grids[i, j].BackColor = grids[i, j + 1].BackColor = grids[i, j + 2].BackColor = grids[i, j + 3].BackColor = Color.Green; 
                    break;

                case 2://O-blue
                    signs[i, j] = signs[i+1, j] = signs[i, j+1] = signs[i+1, j+1] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j+1].BackColor = grids[i+1, j+1].BackColor = Color.Blue;
                    break;
                case 3://Z-yellow
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j - 1] = signs[i, j + 1] = true;
                    grids[i, j].BackColor = grids[i+1, j].BackColor = grids[i+1, j-1].BackColor = grids[i, j+1].BackColor = Color.Yellow;
                    break;
                case 13://Z-spin
                    signs[i, j] = signs[i, j+1] = signs[i+1, j+1] = signs[i-1, j] = true;
                    grids[i, j].BackColor = grids[i, j + 1].BackColor = grids[i + 1, j + 1].BackColor = grids[i - 1, j].BackColor = Color.Yellow;
                    break;
                case 4://S-red
                    signs[i, j] = signs[i+1, j] = signs[i+1, j+1] = signs[i, j-1] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 1, j + 1].BackColor = grids[i, j - 1].BackColor = Color.Red;
                    break;
                case 14://S-spin
                    signs[i, j] = signs[i+1, j] = signs[i, j+1] = signs[i-1, j+1] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i - 1, j + 1].BackColor = Color.Red;
                    break;
                case 5://J-Gray
                    signs[i, j] = signs[i+1, j] = signs[i+1, j-1] = signs[i+1, j-2] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 1, j - 1].BackColor = grids[i+1, j - 2].BackColor = Color.Gray;
                    break;
                case 15://J-Spin
                    signs[i, j] = signs[i, j+1] = signs[i+1, j+1] = signs[i+2, j+1] = true;
                    grids[i, j].BackColor = grids[i , j+1].BackColor = grids[i + 1, j + 1].BackColor = grids[i+2, j + 1].BackColor = Color.Gray;
                    break;
                case 25://J-Spin
                    signs[i, j] = signs[i-1, j] = signs[i-1, j+1] = signs[i-1, j+2] = true;
                    grids[i, j].BackColor = grids[i-1, j].BackColor = grids[i - 1, j+1].BackColor = grids[i-1, j + 2].BackColor = Color.Gray;
                    break;
                case 35://J-Spin
                    signs[i, j] = signs[i, j-1] = signs[i-1, j-1] = signs[i-2, j-1] = true;
                    grids[i, j].BackColor = grids[i, j-1].BackColor = grids[i-1, j-1].BackColor = grids[i - 2, j - 1].BackColor = Color.Gray;
                    break;
                case 6://L-Orange
                    signs[i, j] = signs[i+1, j] = signs[i+1, j+1] = signs[i+1, j+2] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 1, j + 1].BackColor = grids[i + 1, j + 2].BackColor = Color.Orange;
                    break;
                case 16://L-Spin
                    signs[i, j] = signs[i, j-1] = signs[i+1, j-1] = signs[i+2, j-1] = true;
                    grids[i, j].BackColor = grids[i, j - 1].BackColor = grids[i + 1, j - 1].BackColor = grids[i+2, j-1].BackColor = Color.Orange;
                    break;
                case 26://L-Spin
                    signs[i, j] = signs[i-1, j] = signs[i-1, j-1] = signs[i-1, j-2] = true;
                    grids[i, j].BackColor = grids[i-1, j].BackColor = grids[i - 1, j - 1].BackColor = grids[i - 1, j - 2].BackColor = Color.Orange;
                    break;
                case 36://L-Spin
                    signs[i, j] = signs[i, j+1] = signs[i-1, j+1] = signs[i-2, j+1] = true;
                    grids[i, j].BackColor = grids[i, j + 1].BackColor = grids[i - 1, j + 1].BackColor = grids[i - 2, j + 1].BackColor = Color.Orange;
                    break;
                case 7://T-Purple
                    signs[i, j] = signs[i+1, j] = signs[i, j+1] = signs[i, j-1] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i, j - 1].BackColor = Color.Purple;
                    break;
                case 17://T-Spin
                    signs[i, j] = signs[i+1, j] = signs[i, j+1] = signs[i-1, j] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i-1, j].BackColor = Color.Purple;
                    break;
                case 27://T-Spin
                    signs[i, j] = signs[i-1, j] = signs[i, j+1] = signs[i, j-1] = true;
                    grids[i, j].BackColor = grids[i - 1, j].BackColor = grids[i, j + 1].BackColor = grids[i, j-1].BackColor = Color.Purple;
                    break;
                case 37://T-Spin
                    signs[i, j] = signs[i+1, j] = signs[i, j-1] = signs[i-1, j] = true;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j - 1].BackColor = grids[i - 1, j].BackColor = Color.Purple;
                    break;

            }
        }

        public void DrawBlack(int i, int j, int type)//i是直的, j是橫的, I, O, L, J, S, Z, T
        {
            switch (type)
            {
                case 1://I-Black
                    signs[i, j] = signs[i + 1, j] = signs[i + 2, j] = signs[i + 3, j] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 2, j].BackColor = grids[i + 3, j].BackColor = Color.Black;
                    break;

                case 11://I-Spin
                    signs[i, j] = signs[i, j + 1] = signs[i, j + 2] = signs[i, j + 3] = false;
                    grids[i, j].BackColor = grids[i, j + 1].BackColor = grids[i, j + 2].BackColor = grids[i, j + 3].BackColor = Color.Black;
                    break;

                case 2://O-Black
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i + 1, j + 1] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i + 1, j + 1].BackColor = Color.Black;
                    break;
                case 3://Z-Black
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j - 1] = signs[i, j + 1] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 1, j - 1].BackColor = grids[i, j + 1].BackColor = Color.Black;
                    break;
                case 13://Z-spin
                    signs[i, j] = signs[i, j+1] = signs[i + 1, j + 1] = signs[i - 1, j] = false;
                    grids[i, j].BackColor = grids[i, j+1].BackColor = grids[i + 1, j + 1].BackColor = grids[i - 1, j].BackColor = Color.Black;
                    break;
                case 4://S-Black
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j + 1] = signs[i, j - 1] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 1, j + 1].BackColor = grids[i, j - 1].BackColor = Color.Black;
                    break;
                case 14://S-spin
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i - 1, j + 1] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i - 1, j + 1].BackColor = Color.Black;
                    break;
                case 5://J-Black
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j - 1] = signs[i + 1, j - 2] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 1, j - 1].BackColor = grids[i + 1, j - 2].BackColor = Color.Black;
                    break;
                case 15://J-Spin
                    signs[i, j] = signs[i, j + 1] = signs[i + 1, j + 1] = signs[i + 2, j + 1] = false;
                    grids[i, j].BackColor = grids[i, j + 1].BackColor = grids[i + 1, j + 1].BackColor = grids[i + 2, j + 1].BackColor = Color.Black;
                    break;
                case 25://J-Spin
                    signs[i, j] = signs[i - 1, j] = signs[i - 1, j + 1] = signs[i - 1, j + 2] = false;
                    grids[i, j].BackColor = grids[i - 1, j].BackColor = grids[i - 1, j + 1].BackColor = grids[i - 1, j + 2].BackColor = Color.Black;
                    break;
                case 35://J-Spin
                    signs[i, j] = signs[i, j - 1] = signs[i - 1, j - 1] = signs[i - 2, j - 1] = false;
                    grids[i, j].BackColor = grids[i, j - 1].BackColor = grids[i - 1, j - 1].BackColor = grids[i - 2, j - 1].BackColor = Color.Black;
                    break;
                case 6://L-Black
                    signs[i, j] = signs[i + 1, j] = signs[i + 1, j + 1] = signs[i + 1, j + 2] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i + 1, j + 1].BackColor = grids[i + 1, j + 2].BackColor = Color.Black;
                    break;
                case 16://L-Spin
                    signs[i, j] = signs[i, j - 1] = signs[i + 1, j - 1] = signs[i + 2, j - 1] = false;
                    grids[i, j].BackColor = grids[i, j - 1].BackColor = grids[i + 1, j - 1].BackColor = grids[i + 2, j - 1].BackColor = Color.Black;
                    break;
                case 26://L-Spin
                    signs[i, j] = signs[i - 1, j] = signs[i - 1, j - 1] = signs[i - 1, j - 2] = false;
                    grids[i, j].BackColor = grids[i - 1, j].BackColor = grids[i - 1, j - 1].BackColor = grids[i - 1, j - 2].BackColor = Color.Black;
                    break;
                case 36://L-Spin
                    signs[i, j] = signs[i, j + 1] = signs[i - 1, j + 1] = signs[i - 2, j + 1] = false;
                    grids[i, j].BackColor = grids[i, j + 1].BackColor = grids[i - 1, j + 1].BackColor = grids[i - 2, j + 1].BackColor = Color.Black;
                    break;
                case 7://T-Black
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i, j - 1] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i, j - 1].BackColor = Color.Black;
                    break;
                case 17://T-Spin
                    signs[i, j] = signs[i + 1, j] = signs[i, j + 1] = signs[i - 1, j] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j + 1].BackColor = grids[i - 1, j].BackColor = Color.Black;
                    break;
                case 27://T-Spin
                    signs[i, j] = signs[i - 1, j] = signs[i, j + 1] = signs[i, j - 1] = false;
                    grids[i, j].BackColor = grids[i - 1, j].BackColor = grids[i, j + 1].BackColor = grids[i, j - 1].BackColor = Color.Black;
                    break;
                case 37://T-Spin
                    signs[i, j] = signs[i + 1, j] = signs[i, j - 1] = signs[i - 1, j] = false;
                    grids[i, j].BackColor = grids[i + 1, j].BackColor = grids[i, j - 1].BackColor = grids[i - 1, j].BackColor = Color.Black;
                    break;

            }
        }

        public void DrawHint(int type)//i是直的, j是橫的, I, O, L, J, S, Z, T
        {
            switch (type)
            {
                case 1://I-Green
                    hint[0, 1].BackColor = hint[1, 1].BackColor = hint[2, 1].BackColor = hint[3, 1].BackColor = Color.Green;
                    break;

                case 2://O-blue
                    hint[0, 0].BackColor = hint[1,0].BackColor = hint[0, 1].BackColor = hint[1, 1].BackColor = Color.Blue;
                    break;
                case 3://Z-yellow
                    hint[0, 2].BackColor = hint[1, 2].BackColor = hint[1, 1].BackColor = hint[0, 3].BackColor = Color.Yellow;
                    break;

                case 4://S-red
                    hint[0, 2].BackColor = hint[1, 2].BackColor = hint[0, 1].BackColor = hint[1, 3].BackColor = Color.Red;
                    break;

                case 5://J-Gray
                    hint[0, 2].BackColor = hint[1, 2].BackColor = hint[1, 1].BackColor = hint[1, 0].BackColor = Color.Gray;
                    break;

                case 6://L-Orange
                    hint[0, 0].BackColor = hint[1, 0].BackColor = hint[1, 1].BackColor = hint[1, 2].BackColor =Color.Orange;
                    break;

                case 7://T-Purple
                    hint[0, 1].BackColor = hint[0, 0].BackColor = hint[1, 1].BackColor = hint[0, 2].BackColor = Color.Purple;
                    break;


            }
        }

        public void ClearHint()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    hint[i, j].BackColor = Color.Black; 
                }
        }
    }
}
