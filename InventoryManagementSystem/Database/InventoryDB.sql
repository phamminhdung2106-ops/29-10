
CREATE DATABASE InventoryDB;
GO
USE InventoryDB;
GO

CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY IDENTITY(1,1),
    TenNCC NVARCHAR(150) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(255)
);

CREATE TABLE VatTu (
    MaVatTu VARCHAR(20) PRIMARY KEY,
    TenVatTu NVARCHAR(150) NOT NULL,
    DVT NVARCHAR(20),
    SoLuongTon DECIMAL(18,2) CHECK (SoLuongTon >= 0)
);

CREATE TABLE PhieuKho (
    MaPhieu INT PRIMARY KEY IDENTITY(1,1),
    LoaiPhieu NVARCHAR(10) NOT NULL, -- 'NHAP' hoặc 'XUAT'
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNCC INT FOREIGN KEY REFERENCES NhaCungCap(MaNCC) NULL,
    TongTien DECIMAL(18,2)
);

CREATE TABLE ChiTietPhieuKho (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuKho(MaPhieu),
    MaVatTu VARCHAR(20) FOREIGN KEY REFERENCES VatTu(MaVatTu),
    SoLuong DECIMAL(18,2) CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2),
    PRIMARY KEY (MaPhieu, MaVatTu)
);

-- Insert dummy data
INSERT INTO NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES (N'Công ty TNHH Nhựa ABC', '0901234567', N'Hà Nội');
INSERT INTO NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES (N'Đại lý Sắt Thép XYZ', '0987654321', N'TP.HCM');

INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES ('VT001', N'Ống nhựa PVC', N'Cái', 150);
INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES ('VT002', N'Thép cuộn', N'Kg', 500);
INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES ('VT003', N'Đinh vít', N'Hộp', 10);
