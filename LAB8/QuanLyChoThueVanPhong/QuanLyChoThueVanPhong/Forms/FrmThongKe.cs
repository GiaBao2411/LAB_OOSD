using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Common;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmThongKe : Form
    {
        readonly ThongKeService s = new ThongKeService();

        DataGridView gTong, gNo;

        public FrmThongKe()
        {
            InitializeComponent();
            BuildUI();
            Tai();
        }

        void BuildUI()
        {
            Ui.ChuanHoa(this, "Thống kê phòng, doanh thu và công nợ", 1000, 560);

            gNo = Ui.Luoi(DockStyle.Fill, 0);
            gTong = Ui.Luoi(DockStyle.Top, 110);

            this.Controls.Add(gNo);
            this.Controls.Add(Ui.Tieu("Công nợ tiền thuê, tiền dịch vụ và tiền phạt theo phòng"));
            this.Controls.Add(gTong);
            this.Controls.Add(Ui.Tieu("Tổng hợp tình trạng phòng và số tiền đã thu"));
            this.Controls.Add(Ui.Hang(Ui.Bt("Làm mới", (o, e) => Tai())));
        }

        void Tai()
        {
            gTong.DataSource = s.TongHop();
            gNo.DataSource = s.CongNo();
        }
    }
}
