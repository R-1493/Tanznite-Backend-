using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Services.GemstoneShape;
using src.Database;
using src.Entity;
using src.Middlewares;
using src.Repository;
using src.Services.Address;
using src.Services.category;
using src.Services.Gemstone;
using src.Services.GemstoneShape;
using src.Services.Jewelry;
using src.Services.Order;
using src.Services.Payment;
using src.Services.review;
using src.Services.User;
using src.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var dataSourceBuilder = new NpgsqlDataSourceBuilder(
    builder.Configuration.GetConnectionString("Local")
);
dataSourceBuilder.MapEnum<Role>();

var dataSource = dataSourceBuilder.Build();
builder.Services.AddSingleton(dataSource);

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(dataSource);
});

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

///user
builder
    .Services.AddScoped<IUserService, UserService>()
    .AddScoped<UserRepository, UserRepository>();

///Address
builder
    .Services.AddScoped<IAddressService, AddressService>()
    .AddScoped<AddressRepository, AddressRepository>();

// add DI services for category
builder
    .Services.AddScoped<ICategoryService, CategoryService>()
    .AddScoped<CategoryRepository, CategoryRepository>();

// add DI services for review
builder
    .Services.AddScoped<IReviewService, ReviewService>()
    .AddScoped<ReviewRepository, ReviewRepository>();

///Payment
builder
    .Services.AddScoped<IPaymentService, PaymentService>()
    .AddScoped<PaymentRepository, PaymentRepository>();

//Gemstones
builder
    .Services.AddScoped<IGemstoneService, GemstoneService>()
    .AddScoped<GemstonesRepository, GemstonesRepository>();

//Jewelry
builder
    .Services.AddScoped<IJewelryService, JewelryService>()
    .AddScoped<JewelryRepository, JewelryRepository>();

//Order
builder
    .Services.AddScoped<IOrderService, OrderService>()
    .AddScoped<OrderRepository, OrderRepository>();

//GemstonShap
builder
    .Services.AddScoped<IGemstoneShapeService, GemstoneShapeService>()
    .AddScoped<GemstoneShapeRepository, GemstoneShapeRepository>();

builder
    .Services.AddAuthentication(options =>
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
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            ),
        };
    });

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("Local"))
        .EnableSensitiveDataLogging()
        .ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning)
        );
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
                .WithOrigins("http://localhost:3000/")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((Host) => true)
                .AllowCredentials();
        }
    );
});

builder.Services.AddAuthorization(Options =>
{
    Options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

    try
    {
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Database is connected");
        }
        else
        {
            Console.WriteLine("Unable to connect to the database.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection failed: {ex.Message}");
    }
}

app.UseCors(MyAllowSpecificOrigins);
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello ");

app.Run();
