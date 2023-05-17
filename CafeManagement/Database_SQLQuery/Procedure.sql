--(1) KHÁCH HÀNG
--Nếu khách hàng chưa là khách hàng thân thiết của quán, Có tổng giá trị hóa đơn từ 100k trở lên có quyền
---đăng kí trở thành khách hàng thân thiết của quán
CREATE PROC sp_ThemKhachHang (@MaKhachHang NVARCHAR(20), @TenKhachHang NVARCHAR(50),
								@SoTienPhaiTra INT)
AS
	BEGIN
		DECLARE @DiemTichLuy INT, @TongChiTieu INT;
		--Nếu chưa là khách hàng thân thiết và có hóa đơn trên 100000 
		IF(@SoTienPhaiTra >=100000 AND @MaKhachHang NOT IN (SELECT SDT FROM KHACHHANGTHANTHIET)) 
		BEGIN
			SET @DiemTichLuy = @SoTienPhaiTra/20000;
			SET @TongChiTieu = @SoTienPhaiTra;
			INSERT INTO KHACHHANGTHANTHIET(SDT, TenKhachHang, DiemTichLuy, TongChiTieu)
			VALUES (@MaKhachHang, @TenKhachHang, @DiemTichLuy, @TongChiTieu)
		END
	END
go

--- Cập nhật lại điểm tích lũy sau mỗi lần thanh toán hóa đơn
CREATE PROC sp_CapNhatDiemTichLuy(@MaKhachHang NVARCHAR(20),@TongHoaDon INT, @DungDiem bit)
AS
	DECLARE @DiemTichLuyMoi INT;
	IF (@DungDiem = 1)
	BEGIN
		SELECT @DiemTichLuyMoi = (SELECT DiemTichLuy FROM KHACHHANGTHANTHIET WHERE SDT = @MaKhachHang)
								- [dbo].giamGia(@MaKhachHang, @TongHoaDon) /1000 --- Mỗi điểm tích lũy tương ứng với 1000VND
								+ [dbo].tinhSoTienPhaiTra(@MaKhachHang, @TongHoaDon, @DungDiem)/20000; 
		UPDATE KHACHHANGTHANTHIET SET DiemTichLuy = @DiemTichLuyMoi WHERE SDT =@MaKhachHang;
	END
	ELSE
	BEGIN
		SELECT @DiemTichLuyMoi = (SELECT DiemTichLuy FROM KHACHHANGTHANTHIET WHERE SDT =  @MaKhachHang)
								+ [dbo].tinhSoTienPhaiTra(@MaKhachHang, @TongHoaDon, @DungDiem)/20000 ;-- Mỗi 20K tương ứng với 1 điểm tích lũy
		UPDATE KHACHHANGTHANTHIET SET DiemTichLuy = @DiemTichLuyMoi WHERE SDT =@MaKhachHang;
	END
go


--- Cập nhật lại Tổng chi tiêu sau mỗi lần thanh toán
CREATE PROC sp_CapNhatTongChiTieu(@MaKhachHang NVARCHAR(20), @SoTienPhaiTra INT)
AS
	BEGIN
		DECLARE @TongChiTieu INT
		SELECT @TongChiTieu = TongChiTieu FROM KHACHHANGTHANTHIET WHERE SDT = @MaKhachHang
		UPDATE KHACHHANGTHANTHIET SET TongChiTieu = @TongChiTieu+ @SoTienPhaiTra WHERE SDT = @MaKhachHang
	END
go



--- Cập nhật khách hàng
CREATE PROC sp_CapNhatKhachHang(@MaKhachHang NVARCHAR(20), @TenKhachHang NVARCHAR(50))
AS
	BEGIN
		UPDATE KHACHHANGTHANTHIET SET SDT = @MaKhachHang, TenKhachHang=@TenKhachHang WHERE SDT = @MaKhachHang
	END
go


--Tìm kiếm khách hàng
CREATE PROC	sp_TimKiemKhachHangTheoTen (@TenKhachHang NVARCHAR(50))
AS
	Begin 
		select * from dbo.KHACHHANGTHANTHIET where TenKhachHang like '%'+@TenKhachHang+'%' or LOWER(TenKhachHang) like '%'+@TenKhachHang+'%'
	end
go

CREATE PROC	sp_TimKiemKhachHangTheoMa(@MaKhachHang NVARCHAR(10))
AS
	Begin 
		select * from dbo.KHACHHANGTHANTHIET where SDT like '%'+@MaKhachHang+'%'
	end
