CREATE DATABASE K22CNT3_TranDuyVu_2210900138_db;
USE K22CNT3_TranDuyVu_2210900138_db;

CREATE TABLE QUAN_TRI (
    ID INT PRIMARY KEY IDENTITY, 
    TaiKhoan VARCHAR(25) UNIQUE, 
    MatKhau VARCHAR(255), 
    TrangThai TINYINT
);

CREATE TABLE LOAI_GAME (
    ID INT PRIMARY KEY IDENTITY, 
    MaLoaiGame VARCHAR(255) UNIQUE, 
    TheLoaiGame NVARCHAR(255), 
    TrangThai TINYINT
);

CREATE TABLE GAME (
    ID INT PRIMARY KEY IDENTITY,
    MaGame VARCHAR(255) UNIQUE, 
    TenGame NVARCHAR(255), 
    HinhAnh NVARCHAR(255), 
    SoLuong INT, 
    DonGia FLOAT, 
    MaLoai INT REFERENCES LOAI_GAME(ID), 
    TrangThai TINYINT
);

CREATE TABLE KHACH_HANG (
    ID INT PRIMARY KEY IDENTITY,
    MaKhachHang VARCHAR(255) UNIQUE, 
    HoTenKhachHang NVARCHAR(255), 
    Email VARCHAR(255) UNIQUE, 
    MatKhau VARCHAR(255), 
    DienThoai VARCHAR(10) UNIQUE, 
    DiaChi NVARCHAR(255), 
    NgayDangKy DATETIME, 
    TrangThai TINYINT
);

CREATE TABLE DANH_GIA (
    ID INT PRIMARY KEY IDENTITY,
    GameID INT REFERENCES GAME(ID),
    KhachHangID INT REFERENCES KHACH_HANG(ID),
    NoiDungDanhGia VARCHAR(500),
    DanhGia TINYINT,
    NgayDanhGia DATETIME
);

CREATE TABLE HOA_DON (
    ID INT PRIMARY KEY IDENTITY, 
    MaHoaDon VARCHAR(255) UNIQUE, 
    KhachHangID INT REFERENCES KHACH_HANG(ID), 
    NgayHoaDon DATETIME, 
    NgayNhan DATETIME, 
    HoTenKhachHang NVARCHAR(255), 
    Email VARCHAR(255), 
    DienThoai VARCHAR(10), 
    DiaChi NVARCHAR(255), 
    TongTriGia FLOAT, 
    TrangThai TINYINT
);

CREATE TABLE CT_HOA_DON (
    ID INT PRIMARY KEY IDENTITY, 
    HoaDonID INT REFERENCES HOA_DON(ID), 
    GameID INT REFERENCES GAME(ID), 
    SoLuongMua INT, 
    DonGiaMua FLOAT, 
    ThanhTien FLOAT, 
    TrangThai TINYINT
);



INSERT INTO QUAN_TRI (TaiKhoan, MatKhau, TrangThai) VALUES
('TDV', '25112004', 1),
('admin2', 'password456', 1),
('admin3', 'password789', 1),
('admin4', 'password101', 1),
('admin5', 'password202', 1);

INSERT INTO LOAI_GAME (MaLoaiGame, TheLoaiGame, TrangThai) VALUES
('L001', 'Bullet Hell', 1),
('L002', 'Bullet Hell', 0),
('L003', 'Bullet Hell', 1);

INSERT INTO GAME (MaGame, TenGame, HinhAnh, SoLuong, DonGia, MaLoai, TrangThai) VALUES
('G001', 'Touhou 1', 'touhou1.jpg', 100, 9.99, 1, 1),
('G002', 'Touhou 2', 'touhou2.jpg', 100, 9.99, 1, 1),
('G003', 'Touhou 3', 'touhou3.jpg', 100, 9.99, 1, 1),
('G004', 'Touhou 4', 'touhou4.jpg', 100, 9.99, 1, 1),
('G005', 'Touhou 5', 'touhou5.jpg', 100, 9.99, 1, 1);

INSERT INTO KHACH_HANG (MaKhachHang, HoTenKhachHang, Email, MatKhau, DienThoai, DiaChi, NgayDangKy, TrangThai) VALUES
('KH001', 'Tran Van A', 'vana@gmail.com', 'password1', '0912345678', 'Ha Noi', '2022-10-01', 1),
('KH002', 'Nguyen Thi B', 'thib@gmail.com', 'password2', '0912345679', 'Ho Chi Minh', '2021-11-15', 1),
('KH003', 'Le Minh C', 'minhc@gmail.com', 'password3', '0912345680', 'Da Nang', '2023-01-25', 1),
('KH004', 'Pham Hong D', 'hongd@gmail.com', 'password4', '0912345681', 'Hai Phong', '2020-08-05', 1),
('KH005', 'Vo Van E', 'vane@gmail.com', 'password5', '0912345682', 'Can Tho', '2023-09-18', 1);

INSERT INTO DANH_GIA (GameID, KhachHangID, NoiDungDanhGia, DanhGia, NgayDanhGia) VALUES
(1, 1, 'Very fun game, enjoyed it a lot!', 5, '2023-10-10'),
(2, 2, 'Great bullet hell game!', 5, '2023-08-15'),
(3, 3, 'Challenging bullet hell, worth playing.', 5, '2023-09-20'),
(4, 4, 'Engaging strategy bullet hell.', 5, '2023-07-30'),
(5, 5, 'Amazing bullet hell experience!', 5, '2023-06-25');


SELECT * FROM QUAN_TRI;
SELECT * FROM LOAI_GAME;
SELECT * FROM GAME;
SELECT * FROM KHACH_HANG;
SELECT * FROM DANH_GIA;
SELECT * FROM HOA_DON;
SELECT * FROM CT_HOA_DON;

DROP TABLE IF EXISTS CT_HOA_DON;
DROP TABLE IF EXISTS HOA_DON;
DROP TABLE IF EXISTS DANH_GIA;
DROP TABLE IF EXISTS KHACH_HANG;
DROP TABLE IF EXISTS GAME;
DROP TABLE IF EXISTS LOAI_GAME;
DROP TABLE IF EXISTS QUAN_TRI;

