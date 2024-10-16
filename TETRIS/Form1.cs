using System.Security.Cryptography.X509Certificates;

namespace TETRIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }  

        public void Form1_Load(object sender, EventArgs e)
        {
            Label[,] grids = MapGenerate.GenerateMap(this); // 調用 MapGenerate 類別中的 GenerateMap 方法
            BlockDesign blockDesign = new BlockDesign(grids);
            blockDesign.DrawBlock(5, 5, 37);

        }
    }
    
}