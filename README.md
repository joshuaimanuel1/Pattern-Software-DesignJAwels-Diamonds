Berikut adalah versi yang telah ditingkatkan dan dibuat lebih menarik dari file `README.md` Anda:

---

# 💎 JAwels & Diamonds - Web-Based Online Jewelry Store

**JAwels & Diamonds** adalah aplikasi toko perhiasan berbasis web yang dikembangkan sebagai bagian dari tugas mata kuliah **COMP6114 - Pattern Software Design**. Dibangun menggunakan **ASP.NET Web Forms** dan menerapkan **Domain-Driven Design (DDD)**, aplikasi ini dirancang untuk menghadirkan pengalaman belanja online yang elegan, efisien, dan aman bagi pengguna.

---

## ✨ Fitur Unggulan

Aplikasi ini mendukung **tiga peran pengguna** dengan fitur khusus untuk masing-masing:

### 👤 Tamu (Guest)

* 🔍 **Jelajahi Produk**: Lihat semua perhiasan yang tersedia.
* 🔐 **Login**: Masuk ke akun yang sudah terdaftar (dengan fitur *Remember Me* menggunakan cookie).
* 📝 **Registrasi**: Daftar sebagai pelanggan baru dengan validasi input yang kuat.

---

### 🛍️ Pelanggan (Customer)

* ✅ Akses semua fitur tamu (kecuali login & registrasi setelah masuk).
* 🛒 **Keranjang Belanja**:

  * Tambah perhiasan ke keranjang.
  * Perbarui kuantitas atau hapus item.
  * Kosongkan keranjang.
* 💳 **Checkout**:

  * Pilih metode pembayaran & lakukan pembelian.
* 📦 **Riwayat Pesanan**:

  * Lihat semua transaksi yang pernah dilakukan.
  * Lihat detail transaksi & ubah status ke *Done* atau *Rejected*.
* ⚙️ **Manajemen Profil**:

  * Lihat dan ubah informasi akun serta ganti password.

---

### 👑 Admin

* ✅ Akses semua fitur tamu (kecuali login & registrasi).
* 💼 **Manajemen Produk** *(CRUD)*:

  * Tambah, ubah, lihat, atau hapus produk perhiasan.
* 📬 **Proses Pesanan**:

  * Ubah status pesanan: `Payment Pending → Shipment Pending → Arrived`.
* 📊 **Laporan Transaksi**:

  * Lihat laporan transaksi yang selesai (*Done*) via SAP Crystal Reports.
  * Termasuk detail transaksi, subtotal, dan total pendapatan.
* ⚙️ **Manajemen Profil**:

  * Sama seperti pelanggan: lihat & ubah info akun.

---

## 🧠 Arsitektur & Teknologi

Proyek ini dibangun dengan pendekatan **Domain-Driven Design (DDD)**, memisahkan logika bisnis dari antarmuka dan infrastruktur agar pengembangan lebih terstruktur dan scalable.

### 🔧 Teknologi yang Digunakan

* **Framework**: ASP.NET Web Forms (.NET Framework 4.7.2+)
* **Bahasa**: C#
* **Database & ORM**: SQL Server LocalDB + Entity Framework 6 (*Code-First*)
* **Pelaporan**: SAP Crystal Reports for Visual Studio
* **IDE**: Visual Studio 2022

---

## 🏗️ Struktur Proyek (DDD Layers)

```
📁 View Layer        → Halaman .aspx dan code-behind.
📁 Controller Layer  → Validasi input & delegasi ke handler.
📁 Handler Layer     → Inti logika bisnis dan pengelolaan proses.
📁 Repository Layer  → Abstraksi akses ke database.
📁 Factory Layer     → Pembuatan objek domain yang konsisten.
📁 Model Layer       → Kelas entitas (POCO) yang dimodelkan dengan EF.
```

---

## 🚀 Cara Menjalankan Proyek (Setup & Instalasi)

### 📋 Prasyarat

* Visual Studio 2022 (ASP.NET workload)
* SQL Server Express LocalDB
* SAP Crystal Reports for Visual Studio

### 📥 Clone Repositori

```bash
git clone https://github.com/joshuaimanuel1/Pattern-Software-DesignJAwels-Diamonds.git
cd Pattern-Software-DesignJAwels-Diamonds
```

### 📂 Buka Solusi

* Buka file `.sln` di Visual Studio 2022.

### 📦 Restore NuGet Packages

* Klik kanan pada **Solution** → *Restore NuGet Packages*.

### ⚙️ Konfigurasi Database

* Buka `Web.config`, pastikan koneksi bernama `JAwelsDbConnectionString` sesuai dengan lingkungan Anda.
* Buka **Package Manager Console** dan jalankan:

```powershell
Update-Database
```

### ▶️ Jalankan Aplikasi

* Tekan `F5` atau klik tombol **Start** di Visual Studio.

---

## 🎯 Catatan

Proyek ini dikembangkan untuk **tujuan pembelajaran** dan eksplorasi pola desain perangkat lunak menggunakan pendekatan arsitektural profesional.

---

Berikut adalah bagian **🌐 Kontribusi** yang telah dirapikan dan ditambahkan ke dalam format profesional di bagian akhir `README.md`:

---

## 🌐 Kontribusi Tim

Proyek ini dikerjakan secara kolaboratif oleh tim mahasiswa sebagai bagian dari tugas mata kuliah COMP6114 - Pattern Software Design. Berikut pembagian tugas anggota tim:

| Fitur                                        | Kontributor |
| -------------------------------------------- | ----------- |
| 🔐 Login & Register                          | Lilif       |
| 🧭 Navigation Bar                            | Lilif       |
| 🏠 Homepage & Jewel Detail Page              | Kiki        |
| ➕ Add Jewel & ✏️ Update Jewel Page           | Kiki        |
| 📦 Handle Orders Page & 📊 Reports Page      | Stev        |
| 🛒 Cart Page & 📁 My Orders Page             | Jojo        |
| 📃 Transaction Detail Page & 👤 Profile Page | Jojo        |

---
