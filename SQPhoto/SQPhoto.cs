using System.ComponentModel;

namespace SQPhoto
{
    [ToolboxBitmap(typeof(PictureBox))]
    public partial class SQPhoto : UserControl
    {
        public SQPhoto()
        {
            InitializeComponent();
            Init();
        }
        /// <summary>
        /// 初始化组件
        /// </summary>
        public void Init()
        {
            //绑定鼠标滚轮缩放图片
            PicBox.MouseWheel += new MouseEventHandler(this.PicBox_MouseWheel);
            PanBox.DoubleClick += new EventHandler(this.Pan_picture_DoubleClick);
            PicBox.DoubleClick += new EventHandler(this.Pan_picture_DoubleClick);
            PicBox.MouseDown += new MouseEventHandler(this.PicBox_MouseDown);
            PicBox.MouseMove += new MouseEventHandler(this.PicBox_MouseMove);
            PicBox.MouseUp += new MouseEventHandler(this.PicBox_MouseUp);
        }

        [Category("自定义"), Browsable(true), Description("图片")]
        public Image Image
        {
            get
            {
                return PicBox.Image;
            }
            set
            {
                PicBox.Image = value;
                // 恢复大小
                if (_AutoReSize)
                {
                    ReSize();
                }
            }
        }

        private bool _CanReSize = true;
        [Category("自定义"), Browsable(true), Description("是否双击恢复原始大小")]
        public bool CanReSize
        {
            get
            {
                return _CanReSize;
            }
            set
            {
                _CanReSize = value;
            }
        }

        private bool _AutoReSize = true;
        [Category("自定义"), Browsable(true), Description("更改图片自动恢复大小")]
        public bool AutoReSize
        {
            get
            {
                return _AutoReSize;
            }
            set
            {
                _AutoReSize = value;
            }
        }


        private bool _CanMove = true;
        [Category("自定义"), Browsable(true), Description("是否允许拖动")]
        public bool CanMove
        {
            get
            {
                return _CanMove;
            }
            set
            {
                _CanMove = value;
            }
        }

        private bool _CanZoom = true;
        [Category("自定义"), Browsable(true), Description("是否允许缩放")]
        public bool CanZoom
        {
            get
            {
                return _CanZoom;
            }
            set
            {
                _CanZoom = value;
            }
        }

        private bool _ZoomCenter = true;
        [Category("自定义"), Browsable(true), Description("是否中心缩放")]
        public bool ZoomCenter
        {
            get
            {
                return _ZoomCenter;
            }
            set
            {
                _ZoomCenter = value;
            }
        }

        private int _ZoomMin = 100;
        [Category("自定义"), Browsable(true), Description("可缩放的最小大小")]
        public int ZoomMin
        {
            get
            {
                return _ZoomMin;
            }
            set
            {
                _ZoomMin = value;
            }
        }

        [Category("自定义"), Browsable(true), Description("图片显示的缩放类型")]
        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return PicBox.SizeMode;
            }
            set
            {
                PicBox.SizeMode = value;
            }
        }

        /// <summary>
        /// 恢复图片原始大小和位置
        /// </summary>
        public void ReSize()
        {
            PicBox.Size = PanBox.Size;
            PicBox.Location = new Point(0, 0);
        }


        Point mouseDownPoint;
        bool isSelected = false;

        /// <summary>
        /// 左键按下，记录鼠标XY值，标记按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = Cursor.Position;
                isSelected = true;
            }
        }

        /// <summary>
        /// 计算鼠标移动位置是否还在容器内
        /// </summary>
        /// <returns></returns>
        private bool IsMouseInPanel()
        {
            if (PanBox.Left < PointToClient(Cursor.Position).X
            && PointToClient(Cursor.Position).X < PanBox.Left + PanBox.Width
            && PanBox.Top < PointToClient(Cursor.Position).Y
            && PointToClient(Cursor.Position).Y < PanBox.Top + PanBox.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            //开启移动 左键按下 并且移动位置在框内
            if (_CanMove && isSelected && IsMouseInPanel())
            {
                PicBox.Location = new Point(PicBox.Left + (Cursor.Position.X - mouseDownPoint.X), PicBox.Top + (Cursor.Position.Y - mouseDownPoint.Y));
                mouseDownPoint = Cursor.Position;
            }
        }

        /// <summary>
        /// 鼠标键松开，标记置为false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_MouseUp(object sender, MouseEventArgs e)
        {
            isSelected = false;
        }

        private void PicBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_CanZoom) return;
            PicZoomSize(e.Delta);
        }

        /// <summary>
        /// 控制图片缩放
        /// </summary>
        /// <param name="change">变化情况，大于 0 放大，小于 0 缩小</param>
        public void PicZoomSize(int change)
        {
            var t = PicBox.Size;
            t.Width += change;
            t.Height += change;

            //控制最小缩放
            if (t.Width < _ZoomMin) return;
            PicBox.Size = t;

            //图片按中心比例放大缩小
            if (!_ZoomCenter) return;
            PicBox.Location = new Point((this.Width - PicBox.Width) / 2, (this.Height - PicBox.Height) / 2);
        }

        /// <summary>
        /// 缩放拖动到找不见了，就双击恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pan_picture_DoubleClick(object sender, EventArgs e)
        {
            //不允许恢复就不执行了
            if (!_CanReSize) return;
            ReSize();
        }


    }
}