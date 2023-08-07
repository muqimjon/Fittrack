// See https://aka.ms/new-console-template for more information
using FTS.Data.Repositories.Common;
using FTS.Service.Services;
using FTS.View.Commons;
using FTS.View.ServiceViews;

Console.WriteLine("Hello, World!");


MainView mainView = new MainView();
mainView.MainMenu();

UnitOfWork unitOfWork = new UnitOfWork();

/*await unitOfWork.UserRepository.CreateAsync(new User()
{
    Email = " kjsnreryjdt",
    Address = "rsthdrhf",
    LastName = "sthsrdfgn",
    FirstName = "srethgrwrgndfg",
    Password = "Passwordrgnfgn",
});

await unitOfWork.SaveAsync();*/


UserService userService = new UserService();
/*
await userService.CreateAsync(new UserCreationDto()
{
    Password = "password",
    Email = " kjsnreryjdt",
    Address = "rsthdrhf",
    LastName = "sthsrdfgn",
    FirstName = "srethgrwrgndfg",
});*/


UserServiceView userServiceView = new UserServiceView();
//userServiceView.CreateAsync();



