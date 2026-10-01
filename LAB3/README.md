# BÀI 3 — HỆ THỐNG QUẢN LÝ KHÁCH SẠN

**Môn:** Phân tích thiết kế hướng đối tượng (OOSD)
**Trường:** Đại học Tài nguyên và Môi trường TP.HCM (HCMUNRE)
**Công nghệ:** C# WinForms (.NET Framework 4.7.2) — ADO.NET — SQL Server (LocalDB/Express)

---

## 1. Mô tả bài toán

Hệ thống quản lý khách sạn dạng ứng dụng nội bộ (WinForms), phục vụ cho nhân viên khách sạn (không phải khách hàng) thao tác trực tiếp. Các nghiệp vụ chính:

- Quản lý danh mục nền: khu vực, phòng, tiện nghi, nhân viên, dịch vụ, quy định đền bù.
- Đặt phòng, nhận phòng, ghi nhận người lưu trú, đánh dấu no-show.
- Ghi nhận dịch vụ sử dụng trong ngày, cộng dồn nếu dùng nhiều lần cùng ngày.
- Trả phòng: kiểm tra tiện nghi, lập phiếu đền bù nếu hư hỏng/mất, lập hóa đơn, ghi nhận thanh toán (nhiều hình thức, nhiều lần).
- Thống kê theo khoảng thời gian: số phiếu đặt, doanh thu, đền bù, dịch vụ sử dụng.

## 2. Cấu trúc thư mục

```
QuanLyKhachSan/
├── QuanLyKhachSan.sln              # Solution file
└── QuanLyKhachSan/
    ├── QuanLyKhachSan.csproj
    ├── App.config                  # Connection string tới SQL Server
    ├── Program.cs                  # Entry point (Main)
    ├── Models.cs                   # KetQuaXuLy, PhongDatItem, DenBuItem
    ├── Database/
    │   └── QuanLyKhachSan.sql      # Script tạo DB + bảng + dữ liệu mẫu
    ├── Data/
    │   └── Db.cs                   # Helper kết nối & thực thi SQL (ADO.NET)
    ├── Services/                   # Lớp nghiệp vụ (Business Logic)
    │   ├── DanhMucService.cs
    │   ├── PhongTienNghiService.cs
    │   ├── DatPhongService.cs
    │   ├── DichVuService.cs
    │   ├── TraPhongService.cs
    │   └── ThongKeService.cs
    └── Forms/                      # Giao diện WinForms
        ├── FrmMain.cs               # Màn hình chính, điều hướng
        ├── FrmDanhMuc.cs            # Quản lý danh mục
        ├── FrmPhongTienNghi.cs      # Phòng - Tiện nghi - Lắp đặt
        ├── FrmDatPhong.cs           # Khách hàng - Đặt/Nhận phòng
        ├── FrmDichVu.cs             # Ghi nhận sử dụng dịch vụ
        ├── FrmTraPhong.cs           # Đền bù - Hóa đơn - Thanh toán - Trả phòng
        └── FrmThongKe.cs            # Thống kê
```

**Kiến trúc:** `WinForms UI → Services (Business Logic) → Data (ADO.NET) → SQL Server`
Form không viết SQL trực tiếp; nghiệp vụ ảnh hưởng nhiều bảng dùng `SqlTransaction` để đảm bảo toàn vẹn (đặt phòng, nhận phòng, ghi dịch vụ, đền bù, thanh toán).

## 3. Hướng dẫn cài đặt & chạy

1. **Tạo database:** Mở SQL Server Object Explorer trong Visual Studio, kết nối server `(localdb)\MSSQLLocalDB` (Windows Authentication). Mở và chạy toàn bộ file `Database/QuanLyKhachSan.sql` để tạo database, bảng, ràng buộc và dữ liệu mẫu.
2. **Kiểm tra connection string:** Nếu không dùng LocalDB mặc định, sửa `connectionString` trong `App.config` cho khớp server của bạn.
3. **Mở solution:** Double-click `QuanLyKhachSan.sln` bằng Visual Studio 2022 (hoặc mới hơn).
4. **Build:** `Ctrl+Shift+B`. Nếu thiếu reference `System.Configuration`, vào Solution Explorer → References → Add Reference → Assemblies → Framework → tích `System.Configuration`.
5. **Chạy:** Nhấn `F5`. Màn hình `FrmMain` hiện ra với 7 nút chức năng.

## 4. Danh sách Actor & Use case

| Actor | Vai trò |
|---|---|
| Độc giả *(không áp dụng — hệ thống khách sạn)* | — |
| **Nhân viên** | Actor tổng quát: quản lý danh mục, ghi nhận dịch vụ |
| **NV lễ tân** | Đặt phòng, nhận phòng |
| **NV phục vụ phòng** | Quản lý phòng/tiện nghi, lập phiếu lắp đặt |
| **NV thanh toán** | Trả phòng, lập hóa đơn, thanh toán |
| **Quản lý** | Tra cứu / thống kê |

