using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var JwtSettings = builder.Configuration.GetSection("JwtSettings");

// Kimlik doğrulama ve JWT yapılandırması
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = JwtSettings["Issuer"],
        ValidAudience = JwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings["Key"]))
    };
});

// CORS ayarlarını yapılandırma
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()  // Bu, her türlü kaynaktan gelen isteklere izin verir
              .AllowAnyHeader()  // Her türlü header (başlık) kabul edilir
              .AllowAnyMethod(); // Herhangi bir HTTP metodu (GET, POST, vb.) kabul edilir
    });
});

// API controller'larını ekle
builder.Services.AddControllers();

// Swagger/OpenAPI desteği ekle
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger'ı uygulamaya dahil et
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

// Kimlik doğrulama ve yetkilendirme middleware'lerini ekle
app.UseAuthentication();
app.UseAuthorization();


// API controller'larını haritalandırma
app.MapControllers();

app.Run(); // Uygulamayı çalıştır

