using ReflactionMediatr.Lib.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// inject all interfaces
builder.Services.AddCustomReflaction(AppDomain.CurrentDomain.GetAssemblies());

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

// custome middleware
app.Services.UseCustomeReflaction();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
