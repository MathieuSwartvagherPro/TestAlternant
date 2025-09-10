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
        new Users { UsrMail = "alice@gmail.com", UsrName = "Alice" },
        new Users { UsrMail = "bob@gmail.com", UsrName = "Bob" },
        new Users { UsrMail = "charlie@gmail.com", UsrName = "Charlie" },
        new Users { UsrMail = "diana@gmail.com", UsrName = "Diana" },
        new Users { UsrMail = "eric@gmail.com", UsrName = "Eric" },
        new Users { UsrMail = "fatima@gmail.com", UsrName = "Fatima" },
        new Users { UsrMail = "georges@gmail.com", UsrName = "Georges" },
        new Users { UsrMail = "hana@gmail.com", UsrName = "Hana" },
        new Users { UsrMail = "ibrahim@gmail.com", UsrName = "Ibrahim" },
        new Users { UsrMail = "julie@gmail.com", UsrName = "Julie" }
    );

    context.SaveChanges();
}

app.Run();