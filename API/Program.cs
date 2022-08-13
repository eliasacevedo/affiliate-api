using API.Filters;
using Business.Business.Affiliates;
using Data.Config;
using Data.Queries.Affiliates;

var  AllOrigins = "AllOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(configure =>
{
    configure.Filters.Add<ResultWrapperlAttribute>();
    configure.Filters.Add<ExceptionFilter>();
    configure.Filters.Add<ModelValidatorFilter>();
    
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAffiliateQuery, AffiliateQuery>();
builder.Services.AddSingleton<IAffiliateLogic, AffiliateLogic>();

builder.Services.AddSingleton<ConnectionStringManager>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllOrigins, policy => {policy.WithOrigins("*");});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(AllOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

