/* =====================================================================
   BÀI TẬP 5.3 - HỆ THỐNG QUẢN LÝ QUÁN CAFE & BÁN HÀNG (POS CAFE SYSTEM)
   Script tạo CSDL CafePOSDB và chèn dữ liệu mẫu (chạy trong SSMS)
   ===================================================================== */
IF DB_ID(N'CafePOSDB') IS NULL
    CREATE DATABASE CafePOSDB;
GO

USE CafePOSDB;
GO

-- Xóa bảng cũ (nếu có) theo thứ tự khóa ngoại để chạy lại script nhiều lần
IF OBJECT_ID(N'ChiTietHoaDon', N'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID(N'HoaDon', N'U')        IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID(N'MonAn', N'U')         IS NOT NULL DROP TABLE MonAn;
IF OBJECT_ID(N'DanhMuc', N'U')       IS NOT NULL DROP TABLE DanhMuc;
IF OBJECT_ID(N'BanAn', N'U')         IS NOT NULL DROP TABLE BanAn;
GO

-- 1. Bàn ăn
CREATE TABLE BanAn (
    MaBan     INT IDENTITY(1,1) PRIMARY KEY,
    TenBan    NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL
        CONSTRAINT DF_BanAn_TrangThai DEFAULT N'Trống',
    CONSTRAINT CK_BanAn_TrangThai CHECK (TrangThai IN (N'Trống', N'Có khách'))
);

-- 2. Danh mục món
CREATE TABLE DanhMuc (
    MaDanhMuc  INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);

-- 3. Thực đơn món
CREATE TABLE MonAn (
    MaMon     INT IDENTITY(1,1) PRIMARY KEY,
    TenMon    NVARCHAR(100) NOT NULL,
    MaDanhMuc INT NOT NULL
        CONSTRAINT FK_MonAn_DanhMuc REFERENCES DanhMuc(MaDanhMuc),
    DonGia    DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_MonAn_DonGia DEFAULT 0,
    CONSTRAINT CK_MonAn_DonGia CHECK (DonGia >= 0)
);

-- 4. Hóa đơn (TrangThai: 0 = chưa thanh toán, 1 = đã thanh toán)
CREATE TABLE HoaDon (
    MaHoaDon  INT IDENTITY(1,1) PRIMARY KEY,
    MaBan     INT NOT NULL
        CONSTRAINT FK_HoaDon_BanAn REFERENCES BanAn(MaBan),
    GioVao    DATETIME NOT NULL
        CONSTRAINT DF_HoaDon_GioVao DEFAULT GETDATE(),
    GioRa     DATETIME NULL,
    TongTien  DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_HoaDon_TongTien DEFAULT 0,
    TrangThai BIT NOT NULL
        CONSTRAINT DF_HoaDon_TrangThai DEFAULT 0
);

-- 5. Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT NOT NULL
        CONSTRAINT FK_CTHD_HoaDon REFERENCES HoaDon(MaHoaDon),
    MaMon    INT NOT NULL
        CONSTRAINT FK_CTHD_MonAn REFERENCES MonAn(MaMon),
    SoLuong  INT NOT NULL,
    DonGia   DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHoaDon, MaMon),
    CONSTRAINT CK_CTHD_SoLuong CHECK (SoLuong > 0)
);
GO

/* ------------------------- DỮ LIỆU MẪU ------------------------- */
INSERT INTO BanAn (TenBan) VALUES
    (N'Bàn 01'), (N'Bàn 02'), (N'Bàn 03'), (N'Bàn 04'),
    (N'Bàn 05'), (N'Bàn 06'), (N'Bàn 07'), (N'Bàn 08'),
    (N'Bàn 09'), (N'Bàn 10'), (N'Bàn 11'), (N'Bàn 12');

INSERT INTO DanhMuc (TenDanhMuc) VALUES
    (N'Cà phê'), (N'Trà sữa'), (N'Đồ ăn nhẹ');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES
    (N'Cà phê đen',        1, 25000),
    (N'Cà phê sữa',        1, 29000),
    (N'Bạc xỉu',           1, 32000),
    (N'Cappuccino',        1, 45000),
    (N'Trà sữa trân châu', 2, 40000),
    (N'Trà sữa matcha',    2, 45000),
    (N'Hồng trà sữa',      2, 38000),
    (N'Bánh tiramisu',     3, 42000),
    (N'Bánh mì que',       3, 20000),
    (N'Khoai tây chiên',   3, 35000);
GO

-- Hóa đơn mẫu đang mở ở Bàn 03 để thấy bàn màu đỏ khi chạy chương trình
DECLARE @MaHD INT;
INSERT INTO HoaDon (MaBan, GioVao, TongTien, TrangThai)
VALUES (3, DATEADD(MINUTE, -35, GETDATE()), 0, 0);
SET @MaHD = SCOPE_IDENTITY();

INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia)
SELECT @MaHD, MaMon, 2, DonGia FROM MonAn WHERE TenMon = N'Cà phê sữa';
INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia)
SELECT @MaHD, MaMon, 1, DonGia FROM MonAn WHERE TenMon = N'Bánh tiramisu';

UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = 3;
GO

SELECT * FROM BanAn;
SELECT * FROM MonAn;
GO
