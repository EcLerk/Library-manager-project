using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using library_manager.Persistance.Data;
using library_manager.Domain.Entities;
using library_manager.Persistance.Repository;
using library_manager.Application.Services;
using library_manager.Domain.Abstractions;
using library_manager.Application.Abstractions;
using library_manager.ViewModel;
using System.Reflection;
using CommunityToolkit.Maui;
using library_manager.Pages;

namespace library_manager;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        string settingsStream = "library_manager.appsettings.json";

        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		var a = Assembly.GetExecutingAssembly();
		using var stream = a.GetManifestResourceStream(settingsStream);
		builder.Configuration.AddJsonStream(stream);
		
        setupServices(builder.Services);
        AddDbContext(builder);
		SeedData(builder.Services);

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static void setupServices(IServiceCollection services)
	{
		//Services
		services.AddSingleton<IUnitOfWork, EFUnitOfWork>();
		services.AddSingleton<IBookService, BookService>();
		services.AddSingleton<IUserService, UserService>();
		services.AddSingleton<IOrderService, OrderService>();

		//ViewModels
        services.AddSingleton<BooksViewModel>();
        services.AddTransient<BookDetailsViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<SingUpViewModel>();
		services.AddSingleton<AddBookViewModel>();
		services.AddSingleton<EditBookViewModel>();
		services.AddSingleton<UserOrdersPage>();

        //Pages
        services.AddSingleton<NewPage1>();
		services.AddSingleton<UsersBookPage>();
		services.AddTransient<BookDetails>();
		services.AddTransient<LoginPage>();
		services.AddTransient<SingUpPage>();
		services.AddSingleton<AddBookPage>();
		services.AddSingleton<EditBookPage>();
		services.AddTransient<UserOrdersPage>();
	}

    private static void AddDbContext(MauiAppBuilder builder)
    {
        var connectionString = 
            builder.Configuration.GetConnectionString("SqlLiteConnection");

        var options = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseSqlite(connectionString)
		.Options;
		builder.Services.AddScoped<LibraryDbContext>((s) => new LibraryDbContext(options));
    }

	public async static void SeedData(IServiceCollection services)
	{
		using var provider = services.BuildServiceProvider();

		var unitOfWork = provider.GetService<IUnitOfWork>();

		//await unitOfWork.RemoveDatabaseAsync();
		await unitOfWork.CreateDatabaseAsync();

		//var bookList = unitOfWork.BooksRepository.ListAllAsync();

		//IReadOnlyList<Book> books = new List<Book>()
		//{
		//	new Book() { Id = 1, Name = "War and Peace", NumberOfBooks = 1 },
		//	new Book() { Id = 2, Name = "1984", NumberOfBooks = 10 },
		//	new Book() { Id = 3, Name = "Pride and Prejudice", NumberOfBooks = 3 },
		//	new Book() { Id = 4, Name = "The Great Gatsby", NumberOfBooks = 5 },
		//	new Book() { Id = 5, Name = "Gone with the wind", NumberOfBooks = 30 }
		//};

		//foreach (var book in books)
		//{
		//	await unitOfWork.BooksRepository.AddAsync(book);

		//}

		//await unitOfWork.UsersRepository.AddAsync(new User() { UserName = "Lera", Password = "1234",
		//	UserRole = User.Role.Admin });
		//await unitOfWork.SaveAllAsync();
	}
}
