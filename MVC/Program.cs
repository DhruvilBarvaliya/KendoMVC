using MVC.Repositorise.Implimentation;
using MVC.Repositorise.Interfaces;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<UserInterface,UserImplimentation>();
builder.Services.AddScoped<NpgsqlConnection>(
    ServiceProvider => {
        string Connection = ServiceProvider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");
        return new NpgsqlConnection(Connection);
    }
);


builder.Services.AddSession(
    Object =>{
        Object.IdleTimeout = TimeSpan.FromMinutes(30);
        Object.Cookie.HttpOnly = true;
        Object.Cookie.IsEssential = true;
    }
);


var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
