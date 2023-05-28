using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using RabbitMQExample.AutofacBusiness;
using RabbitMQExample.DatabaseContext;
using RabbitMQExample.Extension;
using RabbitMQExample.Messaging;
using RabbitMQExample.RabbitMQSender;
using RabbitMQExample.Services;
using RabbitMQExample.Services.Abstract;
using RabbitMQExample.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHostedService<RabbitMQConsumer>();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());//Dependency injection için gerekli adým.Autofac kullanýmý için hazýrlýk.
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());//Baðýmlýlýktan kurtulmak için IoC yapýlan dosyanýn yolunu veriyoruz.
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton<IRabbitMQCartMessageSender,RabbitMQCartMessageSender>();

builder.Services.AddSingleton(new OrderService(optionBuilder.Options));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyResolver(new ICoreModule[]
                 {
                     new CoreModule()
                 });
builder.Services.AddSwaggerGen();
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
