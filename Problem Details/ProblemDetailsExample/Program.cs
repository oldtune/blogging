using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using ProblemDetailsExample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = ctx =>
    {
        var exception = ctx.HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;
        if (exception != null && exception is GreetingException greetingException)
        {
            ctx.ProblemDetails.Status = 500;
            ctx.ProblemDetails.Title = greetingException.Greeting;
        }
    };
});
builder.Services.AddControllers();

var app = builder.Build();
app.UseExceptionHandler();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.MapControllers();
app.Run();