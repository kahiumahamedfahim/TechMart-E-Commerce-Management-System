# TechMart E-Commerce Management System

## Project Information

| Field          | Value                        |
| -------------- | ---------------------------- |
| Project Name   | TechMart                     |
| Project Type   | E-Commerce Management System |
| Technology     | ASP.NET Core MVC             |
| Architecture   | Layered Architecture         |
| Database       | SQL Server                   |
| ORM            | Entity Framework Core        |
| Authentication | Cookie Authentication        |
| Version        | 1.0                          |
| Status         | Planning                     |

---

# Vision

TechMart is a technology-focused e-commerce platform inspired by modern online retailers such as technology stores and online marketplaces.

The system allows administrators to manage products, brands, categories, inventory, customers, and orders while customers can browse products, manage carts, and place orders.

The primary goal of this project is to learn enterprise-level ASP.NET Core MVC development through real-world business implementation.

---

# System Modules

## Core Modules

* Authentication & Authorization
* User Management
* Category Management
* Brand Management
* Product Management
* Customer Management
* Cart Management
* Order Management
* Inventory Management
* Reporting System
* Analytics Dashboard

---

# User Roles

## SuperAdmin

System Owner

Responsibilities:

* Create Admin
* Manage Admin Accounts
* Access All Modules
* View Analytics
* Configure System

---

## Admin

Store Administrator

Responsibilities:

* Manage Categories
* Manage Brands
* Manage Products
* Manage Inventory
* Manage Orders
* Manage Customers

---

## Customer

Responsibilities:

* Register Account
* Verify Email
* Browse Products
* Manage Cart
* Place Orders
* View Order History

---

# Development Phases

---

# Phase 1: Authentication & Admin Management

## Objective

Build the security foundation of the system and establish role-based access control.

---

## Features

### Authentication

* Register SuperAdmin
* Login
* Logout
* Cookie Authentication
* Claims Creation
* Password Hashing

### Email Verification

* Generate Verification Code
* Send Verification Email
* Verify Email
* Prevent Login Until Verification

### Password Management

* Forgot Password
* Reset Password
* Change Password

### Profile Management

* View Profile
* Update Profile
* Upload Profile Image

### Admin Management

* Create Admin
* Edit Admin
* Disable Admin
* View Admin List

---

## Workflow

```text
Register SuperAdmin
        ↓
Verify Email
        ↓
Login
        ↓
Dashboard
        ↓
Create Admin
        ↓
Admin Login
```

---

## Database Tables

### Users

* Id
* UserId
* Name
* Email
* PasswordHash
* ProfileImage
* Role
* IsEmailVerified
* IsActive
* CreatedAt
* UpdatedAt

### EmailVerificationCodes

* Id
* UserId
* VerificationCode
* ExpiryTime
* IsUsed

### PasswordResetCodes

* Id
* UserId
* ResetCode
* ExpiryTime
* IsUsed

---

## Deliverables

* Secure Login System
* Email Verification System
* Profile Management
* Admin Management
* Authorization System

---

# Phase 2: Category Management

## Objective

Provide a structured product classification system.

---

## Features

* Create Category
* Edit Category
* Delete Category
* Category Image Upload
* View Categories
* Search Categories

---

## Workflow

```text
Admin Login
      ↓
Category Module
      ↓
Create Category
      ↓
Category Available For Products
```

---

## Database Tables

### Categories

* Id
* CategoryCode
* Name
* Description
* Image
* IsActive
* CreatedAt

---

## Deliverables

* Category CRUD
* Category Image Upload
* Category Search

---

# Phase 3: Brand Management

## Objective

Manage manufacturer and product brands.

---

## Features

* Create Brand
* Edit Brand
* Delete Brand
* Brand Logo Upload
* Brand Search

---

## Database Tables

### Brands

* Id
* BrandCode
* Name
* Description
* Logo
* IsActive
* CreatedAt

---

## Deliverables

