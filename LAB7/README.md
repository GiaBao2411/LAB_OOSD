# Bài 7 – Quản lý nhân sự công ty sơn Đông Á

Ứng dụng Windows Forms viết bằng C# (.NET Framework 4.7.2), dùng SQL Server. Chương trình quản lý tuyển dụng và thử việc, hợp đồng, bảo hiểm, quyết định chức vụ và lương, phân công tuần, chấm công, phụ trội, bảng lương, khen thưởng, kỷ luật và thống kê nhân sự.

---

## 1. Cần cài trước

| Phần mềm | Ghi chú |
|---|---|
| Visual Studio 2019 hoặc 2022 | Khi cài chọn workload **.NET desktop development** |
| .NET Framework 4.7.2 Developer Pack | Thường có sẵn khi cài workload trên |
| SQL Server (Express, Developer hoặc LocalDB) | Bản nào cũng chạy được |
| SQL Server Management Studio (SSMS) | Không bắt buộc, dùng để xem dữ liệu hoặc chạy script bằng tay |

---

## 2. Chạy nhanh (4 bước)

### Bước 1 – Giải nén
Giải nén `QuanLyNhanSu.zip` ra một thư mục, ví dụ `D:\QuanLyNhanSu`.
**Không** mở trực tiếp bên trong file zip.

### Bước 2 – Mở project
Nhấp đúp file **`QuanLyNhanSu.sln`**. Nếu Visual Studio không mở được file `.sln` thì mở file **`QuanLyNhanSu.csproj`**, hai file nằm cùng thư mục.

### Bước 3 – Sửa chuỗi kết nối trong `App.config`
Mở file `App.config` trong Solution Explorer và sửa dòng `connectionString` cho đúng máy của bạn.

**Cách A – Đăng nhập bằng tài khoản `sa` (SQL Server Authentication):**
```xml
<add name="QuanLyNhanSuDB"
     connectionString="Data Source=TEN_MAY\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;User ID=sa;Password=MAT_KHAU;TrustServerCertificate=True"
     providerName="System.Data.SqlClient" />
```

**Cách B – Đăng nhập bằng tài khoản Windows (Windows Authentication):**
```xml
<add name="QuanLyNhanSuDB"
     connectionString="Data Source=TEN_MAY\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True;TrustServerCertificate=True"
     providerName="System.Data.SqlClient" />
```

Muốn biết điền gì vào `Data Source`, mở SSMS và xem ô **Server name** trong hộp thoại Connect. Ví dụ:

| Loại SQL Server | Data Source |
|---|---|
| SQL Server Express mặc định | `.\SQLEXPRESS` hoặc `TEN_MAY\SQLEXPRESS` |
| Instance đặt tên riêng | `TEN_MAY\TEN_INSTANCE` (ví dụ `GIAHIEU\SQLEXPRESS01`) |
| SQL Server bản đầy đủ (Developer hoặc Standard) | `.` hoặc `TEN_MAY` |
| LocalDB đi kèm Visual Studio | `(localdb)\MSSQLLocalDB` |

> Chỉ sửa `Data Source`, `User ID` và `Password`. **Giữ nguyên** `Initial Catalog=QuanLyNhanSu`.

### Bước 4 – Chạy
Bấm **F5** (hoặc nút **Start**).

Lần chạy đầu, nếu chưa có database `QuanLyNhanSu`, chương trình sẽ **tự tạo database và dữ liệu mẫu** bằng file `Database\QuanLyNhanSu.sql`, rồi mở màn hình chính. Từ lần sau chương trình dùng lại database đã có.

---

## 3. Tạo database bằng tay (nếu muốn)

1. Mở SSMS và kết nối vào SQL Server.
2. Vào **File → Open → File…** và chọn `Database\QuanLyNhanSu.sql`.
3. Bấm **Execute** (F5). Script sẽ tạo database, 20 bảng và dữ liệu mẫu.
4. Quay lại Visual Studio và bấm F5.

Muốn **làm lại dữ liệu từ đầu** thì chạy lại file `.sql` (script tự xóa bảng cũ rồi tạo lại). Cách khác là xóa database bằng lệnh `DROP DATABASE QuanLyNhanSu;` rồi chạy lại chương trình.

---

## 4. Một số lỗi thường gặp

| Lỗi | Cách xử lý |
|---|---|
| *A network-related or instance-specific error…* | Sai `Data Source` hoặc SQL Server chưa chạy. Kiểm tra lại tên server trong SSMS, mở **Services** và bật dịch vụ `SQL Server (SQLEXPRESS)` |
| *Login failed for user 'sa'* | Sai mật khẩu, hoặc server chưa bật **SQL Server and Windows Authentication mode** (vào SSMS → chuột phải server → Properties → Security), hoặc tài khoản `sa` đang bị Disable |
| *The certificate chain was issued by an authority that is not trusted* | Thêm `TrustServerCertificate=True` vào cuối chuỗi kết nối |
| *Không tìm thấy file script: …\Database\QuanLyNhanSu.sql* | Chạy bằng Visual Studio (F5) để file `.sql` được copy theo, hoặc tạo database bằng tay như mục 3 |
| *CREATE DATABASE permission denied* | Tài khoản đang dùng không có quyền tạo database. Dùng `sa` hoặc tạo database bằng tay như mục 3 |
| Mở `.sln` không được, chỉ mở được `.csproj` | Mở thẳng `QuanLyNhanSu.csproj`, kết quả giống nhau |
| Lỗi thiếu .NET Framework 4.7.2 | Cài **.NET Framework 4.7.2 Developer Pack**, hoặc dùng Visual Studio Installer để thêm workload .NET desktop development |

