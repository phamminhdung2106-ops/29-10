# BÀI TẬP 5.3 – HỆ THỐNG QUẢN LÝ QUÁN CAFE & BÁN HÀNG (POS CAFE SYSTEM)

## MỤC 1: THÔNG TIN SINH VIÊN

- **Họ và tên sinh viên:** [Điền họ tên]
- **Mã sinh viên:** [Điền MSV]
- **Tên Đề tài / Bài tập:** Bài 5.3 – Hệ thống quản lý quán Cafe & bán hàng (POS Cafe System)

## MỤC 2: HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

**Yêu cầu:** Windows, SQL Server (Express/LocalDB/Developer) + SSMS, Visual Studio có hỗ trợ **.NET 10 SDK** (project target `net10.0-windows`).

**Các bước cài đặt:**

1. Mở SQL Server Management Studio (SSMS), chạy file `Database/ScriptDB.sql` để khởi tạo CSDL **CafePOSDB** và dữ liệu mẫu.
2. Mở file `CafePOS.sln` bằng Visual Studio.
3. Mở file cấu hình `CafePOS/App.config`, sửa lại chuỗi kết nối `ConnectionString` (phần `Server=...`) cho phù hợp với máy cá nhân.
4. Build & Run dự án (F5). Visual Studio sẽ tự khôi phục (restore) các gói NuGet `Microsoft.Data.SqlClient` và `System.Configuration.ConfigurationManager`.

## MỤC 3: CẤU TRÚC THƯ MỤC (3-TIER)

```
├── Database/
│   └── ScriptDB.sql              # Tạo CSDL CafePOSDB + dữ liệu mẫu
├── CafePOS/
│   ├── DTO/                      # BanAnDTO, DanhMucDTO, MonAnDTO
│   ├── DAL/                      # DatabaseHelper, BanAnDAL, DanhMucDAL, MonAnDAL, HoaDonDAL (ADO.NET)
│   ├── BUS/                      # BanAnBUS, DanhMucBUS, MonAnBUS, HoaDonBUS (nghiệp vụ + validation)
│   ├── GUI/                      # Form1 (sơ đồ bàn), FormQuanLyThucDon
│   ├── App.config                # Chuỗi kết nối
│   └── Program.cs
├── Preview/                      # Ảnh xem trước giao diện Designer
├── README.md
└── CafePOS.sln
```

## MỤC 4: CHỨC NĂNG ĐÃ THỰC HIỆN

| Yêu cầu | Cách thực hiện |
|---|---|
| Sơ đồ bàn dạng Button động | `FlowLayoutPanel` sinh `Button` theo bảng `BanAn`; bàn **Trống = xanh**, **Có khách = đỏ**; bàn đang chọn có viền đậm |
| Nạp menu / hóa đơn tạm (mô hình ngắt kết nối) | `SqlDataAdapter` + `DataSet` (bảng `DanhMuc`, `MonAn`) cho thực đơn; `SqlDataAdapter` + `DataTable` cho các món đã gọi của bàn, hiển thị bằng `DataGridView` |
| Gọi món | Chọn Danh mục → chọn Món (lọc bằng `DataView.RowFilter`) → nhập số lượng → **Thêm món**. Tự tạo hóa đơn nếu bàn chưa có, cộng dồn số lượng nếu món đã gọi, bàn tự chuyển sang "Có khách" (trong 1 transaction) |
| Đổi bàn | Chọn một bàn trống trong danh sách → **Đổi bàn**: chuyển hóa đơn chưa thanh toán sang bàn mới, cập nhật trạng thái 2 bàn (transaction) |
| Thanh toán | **1 `SqlTransaction`**: tính tổng tiền → cập nhật `GioRa`, `TongTien`, `TrangThai = 1` cho `HoaDon` → bàn về "Trống"; lỗi ở bước nào thì `Rollback` |
| Quản lý thực đơn (3-Tier CRUD) | `FormQuanLyThucDon`: thêm/sửa/xóa **danh mục** và **món** (đổi giá bán). Validation: tên món không rỗng, đơn giá không âm, phải chọn danh mục (kiểm tra ở GUI bằng `ErrorProvider` và ở lớp BUS) |
| Chống SQL Injection | Mọi câu lệnh đều dùng `SqlParameter` |

## MỤC 5: GHI CHÚ

- Món đã có trong hóa đơn nào thì không xóa được khỏi thực đơn (ràng buộc khóa ngoại) – chương trình báo lỗi thân thiện.
- Danh mục còn món ăn thì không xóa được.
- Bàn 03 có sẵn một hóa đơn mở trong dữ liệu mẫu để thấy ngay bàn màu đỏ.