go


--Xóa khách hàng
CREATE PROC sp_XoaKhachHang (@SDT NVARCHAR(20))
AS
	DELETE FROM KHACHHANGTHANTHIET WHERE SDT = @SDT
go



--(2) HÓA ĐƠN - CHI TIẾT HÓA ĐƠN
--- Thêm chi tiết hóa đơn
CREATE PROC sp_ThemChiTietHoaDon(@MaThucUong nvarchar(10), @SoLuong int)
AS
	BEGIN
		DECLARE @MaHoaDon INT, @NgayGio DATETIME,@DonGia INT;
		SET @NgayGio = (SELECT MAX(NgayGio) FROM HOADON);
		SET @MaHoaDon = (SELECT MAX(MaHoaDon) FROM HOADON GROUP BY NgayGio HAVING NgayGio = @NgayGio);
		SET @DonGia = (SELECT DonGia FROM THUCUONG WHERE  MaThucUong = @MaThucUong)
		
		--Transaction đảm bảo việc khi thưc hiện thanh toán các món đã gọi xong thì số lượng món còn lại được cập nhật đúng
		SET XACT_ABORT ON
		BEGIN TRAN 
			INSERT INTO CHITIETHOADON(MaHoaDon, NgayGio, MaThucUong, DonGia, SoLuong)
					VALUES (@MaHoaDon,@NgayGio , @MaThucUong, @DonGia, @SoLuong)
			UPDATE THUCUONG SET THUCUONG.SoLuong = THUCUONG.SoLuong - @SoLuong WHERE THUCUONG.MaThucUong = @MaThucUong
		COMMIT TRAN
	END
go




--- Thêm hóa đơn
CREATE PROC sp_ThemHoaDon( @MaKhachHang nvarchar(20),@MaNhanVien nvarchar(10),@TongHoaDon INT, @GiamGia INT)
AS
BEGIN
	DECLARE @MaHoaDon INT, @NgayGio DATETIME,  @MHDTemp INT;
	SET @NgayGio = GETDATE();
	INSERT INTO HOADON(MaHoaDon, NgayGio, MaKhachHang, MaNhanVien, TongHoaDon, GiamGia)
	VALUES (@MaHoaDon, @NgayGio,  @MaKhachHang, @MaNhanVien, @TongHoaDon, @GiamGia)
END
go


--(3) DANH MỤC

--Sửa thông tin danh muc (trừ mã món): tên, đơn giá, danh mục, số lượng, trạng thái (còn được bán tại quán, không còn bán tại quán) 
CREATE PROCEDURE sp_CapNhatDanhMuc (@MaDanhMuc NVARCHAR(10), @TenDanhMuc NVARCHAR(30))
AS
	BEGIN
		UPDATE DANHMUC SET TenDanhMuc = @TenDanhMuc
		WHERE MaDanhMuc = @MaDanhMuc
	END
go


--(4) NHÂN VIÊN
---Cập nhật nhân viên
CREATE PROC sp_CapNhatNhanVien(@MaNhanVien NVARCHAR(10), @TenNhanVien NVARCHAR(50),
							@MatKhau VARCHAR(30), @NgaySinh DATE, @SDT NVARCHAR(20), @Luong int, @TrangThai int)
AS
	BEGIN
		UPDATE NHANVIEN SET TenNhanVien=@TenNhanVien, MatKhau=@MatKhau,NgaySinh=@NgaySinh,
							SDT=@SDT, Luong=@Luong, TrangThai = @TrangThai
		WHERE MaNhanVien=@MaNhanVien and TrangThai = 1
	END
go

--tính số giờ làm
CREATE PROC sp_TinhSoGioLam(@ThoiGianDangNhap DATETIME, @ThoiGianDangXuat DATETIME, @MaNhanVien NVARCHAR(10))
AS
BEGIN
	DECLARE @ThoiGian TIME, @SoGioLam REAL;
	SELECT  @ThoiGian = @ThoiGianDangXuat - @ThoiGianDangNhap
	IF (DATEPART(MINUTE, @ThoiGian) >=30)
		SET @SoGioLam = (DATEPART(HOUR, @ThoiGian)+0.5)
	ELSE
		SET @SoGioLam= DATEPART(HOUR, @ThoiGian)
	UPDATE NHANVIEN SET SoGioLamViec = SoGioLamViec+ @SoGioLam WHERE MaNhanVien = @MaNhanVien
