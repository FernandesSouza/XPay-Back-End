using Vanguardium.ApplicationService.RabbitMqServices;
using Vanguardium.IoC;
using Vanguardium.Settings;
using Vanguardium.Settings.Handlers;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddInversionControllerHandler();
builder.Services.AddSettingsControl(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RabbitMqImplement(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

 await app.MigrateDatabase();
app.Run();
