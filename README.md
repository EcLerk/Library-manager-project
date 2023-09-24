# Library-manager-project  


## About

The automated library management system provides the ability to automate processes for libraries of any type and purpose.  
  
**The development was carried out using .NET MAUI**  

## Content
- [Description](#description)
- [Application Interface](#application-interface)
  - [SingIn&SingUp Pages](#singinsingup-pages)
  - [Main Page](#main-page)
  - [Details Page](#details-page)
  - [Orders Page](#orders-page)
- [UseCase Diagram](#usecase-diagram)
- [Class Diagram](#class-diagram)
- [Developers](#developers)
## Description
An automated library management system is a software solution designed to automate and optimize library processes. It provides tools for efficient inventory, cataloging, storage and retrieval of books, as well as management of checkout and return of materials, helping to improve library operations and provide a better patron experience. 

Design patterns such as MVVM, Repository and UnitOfWork were used. Connection to the database was made using the Entity Framework.  
## Application Interface
In the application, all users are divided into two roles: *administrators* and *readers*. All users have access to the book collection, and the user can also select a book and go to a page with more detailed information about the book. The reader can order books and view all their orders on a separate page. The administrator has access to add, delete and edit information about books stored in the library. A user with the administrator role can view lists of ordered and issued books.
### SingIn&SingUp Pages
<div>
  <img src="Media/LogIn.png" width=40% height=60%>
  <img src="Media/SingUp.png" width=40% height=60%>
</div> 

### Main Page
After successful registration or authorization, the user is redirected to the main page (see pic.). This page displays a list of all books held by the library. The list elements themselves contain the Id of the book, its title and the number of books currently available.  

<img src="Media/MainPage.png" width=60% height=60%>

### Details Page
Double clicking on a book will take you to a page with detailed information.  

<img src="Media/DetailsPage.png" width=60% height=60%>

### Orders Page
The reader has the opportunity to order a book by clicking on the “Order” button. The book will be added to the user's order list

<img src="Media/OrdersPage.png" width=60% height=60%>

## UseCase Diagram
![newUseCase](https://github.com/EcLerk/Library-manager-project/assets/87236352/4a2321cf-74f1-4ce4-b336-0be360be2ff4)

## Class Diagram
![ClassDiagram1](https://github.com/EcLerk/Library-manager-project/assets/87236352/b4462a77-a2e6-4153-9438-2df09d57e8ab)
## Developers

- [EcLerk](https://github.com/EcLerk)
