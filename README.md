# Survivor Yarışması Web API Projesi 🌟

Bu proje, Survivor yarışması için bir Web API uygulaması geliştirmek üzere tasarlanmıştır. Yarışmacılar (“Competitors”) ve kategoriler (“Categories”) arasında bire çok (one-to-many) ilişkisi kurulmuştur. API, bu tablolarla ilgili CRUD işlemlerini yerine getiren endpointler içermektedir.

## 🔧 Teknolojiler

- **.NET Core 7.0**
- **Entity Framework Core**
- **ASP.NET Web API**
- **SQL Server**
- **Swagger** (API dokümentasyonu ve test için)
- **Postman** (Manuel testler için)

## 📊 Veri Modeli

### BaseEntity Class
Tüm tablolar için ortak olan alanlar BaseEntity üzerinden tanımlanmıştır.

```csharp
public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
}
```

### Competitor Entity

```csharp
public class Competitor : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
```

### Category Entity

```csharp
public class Category : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Competitor> Competitors { get; set; }
}
```

### Veri Tabanı Konfigürasyonu
EF Core ile Category ve Competitor arasındaki bire çok ilişki aşağıdaki gibi konfigüre edilmiştir:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Category>()
        .HasMany(c => c.Competitors)
        .WithOne(e => e.Category)
        .HasForeignKey(e => e.CategoryId);

    base.OnModelCreating(modelBuilder);
}
```

## 🔠 Endpointler

### CompetitorController

| HTTP Metodu | URL                                | Açıklama                             |
|-------------|------------------------------------|-----------------------------------------|
| **GET**     | `/api/competitors`                | Tüm yarışmacıları listele       |
| **GET**     | `/api/competitors/{id}`           | Belirli bir yarışmacıyı getir    |
| **GET**     | `/api/competitors/categories/{CategoryId}` | Kategoriye göre yarışmacıları getir |
| **POST**    | `/api/competitors`                | Yeni bir yarışmacı ekle           |
| **PUT**     | `/api/competitors/{id}`           | Belirli bir yarışmacıyı güncelle  |
| **DELETE**  | `/api/competitors/{id}`           | Belirli bir yarışmacıyı sil      |

### CategoryController

| HTTP Metodu | URL                   | Açıklama                          |
|-------------|-----------------------|----------------------------------|
| **GET**     | `/api/categories`     | Tüm kategorileri listele             |
| **GET**     | `/api/categories/{id}`| Belirli bir kategoriyi getir     |
| **POST**    | `/api/categories`     | Yeni bir kategori ekle          |
| **PUT**     | `/api/categories/{id}`| Belirli bir kategoriyi güncelle |
| **DELETE**  | `/api/categories/{id}`| Belirli bir kategoriyi sil       |

## 📊 Veritabanı Oluşturma
EF Core Migrations kullanılarak veritabanı tabloları oluşturulur:

1. Migration oluşturun:
   ```bash
   dotnet ef migrations add InitialCreate
   ```
2. Migrationı uygulayın:
   ```bash
   dotnet ef database update
   ```

## 🗭Örnek Veri
**Seed Data** ile aşağıdaki örnek kategoriler ve yarışmacılar eklenmiştir:

### Kategoriler:
- **1**: Ünlüler
- **2**: Gönüllüler

### Yarışmacılar:
| Id | Ad      | Soyad     | Kategori |
|----|---------|-----------|----------|
| 1  | Acun    | Ilıcalı | Ünlüler   |
| 2  | Aleyna  | Avcı     | Ünlüler   |
| 3  | Kıvanç | Tatlıtuğ  | Ünlüler   |
| 4  | Ayşe   | Karaca    | Gönüllüler |

## 📈 Swagger Kullanımı
Projenizi çalıştırdıktan sonra Swagger arayüzünü çalıştırmak için tarayıcıda aşağıdaki URL’i açın:

```
http://localhost:5000/swagger
```

Swagger ile endpointlerinizi kolayca test edebilirsiniz.

## 🔧 API’yi Postman’de Test Etmek
1. Postman'i açın ve yeni bir koleksiyon oluşturun.
2. CRUD işlemleri için yukarıdaki endpointleri kullanarak istekler oluşturun.
3. JSON formatında veri gönderin.

### 🔒 Authorization (Eğer gerekliyse)
Eğer API'ınıza bir kimlik doğrulama mekanizması eklediyseniz (JWT, Basic Auth vb.), Postman'de gerekli kimlik bilgilerini girin.



