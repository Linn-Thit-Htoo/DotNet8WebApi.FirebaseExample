var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

FirebaseApp.Create(
    new AppOptions()
    {
        Credential = GoogleCredential.FromFile(
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "testfirebase-ad8e7-firebase-adminsdk-9e77o-4079fd9b62.json"
            )
        ),
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
