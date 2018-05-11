# cameron-wagstaff-project1
# Hopefully hosted at food.cameronwagstaff.net
# project 1: restaurant review application
April 2018 .NET / Pushpinder Kaur, Nick Escalona

## functionality
* display top 3 restaurants by average rating
* display all restaurants
  * should allow more than one method of sorting
* display details of a restaurant
* display all the reviews of a restaurant
* create, update, delete restaurants
* create, update, delete reviews
* search restaurants (e.g. by partial name), and display all matching results

## structure
### class library
* all business logic must be here - sorting, search logic
* should have a helper class that can serialize and deserialize restaurant and review objects in some way (XML or JSON)

### data access
* manages database connection
* use repository pattern for separation of concerns

### user interface
* ASP.NET MVC application
* server-side validation
* client-side validation
* should not directly depend on data access layer

### unit test
* should not cause actual database access
* should develop some parts of application with test-driven development - writing the tests first

## object model
### restaurant
* has a name and other relevant data (e.g. location)
* has many reviews
* has average rating, computed from all its reviews

### review
* has a rating and other relevant data (e.g. reviewer name)

## technologies
* C#/.NET
* Entity Framework
* ASP.NET MVC
* Amazon RDS for SQL Server
* xUnit, NUnit, or MSTest
* NLog