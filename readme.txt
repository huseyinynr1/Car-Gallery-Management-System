
Car Gallery Management System 🚗
Bu proje, bir araba galeri yönetim sistemini kapsamlı bir şekilde ele alan bir uygulamadır. React ile yazılmış kullanıcı dostu bir front-end ve ASP.NET Core WebAPI ile geliştirilen güçlü bir back-end mimarisine sahiptir. Sistem, kullanıcıların araba galerisini etkili bir şekilde yönetmesine olanak sağlar.

Proje Amaçları
Araba galerisi yönetimini kolaylaştırmak ve hızlandırmak.
Kullanıcıların stokları, bakım süreçlerini ve satış işlemlerini etkili bir şekilde takip etmelerine yardımcı olmak.
Dinamik grafikler ve analizler sunarak karar verme süreçlerini desteklemek.


Özellikler
🚘 Araba Yönetimi:
Araç listesi oluşturma, arama, düzenleme ve filtreleme.
Araçların stok durumlarını ve analizlerini takip etme.

🔧 Bakım Yönetimi:
Bakım planlaması, bakımların takibi ve güncellenmesi.
Bakımlarla ilgili grafikler ve detaylı analizler.

💼 Satış Yönetimi:
Araç satış işlemleri, durum takibi ve güncellemeler.
Satış verileri için görselleştirilmiş analiz ve grafikler.


🔍 Filtreleme ve Sıralama:
Marka, model, yıl, fiyat aralığı ve durum gibi özelliklere göre detaylı filtreleme.
Kullanıcı dostu filtreleme arayüzü.

📊 Grafik ve Analiz Araçları:
Aylık ve yıllık satış/maliyet analizleri.
Araba stoğu ve bakım durumlarını görselleştiren grafikler.
Bakım ve satış verilerinin görselleştirilmesi.
Envanter durumunun dinamik grafiklerle analizi.

🌐 Modern ve Dinamik Arayüz:
Gerçek zamanlı güncellemeler ve animasyonlu geçişler.
Kullanıcı dostu tasarım ve mobil uyumluluk.

🔒 Güvenli API Erişimi:
JWT ile kimlik doğrulama ve kullanıcı yönetimi.

🎨 Animasyonlar ve Görselleştirme:
Anlık güncellemelerde animasyonlu geçişler.
Satış ve bakım işlemleri için özelleştirilmiş animasyon efektleri.




Proje Yapısı

CarGalleryManagement/
├── frontend/                   # Kullanıcı arayüzü kodları
│   ├── src/                    # React uygulama dosyaları
│   │   ├── css/                # Stil dosyaları (CSS/SCSS)
│   │   ├── Pages/              # Sayfa bileşenleri
│   │   ├── Redux/              # Redux ile state yönetimi
│   │   └── index.js            # Ana giriş dosyası
│   ├── public/                 # Statik dosyalar (HTML, favicon, vb.)
│   ├── package.json            # Bağımlılık dosyası
│   └── README.md               # Front-end için özel açıklamalar
├── backend/                    # WebAPI kodları
│   ├── Application/            # İş kuralları ve iş mantığı
│   ├── Domain/                 # Temel domain modelleri ve iş mantıkları
│   ├── Infrastructure/         # Harici servisler ve araçlar (ör. e-posta, üçüncü taraf entegrasyonlar)
│   ├── Persistence/            # Veritabanı erişim katmanı
│   ├── WebAPI/                 # API uç noktaları ve yapılandırmaları
│   │   ├── Controllers/        # API Controller sınıfları
│   │   ├── Program.cs          # Giriş noktası
│   │   └── appsettings.json    # Yapılandırma dosyası
│   └── README.md               # Back-end için özel açıklamalar
├── README.md                   # Genel proje açıklaması
├── .gitignore                  # Gereksiz dosyaları hariç tutar



Klasörlerin İşlevleri
Frontend (React)

src/css/: Projenin stil dosyaları burada tutulur.

src/Pages/: Her bir sayfaya ait bileşenler bu klasörde bulunur (ör. HomePage, LoginPage).

src/Redux/: Redux ile state yönetimi yapılır. actions, reducers ve store yapılandırmaları bu klasörde bulunur.

public/: Statik dosyalar (ör. HTML, favicon).

Backend (ASP.NET Core WebAPI)

Application/: İş kuralları, CQRS ve Mediator pattern kullanımı gibi uygulama mantıkları burada bulunur.

Domain/: Veritabanı modelleri ve iş kuralları için temel domain sınıfları.

Infrastructure/: Harici servisler ve yardımcı araçlar (ör. üçüncü taraf API entegrasyonları, e-posta servisleri).

Persistence/: Veritabanı ile ilgili işlemler (Entity Framework Core bağlamları, migration’lar, repository pattern).

WebAPI/: Projenin API uç noktaları ve genel yapılandırmalar.



Kullanılan Teknolojiler

Front-end (React)

React Hooks (useState, useEffect, useReducer, vb.)

Redux ile gelişmiş state yönetimi

Redux Thunk ile API entegrasyonu

Chart.js ve D3.js ile dinamik grafikler

CSS ve SCSS ile özelleştirilmiş stil



Back-end (ASP.NET Core WebAPI)

Clean Architecture ve SOLID prensiplerini dikkate alarak kodlama

ASP.NET Core ile RESTful API geliştirme

Onion Mimari kapsamında geliştirme

DDD(Domain-Driven Design) temel modeller value objects işlemleri

Entity Framework Core ile MSSQL veritabanı yönetimi

CQRS ve Mediator pattern

SignalR ile gerçek zamanlı bildirimler

AutoMapper ile veri eşleme


