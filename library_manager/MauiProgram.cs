using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using library_manager.Persistance.Data;
using library_manager.Domain.Entities;
using library_manager.Persistance.Repository;
using library_manager.Application.Services;
using CommunityToolkit.Maui;
using library_manager.Domain.Abstractions;
using library_manager.Application.Abstractions;
using library_manager.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace library_manager;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		#region DataBase

		var confBuilder = new ConfigurationBuilder();
		// установка пути к текущему каталогу
		confBuilder.SetBasePath(Directory.GetCurrentDirectory());
		// получаем конфигурацию из файла appsettings.json
		confBuilder.AddJsonFile("E:/Kursovaya 2.0/library_manager/library_manager/appsettings.json");
		// создаем конфигурацию
		var config = confBuilder.Build();
		// получаем строку подключения
		string connectionString = ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");

		var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
		var options = optionsBuilder.UseSqlite(connectionString).Options;
		#endregion


        EFUnitOfWork unitOfWork = new EFUnitOfWork(new LibraryDbContext(options));
		unitOfWork.CreateDatabaseAsync().Wait();
		BookService bookService = new BookService(unitOfWork);
		//bookService.AddAsync(new Book { Id = 1, Name = "War and Peace" }).Wait();
		//bookService.AddAsync(new Book { Id = 2, Name = "1984" }).Wait();

		//bookService.DeleteAsync(3).Wait();
		
        setupServices(builder.Services);

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static void setupServices(IServiceCollection services)
	{
		//services.AddSingleton<IBaseService<Book>>();
		services.AddSingleton<IUnitOfWork, EFUnitOfWork>();
		//services.AddSingleton<IRepository<Book>, EFRepository<Book>>();
		services.AddSingleton<IBookService, BookService>();
		services.AddSingleton<IUserService, UserService>();

		try
		{
            services.AddTransient<BooksViewModel>();
        }
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			
		}
			

		services.AddSingleton<TestPage>();

	}
}
