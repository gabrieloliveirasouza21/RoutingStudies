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

});

app.Run();
