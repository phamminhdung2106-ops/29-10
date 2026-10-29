
using InventoryManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagementSystem.DAL
{
    public class GiaoDichDAL : DBConnect
    {
        public bool LuuPhieuKho(string loaiPhieu, int? maNCC, decimal tongTien, List<ChiTietPhieuKhoDTO> chiTietList, out string errorMsg)
        {
            errorMsg = string.Empty;
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                // 1. Insert PhieuKho
                SqlCommand cmdPhieu = new SqlCommand("INSERT INTO PhieuKho (LoaiPhieu, NgayLap, MaNCC, TongTien) OUTPUT INSERTED.MaPhieu VALUES (@LoaiPhieu, @NgayLap, @MaNCC, @TongTien)", conn, trans);
                cmdPhieu.Parameters.AddWithValue("@LoaiPhieu", loaiPhieu);
                cmdPhieu.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                cmdPhieu.Parameters.AddWithValue("@MaNCC", (object)maNCC ?? DBNull.Value);
                cmdPhieu.Parameters.AddWithValue("@TongTien", tongTien);
                
                int maPhieu = (int)cmdPhieu.ExecuteScalar();

                foreach (var ct in chiTietList)
                {
                    // 2. Insert ChiTietPhieuKho
                    SqlCommand cmdCT = new SqlCommand("INSERT INTO ChiTietPhieuKho (MaPhieu, MaVatTu, SoLuong, DonGia) VALUES (@MaPhieu, @MaVatTu, @SoLuong, @DonGia)", conn, trans);
                    cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmdCT.Parameters.AddWithValue("@MaVatTu", ct.MaVatTu);
                    cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                    cmdCT.Parameters.AddWithValue("@DonGia", ct.DonGia);
                    cmdCT.ExecuteNonQuery();

                    // 3. Update Kho
                    SqlCommand cmdKho = new SqlCommand();
                    cmdKho.Connection = conn;
                    cmdKho.Transaction = trans;
                    if (loaiPhieu == "NHAP")
                    {
                        cmdKho.CommandText = "UPDATE VatTu SET SoLuongTon = SoLuongTon + @SL WHERE MaVatTu = @MaVT";
                    }
                    else // XUAT
                    {
                        cmdKho.CommandText = "UPDATE VatTu SET SoLuongTon = SoLuongTon - @SL WHERE MaVatTu = @MaVT";
                    }
                    cmdKho.Parameters.AddWithValue("@SL", ct.SoLuong);
                    cmdKho.Parameters.AddWithValue("@MaVT", ct.MaVatTu);
                    cmdKho.ExecuteNonQuery();

                    // Check ton kho sau khi cap nhat (check constraint tren CSDL cung se quang loi, nhung kiem tra code cho an toan)
                    if (loaiPhieu == "XUAT")
                    {
                        SqlCommand cmdCheck = new SqlCommand("SELECT SoLuongTon FROM VatTu WHERE MaVatTu = @MaVT", conn, trans);
                        cmdCheck.Parameters.AddWithValue("@MaVT", ct.MaVatTu);
                        decimal tonKho = Convert.ToDecimal(cmdCheck.ExecuteScalar());
                        if (tonKho < 0)
                        {
                            throw new Exception($"Vật tư {ct.TenVatTu} không đủ hàng trong kho để xuất!");
                        }
                    }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                errorMsg = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
