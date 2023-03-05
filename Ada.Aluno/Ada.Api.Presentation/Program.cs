using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICriarAlunoUseCase, CriarAlunoUseCase>();

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
