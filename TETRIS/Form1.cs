namespace TETRIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Label[,] grids = MapGenerate.GenerateMap(this); // 調用 MapGenerate 類別中的 GenerateMap 方法

        }
    }
}