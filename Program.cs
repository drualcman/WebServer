using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
int port = args.Length > 0 ? (int.TryParse(args[0], out int p) ? p : 44500) : 44500;
builder.WebHost.UseUrls($"https://localhost:{port}");

var app = builder.Build();

app.UseFileServer(new FileServerOptions 
{
    FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
});

app.Run();
