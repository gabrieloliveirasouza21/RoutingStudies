var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//rotas basicamente e uma forma de coincidir a requisição HTTP que está vindo, para
//a URL e o método especificados em um endpoint (middleware), o que antes era usado apenas
//no endpoint "/"

//habilita para usar rotas
app.UseRouting();

//aqui é onde se cria os endpoints usando Map() ; MapGet() ou MapPost().
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/files/{filename}.{extension=txt}", async (context) =>
    {
        string? file = context.Request.RouteValues["filename"].ToString();
        string? ext = context.Request.RouteValues["extension"].ToString();
        await context.Response.WriteAsync($"{file}.{ext}");
    });

    endpoints.MapPost("/employee/profile/{name=lucas}", async (context) =>
    {
        string? nome = context.Request.RouteValues["name"].ToString();
        await context.Response.WriteAsync($"{nome}");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync($"Pagina chamada na seguinte URL : {context.Request.Path}");
});

app.Run();
