using Microsoft.EntityFrameworkCore;
using UniversityManager.Back.Application.Interfaces;
using UniversityManager.Back.Application.Services;
using UniversityManager.Back.Persistence;
using UniversityManager.Back.Persistence.Contexts;
using UniversityManager.Back.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UniversityManagerContext>(optionsBuilder =>
            optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("ManagerUniversityConnection"))
);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddScoped<StudentsServices, StudentsServices>();
builder.Services.AddScoped<CoursesServices, CoursesServices>();
builder.Services.AddScoped<TeacherServices, TeacherServices>();
builder.Services.AddScoped<SubjectsServices, SubjectsServices>();
builder.Services.AddScoped<SemestersServices, SemestersServices>();
builder.Services.AddScoped<ManagerUniversityPersistence, ManagerUniversityPersistence>();
builder.Services.AddScoped<TeacherPersistence, TeacherPersistence>();
builder.Services.AddScoped<StudentPersistence, StudentPersistence>();
builder.Services.AddScoped<CoursesPersistence, CoursesPersistence>();
builder.Services.AddScoped<SubjectPersistence, SubjectPersistence>();
builder.Services.AddScoped<SemestersPersistence, SemestersPersistence>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
