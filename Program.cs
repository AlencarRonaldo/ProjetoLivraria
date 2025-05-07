using ProjetoLivros.Context;
using ProjetoLivros.Interface;

var builder = WebApplication.CreateBuilder(args);

// Avisa que a aplicacao usa controllers
builder.Services.AddControllers();

// Adiciono Gerador de Swagger
builder.Services.AddSwaggerGen();

// dotnet ef migrations add Inicial
// dotnet ef database update
builder.Services.AddDbContext<LivrosContext>();
builder.Services.AddScoped<ICategoriaRepository, ICategoriaRepository>();

var app = builder.Build();

// Avisa o .NET que eu tenho Controladores
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string .Empty;
});

app.Run();
