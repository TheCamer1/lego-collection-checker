using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseDefaultFiles();  // Add this line to serve index.html as the default document
app.UseStaticFiles();   // Ensures static files are served, important for your index.html

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // Make sure your API routes are registered

app.Run();
