using System.Security.Cryptography.X509Certificates;

namespace TETRIS
{
    public partial class Form1 : Form
    {
        public Label[,]? grids;
        public BlockDesign? blockDesign;
        public System.Windows.Forms.Timer? timer;
        public int block_I = 0;
        public int block_J = 0;
        public int block_Type = 0;
        public Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }  

        public void Form1_Load(object sender, EventArgs e)
        {
            grids = MapGenerate.GenerateMap(this); // �{�� MapGenerate e�е� GenerateMap ����
            blockDesign = new BlockDesign(grids);

            block_I = 15;
            block_J = random.Next(4, 7);
            block_Type = random.Next(1, 7);
            blockDesign.DrawBlock(block_I, block_J, block_Type);
            InitializeTimer();

        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // �O��Ӌ�r���ĕr�g�g���� 1000 ���루�� 1 �룩
            timer.Tick += Timer_Tick; // �]�� Timer_Tick ���鶨�r�|�l�¼���̎����
            timer.Start(); // ����Ӌ�r��


        }

        // Ӌ�r���� Tick �¼�̎����
        private void Timer_Tick(object? sender, EventArgs e)
        {
            // ���@�e���÷��K�Ԅ��½���߉݋
            if (block_I > 0)
            {
                blockDesign.DrawBlack(block_I, block_J, block_Type);
                block_I--;
                blockDesign.DrawBlock(block_I, block_J, block_Type);
                Console.WriteLine("Timer ticked - move block down");
            }

        }
        //timer.stop;


    }
    
}