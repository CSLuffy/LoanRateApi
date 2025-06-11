using LoanRateAPI.Data;
using LoanRateAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure dependency injection following SOLID principles:
// 1. Register the data provider interface and its static implementation.
//    This allows for easy swapping of data sources (e.g., from static to database).
builder.Services.AddSingleton<ILoanRateDataProvider, StaticLoanRateDataProvider>();
// 2. Register the loan rate service interface and its implementation.
//    This separates the business logic from the controller and data source.
builder.Services.AddScoped<ILoanRateService, LoanRateService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
