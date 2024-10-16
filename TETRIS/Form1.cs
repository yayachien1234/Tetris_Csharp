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
            Label[,] grids = MapGenerate.GenerateMap(this); // �{�� MapGenerate e�е� GenerateMap ����
            BlockDesign blockDesign = new BlockDesign(grids);
            blockDesign.DrawBlock(5, 5, 37);

        }
    }
    
}