* Brand CRUD
* Brand Logo Upload
* Brand Search

---

# Phase 4: Product Management

## Objective

Manage all products available for sale.

---

## Features

### Product Information

* Product Name
* Product Code
* Description
* Price
* Stock Quantity

### Product Images

* Thumbnail Image
* Multiple Product Images

### Product Management

* Add Product
* Edit Product
* Delete Product
* Product Details
* Search Product

---

## Workflow

```text
Category Created
      ↓
Brand Created
      ↓
Product Created
      ↓
Available For Sale
```

---

## Database Tables

### Products

* Id
* ProductCode
* Name
* Description
* Price
* Stock
* CategoryId
* BrandId
* ThumbnailImage
* IsActive
* CreatedAt

### ProductImages

* Id
* ProductId
* ImagePath

---

## Deliverables

* Product CRUD
* Product Gallery
* Product Search

---

# Phase 5: Customer Management

## Objective

Manage customer accounts and profiles.

---

## Features

* Customer Registration
* Email Verification
* Customer Login
* Customer Profile
* Customer Status Management

---

## Database Tables

### Users

(Customer Role)

---

## Deliverables

* Customer Account System
* Customer Management

---

# Phase 6: Cart System

## Objective

Allow customers to collect products before checkout.

---

## Features

* Add To Cart
* Update Quantity
* Remove Product
* View Cart
* Cart Summary

---

## Database Tables

### Carts

* Id
* UserId
* CreatedAt

### CartItems

* Id
* CartId
* ProductId
* Quantity

---

## Deliverables

* Shopping Cart Module

---

# Phase 7: Order System

## Objective

Process customer purchases.

---

## Features

* Checkout
* Place Order
* Order Details
* Order History
* Order Tracking

---

## Order Status

* Pending
* Confirmed
* Processing
* Shipped
* Delivered
* Cancelled

---

## Database Tables

### Orders

* Id
* OrderNumber
* UserId
* TotalAmount
* Status
* OrderDate

### OrderItems

* Id
* OrderId
* ProductId
* Quantity
* UnitPrice

---

## Deliverables

* Order Processing System

---

# Phase 8: Inventory Management

## Objective

Track stock movement and inventory levels.

---

## Features

* Stock In
* Stock Out
* Inventory History
* Low Stock Alerts

---

## Database Tables

### InventoryTransactions

* Id
* ProductId
* TransactionType
* Quantity
* Remarks
* CreatedAt

---

## Deliverables

* Inventory Tracking System

---

# Phase 9: Reporting System

## Objective

Provide business reports.

---

## Features

* Daily Sales Report
* Monthly Sales Report
* Product Report
* Customer Report
* Inventory Report

---

## Deliverables

* Sales Reports
* Inventory Reports

---

# Phase 10: Analytics System

## Objective

Provide business insights and performance analysis.

---

## Dashboard Features

### Statistics

* Total Revenue
* Total Orders
* Total Customers
* Total Products

### Analytics

* Best Selling Products
* Best Selling Brands
* Top Categories
* Revenue Trends
* Order Trends
* Low Stock Products

### Charts

* Monthly Revenue Chart
* Order Trend Chart
* Product Performance Chart

---

## Deliverables

* Analytics Dashboard
* Business Intelligence Reports

---

# Final Architecture

```text
TechMart
│
├── Controllers
├── Services
├── Repositories
├── Entities
├── ViewModels
├── Data
├── Configurations
├── Views
├── Helpers
├── Middleware
├── wwwroot
│   ├── uploads
│   │   ├── profiles
│   │   ├── categories
│   │   ├── brands
│   │   └── products
│
└── Documentation
```

---

# Project Completion Goal

By completing TechMart, the developer should gain practical experience in:

* ASP.NET Core MVC
* Layered Architecture
* Entity Framework Core
* SQL Server
* Cookie Authentication
* Role-Based Authorization
* Email Verification
* File Upload Management
* Inventory Management
* Order Processing
* Reporting
* Analytics
* Production Deployment
# TechMart E-Commerce Management System

