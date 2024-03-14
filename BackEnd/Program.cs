using BackEnd.Contexts;
using BackEnd.Interfaces;
using BackEnd.Models;
using BackEnd.Repository;
using BackEnd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options=>{
    options.AddPolicy("reactApp",opts=>{
        opts.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

// builder.Services.AddDbContext<LoginContext>(opts => {
//     opts.UseMySQL(builder.Configuration.GetConnectionString("loginconn"));
// });

//testing data
builder.Services.AddSingleton<LoginContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IRespository<string,User>, UserRepository>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IRespository<int,Courses>, CourseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors("reactApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
