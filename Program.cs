using bootcamp_store_backend.Application.Mappings;
using bootcamp_store_backend.Application.Services;
using bootcamp_store_backend.Domain.Persistence;
using bootcamp_store_backend.Domain.Services;
using bootcamp_store_backend.Infraestructure.Persistence;
using bootcamp_store_backend.Infrastucture.Persistance;
using bootcamp_store_backend.Infrastucture.Specs;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemReposity, ItemRepository>();
builder.Services.AddScoped(typeof(ISpecificationParser<>), typeof(SpecificationParser<>));
builder.Services.AddScoped<IImageVerifier, ImageVerifier>();
builder.Services.AddAutoMapper(typeof(CategoryMapperProfile));
builder.Services.AddAutoMapper(typeof(ItemMapperProfile));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();
// Agregar la configuración para las URLs en minúsculas
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<StoreContext>(options =>
        options.UseInMemoryDatabase(connectionString)
    );
}

var app = builder.Build();
ConfigureExceptionHandler(app);

if (builder.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    DevelopmentDataLoader dataLoader = new(context);
    dataLoader.LoadData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureExceptionHandler(WebApplication app)
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            IExceptionHandlerFeature? exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerFeature>();
            var logger = app.Services.GetRequiredService<ILogger<Program>>();

            if (exceptionHandlerPathFeature?.Error != null)
            {
                logger.LogError(exceptionHandlerPathFeature.Error, "An unhandled exception ocurred while processing the request.");
            }
            else
            {
                logger.LogError("An unhandled exception ocurred while processin the request.");
            }

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unhandled exception ocurred while processin the request.");
        });
    });
}
