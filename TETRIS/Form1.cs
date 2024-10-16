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
            grids = MapGenerate.GenerateMap(this); // 調用 MapGenerate 類別中的 GenerateMap 方法
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
            timer.Interval = 1000; // 設置計時器的時間間隔為 1000 毫秒（即 1 秒）
            timer.Tick += Timer_Tick; // 註冊 Timer_Tick 作為定時觸發事件的處理函數
            timer.Start(); // 啟動計時器


        }

        // 計時器的 Tick 事件處理函數
        private void Timer_Tick(object? sender, EventArgs e)
        {
            // 在這裡放置方塊自動下降的邏輯
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