END
go


-- Xóa nhân viên
CREATE PROC sp_XoaNhanVien (@MaNhanVien NVARCHAR(10))---- Không xóa hoàn toàn mà chỉ vô hiệu hóa nhân viên đó set trạng thái  = 0 
AS
	BEGIN
		UPDATE NHANVIEN set TrangThai = 0
		WHERE MaNhanVien = @MaNhanVien
	END
go


-- Thêm nhân viên
CREATE PROC sp_ThemNhanVien( @TenNhanVien nvarchar(50), @MatKhau varchar(10), @ChucVu nvarchar(30), @NgaySinh date, @SDT nvarchar(20), @Luong int)
AS
	BEGIN
		DECLARE @Count int, @MaNhanVien NVARCHAR(10), @TrangThai int, @SoGioLam int
		SET @SoGioLam = 0
		SET @TrangThai = 1
		----------Tăng tự động Mã Nhân Viên----------------
		SET @Count = (SELECT COUNT(*) FROM NHANVIEN) + 1
		IF (@Count >=10)
			SET @MaNhanVien = 'NV' +  CAST(@Count AS nvarchar)
		ELSE 
			SET @MaNhanVien = 'NV0' +  CAST(@Count AS nvarchar)
		INSERT INTO NHANVIEN(MaNhanVien, TenNhanVien, MatKhau, ChucVu, NgaySinh, SDT,Luong, SoGioLamViec, TrangThai)
		VALUES(@MaNhanVien, @TenNhanVien, @MatKhau, @ChucVu,  @NgaySinh, @SDT, @Luong, @SoGioLam, @TrangThai)
	END
go

-- Tìm kiếm nhân viên
CREATE PROC	sp_TimKiemNVTheoTen (@TenNhanVien NVARCHAR (50))
AS
	SELECT * FROM NHANVIEN n WHERE n.TenNhanVien = @TenNhanVien

GO
CREATE PROC	sp_TimKiemNVTheoMa (@MaNhanVien NVARCHAR (50))
AS
	SELECT * FROM NHANVIEN n WHERE n.MaNhanVien = @MaNhanVien

GO

--(5) THỨC UỐNG

--Thêm món trong menu
CREATE PROCEDURE sp_ThemMon (@MaThucUong NVARCHAR(10), @TenThucUong NVARCHAR(50), @DanhMuc NVARCHAR(30),
							@DonGia INT, @SoLuong INT, @TrangThaiMon BIT)
AS
	BEGIN
		INSERT INTO THUCUONG VALUES (@MaThucUong,@TenThucUong, @DanhMuc, @DonGia,@SoLuong,@TrangThaiMon)
	END



--Sửa thông tin món (trừ mã món): tên, đơn giá, danh mục, số lượng, trạng thái (còn được bán tại quán, không còn bán tại quán) 

go

CREATE PROCEDURE sp_CapNhatMon (@MaThucUong NVARCHAR(10),@TenThucUong NVARCHAR(50),
								@DanhMuc NVARCHAR(30),@DonGia INT, @SoLuong INT, @TrangThaiMon BIT)
AS
	BEGIN
		UPDATE THUCUONG SET TenThucUong = @TenThucUong, DanhMuc = @DanhMuc, 
		DonGia = @DonGia, SoLuong = @SoLuong, TrangThaiMon = @TrangThaiMon
		WHERE MaThucUong = @MaThucUong
	END
go

--Tìm kiếm thức uống theo tên
CREATE PROC	sp_TimKiemMonTheoTen (@TenThucUong NVARCHAR(50))
AS
	Begin 
		select * from dbo.THUCUONG where TenThucUong like '%'+@TenThucUong+'%' or LOWER(TenThucUong) like '%'+@TenThucUong+'%'
	end
go


CREATE PROC	sp_TimKiemMonTheoMa(@MaThucUong NVARCHAR(10))
AS
	Begin 
		select * from dbo.THUCUONG where MaThucUong like '%'+@MaThucUong+'%' or LOWER(MaThucUong) like '%'+@MaThucUong+'%'
	end
go

-- XÓA MÓN
CREATE PROC sp_XoaMon (@MaThucUong NVARCHAR(10))
AS
	BEGIN
		DELETE FROM dbo.THUCUONG WHERE MaThucUong = @MaThucUong
	END
