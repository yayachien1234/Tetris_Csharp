using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TETRIS
{
    public class MapGenerate
    {
        public static Label[,] GenerateMap(Form form)
        {
            form.Size = new Size(1500, 1200);//初始化視窗大小
            form.FormBorderStyle = FormBorderStyle.FixedSingle;//防止玩家調整大小
            form.MaximizeBox = false;//防止玩家調整大小

            Label[,] grids = new Label[22, 10]; // 繪製遊戲地圖，寬高分別是10和22
            

            for (int i = 0; i < 22; i++)
                for (int j = 0; j < 10; j++)
                {
                    grids[i, j] = new Label();
                    grids[i, j].Width = 30;
                    grids[i, j].Height = 30;
                    grids[i, j].BorderStyle = BorderStyle.FixedSingle; //添加邊框
                    grids[i, j].BackColor = Color.Black;
                    grids[i, j].Left = 600 + 30 * j; //設定地圖位置
                    grids[i, j].Top = 800 - i * 30;
                    grids[i, j].Visible = true;
                    form.Controls.Add(grids[i, j]);
                }

            return grids;
        }

        public static Label[,] GenerateHint(Form form)
        {
            Label[,] hint = new Label[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    hint[i, j] = new Label();
                    hint[i, j].Width = 30;
                    hint[i, j].Height = 30;
                    hint[i, j].BorderStyle = BorderStyle.FixedSingle; //添加邊框
                    hint[i, j].BackColor = Color.Black;
                    hint[i, j].Left = 1000 + 30 * j; //設定地圖位置
                    hint[i, j].Top = 300 - i * 30;
                    hint[i, j].Visible = true;
                    form.Controls.Add(hint[i, j]);
                }

            return hint;
        }
    }
}
