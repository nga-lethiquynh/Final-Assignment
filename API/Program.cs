using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoeStore.API.Data;
using ShoeStore.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShoeStoreContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
// .AddEntityFrameworkStores<ShoeStoreContext>()
// .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ShoeStore API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoeStore API v1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// // Khởi tạo cơ sở dữ liệu
// using (var scope = app.Services.CreateScope())
// {
// var services = scope.ServiceProvider;
// await DbInitializer.Initialize(services);
// }

app.Run();