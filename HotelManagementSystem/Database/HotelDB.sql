
CREATE DATABASE HotelDB;
GO
USE HotelDB;
GO

CREATE TABLE Phong (
    SoPhong VARCHAR(10) PRIMARY KEY,
    LoaiPhong NVARCHAR(50),
    GiaTheoGio DECIMAL(18,2),
    TrangThai NVARCHAR(30) -- 'Trống', 'Đang ở', 'Đang dọn dẹp'
);

CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    CCCD VARCHAR(20) UNIQUE NOT NULL,
    SoDienThoai VARCHAR(15)
);

CREATE TABLE DichVu (
    MaDV INT PRIMARY KEY IDENTITY(1,1),
    TenDV NVARCHAR(100),
    DonGia DECIMAL(18,2)
);

CREATE TABLE PhieuDatPhong (
    MaPhieu INT PRIMARY KEY IDENTITY(1,1),
    SoPhong VARCHAR(10) FOREIGN KEY REFERENCES Phong(SoPhong),
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    NgayNhanPhong DATETIME,
    NgayTraPhong DATETIME,
    TongTienThanhToan DECIMAL(18,2)
);

CREATE TABLE SuDungDichVu (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuDatPhong(MaPhieu),
    MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV),
    SoLuong INT,
    ThoiGian DATETIME,
    PRIMARY KEY (MaPhieu, MaDV, ThoiGian)
);

-- Insert dummy data
INSERT INTO Phong VALUES ('P101', N'Đơn', 50000, N'Trống');
INSERT INTO Phong VALUES ('P102', N'Đôi', 80000, N'Trống');
INSERT INTO Phong VALUES ('P201', N'VIP', 150000, N'Trống');

INSERT INTO DichVu (TenDV, DonGia) VALUES (N'Nước suối', 15000);
INSERT INTO DichVu (TenDV, DonGia) VALUES (N'Giặt là', 50000);
INSERT INTO DichVu (TenDV, DonGia) VALUES (N'Mì tôm trứng', 35000);
