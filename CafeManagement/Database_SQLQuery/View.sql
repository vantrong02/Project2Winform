-- XUẤT CHITIETHOADON SAU KHI KHÁCH HÀNG NHẬN HÓA ĐƠN VÀ CHỜ LẤY NƯỚC
CREATE VIEW vi_ChiTietHoaDon AS
SELECT d.MaHoaDon, hd.MaNhanVien, MaKhachHang,hd.NgayGio, m.TenThucUong, d.DonGia, d.SoLuong,(d.DonGia * d.SoLuong) as ThanhTien
FROM CHITIETHOADON d INNER  JOIN THUCUONG m ON d.MaThucUong = m.MaThucUong
		INNER JOIN HOADON hd ON d.MaHoaDon = hd.MaHoaDon where d.NgayGio = hd.NgayGio

go
--TRÍCH XUẤT LỊCH SỬ BÁN HÀNG 
--(Mã hóa đơn, ngày giờ, thông tin nhân viên nhận order, thông tin món, giá tiền)
CREATE VIEW vi_LichSuBanHang AS
SELECT hd.MaHoaDon,hd.NgayGio, hd.MaKhachHang, kh.TenKhachHang, hd.MaNhanVien, nv.TenNhanVien, hd.TongHoaDon, hd.GiamGia
FROM HOADON hd, NHANVIEN nv, KHACHHANGTHANTHIET kh
WHERE hd.MaNhanVien = nv.MaNhanVien and hd.MaKhachHang = kh.SDT
go

-- View trả về danh sách khách hàng thân thiết
CREATE VIEW vi_GetInfoKhachHang
AS
	SELECT * FROM KHACHHANGTHANTHIET
go

CREATE VIEW vi_GetMaThucUong
AS
	SELECT MaThucUong, TenThucUong from THUCUONG
go


CREATE VIEW vi_NhanVienList
AS
	SELECT *FROM NHANVIEN
