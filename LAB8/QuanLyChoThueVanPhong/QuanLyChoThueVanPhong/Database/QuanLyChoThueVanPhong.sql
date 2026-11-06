/* Lab 8 - Quản lý cho thuê văn phòng - QuanLyChoThueVanPhong */
IF DB_ID(N'QuanLyChoThueVanPhong') IS NULL CREATE DATABASE QuanLyChoThueVanPhong;
GO
USE QuanLyChoThueVanPhong;
GO
IF OBJECT_ID('PhieuThu','U')            IS NOT NULL DROP TABLE PhieuThu;
IF OBJECT_ID('QuyetDinhXuPhat','U')     IS NOT NULL DROP TABLE QuyetDinhXuPhat;
IF OBJECT_ID('KeHoachTuSua','U')        IS NOT NULL DROP TABLE KeHoachTuSua;
IF OBJECT_ID('BienBanKiemTra','U')      IS NOT NULL DROP TABLE BienBanKiemTra;
IF OBJECT_ID('TheGiuXe','U')            IS NOT NULL DROP TABLE TheGiuXe;
IF OBJECT_ID('Xe','U')                  IS NOT NULL DROP TABLE Xe;
IF OBJECT_ID('NhanVienCongTy','U')      IS NOT NULL DROP TABLE NhanVienCongTy;
IF OBJECT_ID('ChiTietHoaDonDichVu','U') IS NOT NULL DROP TABLE ChiTietHoaDonDichVu;
IF OBJECT_ID('HoaDonDichVu','U')        IS NOT NULL DROP TABLE HoaDonDichVu;
IF OBJECT_ID('SuDungDichVu','U')        IS NOT NULL DROP TABLE SuDungDichVu;
IF OBJECT_ID('DichVu','U')              IS NOT NULL DROP TABLE DichVu;
IF OBJECT_ID('KhoanThuTienThue','U')    IS NOT NULL DROP TABLE KhoanThuTienThue;
IF OBJECT_ID('ChiTietGiaHan','U')       IS NOT NULL DROP TABLE ChiTietGiaHan;
IF OBJECT_ID('PhieuGiaHan','U')         IS NOT NULL DROP TABLE PhieuGiaHan;
IF OBJECT_ID('ChiTietHopDong','U')      IS NOT NULL DROP TABLE ChiTietHopDong;
IF OBJECT_ID('HopDongThue','U')         IS NOT NULL DROP TABLE HopDongThue;
IF OBJECT_ID('KhachHang','U')           IS NOT NULL DROP TABLE KhachHang;
IF OBJECT_ID('BangGiaThue','U')         IS NOT NULL DROP TABLE BangGiaThue;
IF OBJECT_ID('Phong','U')               IS NOT NULL DROP TABLE Phong;
IF OBJECT_ID('Tang','U')                IS NOT NULL DROP TABLE Tang;
GO

CREATE TABLE Tang(
    MaTang varchar(10)  NOT NULL PRIMARY KEY,
    SoTang int          NOT NULL UNIQUE,
    DoCao  decimal(8,2) NOT NULL CHECK (DoCao > 0)
);

CREATE TABLE Phong(
    MaPhong   varchar(10)   NOT NULL PRIMARY KEY,
    MaTang    varchar(10)   NOT NULL,
    Huong     nvarchar(30)  NOT NULL,
    DienTich  decimal(10,2) NOT NULL CHECK (DienTich > 0),
    TinhTrang varchar(20)   NOT NULL DEFAULT 'TRONG',
    CONSTRAINT CK_Phong_TinhTrang CHECK (TinhTrang IN ('TRONG','DA_THUE','TU_SUA')),
    CONSTRAINT FK_Phong_Tang FOREIGN KEY (MaTang) REFERENCES Tang(MaTang)
);

CREATE TABLE BangGiaThue(
    MaGia       varchar(20)   NOT NULL PRIMARY KEY,
    MaPhong     varchar(10)   NOT NULL,
    NgayHieuLuc date          NOT NULL,
    DonGiaThang decimal(18,2) NOT NULL CHECK (DonGiaThang >= 0),
    CONSTRAINT UQ_Gia_Phong_Ngay UNIQUE (MaPhong, NgayHieuLuc),
    CONSTRAINT FK_Gia_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
);