## Project Information

| Field          | Value                        |
| -------------- | ---------------------------- |
| Project Name   | TechMart                     |
| Project Type   | E-Commerce Management System |
| Technology     | ASP.NET Core MVC             |
| Architecture   | Layered Architecture         |
| Database       | SQL Server                   |
| ORM            | Entity Framework Core        |
| Authentication | Cookie Authentication        |
| Version        | 1.0                          |
| Status         | Planning                     |

---

# Vision

TechMart is a technology-focused e-commerce platform inspired by modern online retailers such as technology stores and online marketplaces.

The system allows administrators to manage products, brands, categories, inventory, customers, and orders while customers can browse products, manage carts, and place orders.

The primary goal of this project is to learn enterprise-level ASP.NET Core MVC development through real-world business implementation.

---

# System Modules

## Core Modules

* Authentication & Authorization
* User Management
* Category Management
* Brand Management
* Product Management
* Customer Management
* Cart Management
* Order Management
* Inventory Management
* Reporting System
* Analytics Dashboard

---

# User Roles

## SuperAdmin

System Owner

Responsibilities:

* Create Admin
* Manage Admin Accounts
* Access All Modules
* View Analytics
* Configure System

---

## Admin

Store Administrator

Responsibilities:

* Manage Categories
* Manage Brands
* Manage Products
* Manage Inventory
* Manage Orders
* Manage Customers

---

## Customer

Responsibilities:

* Register Account
* Verify Email
* Browse Products
* Manage Cart
* Place Orders
* View Order History

---

# Development Phases

---

# Phase 1: Authentication & Admin Management

## Objective

Build the security foundation of the system and establish role-based access control.

---

## Features

### Authentication

* Register SuperAdmin
* Login
* Logout
* Cookie Authentication
* Claims Creation
* Password Hashing

### Email Verification

* Generate Verification Code
* Send Verification Email
* Verify Email
* Prevent Login Until Verification

### Password Management

* Forgot Password
* Reset Password
* Change Password

### Profile Management

* View Profile
* Update Profile
* Upload Profile Image

### Admin Management

* Create Admin
* Edit Admin
* Disable Admin
* View Admin List

---

## Workflow

```text
Register SuperAdmin
        ↓
Verify Email
        ↓
Login
        ↓
Dashboard
        ↓
Create Admin
        ↓
Admin Login
```

---

## Database Tables

### Users

* Id
* UserId
* Name
* Email
* PasswordHash
* ProfileImage
* Role
* IsEmailVerified
* IsActive
* CreatedAt
* UpdatedAt

### EmailVerificationCodes

* Id
* UserId
* VerificationCode
* ExpiryTime
* IsUsed

### PasswordResetCodes

* Id
* UserId
* ResetCode
* ExpiryTime
* IsUsed

---

## Deliverables

* Secure Login System
* Email Verification System
* Profile Management
* Admin Management
* Authorization System

---

# Phase 2: Category Management

## Objective

Provide a structured product classification system.

---

## Features

* Create Category
* Edit Category
* Delete Category
* Category Image Upload
* View Categories
* Search Categories

---

## Workflow

```text
Admin Login
      ↓
Category Module
      ↓
Create Category
      ↓
Category Available For Products
```

---

## Database Tables

### Categories

* Id
* CategoryCode
* Name
* Description
* Image
* IsActive
* CreatedAt

---

## Deliverables

* Category CRUD
* Category Image Upload
* Category Search

---

# Phase 3: Brand Management

## Objective

Manage manufacturer and product brands.

---

## Features

* Create Brand
* Edit Brand
* Delete Brand
* Brand Logo Upload
* Brand Search

---

## Database Tables

### Brands

* Id
* BrandCode
* Name
* Description
* Logo
* IsActive
* CreatedAt

---

## Deliverables

* Brand CRUD
* Brand Logo Upload
* Brand Search