| Use case | Form tương ứng | Service |
|---|---|---|
| Quản lý danh mục | FrmDanhMuc | DanhMucService |
| Quản lý phòng - tiện nghi | FrmPhongTienNghi | PhongTienNghiService |
| Đặt / nhận phòng | FrmDatPhong | DatPhongService |
| Ghi nhận dịch vụ | FrmDichVu | DichVuService |
| Trả phòng - thanh toán | FrmTraPhong | TraPhongService |
| Tra cứu / thống kê | FrmThongKe | ThongKeService |

## 5. Quy tắc nghiệp vụ (Business Rules)

| ID | Quy tắc |
|---|---|
| BR01 | Một khu vực có nhiều phòng; một phòng thuộc một khu vực. |
| BR02 | Mỗi phòng có sức chứa tối đa và đơn giá thuê theo ngày. |
| BR03 | Một tiện nghi có số thứ tự phân biệt trong cùng loại tiện nghi. |
| BR04 | Trong một ngày, một thiết bị chỉ được trang bị cho một phòng duy nhất. |
| BR05 | Phiếu đặt phòng ghi phòng, ngày nhận, ngày trả dự kiến và tiền cọc. |
| BR06 | Ghi họ tên, CCCD và quốc tịch của người lưu trú. |
| BR07 | Cùng một dịch vụ dùng nhiều lần trong ngày được cộng dồn thành một lần. |
| BR08 | Khi có hư hỏng/mất mát thì lập phiếu đền bù theo tiện nghi và mức độ thiệt hại. |
| BR09 | Hóa đơn gồm tiền thuê phòng và tiền sử dụng dịch vụ. |
| BR10 | Thanh toán hỗ trợ tiền mặt, chuyển khoản, thẻ, ví điện tử (có thể nhiều giao dịch cho 1 hóa đơn). |

## 6. Bảng test case tiêu biểu

| TC | Điều kiện | Thao tác | Kết quả mong đợi |
|---|---|---|---|
| TC01 | Phòng trống, số người ≤ sức chứa | Lập phiếu đặt | Thành công |
| TC02 | Số người vượt sức chứa | Lập phiếu đặt | Từ chối |
| TC03 | Phòng trùng lịch với phiếu Đã đặt/Đang ở khác | Lập phiếu đặt | Từ chối |
| TC04 | Thiết bị đã lắp cho phòng khác trong cùng ngày | Lập phiếu lắp đặt | Từ chối (UNIQUE constraint) |
| TC05 | Phiếu ở trạng thái Đã đặt | Nhận phòng | Chuyển trạng thái Đang ở |
| TC06 | Đã đủ số người đăng ký cho phòng | Thêm người lưu trú | Từ chối |
| TC07 | Cùng dịch vụ, dùng lần 2 trong ngày | Ghi nhận dịch vụ | Cộng dồn số lượng, không tạo dòng mới |
| TC08 | Phiếu không ở trạng thái Đang ở | Ghi nhận dịch vụ | Từ chối |
| TC09 | Tiện nghi bị hư hỏng | Lập phiếu đền bù | Thành công, tính đúng tổng tiền |
| TC10 | Phiếu đang ở có dùng dịch vụ | Lập hóa đơn | Tổng tiền = Tiền phòng + Tiền dịch vụ |
| TC11 | Thanh toán một phần | Ghi nhận thanh toán | Hóa đơn vẫn ở trạng thái Chưa thanh toán |
| TC12 | Thanh toán đủ tổng tiền | Ghi nhận thanh toán | Hóa đơn chuyển Đã thanh toán |
| TC13 | Hóa đơn chưa thanh toán đủ | Hoàn tất trả phòng | Từ chối |
| TC14 | Hóa đơn đã thanh toán đủ | Hoàn tất trả phòng | Phiếu chuyển Đã trả, phòng chuyển Trống |
| TC15 | Khoảng ngày hợp lệ (đến ≥ từ) | Thống kê | Trả về đúng số liệu tổng hợp và theo dịch vụ |

## 7. Ghi chú triển khai

- Toàn bộ giao diện Form được dựng bằng code (trong hàm `BuildUI()` của mỗi Form) thay vì kéo-thả trên Designer, để dễ kiểm soát và tránh lỗi lệch layout do DPI màn hình.
- `AutoScaleMode = None` được đặt ở mỗi Form để layout không bị scale sai khi máy bật DPI > 100%.
- Mọi thao tác ghi dữ liệu ảnh hưởng nhiều bảng (đặt phòng, nhận phòng, ghi dịch vụ, đền bù, thanh toán) đều dùng `SqlTransaction`, rollback tự động nếu có lỗi giữa chừng.
- Số ngày tính tiền khi lập hóa đơn do nhân viên nhập tay, vì đề bài gốc không quy định cách làm tròn ngày/đêm lưu trú.
- Mức đền bù tham khảo từ bảng `QuyDinhDenBu`, không phải mức chính thức cố định của khách sạn.

## 8. Tác giả

Sinh viên: Huỳnh Gia Bảo
MSSV: 1250080014
Lớp: 12_DH_CNPM1
