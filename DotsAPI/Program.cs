using DotsAPI.Data;

var  myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>  
{  
    options.AddPolicy(name: myAllowSpecificOrigins,  
        policy  =>  
        {  
            policy.WithOrigins("http://localhost:3000");
        });  
});

builder.Services.AddScoped<IDotRepository, DotRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseCors(myAllowSpecificOrigins);

app.Run();