using Employ_of_Company.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//----------------------------------------------------------------------------




//This method is going to get all the values from db
app.MapGet("/api/employs/", (ILogger<Program> _log) =>
{
    ApiRespon respons = new ApiRespon();
    respons.issucces = true;
    respons.statuscode= StatusCodes.Status200OK.ToString();
    
    respons.result = EmployCreat.info;

    _log.Log(LogLevel. Information, "getting all coupon");
    return Results.Ok( respons);

}).WithName("gettingAll");







//==========================================================================
//This part takes An id and find the equivalent value and returns;

app.MapGet("/api/employ/{id:int}", (int id) =>
{
    if (id == 0)
    {
        return Results.NotFound();
    }

   return Results.Ok( EmployCreat.info.FirstOrDefault(u => u.Id==id));
    

});

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//This part is for adding employ in db and we are going to get value from body/user

app.MapPost("/api/employ/", ([FromBody] EmployInfo human ) =>
{

    if(human.Id != 0)
    {
        return Results.BadRequest("here is a problem");
    }

    human.Id = EmployCreat.info.OrderByDescending(u => u.Id).FirstOrDefault().Id+1 ;//increasing the id number

    EmployCreat.info.Add(human);

    return Results.CreatedAtRoute("id "+ human.Id);

});
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
app.MapDelete("/api/employ/{id:int}", (int id) =>
{
    if (!EmployCreat.info.Any(u => u.Id==id))
    {
        return Results.BadRequest();
    }

    EmployInfo human1 = EmployCreat.info.FirstOrDefault(u=>u.Id==id);
    EmployCreat.info.Remove(human1);

    return Results.Ok();

});



app.UseHttpsRedirection();


app.Run();


