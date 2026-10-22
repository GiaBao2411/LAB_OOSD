/* Bài 5 - Quản lý hồ sơ bệnh án - bệnh viện đa khoa quốc tế
   Chạy toàn bộ file này trong SSMS (hoặc để chương trình tự chạy ở lần mở đầu tiên). */
IF DB_ID(N'QuanLyBenhAn') IS NULL CREATE DATABASE QuanLyBenhAn;
GO
USE QuanLyBenhAn;
GO

IF OBJECT_ID('LichHen', 'U') IS NOT NULL DROP TABLE LichHen;
IF OBJECT_ID('ChiTietToa', 'U') IS NOT NULL DROP TABLE ChiTietToa;
IF OBJECT_ID('ToaThuoc', 'U') IS NOT NULL DROP TABLE ToaThuoc;
IF OBJECT_ID('PhieuKham_XetNghiem', 'U') IS NOT NULL DROP TABLE PhieuKham_XetNghiem;
IF OBJECT_ID('PhieuKham', 'U') IS NOT NULL DROP TABLE PhieuKham;
IF OBJECT_ID('PhieuDangKy', 'U') IS NOT NULL DROP TABLE PhieuDangKy;
IF OBJECT_ID('HoSoBenhAn', 'U') IS NOT NULL DROP TABLE HoSoBenhAn;
IF OBJECT_ID('BenhNhan', 'U') IS NOT NULL DROP TABLE BenhNhan;
IF OBJECT_ID('XetNghiem', 'U') IS NOT NULL DROP TABLE XetNghiem;
IF OBJECT_ID('Thuoc', 'U') IS NOT NULL DROP TABLE Thuoc;
IF OBJECT_ID('BacSi', 'U') IS NOT NULL DROP TABLE BacSi;
IF OBJECT_ID('Khoa', 'U') IS NOT NULL DROP TABLE Khoa;
GO

CREATE TABLE Khoa (
    MaKhoa  varchar(10)    NOT NULL PRIMARY KEY,
    TenKhoa nvarchar(100)  NOT NULL UNIQUE
);

CREATE TABLE BacSi (
    MaBS      varchar(10)   NOT NULL PRIMARY KEY,
    HoTen     nvarchar(100) NOT NULL,
    MaKhoa    varchar(10)   NOT NULL REFERENCES Khoa(MaKhoa),
    DienThoai varchar(15)   NULL,
    ChuyenMon nvarchar(100) NULL
);

CREATE TABLE Thuoc (
    MaThuoc       varchar(10)   NOT NULL PRIMARY KEY,
    TenThuoc      nvarchar(100) NOT NULL,
    DonViTinh     nvarchar(20)  NOT NULL,
    ChongChiDinh  nvarchar(200) NULL
);

CREATE TABLE XetNghiem (
    MaXN   varchar(10)    NOT NULL PRIMARY KEY,
    TenXN  nvarchar(100)  NOT NULL,
    DonGia decimal(18, 0) NOT NULL CHECK (DonGia >= 0)
);

CREATE TABLE BenhNhan (
    MaBN      varchar(10)    NOT NULL PRIMARY KEY,
    HoTen     nvarchar(100)  NOT NULL,
    DiaChi    nvarchar(200)  NOT NULL,
    NgaySinh  date           NOT NULL,
    DienThoai varchar(15)    NOT NULL,
    Anh       varbinary(max) NULL            -- ảnh 3x4
);

CREATE TABLE HoSoBenhAn (
    MaHoSo     varchar(10) NOT NULL PRIMARY KEY,
    MaBN       varchar(10) NOT NULL,   -- mỗi bệnh nhân một hồ sơ
    NgayCap    date        NOT NULL,
    NgayHetHan date        NOT NULL,
    CONSTRAINT UQ_HoSo_BN UNIQUE (MaBN),
    CONSTRAINT FK_HoSo_BN FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN),
    CONSTRAINT CK_HoSo_Han CHECK (NgayHetHan > NgayCap)
);

-- Phiếu đăng ký: lần đầu (MOI) và các lần đóng lệ phí gia hạn hằng năm (GIAHAN)
CREATE TABLE PhieuDangKy (
    MaPDK      int IDENTITY(1, 1) PRIMARY KEY,
    MaBN       varchar(10)    NOT NULL REFERENCES BenhNhan(MaBN),
    MaHoSo     varchar(10)    NOT NULL REFERENCES HoSoBenhAn(MaHoSo),
    NgayDangKy date           NOT NULL,
    LePhi      decimal(18, 0) NOT NULL CHECK (LePhi > 0),
    TuNgay     date           NOT NULL,
    DenNgay    date           NOT NULL,
    LoaiDK     varchar(10)    NOT NULL CHECK (LoaiDK IN ('MOI', 'GIAHAN'))
);