GO

CREATE PROC	sp_TimKiemMonTheoMa (@MaThucUong NVARCHAR (20))
AS
	SELECT * FROM THUCUONG m WHERE m.MaThucUong = @MaThucUong

go
--(6) DOANH THU
----------------STORE PROCEDURE--------------------------------------------------------------------------------------------------------
-----------------XEM DOANH THU HÔM NAY-------------------------------------------------------------------------------------------------
CREATE PROC sp_XemDoanhThuHomNay
AS
	SELECT  d.Ngay, COUNT(h.MaHoaDon) AS 'SL Đơn', TEMP.SLMon, d.DoanhThu
	FROM DOANHTHU d INNER JOIN HOADON h 
			ON d.Ngay = CONVERT(DATE,h.NgayGio) 
		INNER JOIN (SELECT SUM(SoLuong) AS SLMon, CONVERT(DATE,NgayGio) AS Ngay FROM CHITIETHOADON  GROUP BY CONVERT(DATE,NgayGio)) AS TEMP 
			ON d.Ngay = TEMP.Ngay
	WHERE d.Ngay = (SELECT CONVERT (DATE, GETDATE()))
	GROUP BY d.Ngay, d.DoanhThu, TEMP.SLMon

	SELECT SUM(SoLuong) AS SLMon, CONVERT(DATE,NgayGio) AS Ngay FROM CHITIETHOADON  GROUP BY CONVERT(DATE,NgayGio)
go
---------------------------------------------------------------------------------------------------------------------------------------
-----------------XEM DOANH THU THEO NĂM------------------------------------------------------------------------------------------------
CREATE PROC sp_XemDoanhThuTheoNam
AS
	SELECT  YEAR(d.Ngay) AS Nam,  COUNT(h.MaHoaDon) AS 'SL Đơn', TEMP.SLMon ,SUM(h.TongHoaDon)- SUM(h.GiamGia) AS DoanhThu
	FROM DOANHTHU d INNER JOIN HOADON h 
			ON d.Ngay = CONVERT(DATE,h.NgayGio) 
		INNER JOIN (SELECT SUM(SoLuong) AS SLMon, YEAR(CONVERT(DATE,NgayGio)) AS Nam FROM CHITIETHOADON  GROUP BY YEAR(CONVERT(DATE,NgayGio))) AS TEMP 
			ON YEAR(d.Ngay) = TEMP.Nam
	GROUP BY YEAR(d.Ngay), TEMP.SLMon
	ORDER BY YEAR(d.Ngay) DESC

-----------------------------------------------------------------------------------------------------------------------------------------
-----------------THỐNG KÊ NHÂN VIÊN THEO DOANH THU BẰNG NĂM-------------------------------------------------------------------------------------------------
CREATE PROC sp_ThongKeNhanVienTheoNam(@year int)
AS
	SELECT YEAR(d.Ngay) AS Nam, n.TenNhanVien, SUM(h.TongHoaDon)- SUM(h.GiamGia) AS DoanhThu
	FROM DOANHTHU d INNER JOIN HOADON h
			ON d.Ngay = CONVERT(DATE,h.NgayGio) 
		FULL JOIN NHANVIEN n
			ON h.MaNhanVien = n.MaNhanVien
	WHERE n.ChucVu = N'Nhân viên' AND YEAR(d.Ngay) = @year
	GROUP BY n.TenNhanVien, YEAR(d.Ngay)
	ORDER BY n.TenNhanVien


-----------------XEM DOANH THU THEO THÁNG------------------------------------------------------------------------------------------------
CREATE PROC sp_XemDoanhThuTheoThang
AS
	DECLARE @year int 
	SET @year = (SELECT CONVERT (INT, YEAR(GETDATE()) ))
	SELECT  MONTH(d.Ngay) AS Thang,  COUNT(h.MaHoaDon) AS 'SL Đơn', TEMP.SLMon, SUM(h.TongHoaDon)- SUM(h.GiamGia) AS DoanhThu
	FROM DOANHTHU d INNER JOIN HOADON h 
			ON d.Ngay = CONVERT(DATE,h.NgayGio) 
		INNER JOIN (SELECT SUM(SoLuong) AS SLMon, MONTH(CONVERT(DATE,NgayGio)) AS Thang FROM CHITIETHOADON  GROUP BY MONTH(CONVERT(DATE,NgayGio))) AS TEMP 
			ON MONTH(d.Ngay) = TEMP.Thang
	WHERE  YEAR(d.Ngay) = @year
	GROUP BY MONTH(d.Ngay),TEMP.SLMon
	ORDER BY MONTH(d.Ngay)

