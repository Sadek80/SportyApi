# Sporty

This document explores the design of Sporty, an API for sports community. It provides users with a bunch of training prograns and products/tools for the sports they love.

We will use a basic MVC pattern, where a single server is deployed
on a cloud provider next to a relational database, and serving HTTP traffic from
a secured JWT-based API endpoints.

## Storage

We'll use SQL Server relational database (schema follows) to fast retrieval of data. Entity Framework Core as a Database ORM, although.
Data will be stored on the server on a separate, backed up volume for resilience.

### Schema:

We'll need at least the following entities to implement the service:

**Users**:
| Column | Type |
|--------|------|
| ID | uniqueidentifier |
| First/Last name | nvarchar |
| Password | nvarchar |
| Email | nvarchar |
| Username | nvarchar |
| City | nvarchar |
| Street | nvarchar |
| BuildingNumber | nvarchar |
| RefreshToken_Token | nvarchar |
| RefreshToken_CreatedOn | nvarchar |
| RefreshToken_ExpiresOn | nvarchar |


**CreditCards**:
| Column | Type |
|--------|------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| CreditCardNum | nvarchar |
| Zipcode | nvarchar |
| ExpirationDate | nvarchar |



**Sports**:
| Column | Type |
|--------|------|
| ID | uniqueidentifier |
| Name | nvarchar |


**UserInterests**:
| Column | Type |
|--------|------|
| UserId | uniqueidentifier |
| SprotId | uniqueidentifier |

**Levels**:
| Column | Type |
|---------|------|
| ID | uniqueidentifier |
| SprotId | uniqueidentifier |
| Description | nvarchar |


**Programs**:
| Column | Type |
|---------|------|
| Id | uniqueidentifier |
| SprotId | uniqueidentifier |
| Name | nvarchar |
| Description | nvarchar |
| DescriptionMinimized | nvarchar |
| Provider | nvarchar |
| ImageUrl | nvarchar |
| Location | nvarchar |
| PricePerMonth | decimal |
| LevelId | uniqueidentifier |


**ReservedPrograms**:
| Column | Type |
|---------|------|
| UserId | uniqueidentifier |
| ProgramId | uniqueidentifier |
| Date | datetimeoffset |


**Products**:
| Column | Type |
|---------|------|
| Id | uniqueidentifier |
| SprotId | uniqueidentifier |
| Name | nvarchar |
| Description | nvarchar |
| DescriptionMinimized | nvarchar |
| Price | decimal |
| ImageUrl | nvarchar |
| Quantity | int |
| Brand | nvarchar |



**Orders**:
| Column | Type |
|---------|------|
| Id | uniqueidentifier |
| UserId | uniqueidentifier |
| Date | datetimeoffset |
| TotalPrice | decimal |
| City | nvarchar |
| Street | nvarchar |
| BuildingNumber | nvarchar |
| CreditCardNum | nvarchar |
| Zipcode | nvarchar |
| ExpirationDate | nvarchar |

**OrderItems**:
| Column | Type |
|---------|------|
| OrderId | uniqueidentifier |
| ProductId | uniqueidentifier |
| Amount | int |
| TotalItemPrice | decimal |


## Server

A simple HTTP server is responsible for authentication, serving stored data.

- ASP.NET Core is selected for implementing the server for Scalability.
- Entity Framework Core to be used as an ORM.

### Auth

For v1, a simple JWT-based auth mechanism is to be used, with passwords
encrypted and stored in the database.

### API

**Auth**:

```
api/Auth/signup  [POST]
api/Auth/login  [POST]
api/Auth/refreshToken [GET]
api/Auth/ForgetPassword [POST]
api/Auth/CheckResetToken [POST]
api/Auth/ResetPassword [POST]
```

**UserProfile**:

```
api/users/profile  [POST]
api/users/profile  [PUT]
```


**Sport**:

```
api/sports  [GET]
api/sports  [POST]
```

**Order**:

```
api/orders/history  [GET]
api/orders  [POST]
```


**Product**:

```
api/products  [GET]
api/products  [POST]
api/products/{productId}  [GET]
```

**TrainingPrograms**:

```
api/programs  [GET]
api/programs  [POST]
api/programs/{programId}  [GET]
api/programs/history  [GET]
api/programs/{programId}/enrill  [GET]
```

## Clients

For now we will start with a mobile client, possibly adding web clients later.

The mobile client will be implemented in Flutter.

## Hosting

The code will be hosted on SmarterASP.NET.

We'll deploy the server to a (likely shared) VPS for flexibility. And we'll start with a manual deployment, to be automated
later using Github actions or similar.

Deployed Link: http://mohamedsadk889-001-site1.etempurl.com/swagger/index.html
