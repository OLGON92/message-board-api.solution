using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Swashbuckle.AspNetCore;
using Microsoft.AspNetCore.Mvc;

using MessageBoardApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<MessageBoardApiContext>(
		dbContextOptions => dbContextOptions
		.UseMySql(
			builder.Configuration["ConnectionStrings:DefaultConnection"],
			ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
			)
		)
	);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(opt =>
																		{
																			opt.DefaultApiVersion = new ApiVersion(1,0);
																			opt.AssumeDefaultVersionWhenUnspecified = true;
																			opt.ReportApiVersions = true;
																			opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
																			new HeaderApiVersionReader("x-api-version"),
																			new MediaTypeApiVersionReader("x-api-version"));
																		});

builder.Services.AddVersionedApiExplorer(setup =>
{
	setup.GroupNameFormat = "'v'VVV";
	setup.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options =>
	{
		foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
		{
			options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
				description.GroupName.ToUpperInvariant());
		}
	});
}
else
{
  app.UseHttpsRedirection();
}
app.UseHttpsRedirection();
// app.UseRequestLocalization(options);
// app.UseStaticFiles();
//app.UseMiddleware<LocalizerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();