CREATE TABLE PhieuKham (
    MaPK          varchar(12)    NOT NULL PRIMARY KEY,
    MaHoSo        varchar(10)    NOT NULL REFERENCES HoSoBenhAn(MaHoSo),
    NgayGioKham   datetime2      NOT NULL,
    MaBS          varchar(10)    NOT NULL REFERENCES BacSi(MaBS),
    MaKhoa        varchar(10)    NOT NULL REFERENCES Khoa(MaKhoa),
    LoaiKham      varchar(10)    NOT NULL CHECK (LoaiKham IN ('DIEUTRI', 'DINHKY')),
    TrieuChung    nvarchar(500)  NOT NULL,
    NhietDo       decimal(4, 1)  NULL CHECK (NhietDo BETWEEN 30 AND 45),
    HuyetAp       varchar(10)    NULL,
    KetLuan       nvarchar(300)  NULL,
    VienPhi       decimal(18, 0) NOT NULL DEFAULT 0 CHECK (VienPhi >= 0),
    DaThanhToan   bit            NOT NULL
);

CREATE TABLE PhieuKham_XetNghiem (
    MaPK   varchar(12)   NOT NULL REFERENCES PhieuKham(MaPK),
    MaXN   varchar(10)   NOT NULL REFERENCES XetNghiem(MaXN),
    KetQua nvarchar(200) NULL,
    PRIMARY KEY (MaPK, MaXN)
);

CREATE TABLE ToaThuoc (
    MaToa   varchar(12)   NOT NULL PRIMARY KEY,
    MaPK    varchar(12)   NOT NULL,   -- mỗi phiếu khám một toa
    NgayLap datetime2     NOT NULL,
    GhiChu  nvarchar(200) NULL,
    CONSTRAINT UQ_Toa_PK UNIQUE (MaPK),
    CONSTRAINT FK_Toa_PK FOREIGN KEY (MaPK) REFERENCES PhieuKham(MaPK)
);

CREATE TABLE ChiTietToa (
    MaToa       varchar(12)   NOT NULL REFERENCES ToaThuoc(MaToa),
    MaThuoc     varchar(10)   NOT NULL REFERENCES Thuoc(MaThuoc),
    SoLuong     int           NOT NULL CHECK (SoLuong > 0),
    LieuDung    nvarchar(200) NOT NULL,
    PhanUngPhu  nvarchar(300) NULL,     -- phản ứng phụ ghi nhận sau điều trị
    PRIMARY KEY (MaToa, MaThuoc)
);

CREATE TABLE LichHen (
    MaLH        int IDENTITY(1, 1) PRIMARY KEY,
    MaHoSo      varchar(10)   NOT NULL REFERENCES HoSoBenhAn(MaHoSo),
    NgayGioHen  datetime2     NOT NULL,
    TrangThai   varchar(10)   NOT NULL CHECK (TrangThai IN ('DAHEN', 'DAKHAM', 'HUY')),
    GhiChu      nvarchar(200) NULL
);
GO

/* ===================== DỮ LIỆU MẪU ===================== */
INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES
 ('K01', N'Nội tổng quát'), ('K02', N'Ngoại'), ('K03', N'Nhi'), ('K04', N'Tim mạch');

INSERT INTO BacSi(MaBS, HoTen, MaKhoa, DienThoai, ChuyenMon) VALUES
 ('BS01', N'Nguyễn Văn An',   'K01', '0901111111', N'Nội tiêu hóa'),
 ('BS02', N'Trần Thị Bích',   'K04', '0902222222', N'Tim mạch can thiệp'),
 ('BS03', N'Lê Quang Huy',    'K02', '0903333333', N'Chấn thương chỉnh hình'),
 ('BS04', N'Phạm Thu Hà',     'K03', '0904444444', N'Nhi hô hấp');

INSERT INTO Thuoc(MaThuoc, TenThuoc, DonViTinh, ChongChiDinh) VALUES
 ('T01', N'Paracetamol 500mg', N'Viên', N'Suy gan nặng'),
 ('T02', N'Amoxicillin 500mg', N'Viên', N'Dị ứng nhóm penicillin'),
 ('T03', N'Amlodipine 5mg',    N'Viên', N'Hạ huyết áp, sốc'),
 ('T04', N'Omeprazole 20mg',   N'Viên', NULL),
 ('T05', N'Vitamin C 500mg',   N'Viên', NULL);

INSERT INTO XetNghiem(MaXN, TenXN, DonGia) VALUES
 ('XN01', N'Công thức máu',   120000),
 ('XN02', N'Đường huyết',      60000),
 ('XN03', N'X-quang ngực',    200000),
 ('XN04', N'Điện tâm đồ',     150000);

