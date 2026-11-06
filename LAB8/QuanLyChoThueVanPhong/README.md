# Quản lý cho thuê văn phòng

Bài thực hành môn Phương pháp phát triển phần mềm hướng đối tượng - Lab 8.
Ứng dụng WinForms theo kiến trúc **Form (giao diện) -> Service (nghiệp vụ) -> Db (dữ liệu) -> SQL Server**,
đúng với bộ mô hình UML và thiết kế cơ sở dữ liệu trong báo cáo.

## 1. Yêu cầu máy

- Windows (WinForms chỉ chạy trên Windows).
- .NET SDK 8.0: https://dotnet.microsoft.com/download/dotnet/8.0
- SQL Server bất kỳ: LocalDB (cài kèm Visual Studio), SQL Server Express hoặc bản đầy đủ.
- Visual Studio Code kèm extension **C# Dev Kit** (hoặc mở thẳng bằng Visual Studio 2022).

## 2. Chạy bằng Visual Studio Code

1. Giải nén, mở **thư mục `QuanLyChoThueVanPhong`** (thư mục có file `QuanLyChoThueVanPhong.sln`) bằng VS Code.
2. Mở Terminal trong VS Code và chạy:

```
dotnet restore
dotnet run --project QuanLyChoThueVanPhong/QuanLyChoThueVanPhong.csproj
```

   Hoặc bấm **F5** (cấu hình sẵn trong `.vscode/launch.json`).

3. Lần chạy đầu tiên chương trình tự tạo cơ sở dữ liệu **QuanLyChoThueVanPhong** và dữ liệu mẫu
   bằng script `QuanLyChoThueVanPhong/Database/QuanLyChoThueVanPhong.sql`.

## 3. Chạy bằng Visual Studio 2022

Mở `QuanLyChoThueVanPhong.sln`, bấm **F5**. Không cần thao tác gì thêm.

## 4. Chuỗi kết nối

Mặc định dùng LocalDB, khai báo trong `QuanLyChoThueVanPhong/App.config`:

```
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyChoThueVanPhong;Integrated Security=True
```

Nếu máy bạn dùng SQL Server Express thì sửa thành:

```
Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyChoThueVanPhong;Integrated Security=True
```

Nếu không muốn chương trình tự tạo cơ sở dữ liệu, hãy mở SSMS chạy tay file
`QuanLyChoThueVanPhong/Database/QuanLyChoThueVanPhong.sql` trước rồi chạy chương trình.

## 5. Cấu trúc thư mục

```
QuanLyChoThueVanPhong/
  QuanLyChoThueVanPhong.sln
  .vscode/                  cấu hình F5 cho VS Code
  QuanLyChoThueVanPhong/
    App.config              chuỗi kết nối
    Program.cs              điểm vào, gọi DbInit rồi mở FrmMain
    Models.cs               KetQuaXuLy và các lớp dữ liệu dùng chung
    Common/Ui.cs            hàm dựng control dùng chung cho các Form
    Data/Db.cs              mở kết nối, Query / Execute / Scalar
    Data/DbInit.cs          tự chạy script SQL ở lần mở đầu tiên
    Database/QuanLyChoThueVanPhong.sql       script tạo bảng, ràng buộc và dữ liệu mẫu
    Services/               toàn bộ quy tắc nghiệp vụ và transaction
    Forms/                  các màn hình
```

## 6. Nghiệp vụ nhiều bảng dùng transaction

- Ký hợp đồng thuê: ghi hợp đồng, từng phòng với đơn giá đã chốt, đánh dấu phòng đã thuê và lập kỳ trả trước sáu tháng đầu.
- Gia hạn hợp đồng: chỉ gia hạn khi phòng không còn nợ, thêm không quá một nửa thời gian thuê.
- Lập hóa đơn dịch vụ cuối tháng: đưa các dòng sử dụng chưa chốt vào hóa đơn và cập nhật tổng tiền.
- Thu tiền thuê và tiền dịch vụ: kiểm tra số còn phải thu trước khi ghi phiếu thu.
- Lập biên bản kiểm tra kèm quyết định xử phạt và kế hoạch tu sửa.
- Cấp thẻ giự xe: thu hồi thẻ cũ rồi cấp thẻ mới.

Mọi thao tác ghi nhiều bảng đều mở `Db.OpenConnection()` + `BeginTransaction()`,
kiểm tra quy tắc ngay trong transaction, `Commit` khi thành công và `Rollback` khi có lỗi,
trả về `KetQuaXuLy.Ok` hoặc `KetQuaXuLy.Fail` để Form hiển thị thông báo.

## 7. Kiểm thử

Chạy lần lượt các trường hợp trong mục **6. KIỂM THỬ TỔNG THỂ** của báo cáo Lab 8
trên dữ liệu mẫu do script tạo ra.
