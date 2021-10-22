create database QLBanHang
go

use QLBanHang
go

-- Loại hàng: vd: Laptop, tablet, mobile
create table LoaiHang (
	MaLoai int primary key not null identity,
	TenLoai nvarchar(200) not null
)

-- Hãng hàng hóa: vd: Samsung, Apple, Xiaomi,...
create table HangHangHoa (
	MaHangHangHoa int primary key not null identity,
	TenHangHangHoa nvarchar(200) not null
)

-- Hàng hóa
create table HangHoa (
	MaHangHoa int primary key not null identity,
	TenHangHoa nvarchar(200) not null,
	HinhAnh Image,
	Gia bigint,
	MaHangHangHoa int not null,
	MaLoai int not null,
	foreign key (MaHangHangHoa) references HangHangHoa(MaHangHangHoa) on update cascade,
	foreign key (MaLoai) references LoaiHang(MaLoai) on update cascade,
)

create table TaiKhoan (
	MaTaiKhoan int not null primary key identity,
	TenTaiKhoan nvarchar(30) not null,
	MatKhau nvarchar(30) not null,
	IsAdmin bit,
	HoTen nvarchar(30) not null,
	SDT nvarchar(12) not null,
	DiaChi nvarchar(200) not null
)

create table HoaDon (
	MaHoaDon int not null primary key identity,
	NgayLapHoaDon DateTime,
	TrangThai nvarchar(30),
	MaHangHoa int not null,
	MaTaiKhoan int not null,
	foreign key (MaHangHoa) references HangHoa(MaHangHoa) on update cascade on delete cascade,
	foreign key (MaTaiKhoan) references TaiKhoan(MaTaiKhoan) on update cascade on delete cascade,
)

select * from HoaDon