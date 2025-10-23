using CA1_Nicolai_de_Groot.Components;
using CA1_Nicolai_deGroot.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<WikipediaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