---

# Phase 4: Product Management

## Objective

Manage all products available for sale.

---

## Features

### Product Information

* Product Name
* Product Code
* Description
* Price
* Stock Quantity

### Product Images

* Thumbnail Image
* Multiple Product Images

### Product Management

* Add Product
* Edit Product
* Delete Product
* Product Details
* Search Product

---

## Workflow

```text
Category Created
      ↓
Brand Created
      ↓
Product Created
      ↓
Available For Sale
```

---

## Database Tables

### Products

* Id
* ProductCode
* Name
* Description
* Price
* Stock
* CategoryId
* BrandId
* ThumbnailImage
* IsActive
* CreatedAt

### ProductImages

* Id
* ProductId
* ImagePath

---

## Deliverables

* Product CRUD
* Product Gallery
* Product Search

---

# Phase 5: Customer Management

## Objective

Manage customer accounts and profiles.

---

## Features

* Customer Registration
* Email Verification
* Customer Login
* Customer Profile
* Customer Status Management

---

## Database Tables

### Users

(Customer Role)

---

## Deliverables

* Customer Account System
* Customer Management

---

# Phase 6: Cart System

## Objective

Allow customers to collect products before checkout.

---

## Features

* Add To Cart
* Update Quantity
* Remove Product
* View Cart
* Cart Summary

---

## Database Tables

### Carts

* Id
* UserId
* CreatedAt

### CartItems

* Id
* CartId
* ProductId
* Quantity

---

## Deliverables

* Shopping Cart Module

---

# Phase 7: Order System

## Objective

Process customer purchases.

---

## Features

* Checkout
* Place Order
* Order Details
* Order History
* Order Tracking

---

## Order Status

* Pending
* Confirmed
* Processing
* Shipped
* Delivered
* Cancelled

---

## Database Tables

### Orders

* Id
* OrderNumber
* UserId
* TotalAmount
* Status
* OrderDate

### OrderItems

* Id
* OrderId
* ProductId
* Quantity
* UnitPrice

---

## Deliverables

* Order Processing System

---

# Phase 8: Inventory Management

## Objective

Track stock movement and inventory levels.

---

## Features

* Stock In
* Stock Out
* Inventory History
* Low Stock Alerts

---

## Database Tables

### InventoryTransactions

* Id
* ProductId
* TransactionType
* Quantity
* Remarks
* CreatedAt

---

## Deliverables

* Inventory Tracking System

---

# Phase 9: Reporting System

## Objective

Provide business reports.

---

## Features

* Daily Sales Report
* Monthly Sales Report
* Product Report
* Customer Report
* Inventory Report

---

## Deliverables

* Sales Reports
* Inventory Reports

---

# Phase 10: Analytics System

## Objective

Provide business insights and performance analysis.

---

## Dashboard Features

### Statistics

* Total Revenue
* Total Orders
* Total Customers
* Total Products

### Analytics

* Best Selling Products
* Best Selling Brands
* Top Categories
* Revenue Trends
* Order Trends
* Low Stock Products

### Charts

* Monthly Revenue Chart
* Order Trend Chart
* Product Performance Chart

---

## Deliverables

* Analytics Dashboard
* Business Intelligence Reports

---

# Final Architecture

```text
TechMart
│
├── Controllers
├── Services
├── Repositories
├── Entities
├── ViewModels
├── Data
├── Configurations
├── Views
├── Helpers
├── Middleware
├── wwwroot
│   ├── uploads
│   │   ├── profiles
│   │   ├── categories
│   │   ├── brands
│   │   └── products
│
└── Documentation
```

---

# Project Completion Goal

By completing TechMart, the developer should gain practical experience in:

* ASP.NET Core MVC
* Layered Architecture
* Entity Framework Core
* SQL Server
* Cookie Authentication
* Role-Based Authorization
* Email Verification
* File Upload Management
* Inventory Management
* Order Processing
* Reporting
* Analytics
* Production Deployment
k# TechMart E-Commerce Management System

