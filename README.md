
![Screenshot 2021-10-01 011322](https://user-images.githubusercontent.com/37630292/135517556-e8757cf9-44fa-428b-a476-a7236df5066a.png)

 #

 This is an API solution & also template for support minimal e-commerce application using .NET5 following the principles of Clean Architecture inspire from [**Jason Taylor**](https://github.com/jasontaylordev/CleanArchitecture). Use this template button or by installing and running the associated NuGet package (see Getting Started for full details). It's easy to jump start from beginning you can try it the barebone project [v0.0.1-beta](https://github.com/sefatanam/ZCommerce/releases/tag/v-0.0.1-beta)

[Recommend to learn Clean Architecture with ASP.NET Core 3.0 • Jason Taylor • GOTO 2019](https://www.youtube.com/watch?v=dK4Yb6-LxAk)


## **Technologies**

* [NET5](https://devblogs.microsoft.com/dotnet/introducing-net-5/)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [XUnit](https://xunit.net/), [FluentAssertions](https://fluentassertions.com/), [Moq](https://github.com/moq) & [Respawn](https://github.com/jbogard/Respawn)
* [SQLite](https://www.sqlite.org/index.htmls)


## **Getting Started**

1. Install the latest [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
2. Install Redis using docker & run ``docker run -d --rm -p 6379:6379 redis``
3. Go to ``ZCommerce.API`` & Run `dotnet run` to run this project template
#
## **Database Migrations**

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project src/ZCommerce.Infrastructure` (optional if in this folder)
* `--startup-project src/ZCommerce.Api`
* `--output-dir Data/Migrations`

For example, to add a new migration from the root folder ( ``src`` ):

 `dotnet ef migrations add "SampleMigration" --project src/ZCommerce.Infrastructure --startup-project src/ZCommerce.Api --output-dir Data\Migrations`
    
Update Database,

 ` dotnet ef database update --project .src/ZCommerce.Infrastructure --startup-project .src/ZCommerce.Api/`

#

 ## **Overview**

### ***ZCommerce.Domain***

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### ***ZCommerce.Application***

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### ***ZCommerce.Infrastructure***

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.


### ***ZCommerce.API***
This layer contain all API end points and contract with **ZCommerce.Application** via MediatR.

#

## **Support** 
<img src="https://media.giphy.com/media/hvRJCLFzcasrR4ia7z/giphy.gif" width="60px">

If you are having problems, please let us know by [raising a new issue](https://github.com/sefatanam/ZCommerce/issues/new).



#
## **License**

This project is licensed with the [MIT license](LICENSE).


**Connect with me**
<p align="left">
<a href="https://twitter.com/sefatanam" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/twitter.svg" alt="haasib25" height="30" width="40" /></a>
<a href="https://www.linkedin.com/in/SefatAnam" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/linked-in-alt.svg" alt="bdshanto" height="30" width="40" /></a>
<a href="https://stackoverflow.com/users/13146200/sefat-anam" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/stack-overflow.svg" alt="bdshanto" height="30" width="40" /></a>
<a href="https://www.instagram.com/im.sefat/" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/instagram.svg" alt="hsibbd" height="30" width="40" /></a>
<a href="https://medium.com/sefatanam" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/medium.svg" alt="bdshanto" height="30" width="40" /></a>
  
</p>