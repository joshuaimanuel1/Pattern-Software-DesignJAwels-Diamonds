JAwels & Diamonds - Web-Based Online Store
Proyek ini adalah aplikasi web toko perhiasan online yang dikembangkan sebagai bagian dari tugas mata kuliah COMP6114 - Pattern Software Design. Aplikasi ini dibangun menggunakan platform ASP.NET Web Forms dengan arsitektur Domain-Driven Design (DDD) untuk mengelola pesanan dan menyediakan pengalaman belanja yang nyaman bagi pelanggan.

Fitur Utama
Aplikasi ini memiliki tiga peran pengguna yang berbeda: Tamu (Guest), Pelanggan (Customer), dan Admin.

👤 Tamu (Guest)
Melihat Perhiasan: Menjelajahi semua produk yang tersedia di toko.

Login: Masuk ke akun pelanggan yang sudah ada. Fitur "Remember Me" menggunakan Cookie.

Registrasi: Mendaftar sebagai pelanggan baru dengan validasi data yang komprehensif.

🛍️ Pelanggan (Customer)
Semua fitur Tamu (kecuali Login & Register setelah masuk).

Keranjang Belanja (Cart):

Menambahkan perhiasan ke keranjang.

Memperbarui kuantitas item di keranjang.

Menghapus item dari keranjang.

Mengosongkan seluruh keranjang.

Checkout: Melakukan proses checkout dengan memilih metode pembayaran.

Riwayat Transaksi (My Orders):

Melihat semua riwayat transaksi.

Melihat detail setiap transaksi.

Mengonfirmasi penerimaan paket (Done) atau menolak paket (Rejected).

Manajemen Profil:

Melihat informasi profil.

Mengubah password akun.

👑 Admin
Semua fitur Tamu (kecuali Login & Register).

Manajemen Perhiasan (CRUD):

Create: Menambahkan produk perhiasan baru ke dalam sistem.

Read: Melihat semua detail produk.

Update: Mengedit informasi produk yang sudah ada.

Delete: Menghapus produk dari sistem.

Manajemen Pesanan (Handle Orders):

Memproses pesanan yang masuk.

Mengubah status pesanan dari "Payment Pending" -> "Shipment Pending" -> "Arrived".

Laporan Transaksi (Reports):

Melihat laporan semua transaksi yang berhasil (Done) menggunakan SAP Crystal Reports.

Laporan mencakup detail transaksi, subtotal, dan grand total pendapatan.

Manajemen Profil:

Melihat informasi profil.

Mengubah password akun.

Arsitektur & Teknologi
Proyek ini dirancang dengan mengikuti prinsip-prinsip Domain-Driven Design (DDD) untuk memisahkan logika bisnis dari infrastruktur dan antarmuka pengguna, sehingga menghasilkan kode yang lebih terstruktur dan mudah dikelola.

Teknologi yang Digunakan
Framework: ASP.NET Web Forms (.NET Framework 4.7.2+)

Bahasa: C#

Database & ORM: SQL Server LocalDB & Entity Framework 6 (Code-First)

Arsitektur: Domain-Driven Design (DDD)

Pelaporan: SAP Crystal Reports for Visual Studio

IDE: Visual Studio 2022

Struktur Proyek (Lapisan DDD)
View Layer: Terdiri dari halaman .aspx dan code-behind-nya. Bertanggung jawab untuk menampilkan informasi kepada pengguna dan menangkap input pengguna.

Controller Layer: Kelas C# yang dipanggil oleh View untuk memvalidasi input dan mendelegasikan permintaan ke lapisan di bawahnya.

Handler Layer: Inti dari logika bisnis aplikasi. Berisi semua proses dan aturan bisnis, serta berkoordinasi dengan Repository untuk manipulasi data.

Repository Layer: Bertindak sebagai jembatan antara Handler dan database. Menyediakan antarmuka untuk mengakses dan memanipulasi objek domain tanpa mengekspos detail implementasi database.

Factory Layer: Digunakan untuk mengenkapsulasi proses pembuatan objek yang kompleks, memastikan objek yang dibuat selalu dalam keadaan konsisten.

Model Layer: Berisi kelas-kelas entitas domain (POCO - Plain Old CLR Object) yang merepresentasikan konsep bisnis dan struktur data. Dikelola menggunakan Entity Framework.

Setup & Instalasi
Untuk menjalankan proyek ini di lingkungan lokal, ikuti langkah-langkah berikut:

Prasyarat:

Visual Studio 2022 (dengan workload ASP.NET and web development).

SQL Server Express LocalDB (biasanya terinstal bersama Visual Studio).

SAP Crystal Reports for Visual Studio.

Clone Repositori:

git clone https://github.com/joshuaimanuel1/Pattern-Software-DesignJAwels-Diamonds.git
cd Pattern-Software-DesignJAwels-Diamonds

Buka Proyek:

Buka file solution (.sln) dengan Visual Studio 2022.

Restore Paket NuGet:

Klik kanan pada Solution di Solution Explorer, lalu pilih "Restore NuGet Packages". Ini akan mengunduh paket yang diperlukan seperti Entity Framework.

Konfigurasi Database:

Buka file Web.config.

Pastikan connectionString bernama JAwelsDbConnectionString sudah dikonfigurasi dengan benar untuk lingkungan Anda (proyek ini dikonfigurasi untuk menggunakan SQL Server LocalDB secara default).

Buka Package Manager Console (Tools > NuGet Package Manager > Package Manager Console).

Jalankan perintah berikut untuk membuat database berdasarkan model (Code-First):

Update-Database

Jalankan Aplikasi:

Tekan F5 atau klik tombol "Start" (dengan browser pilihan Anda) untuk menjalankan aplikasi.

Proyek ini dibuat untuk tujuan pendidikan.
