using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Application.Interfaces.UseCases;
using Ada.Aluno.Application.UseCases;
using Ada.Aluno.Infra;
using Ada.Aluno.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<SqlServerConnection>(x => new SqlServerConnection(
    builder.Configuration.GetConnectionString("MeuSqlLocal")));

builder.Services.AddScoped<ICriarAlunoUseCase, CriarAlunoUseCase>();
builder.Services.AddScoped<IDeletarAlunoUseCase, DeletarAlunoUseCase>();
builder.Services.AddScoped<IEditarAlunoUseCase, EditarAlunoUseCase>();
builder.Services.AddScoped<IListarAlunoPorIdUseCase, ListarAlunoPorIdUseCase>();
builder.Services.AddScoped<IListarAlunosUseCase, ListarAlunosUseCase>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) => 
{
    var profile = context.Request.Headers["Profile"];

    if(profile == "Ada")
    {
        await next.Invoke();
    }
    else
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsJsonAsync(new
        {
            Message = "Você não tem acesso a esse método"
        });
    }
});

app.MapControllers();

app.Run();