## Project Information

| Field          | Value                        |
| -------------- | ---------------------------- |
| Project Name   | TechMart                     |
| Project Type   | E-Commerce Management System |
| Technology     | ASP.NET Core MVC             |
| Architecture   | Layered Architecture         |
| Database       | SQL Server                   |
| ORM            | Entity Framework Core        |
| Authentication | Cookie Authentication        |
| Version        | 1.0                          |
| Status         | Planning                     |

---

# Vision

TechMart is a technology-focused e-commerce platform inspired by modern online retailers such as technology stores and online marketplaces.

The system allows administrators to manage products, brands, categories, inventory, customers, and orders while customers can browse products, manage carts, and place orders.

The primary goal of this project is to learn enterprise-level ASP.NET Core MVC development through real-world business implementation.

---

# System Modules

## Core Modules

* Authentication & Authorization
* User Management
* Category Management
* Brand Management
* Product Management
* Customer Management
* Cart Management
* Order Management
* Inventory Management
* Reporting System
* Analytics Dashboard

---

# User Roles

## SuperAdmin

System Owner

Responsibilities:

* Create Admin
* Manage Admin Accounts
* Access All Modules
* View Analytics
* Configure System

---

## Admin

Store Administrator

Responsibilities:

* Manage Categories
* Manage Brands
* Manage Products
* Manage Inventory
* Manage Orders
* Manage Customers

---

## Customer

Responsibilities:

* Register Account
* Verify Email
* Browse Products
* Manage Cart
* Place Orders
* View Order History

---

# Development Phases

---

# Phase 1: Authentication & Admin Management

## Objective

Build the security foundation of the system and establish role-based access control.

---

## Features

### Authentication

* Register SuperAdmin
* Login
* Logout
* Cookie Authentication
* Claims Creation
* Password Hashing

### Email Verification

* Generate Verification Code
* Send Verification Email
* Verify Email
* Prevent Login Until Verification

### Password Management

* Forgot Password
* Reset Password
* Change Password

### Profile Management

* View Profile
* Update Profile
* Upload Profile Image

### Admin Management

* Create Admin
* Edit Admin
* Disable Admin
* View Admin List

---

## Workflow

```text
Register SuperAdmin
        ↓
Verify Email
        ↓
Login
        ↓
Dashboard
        ↓
Create Admin
        ↓
Admin Login
```

---

## Database Tables

### Users

* Id
* UserId
* Name
* Email
* PasswordHash
* ProfileImage
* Role
* IsEmailVerified
* IsActive
* CreatedAt
* UpdatedAt

### EmailVerificationCodes

* Id
* UserId
* VerificationCode
* ExpiryTime
* IsUsed

### PasswordResetCodes

* Id
* UserId
* ResetCode
* ExpiryTime
* IsUsed

---

## Deliverables

* Secure Login System
* Email Verification System
* Profile Management
* Admin Management
* Authorization System

---

# Phase 2: Category Management

## Objective

Provide a structured product classification system.

---

## Features

* Create Category
* Edit Category
* Delete Category
* Category Image Upload
* View Categories
* Search Categories

---

## Workflow

```text
Admin Login
      ↓
Category Module
      ↓
Create Category
      ↓
Category Available For Products
```

---

## Database Tables

### Categories

* Id
* CategoryCode
* Name
* Description
* Image
* IsActive
* CreatedAt

---

## Deliverables

* Category CRUD
* Category Image Upload
* Category Search

---

# Phase 3: Brand Management

## Objective

Manage manufacturer and product brands.

---

## Features

* Create Brand
* Edit Brand
* Delete Brand
* Brand Logo Upload
* Brand Search

---

## Database Tables

### Brands

* Id
* BrandCode
* Name
* Description
* Logo
* IsActive
* CreatedAt

---

## Deliverables

* Brand CRUD
* Brand Logo Upload
* Brand Search

---

