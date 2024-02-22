using AutoMapper;
using Employ_of_Company;
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

builder.Services.AddAutoMapper(typeof(Mapping_Config_Employ));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//----------------------------------------------------------------------------




//This method is going to get all the values from db
app.MapGet("/api/employs/", ( IMapper _mat ,ILogger<Program> _log) =>
{
    ApiRespon respons = new ApiRespon();

    respons.issucces = true;
    respons.statuscode= HttpStatusCode.OK;    
    respons.result = EmployCreat.info;

    _log.Log(LogLevel. Information, "getting all coupon");
    return Results.Ok(respons);

}).WithName("gettingAll").Produces<ApiRespon>();







//==========================================================================
//This part takes An id and find the equivalent value and returns;

app.MapGet("/api/employ/{id:int}", (IMapper _map ,int id) =>
{
    ApiRespon respon = new ApiRespon();
    respon.issucces = true;
    respon.statuscode= HttpStatusCode.OK;
    respon.result =  EmployCreat.info.FirstOrDefault(u => u.Id==id);
    
    if (id == 0)

    {
        return Results.NotFound();
    }


    return Results.Ok(respon);

}).Produces<ApiRespon>(200);





//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//This part is for adding employ in db and we are going to get value from body/user

app.MapPost("/api/employ/", ( IMapper _map,[FromBody] EmployDTO human ) =>
{
    ApiRespon respon = new ApiRespon() { issucces = false, statuscode= HttpStatusCode.BadRequest };



    if (string.IsNullOrEmpty(human.Name))
    {
        respon.Errormessages.Add("THERE WAS A PROBLEM WIRH NAME");
        return Results.BadRequest(respon);
    }

    if(EmployCreat.info.FirstOrDefault(u=>u.Name.ToLower()==human.Name.ToLower()) != null)
    {
        respon.Errormessages.Add("There already employ exist with this name");
        return Results.BadRequest(respon);
    }
   
    var hum = _map.Map<EmployInfo>(human);//we are changing the EmployDTO into EmployInfo
    hum.Id = EmployCreat.info.OrderByDescending(u => u.Id).FirstOrDefault().Id+1 ;//increasing the id number



    EmployCreat.info.Add(hum);
    
    var har = _map.Map<EmployDTO>(human);

   

        respon.result = har;
        respon.statuscode = HttpStatusCode.Created;
        respon.issucces= true;
    return Results.Ok(respon);


// return Results.CreatedAtRoute("getEmploy", new {id=hum.Id}, har);

}).WithDisplayName("created new employ").Produces<ApiRespon>(201);





//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
app.MapDelete("/api/employ/{id:int}", (int id) =>
{
    ApiRespon respons = new ApiRespon { issucces= false , statuscode= HttpStatusCode.BadRequest };

    if (!EmployCreat.info.Any(u => u.Id==id))
    {
        respons.Errormessages.Add("Id doen't maches or doesn't exist ");
        return Results.BadRequest();
    }

    EmployInfo human1 = EmployCreat.info.FirstOrDefault(u=>u.Id==id);
    EmployCreat.info.Remove(human1);

    respons.issucces=true;
    respons.statuscode= HttpStatusCode.NotFound;
    respons.result = human1;

    return Results.Ok(respons);

}).Produces<ApiRespon>();

//##############################################################################################

app.MapPut("/api/employ/", (IMapper _map, [FromBody] EmployUpdateDTO newEmploy ) =>
{
    ApiRespon respons = new ApiRespon { issucces= false, statuscode= HttpStatusCode.BadRequest };

    if (newEmploy.Id == EmployCreat.info.FirstOrDefault(u => u.Id == newEmploy.Id).Id)
    {

        var employ = _map.Map<EmployInfo>(newEmploy);


            EmployCreat.info.Remove(employ);
    
    respons.issucces = true;
    respons.statuscode = HttpStatusCode.UpgradeRequired;
    respons.result = employ;

    return Results.RedirectToRoute("created new employ", employ);

    }
    


        respons.Errormessages.Add("there is no employ by this information");
        Console.WriteLine("some thing is heree");
        return Results.BadRequest();

}) ;



app.UseHttpsRedirection();


app.Run();