CREATE TABLE KhachHang(
    MaKH         varchar(10)   NOT NULL PRIMARY KEY,
    TenCongTy    nvarchar(150) NOT NULL,
    MaSoThue     varchar(20)   NULL,
    DiaChi       nvarchar(200) NOT NULL,
    DienThoai    varchar(20)   NOT NULL,
    NguoiDaiDien nvarchar(100) NOT NULL
);

CREATE TABLE HopDongThue(
    SoHD         varchar(20)   NOT NULL PRIMARY KEY,
    MaKH         varchar(10)   NOT NULL,
    NgayKy       date          NOT NULL,
    NgayBatDau   date          NOT NULL,
    SoThangThue  int           NOT NULL,
    DieuKhoan    nvarchar(max) NULL,
    TrangThai    varchar(20)   NOT NULL DEFAULT 'HIEU_LUC',
    CONSTRAINT CK_HD_SoThang CHECK (SoThangThue >= 6),
    CONSTRAINT CK_HD_Ngay    CHECK (NgayBatDau >= NgayKy),
    CONSTRAINT CK_HD_TrangThai CHECK (TrangThai IN
        ('HIEU_LUC','DA_KET_THUC','HUY')),
    CONSTRAINT FK_HD_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE ChiTietHopDong(
    MaCT                varchar(20)   NOT NULL PRIMARY KEY,
    SoHD                varchar(20)   NOT NULL,
    MaPhong             varchar(10)   NOT NULL,
    MaGia               varchar(20)   NOT NULL,
    DonGiaThang         decimal(18,2) NOT NULL CHECK (DonGiaThang >= 0),
    NgayKetThucGoc      date          NOT NULL,
    NgayKetThucHienTai  date          NOT NULL,
    CONSTRAINT UQ_CTHD_HD_Phong UNIQUE (SoHD, MaPhong),
    CONSTRAINT CK_CTHD_Ngay CHECK (NgayKetThucHienTai >= NgayKetThucGoc),
    CONSTRAINT FK_CTHD_HD    FOREIGN KEY (SoHD)    REFERENCES HopDongThue(SoHD),
    CONSTRAINT FK_CTHD_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT FK_CTHD_Gia   FOREIGN KEY (MaGia)   REFERENCES BangGiaThue(MaGia)
);

CREATE TABLE PhieuGiaHan(
    SoPGH     varchar(20)   NOT NULL PRIMARY KEY,
    SoHD      varchar(20)   NOT NULL,
    NgayLap   date          NOT NULL,
    NguoiLap  nvarchar(100) NOT NULL,
    CONSTRAINT FK_PGH_HD FOREIGN KEY (SoHD) REFERENCES HopDongThue(SoHD)
);

CREATE TABLE ChiTietGiaHan(
    SoPGH          varchar(20) NOT NULL,
    MaCT           varchar(20) NOT NULL,
    SoThangGiaHan  int         NOT NULL CHECK (SoThangGiaHan > 0),
    NgayBatDauGH   date        NOT NULL,
    NgayKetThucGH  date        NOT NULL,
    CONSTRAINT PK_CTGH PRIMARY KEY (SoPGH, MaCT),
    CONSTRAINT CK_CTGH_Ngay CHECK (NgayKetThucGH > NgayBatDauGH),
    CONSTRAINT FK_CTGH_PGH FOREIGN KEY (SoPGH) REFERENCES PhieuGiaHan(SoPGH),
    CONSTRAINT FK_CTGH_CT  FOREIGN KEY (MaCT)  REFERENCES ChiTietHopDong(MaCT)
);

CREATE TABLE KhoanThuTienThue(
    MaKhoanThu   varchar(20)   NOT NULL PRIMARY KEY,
    MaCT         varchar(20)   NOT NULL,
    LoaiKy       varchar(10)   NOT NULL,
    KySo         int           NOT NULL CHECK (KySo > 0),
    TuNgay       date          NOT NULL,
    DenNgay      date          NOT NULL,
    HanThanhToan date          NOT NULL,
    SoTien       decimal(18,2) NOT NULL CHECK (SoTien >= 0),
    CONSTRAINT UQ_KhoanThu UNIQUE (MaCT, LoaiKy, KySo),
    CONSTRAINT CK_KhoanThu_Loai CHECK (LoaiKy IN ('TRA_TRUOC','THANG')),
    CONSTRAINT CK_KhoanThu_Ngay CHECK (DenNgay >= TuNgay),
    CONSTRAINT FK_KhoanThu_CT FOREIGN KEY (MaCT) REFERENCES ChiTietHopDong(MaCT)
);

CREATE TABLE DichVu(
    MaDV      varchar(10)   NOT NULL PRIMARY KEY,
    TenDV     nvarchar(100) NOT NULL UNIQUE,
    DonViTinh nvarchar(30)  NOT NULL,
    DonGia    decimal(18,2) NOT NULL CHECK (DonGia >= 0)
);

CREATE TABLE SuDungDichVu(
    MaSD     varchar(20)   NOT NULL PRIMARY KEY,
    MaCT     varchar(20)   NOT NULL,
    MaDV     varchar(10)   NOT NULL,
    KyThang  date          NOT NULL,
    SoLuong  decimal(18,3) NOT NULL CHECK (SoLuong >= 0),
    DonGia   decimal(18,2) NOT NULL CHECK (DonGia >= 0),
    DaChot   bit           NOT NULL DEFAULT 0,
    CONSTRAINT UQ_SDDV UNIQUE (MaCT, MaDV, KyThang),
    CONSTRAINT FK_SDDV_CT FOREIGN KEY (MaCT) REFERENCES ChiTietHopDong(MaCT),
    CONSTRAINT FK_SDDV_DV FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);

CREATE TABLE HoaDonDichVu(
    MaHDDV       varchar(20)   NOT NULL PRIMARY KEY,
    MaCT         varchar(20)   NOT NULL,
    KyThang      date          NOT NULL,
    NgayLap      date          NOT NULL,
    HanThanhToan date          NOT NULL,
    TongTien     decimal(18,2) NOT NULL DEFAULT 0 CHECK (TongTien >= 0),
    CONSTRAINT UQ_HDDV_CT_Ky UNIQUE (MaCT, KyThang),
    CONSTRAINT FK_HDDV_CT FOREIGN KEY (MaCT) REFERENCES ChiTietHopDong(MaCT)
);

CREATE TABLE ChiTietHoaDonDichVu(
    MaHDDV    varchar(20)   NOT NULL,
    MaSD      varchar(20)   NOT NULL,
    ThanhTien decimal(18,2) NOT NULL CHECK (ThanhTien >= 0),
    CONSTRAINT PK_CTHDDV PRIMARY KEY (MaHDDV, MaSD),
    CONSTRAINT UQ_CTHDDV_SD UNIQUE (MaSD),
    CONSTRAINT FK_CTHDDV_HD FOREIGN KEY (MaHDDV) REFERENCES HoaDonDichVu(MaHDDV),
    CONSTRAINT FK_CTHDDV_SD FOREIGN KEY (MaSD)   REFERENCES SuDungDichVu(MaSD)
);

CREATE TABLE NhanVienCongTy(
    MaNV      varchar(20)   NOT NULL PRIMARY KEY,
    MaKH      varchar(10)   NOT NULL,
    MaPhong   varchar(10)   NOT NULL,
    HoTen     nvarchar(100) NOT NULL,
    HinhAnh   nvarchar(300) NULL,
    ChucVu    nvarchar(100) NOT NULL,
    TrangThai varchar(15)   NOT NULL DEFAULT 'DANG_LAM',
    NgayNghi  date          NULL,
    CONSTRAINT CK_NVCT_TrangThai CHECK (TrangThai IN ('DANG_LAM','NGHI')),
    CONSTRAINT CK_NVCT_NgayNghi CHECK (
        (TrangThai = 'NGHI' AND NgayNghi IS NOT NULL) OR
        (TrangThai = 'DANG_LAM' AND NgayNghi IS NULL)),
    CONSTRAINT FK_NVCT_KH    FOREIGN KEY (MaKH)    REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_NVCT_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
);

CREATE TABLE Xe(
    MaXe     varchar(20)  NOT NULL PRIMARY KEY,
    MaNV     varchar(20)  NOT NULL,
    BienSo   varchar(20)  NOT NULL UNIQUE,
    LoaiXe   nvarchar(30) NOT NULL,
    NhanHieu nvarchar(50) NULL,
    MauXe    nvarchar(30) NULL,
    CONSTRAINT FK_Xe_NV FOREIGN KEY (MaNV) REFERENCES NhanVienCongTy(MaNV)
);

CREATE TABLE TheGiuXe(
    MaThe       varchar(20) NOT NULL PRIMARY KEY,
    MaXe        varchar(20) NOT NULL,
    NgayCap     date        NOT NULL,
    TrangThai   varchar(15) NOT NULL DEFAULT 'HIEU_LUC',
    NgayThuHoi  date        NULL,
    CONSTRAINT CK_The_TrangThai CHECK (TrangThai IN ('HIEU_LUC','THU_HOI')),
    CONSTRAINT CK_The_ThuHoi CHECK (
        (TrangThai = 'THU_HOI' AND NgayThuHoi IS NOT NULL) OR
        (TrangThai = 'HIEU_LUC' AND NgayThuHoi IS NULL)),
    CONSTRAINT FK_The_Xe FOREIGN KEY (MaXe) REFERENCES Xe(MaXe)
);
GO
-- mỗi xe chỉ có một thẻ giữ xe còn hiệu lực
CREATE UNIQUE INDEX UQ_The_HieuLuc ON TheGiuXe(MaXe) WHERE TrangThai = 'HIEU_LUC';
GO

CREATE TABLE BienBanKiemTra(
    SoBB          varchar(20)   NOT NULL PRIMARY KEY,
    MaPhong       varchar(10)   NOT NULL,
    NgayKiemTra   date          NOT NULL,
    NguoiKiemTra  nvarchar(100) NOT NULL,
    HienTrang     nvarchar(500) NOT NULL,
    TuYSuaKetCau  bit           NOT NULL DEFAULT 0,
    MinhChung     nvarchar(300) NULL,
    KetLuan       nvarchar(500) NOT NULL,
    CONSTRAINT UQ_BB_Phong_Ngay UNIQUE (MaPhong, NgayKiemTra),
    CONSTRAINT FK_BB_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
);

CREATE TABLE KeHoachTuSua(
    MaKeHoach     varchar(20)   NOT NULL PRIMARY KEY,
    SoBB          varchar(20)   NOT NULL,
    NoiDung       nvarchar(500) NOT NULL,
    NgayBatDau    date          NOT NULL,
    NgayKetThuc   date          NOT NULL,
    ChiPhiDuKien  decimal(18,2) NOT NULL CHECK (ChiPhiDuKien >= 0),
    TrangThai     varchar(15)   NOT NULL DEFAULT 'KE_HOACH',
    CONSTRAINT CK_KH_Ngay CHECK (NgayKetThuc >= NgayBatDau),
    CONSTRAINT CK_KH_TrangThai CHECK (TrangThai IN
        ('KE_HOACH','DANG_LAM','HOAN_TAT')),
    CONSTRAINT FK_KH_BB FOREIGN KEY (SoBB) REFERENCES BienBanKiemTra(SoBB)
);

CREATE TABLE QuyetDinhXuPhat(
    SoQD            varchar(20)   NOT NULL PRIMARY KEY,
    SoBB            varchar(20)   NOT NULL,
    MaCT            varchar(20)   NOT NULL,
    NgayLap         date          NOT NULL,
    QuyDinhApDung   nvarchar(300) NOT NULL,
    LyDo            nvarchar(500) NOT NULL,
    SoTienPhat      decimal(18,2) NOT NULL CHECK (SoTienPhat >= 0),
    CONSTRAINT FK_QD_BB FOREIGN KEY (SoBB) REFERENCES BienBanKiemTra(SoBB),
    CONSTRAINT FK_QD_CT FOREIGN KEY (MaCT) REFERENCES ChiTietHopDong(MaCT)
);

CREATE TABLE PhieuThu(
    SoPT        varchar(20)   NOT NULL PRIMARY KEY,
    NgayThu     datetime2     NOT NULL DEFAULT SYSDATETIME(),
    LoaiThu     varchar(10)   NOT NULL,
    MaKhoanThu  varchar(20)   NULL,
    MaHDDV      varchar(20)   NULL,
    SoQD        varchar(20)   NULL,
    SoTien      decimal(18,2) NOT NULL CHECK (SoTien > 0),
    HinhThuc    nvarchar(30)  NOT NULL,
    CONSTRAINT CK_PT_Loai CHECK (LoaiThu IN ('TIEN_THUE','DICH_VU','PHAT')),
    CONSTRAINT CK_PT_ChungTu CHECK (
        (LoaiThu = 'TIEN_THUE' AND MaKhoanThu IS NOT NULL
             AND MaHDDV IS NULL AND SoQD IS NULL) OR
        (LoaiThu = 'DICH_VU'   AND MaHDDV IS NOT NULL
             AND MaKhoanThu IS NULL AND SoQD IS NULL) OR
        (LoaiThu = 'PHAT'      AND SoQD IS NOT NULL
             AND MaKhoanThu IS NULL AND MaHDDV IS NULL)),
    CONSTRAINT FK_PT_KhoanThu FOREIGN KEY (MaKhoanThu)
        REFERENCES KhoanThuTienThue(MaKhoanThu),
    CONSTRAINT FK_PT_HDDV FOREIGN KEY (MaHDDV) REFERENCES HoaDonDichVu(MaHDDV),
    CONSTRAINT FK_PT_QD   FOREIGN KEY (SoQD)   REFERENCES QuyetDinhXuPhat(SoQD)
);
GO
CREATE INDEX IX_KhoanThu_Han ON KhoanThuTienThue(HanThanhToan, MaCT);
CREATE INDEX IX_HDDV_Ky      ON HoaDonDichVu(KyThang, MaCT);
CREATE INDEX IX_NVCT_Phong   ON NhanVienCongTy(MaPhong, TrangThai);
GO
/* ---------------- Dữ liệu mẫu ---------------- */
INSERT INTO Tang(MaTang, SoTang, DoCao) VALUES
 ('T01', 1, 3.60),
 ('T02', 2, 3.40),
 ('T03', 3, 3.40);

INSERT INTO Phong(MaPhong, MaTang, Huong, DienTich, TinhTrang) VALUES
 ('P101', 'T01', N'Đông Nam', 120.00, 'DA_THUE'),
 ('P102', 'T01', N'Tây Bắc',  100.00, 'DA_THUE'),
 ('P201', 'T02', N'Đông',      95.00, 'TRONG'),
 ('P202', 'T02', N'Nam',      110.00, 'TRONG'),
 ('P301', 'T03', N'Bắc',      130.00, 'TRONG');

INSERT INTO BangGiaThue(MaGia, MaPhong, NgayHieuLuc, DonGiaThang) VALUES
 ('G101', 'P101', '2026-01-01', 20000000),
 ('G102', 'P102', '2026-01-01', 18000000),
 ('G201', 'P201', '2026-01-01', 17000000),
 ('G202', 'P202', '2026-01-01', 19000000),
 ('G301', 'P301', '2026-01-01', 21000000);

INSERT INTO KhachHang(MaKH, TenCongTy, MaSoThue, DiaChi, DienThoai, NguoiDaiDien) VALUES
 ('KH01', N'Công ty TNHH An Phát',    '0312345678', N'Quận 1, TP.HCM',  '02838001122', N'Huỳnh Gia Bảo'),
 ('KH02', N'Công ty CP Minh Long',    '0398765432', N'Quận 3, TP.HCM',  '02838003344', N'Nguyễn Thị Lan'),
 ('KH03', N'Công ty TNHH Sao Việt',   NULL,         N'Quận 7, TP.HCM',  '02838005566', N'Trần Minh Quang');

INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES
 ('DV01', N'Điện',     N'kWh',   3500),
 ('DV02', N'Nước',     N'm3',   15000),
 ('DV03', N'Internet', N'Tháng', 500000),
 ('DV04', N'Vệ sinh',  N'Tháng', 300000);

INSERT INTO HopDongThue(SoHD, MaKH, NgayKy, NgayBatDau, SoThangThue, DieuKhoan, TrangThai) VALUES
 ('HD001', 'KH01', '2026-01-05', '2026-02-01', 12,
  N'Trả trước sáu tháng đầu, từ tháng thứ bảy trả vào đầu mỗi tháng. Không tự ý thay đổi kết cấu văn phòng.',
  'HIEU_LUC');

INSERT INTO ChiTietHopDong(MaCT, SoHD, MaPhong, MaGia, DonGiaThang,
                           NgayKetThucGoc, NgayKetThucHienTai) VALUES
 ('CT001', 'HD001', 'P101', 'G101', 20000000, '2027-01-31', '2027-01-31'),
 ('CT002', 'HD001', 'P102', 'G102', 18000000, '2027-01-31', '2027-01-31');

INSERT INTO KhoanThuTienThue(MaKhoanThu, MaCT, LoaiKy, KySo, TuNgay, DenNgay,
                             HanThanhToan, SoTien) VALUES
('CT00100', 'KT001', 'TRA_TRUOC', 1, '2026-02-01', '2026-07-31', '2026-02-01', 120000000),
 ('CT00107', 'KT001', 'THANG', 7, '2026-08-01', '2026-08-31', '2026-08-01', 20000000),
 ('CT00108', 'KT001', 'THANG', 8, '2026-09-01', '2026-09-30', '2026-09-01', 20000000),
 ('CT00109', 'KT001', 'THANG', 9, '2026-10-01', '2026-10-31', '2026-10-01', 20000000),
 ('CT00110', 'KT001', 'THANG', 10, '2026-11-01', '2026-11-30', '2026-11-01', 20000000),
 ('CT00111', 'KT001', 'THANG', 11, '2026-12-01', '2026-12-31', '2026-12-01', 20000000),
 ('CT00112', 'KT001', 'THANG', 12, '2027-01-01', '2027-01-31', '2027-01-01', 20000000),
 ('CT00200', 'KT002', 'TRA_TRUOC', 1, '2026-02-01', '2026-07-31', '2026-02-01', 108000000),
 ('CT00207', 'KT002', 'THANG', 7, '2026-08-01', '2026-08-31', '2026-08-01', 18000000),
 ('CT00208', 'KT002', 'THANG', 8, '2026-09-01', '2026-09-30', '2026-09-01', 18000000),
 ('CT00209', 'KT002', 'THANG', 9, '2026-10-01', '2026-10-31', '2026-10-01', 18000000),
 ('CT00210', 'KT002', 'THANG', 10, '2026-11-01', '2026-11-30', '2026-11-01', 18000000),
 ('CT00211', 'KT002', 'THANG', 11, '2026-12-01', '2026-12-31', '2026-12-01', 18000000),
 ('CT00212', 'KT002', 'THANG', 12, '2027-01-01', '2027-01-31', '2027-01-01', 18000000);

INSERT INTO SuDungDichVu(MaSD, MaCT, MaDV, KyThang, SoLuong, DonGia, DaChot) VALUES
 ('SD001', 'CT001', 'DV01', '2026-02-01', 1200.000, 3500, 1),
 ('SD002', 'CT001', 'DV02', '2026-02-01',   30.000, 15000, 1),
 ('SD003', 'CT001', 'DV03', '2026-02-01',    1.000, 500000, 1),
 ('SD004', 'CT002', 'DV01', '2026-02-01',  800.000, 3500, 0),
 ('SD005', 'CT002', 'DV02', '2026-02-01',   22.000, 15000, 0);

INSERT INTO HoaDonDichVu(MaHDDV, MaCT, KyThang, NgayLap, HanThanhToan, TongTien) VALUES
 ('HDDV001', 'CT001', '2026-02-01', '2026-02-28', '2026-03-07', 5150000);

INSERT INTO ChiTietHoaDonDichVu(MaHDDV, MaSD, ThanhTien) VALUES
 ('HDDV001', 'SD001', 4200000),
 ('HDDV001', 'SD002',  450000),
 ('HDDV001', 'SD003',  500000);

INSERT INTO NhanVienCongTy(MaNV, MaKH, MaPhong, HoTen, HinhAnh, ChucVu, TrangThai) VALUES
 ('NV001', 'KH01', 'P101', N'Trần Văn Long', N'images/nv001.jpg', N'Trưởng phòng', 'DANG_LAM'),
 ('NV002', 'KH01', 'P101', N'Lê Thị Hoa',    NULL,                N'Nhân viên',    'DANG_LAM'),
 ('NV003', 'KH01', 'P102', N'Phạm Văn Sơn',  NULL,                N'Kế toán',      'DANG_LAM');

INSERT INTO Xe(MaXe, MaNV, BienSo, LoaiXe, NhanHieu, MauXe) VALUES
 ('X001', 'NV001', '51F-123.45', N'Xe máy', N'Honda',  N'Đen'),
 ('X002', 'NV002', '51A-678.90', N'Xe hơi', N'Toyota', N'Trắng'),
 ('X003', 'NV003', '59H-246.80', N'Xe máy', N'Yamaha', N'Xanh');

INSERT INTO TheGiuXe(MaThe, MaXe, NgayCap, TrangThai, NgayThuHoi) VALUES
 ('THE001', 'X001', '2026-02-02', 'HIEU_LUC', NULL),
 ('THE002', 'X002', '2026-02-02', 'HIEU_LUC', NULL);

INSERT INTO BienBanKiemTra(SoBB, MaPhong, NgayKiemTra, NguoiKiemTra, HienTrang,
                           TuYSuaKetCau, MinhChung, KetLuan) VALUES
 ('BB001', 'P201', '2026-06-15', N'Nguyễn Văn Tâm', N'Tường và sàn bình thường, trần bị thấm nhẹ',
  0, NULL, N'Đề nghị lập kế hoạch tu sửa trần phòng P201'),
 ('BB002', 'P101', '2026-06-15', N'Nguyễn Văn Tâm', N'Khách tự ngăn thêm vách thạch cao giữa phòng',
  1, N'images/bb002.jpg', N'Khách tự ý thay đổi kết cấu văn phòng, lập quyết định xử phạt');

INSERT INTO KeHoachTuSua(MaKeHoach, SoBB, NoiDung, NgayBatDau, NgayKetThuc,
                         ChiPhiDuKien, TrangThai) VALUES
 ('KH001', 'BB001', N'Chống thấm và sơn lại trần phòng P201', '2026-07-01', '2026-07-10',
  12000000, 'KE_HOACH');

INSERT INTO QuyetDinhXuPhat(SoQD, SoBB, MaCT, NgayLap, QuyDinhApDung, LyDo, SoTienPhat) VALUES
 ('QD001', 'BB002', 'CT001', '2026-06-16',
  N'Quy định của cao ốc về thay đổi kết cấu văn phòng',
  N'Tự ý ngăn thêm vách thạch cao không xin phép', 5000000);

INSERT INTO PhieuThu(SoPT, NgayThu, LoaiThu, MaKhoanThu, MaHDDV, SoQD, SoTien, HinhThuc) VALUES
 ('PT001', '2026-02-01T09:00:00', 'TIEN_THUE', 'KT00100', NULL, NULL, 120000000, N'Chuyển khoản'),
 ('PT002', '2026-02-01T09:05:00', 'TIEN_THUE', 'KT00200', NULL, NULL, 108000000, N'Chuyển khoản'),
 ('PT003', '2026-03-05T10:00:00', 'DICH_VU',   NULL, 'HDDV001', NULL,   5150000, N'Tiền mặt'),
 ('PT004', '2026-06-20T14:00:00', 'PHAT',      NULL, NULL, 'QD001',     5000000, N'Tiền mặt');
GO