# Phase 4: Product Management

## Objective

Manage all products available for sale.

---

## Features

### Product Information

* Product Name
* Product Code
* Description
* Price
* Stock Quantity

### Product Images

* Thumbnail Image
* Multiple Product Images

### Product Management

* Add Product
* Edit Product
* Delete Product
* Product Details
* Search Product

---

## Workflow

```text
Category Created
      ↓
Brand Created
      ↓
Product Created
      ↓
Available For Sale
```

---

## Database Tables

### Products

* Id
* ProductCode
* Name
* Description
* Price
* Stock
* CategoryId
* BrandId
* ThumbnailImage
* IsActive
* CreatedAt

### ProductImages

* Id
* ProductId
* ImagePath

---

## Deliverables

* Product CRUD
* Product Gallery
* Product Search

---

# Phase 5: Customer Management

## Objective

Manage customer accounts and profiles.

---

## Features

* Customer Registration
* Email Verification
* Customer Login
* Customer Profile
* Customer Status Management

---

## Database Tables

### Users

(Customer Role)

---

## Deliverables

* Customer Account System
* Customer Management

---

# Phase 6: Cart System

## Objective

Allow customers to collect products before checkout.

---

## Features

* Add To Cart
* Update Quantity
* Remove Product
* View Cart
* Cart Summary

---

## Database Tables

### Carts

* Id
* UserId
* CreatedAt

### CartItems

* Id
* CartId
* ProductId
* Quantity

---

## Deliverables

* Shopping Cart Module

---

# Phase 7: Order System

## Objective

Process customer purchases.

---

## Features

* Checkout
* Place Order
* Order Details
* Order History
* Order Tracking

---

## Order Status

* Pending
* Confirmed
* Processing
* Shipped
* Delivered
* Cancelled

---

## Database Tables

### Orders

* Id
* OrderNumber
* UserId
* TotalAmount
* Status
* OrderDate

### OrderItems

* Id
* OrderId
* ProductId
* Quantity
* UnitPrice

---

## Deliverables

* Order Processing System

---

# Phase 8: Inventory Management

## Objective

Track stock movement and inventory levels.

---

## Features

* Stock In
* Stock Out
* Inventory History
* Low Stock Alerts

---

## Database Tables

### InventoryTransactions

* Id
* ProductId
* TransactionType
* Quantity
* Remarks
* CreatedAt

---

## Deliverables

* Inventory Tracking System

---

# Phase 9: Reporting System

## Objective

Provide business reports.

---

## Features

* Daily Sales Report
* Monthly Sales Report
* Product Report
* Customer Report
* Inventory Report

---

## Deliverables

* Sales Reports
* Inventory Reports

---

# Phase 10: Analytics System

## Objective

Provide business insights and performance analysis.

---

## Dashboard Features

### Statistics

* Total Revenue
* Total Orders
* Total Customers
* Total Products

### Analytics

* Best Selling Products
* Best Selling Brands
* Top Categories
* Revenue Trends
* Order Trends
* Low Stock Products

### Charts

* Monthly Revenue Chart
* Order Trend Chart
* Product Performance Chart

---

## Deliverables

* Analytics Dashboard
* Business Intelligence Reports

---

# Final Architecture

```text
TechMart
│
├── Controllers
├── Services
├── Repositories
├── Entities
├── ViewModels
├── Data
├── Configurations
├── Views
├── Helpers
├── Middleware
├── wwwroot
│   ├── uploads
│   │   ├── profiles
│   │   ├── categories
│   │   ├── brands
│   │   └── products
│
└── Documentation
```

---

# Project Completion Goal

By completing TechMart, the developer should gain practical experience in:

* ASP.NET Core MVC
* Layered Architecture
* Entity Framework Core
* SQL Server
* Cookie Authentication
* Role-Based Authorization
* Email Verification
* File Upload Management
* Inventory Management
* Order Processing
* Reporting
* Analytics
* Production Deployment
