using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200/");
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

//options.AddPolicy("AllowSpecificOrigin",
//  abuilder => abuilder
//  .AllowAnyOrigin()
//  .AllowAnyMethod()
//  .AllowAnyHeader()
//  .WithOrigins("*")
//  )

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();
