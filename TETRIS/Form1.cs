using System.Security.Cryptography.X509Certificates;

namespace TETRIS
{
    public partial class Form1 : Form
    {
        public Label[,]? grids;
        public bool[,] signs = new bool[22, 10];
        public BlockDesign? blockDesign;
        public System.Windows.Forms.Timer? timer;
        public int block_I = 0;
        public int block_J = 0;
        public int block_Type = 0;
        public Random random = new Random();
       

        public Form1()
        {
            this.KeyPreview = true; // �O�� KeyPreview ���Ԟ� true
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // ӆ� KeyDown �¼�
            InitializeComponent();
        }  

        public void Form1_Load(object sender, EventArgs e)
        {
            grids = MapGenerate.GenerateMap(this); // �{�� MapGenerate e�е� GenerateMap ����
            blockDesign = new BlockDesign(grids, signs);

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
            timer.Interval = 1000;
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

        //���Ʒ��K�������Ƅ�
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    // ����^���r�Ą���
                    MoveBlockLeft();
                    break;
                case Keys.Right:
                    // �Ҽ��^���r�Ą���
                    MoveBlockRight();
                    break;
                case Keys.Up:
                    // �ϼ��^���r�Ą����������Á����D��
                    RotateBlock();
                    break;
                case Keys.Down:
                    // �¼��^���r�Ą����������Á�����½���
                    DropBlock();
                    break;
                case Keys.Space:
                    // �հ��I���r�Ą���
                    //HardDropBlock();
                    break;
                default:
                    break;

            }
        }

        private void MoveBlockLeft()
        {
            if ( true )
            {
                blockDesign.DrawBlack(block_I, block_J, block_Type);
                block_J--;
                blockDesign.DrawBlock(block_I, block_J, block_Type);
            }
        }

        private void MoveBlockRight()
        {
            if ( true )
            {
                blockDesign.DrawBlack(block_I, block_J, block_Type);
                block_J++;
                blockDesign.DrawBlock(block_I, block_J, block_Type);
            }
        }

        private void DropBlock()
        {
            if ( true)
            {
                timer.Interval = 250;
            }
        }

        private void RotateBlock()
        {
            switch (block_Type)
            {
                case 1://I-Black
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 11;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;

                case 11://I-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 1;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;

                case 2://O-Black
                    break;
                case 3://Z-Black
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 13;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 13://Z-spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 3;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 4://S-Black
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 14;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 14://S-spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 14;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 5://J-Black
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 15;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 15://J-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 25;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 25://J-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 35;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 35://J-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 5;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 6://L-Black
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 16;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 16://L-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 26;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 26://L-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 36;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 36://L-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 6;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 7://T-Black
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 17;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 17://T-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 27;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 27://T-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 37;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
                case 37://T-Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    block_Type = 7;
                    blockDesign.DrawBlock(block_I, block_J, block_Type);
                    break;
            }
        }

    }
    
}