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

});

app.Run();
