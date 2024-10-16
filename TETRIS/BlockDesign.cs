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

        public void DrawBlock(uint i, uint j, uint type)//i是直的, j是橫的
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
                case 3://S-yellow
                    grids[i, j].BackColor = Color.White;
                    grids[i+1, j].BackColor = grids[i+1, j-1].BackColor = grids[i, j+1].BackColor = Color.Yellow;
                    break;
            }
        }
    }
}