-----------------------------------------------------------------------------------------------------------------------------------------
-----------------THỐNG KÊ NHÂN VIÊN THEO DOANH THU BẰNG THÁNG-------------------------------------------------------------------------------------------------
CREATE PROC sp_ThongKeNhanVienTheoThang(@month int)
AS
	SELECT MONTH(d.Ngay) AS Thang, n.TenNhanVien, SUM(h.TongHoaDon)- SUM(h.GiamGia) AS DoanhThu
	FROM DOANHTHU d INNER JOIN HOADON h
			ON d.Ngay = CONVERT(DATE,h.NgayGio) 
		FULL JOIN NHANVIEN n
			ON h.MaNhanVien = n.MaNhanVien
	WHERE n.ChucVu = N'Nhân viên' AND MONTH(d.Ngay) = @month AND YEAR(d.Ngay) = YEAR(CONVERT(DATE, GETDATE()))
	GROUP BY n.TenNhanVien, MONTH(d.Ngay)
	ORDER BY n.TenNhanVien

-----------------------------------------------------------------------------------------------------------------------------------------
-----------------XEM DOANH THU THEO NGÀY-------------------------------------------------------------------------------------------------
CREATE PROC sp_XemDoanhThuTheoNgay
AS
	DECLARE @year int
	SET @year = (SELECT CONVERT (INT, YEAR(GETDATE()) )) 
	SELECT  d.Ngay AS Ngay,  COUNT(h.MaHoaDon) AS 'SL Đơn', TEMP.SLMon, DoanhThu
	FROM DOANHTHU d INNER JOIN HOADON h 
			ON d.Ngay = CONVERT(DATE,h.NgayGio) 
		INNER JOIN (SELECT SUM(SoLuong) AS SLMon, CONVERT(DATE,NgayGio) AS Ngay FROM CHITIETHOADON  GROUP BY CONVERT(DATE,NgayGio)) AS TEMP 
			ON d.Ngay = TEMP.Ngay
	WHERE  YEAR(d.Ngay) = @year
	GROUP BY  d.Ngay, TEMP.SLMon,  DoanhThu
	ORDER BY d.Ngay DESC

go

-----------------------------------------------------------------------------------------------------------------------------------------
-----------------XEM DOANH THU TÙY CHỌN--------------------------------------------------------------------------------------------------
CREATE PROC sp_XemDoanhThuTuyChon (@begin_date date, @end_date date)
AS
	SELECT  d.Ngay AS Ngay,  COUNT(h.MaHoaDon) AS 'SL Đơn', TEMP.SLMon, DoanhThu
	FROM DOANHTHU d INNER JOIN HOADON h 
			ON d.Ngay = CONVERT(DATE,h.NgayGio) 
		INNER JOIN (SELECT SUM(SoLuong) AS SLMon, CONVERT(DATE,NgayGio) AS Ngay FROM CHITIETHOADON  GROUP BY CONVERT(DATE,NgayGio)) AS TEMP 
			ON d.Ngay = TEMP.Ngay
	WHERE  d.Ngay BETWEEN @begin_date AND @end_date
	GROUP BY  d.Ngay, TEMP.SLMon,  DoanhThu
	ORDER BY d.Ngay ASC
go
-----------------------------------------------------------------------------------------------------------------------------------------
-----------------CREATE STORE PROCEDURE LẤY THÔNG TIN HÓA ĐƠN THEO DOANH THU-------------------------------------------------------------
CREATE PROC sp_LoadSanPhamTheoDoanhThu (@datebegin date, @dateend date)
AS 
	SELECT hd.MaThucUong, t.TenThucUong, SUM(hd.SoLuong) AS SoLuong, hd.DonGia, SUM(hd.SoLuong*hd.DonGia) AS TongTien
	FROM CHITIETHOADON hd LEFT JOIN THUCUONG t 
		ON hd.MaThucUong = t.MaThucUong
	WHERE (SELECT CONVERT (DATE, hd.NgayGio)) BETWEEN @datebegin AND @dateend
	GROUP BY hd.MaThucUong, t.TenThucUong, hd.DonGia
	ORDER BY SUM(hd.SoLuong) DESC


	
