using Microsoft.EntityFrameworkCore;
using Task11;
using Task11.Data;
using Task11.DTO;
using Task11.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<BaseApplicationContext, ApplicationContext>(ServiceLifetime.Transient);
builder.Services.AddTransient<OperationTypeService>();
builder.Services.AddTransient<FinancialOperationService>();
builder.Services.AddTransient<ReportService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(b =>
    {
        b.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseCors();
app.MapGet("/", () => "Hello World!");

app.Run();
