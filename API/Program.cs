using API.Accounts.Extensions;
using API.App.Extensions;
using API.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices();
builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
