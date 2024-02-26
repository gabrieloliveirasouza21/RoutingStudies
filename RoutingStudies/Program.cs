var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//rotas basicamente e uma forma de coincidir a requisi��o HTTP que est� vindo, para
//a URL e o m�todo especificados em um endpoint (middleware), o que antes era usado apenas
//no endpoint "/"

//habilita para usar rotas
app.UseRouting();

//aqui � onde se cria os endpoints usando Map() ; MapGet() ou MapPost().
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/files/{filename?}", async (context) =>
    {
        if (context.Request.RouteValues.ContainsKey("filename"))
        {
            string? file = context.Request.RouteValues["filename"].ToString();
            await context.Response.WriteAsync($"{file}");
        }
        else
        {
            await context.Response.WriteAsync("Arquivo n�o encontrado");
        }
    });
        

    endpoints.MapPost("/employee/profile/{name?}", async (context) =>
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
