using Microsoft.OpenApi.Models;
using WeatherDataLayer;
using WeatherDataLayer.DataFetcher;
using WeatherDataLayer.DataManager;
using WeatherDataLayer.DataRepository;
using WeatherDataServiceLayer.DataService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IWeatherDataRepository, WeatherDataRepository>();
builder.Services.AddScoped<IWeatherDataService, WeatherDataService>();

builder.Services.AddHttpClient<IWeatherDataFetcher, WeatherDataFetcher>();

builder.Services.AddDbContext<WeatherDbContext>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather API", Version = "v1" });
});

var app = builder.Build();

var weatherDataFetcher = new WeatherDataFetcher(new HttpClient());
var weatherDataService = new WeatherDataRepository(new WeatherDbContext());

var weatherDataManager = new WeatherDataManager(weatherDataFetcher, weatherDataService);
await weatherDataManager.ManageDataAsync();
var res = await weatherDataService.GetAllWeatherDataAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();