INSERT INTO BenhNhan(MaBN, HoTen, DiaChi, NgaySinh, DienThoai, Anh) VALUES
 ('BN001', N'Nguyễn Minh Tuấn', N'12 Lê Lợi, Quận 1, TP.HCM',      '1985-04-12', '0901234567', NULL),
 ('BN002', N'Trần Thị Lan',     N'45 Nguyễn Trãi, Quận 5, TP.HCM', '1990-09-30', '0912345678', NULL),
 ('BN003', N'Lê Hoàng Nam',     N'78 Hai Bà Trưng, Quận 3, TP.HCM','1978-01-20', '0987654321', NULL);

INSERT INTO HoSoBenhAn(MaHoSo, MaBN, NgayCap, NgayHetHan) VALUES
 ('HS001', 'BN001', '2026-03-01', '2027-03-01'),
 ('HS002', 'BN002', '2026-05-15', '2027-05-15'),
 ('HS003', 'BN003', '2025-06-01', '2026-06-01');      -- đã hết hạn lệ phí

INSERT INTO PhieuDangKy(MaBN, MaHoSo, NgayDangKy, LePhi, TuNgay, DenNgay, LoaiDK) VALUES
 ('BN001', 'HS001', '2026-03-01', 500000, '2026-03-01', '2027-03-01', 'MOI'),
 ('BN002', 'HS002', '2026-05-15', 500000, '2026-05-15', '2027-05-15', 'MOI'),
 ('BN003', 'HS003', '2025-06-01', 500000, '2025-06-01', '2026-06-01', 'MOI');

INSERT INTO PhieuKham(MaPK, MaHoSo, NgayGioKham, MaBS, MaKhoa, LoaiKham, TrieuChung, NhietDo, HuyetAp, KetLuan, VienPhi, DaThanhToan) VALUES
 ('PK001', 'HS001', '2026-04-10 09:30', 'BS01', 'K01', 'DIEUTRI', N'Nhức đầu, sốt nhẹ, ho',           38.2, '120/80', N'Cảm cúm',               250000, 1),
 ('PK002', 'HS001', '2026-07-05 08:00', 'BS01', 'K01', 'DINHKY',  N'Khám sức khỏe định kỳ, không có bệnh', 36.8, '118/76', N'Sức khỏe bình thường',       0, 1),
 ('PK003', 'HS002', '2026-08-20 14:15', 'BS02', 'K04', 'DIEUTRI', N'Tức ngực, hồi hộp, chóng mặt',     37.0, '150/95', N'Tăng huyết áp độ 1',    480000, 1),
 ('PK004', 'HS003', '2025-12-10 10:00', 'BS03', 'K02', 'DIEUTRI', N'Đau lưng sau khi mang vác nặng',    36.9, '125/80', N'Đau cơ lưng',           300000, 1);

INSERT INTO PhieuKham_XetNghiem(MaPK, MaXN, KetQua) VALUES
 ('PK001', 'XN01', N'Bạch cầu tăng nhẹ'),
 ('PK003', 'XN04', N'Nhịp xoang nhanh'),
 ('PK003', 'XN02', N'Bình thường');

INSERT INTO ToaThuoc(MaToa, MaPK, NgayLap, GhiChu) VALUES
 ('TO001', 'PK001', '2026-04-10 10:15', N'Tái khám sau 5 ngày nếu còn sốt'),
 ('TO002', 'PK003', '2026-08-20 15:00', N'Theo dõi huyết áp tại nhà mỗi ngày');

INSERT INTO ChiTietToa(MaToa, MaThuoc, SoLuong, LieuDung, PhanUngPhu) VALUES
 ('TO001', 'T01', 10, N'Uống 1 viên khi sốt trên 38,5 độ, cách nhau 6 giờ', NULL),
 ('TO001', 'T05', 10, N'Uống 1 viên mỗi sáng sau ăn', NULL),
 ('TO002', 'T03', 30, N'Uống 1 viên mỗi sáng', N'Phù nhẹ mắt cá chân'),
 ('TO002', 'T04', 14, N'Uống 1 viên trước ăn sáng 30 phút', NULL);

INSERT INTO LichHen(MaHoSo, NgayGioHen, TrangThai, GhiChu) VALUES
 ('HS001', '2026-07-05 08:00', 'DAKHAM', N'Khám định kỳ quý 3'),
 ('HS002', '2026-12-10 09:00', 'DAHEN',  N'Khám định kỳ quý 4'),
 ('HS002', '2026-09-15 10:00', 'HUY',    N'Bệnh nhân báo bận');
GO
PRINT N'Đã tạo CSDL QuanLyBenhAn và dữ liệu mẫu.';
GO
