using System.Security.Cryptography.X509Certificates;

namespace TETRIS
{
    public partial class Form1 : Form
    {
        public Label[,]? grids;
        public Label[,]? hint;
        public bool[,] signs = new bool[22, 10];
        public BlockDesign? blockDesign;
        public System.Windows.Forms.Timer? timer;
        public int block_I = 0;
        public int block_J = 0;
        public int block_Type = 0;
        public int new_block_Type = 0;
        public Random random = new Random();
        public int point = 0;
        public Label pointText = new Label();
        public bool timerStatus = true;
        public bool firstGenerate = true;


        public Form1()
        {
            this.KeyPreview = true; // �O�� KeyPreview ���Ԟ� true
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // ӆ� KeyDown �¼�
            InitializeComponent();
        }  

        public void Form1_Load(object sender, EventArgs e)
        {
            grids = MapGenerate.GenerateMap(this); // �{�� MapGenerate e�е� GenerateMap ����
            hint = MapGenerate.GenerateHint(this);
            blockDesign = new BlockDesign(grids, signs, hint);
            for (int i = 0; i < signs.GetLength(0); i++)
            {
                for (int j = 0; j < signs.GetLength(1); j++)
                {
                    signs[i, j] = false;
                }
            }
            GenerateNewBlock();
            InitializeTimer();
            InitializePointText();
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // �O��Ӌ�r���ĕr�g�g���� 1000 ���루�� 1 �룩
            timer.Tick += Timer_Tick; // �]�� Timer_Tick ���鶨�r�|�l�¼���̎����
            timer.Start(); // ����Ӌ�r��


        }
        
        private void InitializePointText()
        {
            // �O�Ì���
            pointText.Text = "�֔���"+point;
            pointText.Font = new Font("Arial", 20, FontStyle.Bold);
            pointText.ForeColor = Color.Black;
            pointText.BackColor = Color.Transparent;
            pointText.AutoSize = true; // �Ԅ��{��Label��С���m������
            pointText.Location = new Point(0, 0); // �O��Label��λ��
            // ��Label���뵽��εĿؼ�����
            this.Controls.Add(pointText);
        }

        // Ӌ�r���� Tick �¼�̎����
        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Interval = 1000;
            // ���@�e���÷��K�Ԅ��½���߉݋
            if (CanNextBlock(block_I-1, block_J, block_Type))
            {
                blockDesign.DrawBlack(block_I, block_J, block_Type);
                block_I--;
                blockDesign.DrawBlock(block_I, block_J, block_Type);
                Console.WriteLine("Timer ticked - move block down");
            }
            else
            {
                GenerateNewBlock();
            }

        }
        //timer.stop;

        private void GenerateNewBlock()
        {
            CheckAndClearRows();
            if (firstGenerate)
            {
                block_Type = random.Next(1, 8);
                firstGenerate = false;
            }
            else
            {
                block_Type = new_block_Type;
            }

            switch (block_Type)
            {
                case 1:
                    block_I = 18;
                    block_J = random.Next(0, 10);
                    break;
                case 2:
                    block_I = 20;
                    block_J = random.Next(0, 9);
                    break;
                case 3:
                    block_I = 20;
                    block_J = random.Next(1, 9);
                    break;
                case 4:
                    block_I = 20;
                    block_J = random.Next(1, 9);
                    break;
                case 5:
                    block_I = 20;
                    block_J = random.Next(2, 10);
                    break;
                case 6:
                    block_I = 20;
                    block_J = random.Next(0, 8);
                    break;
                case 7:
                    block_I = 20;
                    block_J = random.Next(1, 9);
                    break;

            }


            if ( !CanNewBlock(block_I, block_J, block_Type ))
            {
                timer.Stop();
                Console.WriteLine("Game Over!");
                for (int i = 0; i <= 21; i++) // ������21��
                {
                    for (int j = 0; j <= 9; j++) // ������9��
                    {
                        grids[i, j].BackColor = Color.Gray;
                    }
                }
            }
            else
            {
                blockDesign.DrawBlock(block_I, block_J, block_Type);
            }
            new_block_Type = random.Next(1, 8);
            blockDesign.ClearHint();
            blockDesign.DrawHint(new_block_Type);
        }

        private bool CanNewBlock(int i, int j, int type)
        {
            switch (type)
            {
                case 1:
                    if (j >= 0 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 2, j] == false && signs[i + 3, j] == false) { return true; }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }

                case 11:
                    if (j + 3 <= 9 && signs[i, j] == false && signs[i, j + 1] == false && signs[i, j + 2] == false && signs[i, j + 3] == false) { return true; }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;
                case 2: // O-Block
                    if (j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j + 1] == false && signs[i + 1, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 3: // Z-Block
                    if (j - 1 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 1, j - 1] == false && signs[i, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 13: // Z-Block Spin
                    if (i - 1 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i, j + 1] == false && signs[i + 1, j + 1] == false && signs[i - 1, j] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 4: // S-Block
                    if (j - 1 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 1, j + 1] == false && signs[i, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 14: // S-Block Spin
                    if (i - 1 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j + 1] == false && signs[i - 1, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 5: // J-Block
                    if (j - 2 >= 0 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 1, j - 1] == false && signs[i + 1, j - 2] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 15: // J-Block Spin (0 degrees)
                    if (i >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i, j + 1] == false && signs[i + 1, j + 1] == false && signs[i + 2, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 25: // J-Block Spin (90 degrees)
                    if (i - 1 >= 0 && j + 2 <= 9 && signs[i, j] == false && signs[i - 1, j] == false && signs[i - 1, j + 1] == false && signs[i - 1, j + 2] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 35: // J-Block Spin (180 degrees)
                    if (i - 2 >= 0 && j - 1 >= 0 && signs[i, j] == false && signs[i, j - 1] == false && signs[i - 1, j - 1] == false && signs[i - 2, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 6: // L-Block
                    if (j + 3 <= 10 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 1, j + 1] == false && signs[i + 1, j + 2] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 16: // L-Block Spin (0 degrees)
                    if (j - 1 >= 0 && signs[i, j] == false && signs[i, j - 1] == false && signs[i + 1, j - 1] == false && signs[i + 2, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 26: // L-Block Spin (90 degrees)
                    if (i - 1 >= 0 && j - 2 >= 0 && signs[i, j] == false && signs[i - 1, j] == false && signs[i - 1, j - 1] == false && signs[i - 1, j - 2] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 36: // L-Block Spin (180 degrees)
                    if (i - 2 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i, j + 1] == false && signs[i - 1, j + 1] == false && signs[i - 2, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 7: // T-Block
                    if (j - 1 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j + 1] == false && signs[i, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 17: // T-Block Spin (0 degrees)
                    if (i - 1 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j + 1] == false && signs[i - 1, j] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 27: // T-Block Spin (90 degrees)
                    if (i - 1 >= 0 && j + 1 <= 9 && j - 1 >= 0 && signs[i, j] == false && signs[i - 1, j] == false && signs[i, j + 1] == false && signs[i, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 37: // T-Block Spin (180 degrees)
                    if (i - 1 >= 0 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j - 1] == false && signs[i - 1, j] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                default: 
                    return false;
                    break;
            }
        }

        //�����I�P��ݔ��
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
                case Keys.P:
                    if (timerStatus)
                    {
                        timer.Stop();
                        timerStatus = false;
                    }
                    else
                    {
                        timer.Start();
                        timerStatus = true;
                    }
                    break;

                default:
                    break;

            }
        }

        private void MoveBlockLeft()
        {
            if ( CanNextBlock(block_I, block_J-1, block_Type) )
            {
                blockDesign.DrawBlack(block_I, block_J, block_Type);
                block_J--;
                blockDesign.DrawBlock(block_I, block_J, block_Type);
            }
        }

        private void MoveBlockRight()
        {
            if (CanNextBlock(block_I, block_J + 1, block_Type))
            {
                blockDesign.DrawBlack(block_I, block_J, block_Type);
                block_J++;
                blockDesign.DrawBlock(block_I, block_J, block_Type);
            }
        }
        //�������I�¼��ٷ��K����
        private void DropBlock()
        {
            if ( true)
            {
                timer.Interval = 100;
            }
        }

        private void RotateBlock()
        {
            switch (block_Type)
            {
                case 1://I-Black
                    if (CanNextBlock(block_I, block_J, 11))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 11;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }

                    break;

                case 11://I-Spin
                    if (CanNextBlock(block_I, block_J, 1))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 1;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;

                case 2://O-Black
                    break;
                case 3://Z-Black
                    if (CanNextBlock(block_I, block_J, 13))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 13;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 13://Z-spin
                    if (CanNextBlock(block_I, block_J, 3))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 3;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 4://S-Black
                    if (CanNextBlock(block_I, block_J, 14))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 14;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 14://S-spin
                    if (CanNextBlock(block_I, block_J, 4))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 4;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 5://J-Black
                    if (CanNextBlock(block_I, block_J, 15))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 15;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 15://J-Spin
                    if (CanNextBlock(block_I, block_J, 25))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 25;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 25://J-Spin
                    if (CanNextBlock(block_I, block_J, 35))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 35;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 35://J-Spin
                    if (CanNextBlock(block_I, block_J, 5))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 5;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 6://L-Black
                    if (CanNextBlock(block_I, block_J, 16))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 16;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 16://L-Spin
                    if (CanNextBlock(block_I, block_J, 26))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 26;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 26://L-Spin
                    if (CanNextBlock(block_I, block_J, 36))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 36;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 36://L-Spin
                    if (CanNextBlock(block_I, block_J, 6))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 6;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 7://T-Black
                    if (CanNextBlock(block_I, block_J, 17))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 17;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 17://T-Spin
                    if (CanNextBlock(block_I, block_J, 27))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 27;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 27://T-Spin
                    if (CanNextBlock(block_I, block_J, 37))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 37;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
                case 37://T-Spin
                    if (CanNextBlock(block_I, block_J, 7))
                    {
                        blockDesign.DrawBlack(block_I, block_J, block_Type);
                        block_Type = 7;
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                    }
                    break;
            }
        }

        private bool CanNextBlock(int i, int j, int type)
        {
            // �z�� i, j �Ƿ񳬳�����
            if (i < 0 || j < 0 || i >= 21 || j >= 10)
            {
                return false;
            }
            switch (type)
            {
                case 1:
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (j>=0 && signs[i, j] == false && signs[i+1, j] == false && signs[i+2, j] == false && signs[i+3, j] == false) { return true; }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }

                case 11:
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if ( j+3<=9 && signs[i, j] == false && signs[i, j + 1] == false && signs[i, j + 2] == false && signs[i, j + 3] ==false) { return true; }
                    else 
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false; 
                    }
                    break;
                case 2: // O-Block
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (j+1<=9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j + 1] == false && signs[i + 1, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 3: // Z-Block
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (j-1>=0 && j+1<=9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 1, j - 1] == false && signs[i, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 13: // Z-Block Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i - 1 >= 0 && j + 1<=9 && signs[i, j] == false && signs[i , j+1] == false && signs[i+1, j + 1] == false && signs[i - 1, j] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 4: // S-Block
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (j - 1 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 1, j + 1] == false && signs[i, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 14: // S-Block Spin
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i-1>=0 && j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j + 1] == false && signs[i - 1, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 5: // J-Block
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (j-2>=0 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 1, j - 1] == false && signs[i + 1, j - 2] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 15: // J-Block Spin (0 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i, j + 1] == false && signs[i + 1, j + 1] == false && signs[i + 2, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 25: // J-Block Spin (90 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i - 1 >= 0 && j + 2 <= 9 && signs[i, j] == false && signs[i - 1, j] == false && signs[i - 1, j + 1] == false && signs[i - 1, j + 2] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 35: // J-Block Spin (180 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i - 2 >= 0 && j - 1>=0 && signs[i, j] == false && signs[i, j - 1] == false && signs[i - 1, j - 1] == false && signs[i - 2, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 6: // L-Block
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (j + 3 <= 10 && signs[i, j] == false && signs[i + 1, j] == false && signs[i + 1, j + 1] == false && signs[i + 1, j + 2] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 16: // L-Block Spin (0 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (j - 1 >= 0 && signs[i, j] == false && signs[i, j - 1] == false && signs[i + 1, j - 1] == false && signs[i + 2, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 26: // L-Block Spin (90 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i - 1 >= 0 && j - 2 >= 0 && signs[i, j] == false && signs[i - 1, j] == false && signs[i - 1, j - 1] == false && signs[i - 1, j - 2] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 36: // L-Block Spin (180 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i - 2 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i, j + 1] == false && signs[i - 1, j + 1] == false && signs[i - 2, j + 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 7: // T-Block
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (j - 1 >= 0 && j + 1<=9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j + 1] == false && signs[i, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 17: // T-Block Spin (0 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i - 1 >= 0 && j + 1 <= 9 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j + 1] == false && signs[i - 1, j] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 27: // T-Block Spin (90 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i - 1 >= 0 && j + 1 <= 9 && j - 1 >= 0 && signs[i, j] == false && signs[i - 1, j] == false && signs[i, j + 1] == false && signs[i, j - 1] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                case 37: // T-Block Spin (180 degrees)
                    blockDesign.DrawBlack(block_I, block_J, block_Type);
                    if (i - 1 >= 0 && signs[i, j] == false && signs[i + 1, j] == false && signs[i, j - 1] == false && signs[i - 1, j] == false)
                    {
                        return true;
                    }
                    else
                    {
                        blockDesign.DrawBlock(block_I, block_J, block_Type);
                        return false;
                    }
                    break;

                default: 
                    return false;
            }
        }
        //�z���Ƿ��п��������ЁK��������
        private void CheckAndClearRows()
        {
            for (int i = 0; i <= 21; i++)
            {
                bool isRowFull = true;

                for (int j = 0; j <= 9; j++)
                {
                    if (!signs[i, j])
                    {
                        isRowFull = false;
                        break;
                    }
                }//�Ƿ���һ�ж��ѽ��M��

                if (isRowFull)
                {
                    point = point + 10;
                    pointText.Text = "�֔���"+point;
                    for (int j = 0; j < 10; j++)
                    {
                        signs[i, j] = false;
                        grids[i, j].BackColor = Color.Black; // ���O��ɫ��հ׸��ɫ
                    }

                    // ���Ϸ���ÿһ�������Ƅ�һ��
                    for (int row = i; row < 21; row++)
                    {
                        for (int col = 0; col < 10 ; col++)
                        {
                            if (signs[row + 1, col]==true)
                            {
                                signs[row, col] = true;
                            }
                            else
                            {
                                signs[row, col] = false;
                            }
                            grids[row, col].BackColor = grids[row + 1, col].BackColor;
                        }
                    }

                    // ������Ϸ�һ�У�������������Ƅ�
                    for (int col = 0; col < 10; col++)
                    {
                        signs[21, col] = false;
                        grids[21, col].BackColor = Color.Black; // �O�Þ�հ�ɫ
                    }
                    CheckAndClearRows();
                }

            }

        }

    }
    
}