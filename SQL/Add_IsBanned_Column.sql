-- Kullanici banlama özelligi için IsBanned sütunu ekleme scripti
-- Veritabaninda users tablosuna IsBanned sütunu ekler

-- Sütunu ekle (eger daha once eklenmediyse)
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'users' AND COLUMN_NAME = 'IsBanned')
BEGIN
    ALTER TABLE users
    ADD IsBanned BIT DEFAULT 0;
    
    PRINT 'IsBanned sütunu basariyla eklendi.';
END
ELSE
BEGIN
    PRINT 'IsBanned sütunu zaten mevcut.';
END

-- Mevcut kullaniciilarin ban durumunu varsayilan olarak false (0) yap
UPDATE users 
SET IsBanned = 0 
WHERE IsBanned IS NULL;

PRINT 'Mevcut kullaniciilarin ban durumu güncellendi.';

-- Index ekleme (performans için)
IF NOT EXISTS (SELECT * FROM sys.indexes 
               WHERE name = 'IX_users_IsBanned' AND object_id = OBJECT_ID('users'))
BEGIN
    CREATE INDEX IX_users_IsBanned ON users(IsBanned);
    PRINT 'IsBanned index'i eklendi.';
END

PRINT 'IsBanned sütunu kurulumu tamamlandi.';
