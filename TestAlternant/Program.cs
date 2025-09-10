using Microsoft.EntityFrameworkCore;
using S_InterModels.IRepository;
using S_InterModels.Models.Optimus;
using S_InterModels.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvcCore();

builder.Services.AddDbContext<OptimusContext>(options => options.UseInMemoryDatabase("OptimusTestDb"));

builder.Services
    .AddScoped<IUsr, Usr>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OptimusContext>();

    context.Users.AddRange(
        new Users { UsrUserId = "A", UsrProfil = "Admin", UsrMail = "alice@gmail.com", UsrName = "Alice" },
        new Users { UsrUserId = "B", UsrProfil = "Admin", UsrMail = "bob@gmail.com", UsrName = "Bob" },
        new Users { UsrUserId = "C", UsrProfil = "Admin", UsrMail = "charlie@gmail.com", UsrName = "Charlie" },
        new Users { UsrUserId = "D", UsrProfil = "Admin", UsrMail = "diana@gmail.com", UsrName = "Diana" },
        new Users { UsrUserId = "E", UsrProfil = "User", UsrMail = "eric@gmail.com", UsrName = "Eric" },
        new Users { UsrUserId = "F", UsrProfil = "User", UsrMail = "fatima@gmail.com", UsrName = "Fatima" },
        new Users { UsrUserId = "G", UsrProfil = "Admin", UsrMail = "georges@gmail.com", UsrName = "Georges" },
        new Users { UsrUserId = "H", UsrProfil = "Admin", UsrMail = "hana@gmail.com", UsrName = "Hana" },
        new Users { UsrUserId = "I", UsrProfil = "User", UsrMail = "ibrahim@gmail.com", UsrName = "Ibrahim" },
        new Users { UsrUserId = "J", UsrProfil = "Admin", UsrMail = "julie@gmail.com", UsrName = "Julie" }
    );

    context.SaveChanges();
}

app.Run();