---

## 5. Các màn hình (13 form)

| Form | Chức năng |
|---|---|
| FrmMain | Menu chính, mở các chức năng |
| FrmDanhMuc | Phòng ban (nhu cầu tuyển, trưởng phòng), chức vụ, ca làm việc |
| FrmNhanVien | Tra cứu, cập nhật hồ sơ, ghi nhận nghỉ việc, xem quá trình công tác |
| FrmTuyenDung | Lập quyết định tuyển dụng thử việc, theo dõi nhân viên thử việc |
| FrmHopDong | Ký hợp đồng chính thức (dài hạn / ngắn hạn), lập hồ sơ BHXH, BHYT |
| FrmQuyetDinh | Quyết định chức vụ (phụ cấp chức vụ) và quyết định lương |
| FrmPhanCong | Kế hoạch phân công theo tuần của trưởng phòng (kèm phụ trội dự kiến) |
| FrmChamCong | Chấm công từng ngày, bảng chấm công tháng |
| FrmPhuTroi | Phiếu ghi nhận giờ phụ trội (tăng ca, ngày lễ, ngày nghỉ) |
| FrmBangLuong | Xem trước và lập bảng lương tháng |
| FrmKhenThuong | Quyết định khen thưởng cá nhân / tập thể, chi phiếu thưởng |
| FrmKyLuat | Quyết định kỷ luật, thu tiền nộp phạt |
| FrmThongKe | Nhân sự theo phòng ban, thử việc / hợp đồng sắp hết hạn, thưởng phạt theo năm |

---

## 6. Dữ liệu mẫu để chạy thử

Dữ liệu mẫu có ngày quanh tháng 9–10/2026.

- **NV001 – Nguyễn Hoàng Long** là Giám đốc, chọn người này làm người ký quyết định khen thưởng và kỷ luật.
- **NV009** đã hết thử việc ngày 30/09/2026 nên **ký được** hợp đồng. **NV010** còn thử việc đến 30/11/2026 nên chương trình **từ chối** ký.
- Phòng **Kỹ thuật** cần tuyển 2 người, phòng **Sản xuất** cần tuyển 3 người. Hãy thử lập quyết định tuyển dụng vào các phòng này.
- Có dữ liệu chấm công tháng 9 và tháng 10 nên có thể **lập bảng lương tháng 9/2026**.
- **NV008** có phiếu phạt 200.000 đ tính theo cách trừ lương, khoản này sẽ bị trừ khi lập bảng lương tháng 9.

---

## 7. Quy định nghiệp vụ chính

- Chỉ tuyển vào phòng ban còn nhu cầu tuyển. Mỗi người được tuyển làm nhu cầu của phòng giảm đi 1.
- Thời gian thử việc từ 1 đến 6 tháng. Lương thử việc không thấp hơn 85% lương tối thiểu vùng.
- Chỉ ký hợp đồng khi đã hết thời gian thử việc. Ký xong, nhân viên chuyển sang trạng thái chính thức.
- Hợp đồng ngắn hạn phải có ngày kết thúc (tối đa 36 tháng). Hợp đồng dài hạn không có ngày kết thúc.
- Chỉ nhân viên có hợp đồng dài hạn mới được lập hồ sơ BHXH (mặc định 8%) và BHYT (mặc định 1,5%).
- Kế hoạch phân công lập theo tuần, bắt đầu từ thứ Hai. Giờ phụ trội được tính bằng 1,5 lần giờ thường.
- **Lương tháng** = lương cơ bản × ngày công / 26 + phụ cấp lương + phụ cấp độc hại + phụ cấp chức vụ + tiền phụ trội − BHXH − BHYT − tiền phạt trừ lương.
- Quyết định khen thưởng và kỷ luật do Giám đốc ký, áp dụng cho một cá nhân hoặc cả tập thể phòng ban.

---

## 8. Cấu trúc thư mục

```
QuanLyNhanSu/
├─ QuanLyNhanSu.sln          Mở file này bằng Visual Studio
├─ QuanLyNhanSu.csproj
├─ App.config                Chuỗi kết nối SQL Server (sửa ở đây)
├─ Program.cs                Điểm khởi động, tự tạo database lần đầu
├─ Data/
│  ├─ Db.cs                  Truy cập SQL Server, transaction
│  └─ DbInit.cs              Tự chạy script tạo database
├─ Services/                 Xử lý nghiệp vụ (12 service + Models.cs)
├─ Forms/                    13 form giao diện (.cs + .Designer.cs)
└─ Database/
   └─ QuanLyNhanSu.sql       Script tạo 20 bảng + dữ liệu mẫu
```

Kiến trúc 3 lớp: **Form** (giao diện) gọi **Service** (kiểm tra nghiệp vụ, transaction), Service gọi lớp **Db** để truy cập SQL Server. Form không chứa câu lệnh SQL.
