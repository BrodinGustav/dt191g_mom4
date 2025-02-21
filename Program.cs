using dt191g_mom4.Data;                 //För användning av MusicDbContext
using Microsoft.EntityFrameworkCore;    //För användning av Sqlite

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<MusicDbContext>(options =>                                    //Använder MusicDbContext
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionString")));   //Använder SqLite och importerar anslutningssträngen


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
