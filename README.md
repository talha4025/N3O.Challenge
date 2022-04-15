# Coding Task (.NET)
This coding task is for a .NET developer and assumes that you are familiar with .NET Core, MVC and REST.

Your task is to build a simple API that manages users using the controller in the provided project file.

There is no absolute time limit and we won't judge you on how long it took you to complete, however we would suggest you spend no more than 2 hours on this task.

1. You must use .NET Core and C#
2. The API should be a ASP.NET Core Web API project
3. The API should consume and return data as JSON
4. You may ignore any security implications, e.g. HTTPS or attempting to authenticate/authorize
6. You may ignore persistent storage. Please use the provided in-memory cache
7. You may use any NuGet packages you wish but be prepared to justify their usage
8. You must use [MediatR](https://github.com/jbogard/MediatR) to implement the web APIs using the CQRS pattern where the implementation of queries and commands can be found inside handlers of the domain project, with the web project responsible for forwarding the commands or queries.

## Specification
You must develop an API that exposes one RESTful endpoint. This endpoint should provide standard CRUD functionality for **Users**.

### Users
#### URL Formats
**POST**
```
/api/users
```
**GET**
```
/api/users
/api/users/{id}
```
**DELETE**
```
/api/users/{id}
```
**PUT**
```
/api/users/{id}
```
#### Fields
| Field Name  | Data Type  | Required | Validation                               |
|--           |--          |--        |--                                        |
| FirstName   | `string`   | true     | max length 128                           |
| LastName    | `string`   | false    | max length 128                           |
| Email       | `string`   | true     | must validate to a typical email address |
| DateOfBirth | `DateTime` | true     | must validate to a valid date            |

 - Every user must have a *unique* email address
 - Users must be 18 years or older at the time of the creation request
 - When returning one user or a list of users include the age of the user in the response as well as the date of birth

## How we will assess your work
Your code should be production quality and utilise design patterns where appropriate. It should conform to best practices and principles such as SOLID, etc. Other things we will take into consideration:

 - Code should be testable
 - We expect you to be mindful of correct HTTP status code usage

To get started clone this repository and when done push it to private repository on your own GitHub account. Add user `n3o-github` as a collaborator so we can take a look.
