using AppLoginAspCore.Repositories.Contract;
using AppLoginAspCore.Repositories.Contracts;
using AppLoginAspCore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adicionado para manipular a Sess�o
builder.Services.AddHttpContextAccessor();

//Adicionar a Interface como um servi�o 
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
