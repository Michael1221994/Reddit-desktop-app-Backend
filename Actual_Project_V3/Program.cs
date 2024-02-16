using Microsoft.EntityFrameworkCore;
using Actual_Project_V3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Actual_Project_V3.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<ISaveRepository, SaveRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICRUDRepository, CRUDRepository>();
builder.Services.AddScoped<IFeedRepository, FeedRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ISubredditRepository, SubredditRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();




builder.Services.AddDbContextPool<Context>(
    options => options.UseSqlServer(
          builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddIdentity<User, IdentityRole>().
   AddEntityFrameworkStores<Context>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
});
//builder.Services.AddScoped<Context, Context>();
//builder.Services.AddDbContext<Context>(options =>
//{
//    options.UseSqlServer(builder.Configuration.
//        GetConnectionString("MyConnection"));
//});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});


var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    //void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddDbContext<Context>(options =>
    //        options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

    //    services.AddIdentity<User, IdentityRole>()
    //           .AddEntityFrameworkStores<Context>()
    //           .AddDefaultTokenProviders();

    //    // Register UserManager<TUser> in the dependency injection container
    //    services.AddScoped<UserManager<User>>();
    //}

    //app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.MapControllers();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

