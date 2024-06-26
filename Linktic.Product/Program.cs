using Linktic.Product.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.ConfigureMapSectionConfiguration(builder.Configuration);
builder.Services.ConfigureDataBaseConnection(connectionString);
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDependencyInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyOrigin");

app.UseErrorHanldinMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
