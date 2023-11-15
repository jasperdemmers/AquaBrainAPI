using AquaBrainAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IKlantService, KlantService>();
builder.Services.AddScoped<IWoningService, WoningService>();
builder.Services.AddScoped<IWatertonService, WatertonService>();
builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddDbContext<DevelopmentContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.UseSwagger();
    //app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
