-- Menü ve Yemek Seçimi Özelliği için Veritabanı Tabloları
-- 9. Hafta Özelliği: Rezervasyon sırasında yemek seçimi

-- MenuItems tablosu oluştur
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MenuItems')
BEGIN
    CREATE TABLE MenuItems (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        Description NVARCHAR(500),
        Price DECIMAL(10,2) NOT NULL,
        ImagePath NVARCHAR(500),
        Category NVARCHAR(50),
        IsAvailable BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE()
    );
    
    PRINT 'MenuItems tablosu başarıyla oluşturuldu.';
END
ELSE
BEGIN
    PRINT 'MenuItems tablosu zaten mevcut.';
END

-- ReservationMenuItems tablosu oluştur (rezervasyon-yemek ilişkisi için)
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ReservationMenuItems')
BEGIN
    CREATE TABLE ReservationMenuItems (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ReservationId INT NOT NULL,
        MenuItemId INT NOT NULL,
        Quantity INT NOT NULL DEFAULT 1,
        UnitPrice DECIMAL(10,2) NOT NULL,
        TotalPrice DECIMAL(10,2) NOT NULL
    );
    
    PRINT 'ReservationMenuItems tablosu başarıyla oluşturuldu.';
END
ELSE
BEGIN
    PRINT 'ReservationMenuItems tablosu zaten mevcut.';
END

-- Örnek menü verileri ekle
IF NOT EXISTS (SELECT * FROM MenuItems WHERE Name = 'Köfte')
BEGIN
    INSERT INTO MenuItems (Name, Description, Price, ImagePath, Category, IsAvailable) VALUES
    ('Köfte', 'Özel soslu ızgara köfte', 150.00, 'images/kofte.jpg', 'Ana Yemek', 1),
    ('Adana Kebabı', 'Acılı Adana kebabı', 180.00, 'images/adana.jpg', 'Ana Yemek', 1),
    ('Lahmacun', 'Klasik lahmacun', 45.00, 'images/lahmacun.jpg', 'Ana Yemek', 1),
    ('Mercimek Çorbası', 'Ev yapımı mercimek çorbası', 35.00, 'images/mercimek.jpg', 'Çorba', 1),
    ('Yayla Çorbası', 'Yoğurtlu yayla çorbası', 40.00, 'images/yayla.jpg', 'Çorba', 1),
    ('Şiş Kebabı', 'Kuzu şiş kebabı', 220.00, 'images/sis.jpg', 'Ana Yemek', 1),
    ('Pilav', 'Tereyağlı pirinç pilavı', 30.00, 'images/pilav.jpg', 'Yan Ürün', 1),
    ('Baklava', 'Fıstıklı baklava', 60.00, 'images/baklava.jpg', 'Tatlı', 1),
    ('Künefe', 'Antep künefesi', 70.00, 'images/kunefe.jpg', 'Tatlı', 1),
    ('Ayran', 'Geleneksel ayran', 15.00, 'images/ayran.jpg', 'İçecek', 1),
    ('Limonata', 'Taze sıkılmış limonata', 35.00, 'images/limonata.jpg', 'İçecek', 1),
    ('Cola', '330ml cola', 25.00, 'images/cola.jpg', 'İçecek', 1),
    ('Su', '500ml su', 10.00, 'images/su.jpg', 'İçecek', 1),
    ('Salata', 'Mevsim salatası', 40.00, 'images/salata.jpg', 'Başlangıç', 1),
    ('Humus', 'Sarımsaklı humus', 35.00, 'images/humus.jpg', 'Başlangıç', 1);
    
    PRINT 'Örnek menü verileri başarıyla eklendi.';
END
ELSE
BEGIN
    PRINT 'Örnek menü verileri zaten mevcut.';
END

PRINT 'Menü tabloları kurulumu tamamlandı.';
