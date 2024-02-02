# Social-Media Application To Share Vacations Photos 🌅
> ASP.NET Social-Media Application

The idea behind the app is to upload your own vacation photos to the site. Other users can like and comment on the inserted photos. The application is written in ASP.NET in MVC architecture. The frontend of the application is a bootstrapped library, the application does not use a frontend framework.

_The application is created in my native language, Polish_

<a name="top"></a>
## Table Of Contents 📖
1. [Installation](#installation)
2. [Functionality of the application for the user](#user-functionality)
3. [Functionality of the application for the administrator](#admin-functionality)
4. [API](#api)
5. [Testing the application](#testing)
   
<a name="installation"></a>
## 1. Installation 👋

First, specify the server name and database name in the appsettings.json file

![appsettings](https://user-images.githubusercontent.com/117681023/224831428-2efb6bce-7437-4be3-98a8-e63f067c4363.JPG)

Then in the console, using commands

`add-migration InitialCreate -context AppDbContext`

`update-database -context AppDbContext`

`add-migration UserInit -context UserContext`

`update-database -context UserContext`

we create migrations and send data to the database by creating entities

Microsoft Sql Server Management Studio should automatically create the tables

![baza_danych_tabele](https://user-images.githubusercontent.com/117681023/224831492-e31e00ea-df08-4825-b270-9e3955df8f89.JPG)

Now the application is ready to be launched

<a name="user-functionality"></a>
## 2. Functionality of the application for the user 🙍‍♂️

In the top right corner you will see buttons for login and registration

![logowanie_i_rejestracja](https://user-images.githubusercontent.com/117681023/224831563-e9bec7f3-a823-48bf-9fdb-1f045902c9d3.JPG)

Once a user is registered, it is saved in the database, and you can then proceed to log in.

After logging in, the top right corner of the application shows the name of the logged-in user. When you click it, the user editing window opens.

![user](https://user-images.githubusercontent.com/117681023/224831607-1547f93c-23df-4333-8d98-08574cbc03b8.JPG)

In order to add their own photo to the site, users must click the "Add your own photo" button on the main page.

![dodawanie_zdjecia](https://user-images.githubusercontent.com/117681023/224831660-cbcd2654-4a0b-4f8e-befc-df39c39b00a9.JPG)

When you click it, a form appears, after which you should click the "Add" button.
In this way, the user adds his photo to the site.
If the data is not entered, or entered incorrectly (_for example, too many characters_), an appropriate message will be returned.

![formularz_dodawanie_zdjecia](https://user-images.githubusercontent.com/117681023/224831711-4c471141-6b0b-488d-b0a2-9fa7eb5b8665.JPG)

A user can like other users' photos. Next to the "Like" button, the number of likes of a particular photo is displayed. 
If the user clicks on this button again the like will be taken away.

![polubienie](https://user-images.githubusercontent.com/117681023/224831771-4ee9d3e2-1f06-46ed-b9a9-5b15f1b85bf7.JPG)

Another user option is to add comments. To add a comment, click the "Add Comment" button under the post.
After clicking on it, a form to fill in the content of the comment appears. 
Next to the add comment button is the "Comments" button for displaying the comments of a particular photo.

![komentarze](https://user-images.githubusercontent.com/117681023/224831815-0168a681-2f65-4615-b2f5-da284f0943bb.JPG)

After clicking the "Comments" button, a view opens displaying the comments of a particular photo. Users also have the ability to like the comments.

![wyswietlanie_komentarzy](https://user-images.githubusercontent.com/117681023/224831870-26ca28f3-5458-4545-8fc5-3443a5f182cb.JPG)

It is also worth mentioning that the site has a paging mechanism, so that only three photos are displayed on the page, and to see the next three you need to go to the next page.

![stronnicowanie](https://user-images.githubusercontent.com/117681023/224831928-165e0ced-fca1-4e19-8057-798658e6f3f1.JPG)

<a name="admin-functionality"></a>
## 3. Functionality of the application for the administrator ⚙

## Configuring the admin role on SQL Server

First, using the button to register, we create a new user who will have the role of administrator.

In the SQL Server software (_in my case, Microsoft SQL Server Management Studio 18_), in the AspNetRoles table, we add a role named "admin".

![rola_admin](https://user-images.githubusercontent.com/117681023/224832009-25228114-7089-400a-9b2c-4c520ec9c63f.JPG)

Then from the AspNetUsers table we copy the ID of the user we want to assign the administrator role.
In the AspNetUserRoles table, we assign the admin role to the given user ID.

![przypisanie_roli](https://user-images.githubusercontent.com/117681023/224832073-f9fac5ef-4e60-4de5-806e-a902285cf64d.JPG)

In this way, we assigned an administrator role to a given user.

## Administrator capabilities in the application

At the very top of the page, next to the button to add a photo, there is a "statistics" button that only a user with the administrator role can click.

![statystyki](https://user-images.githubusercontent.com/117681023/224832119-4bdf4582-e390-4a86-af89-4df4756fceee.JPG)

When it is clicked, a view appears with a list of all photos sorted by ID along with their information.
In each line next to the photos there are "Edit" and "Delete" buttons.
After clicking the edit button, the administrator is shown a completed form for editing the selected photo (_the data displayed automatically in the form are the old photo data_).
On the other hand, if you click the "Delete" button, the photo in question will be deleted from the database.

![statystyki_zdjec](https://user-images.githubusercontent.com/117681023/224832170-d3eb737a-fb75-4ab4-87b8-1fdb2cc4b3de.JPG)

<a name="api"></a>
## 4. API 🦅

The application also supports APIs.

The easiest way to test the operation of the API is in a browser extension - the Boomerang tool.

* GET all the pictures

![get](https://user-images.githubusercontent.com/117681023/224832246-d06a53a8-3974-46b4-8e13-3409a3abc997.JPG)

* GET a specific photo

![get_by_id](https://user-images.githubusercontent.com/117681023/224832290-e381366d-29da-4b2f-8dab-3e16f4b5080b.JPG)

* POST

![post](https://user-images.githubusercontent.com/117681023/224832346-258da519-90f9-4983-ab26-79ff5cc61d40.JPG)

* PUT

![put](https://user-images.githubusercontent.com/117681023/224832389-3aa4a079-8b04-48f7-bda5-54169219aa90.JPG)

* DELETE

![delete](https://user-images.githubusercontent.com/117681023/224832437-2dee0238-9b36-4c3b-8762-593d2f313535.JPG)

<a name="testing"></a>
## 5. Testing the application ⚖

The project also has unit tests for the API controller prepared. To run them, right-click on PhotosControllerTest and select "Run tests."

![testowanie](https://user-images.githubusercontent.com/117681023/224832487-5e81d432-8233-443d-8a06-c53b971bcee8.JPG)

[🔼 Back to top](#top)
