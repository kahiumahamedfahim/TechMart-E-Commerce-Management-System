# TechMart E-Commerce Management System

# Phase 2 - Category Management

---

# Module Overview

## Module Name
Category Management

## Phase
Phase 2

## Developed By
Admin Panel

## Objective

The Category Management module provides a centralized system for organizing products into logical groups. It enables administrators to create, manage, search, and maintain product categories that are later used throughout the product management system.

---

# Business Goals

- Organize products efficiently
- Improve product discoverability
- Reduce duplicate categories
- Support scalable inventory management
- Maintain clean product hierarchy

---

# Functional Requirements

## Category CRUD

The administrator should be able to

- Create Category
- View Categories
- Edit Category
- Delete Category
- Activate/Deactivate Category

---

## Category Image

Administrator can

- Upload category image
- Replace existing image
- Remove image (optional)

Supported formats

- jpg
- jpeg
- png
- webp

Maximum Size

- 2 MB

---

## Category Search

Administrator can search using

- Category Name
- Category Code

Search should support

- Partial Match
- Case Insensitive Search

Example

Searching

```
Ele
```

Should return

```
Electronics
Electrical
Electronic Accessories
```

---

# User Workflow

```
Admin Login
      │
      ▼
Dashboard
      │
      ▼
Category Management
      │
      ├───────────────┐
      ▼               ▼
Create Category   View Categories
      │               │
      ▼               ▼
Save Category     Search/Edit/Delete
      │
      ▼
Category Available During Product Creation
```

---

# Database Design

## Table : Categories

| Column | Type | Description |
|---------|------|-------------|
| Id | bigint | Primary Key |
| CategoryCode | nvarchar(20) | Unique Category Code |
| Name | nvarchar(100) | Category Name |
| Description | nvarchar(500) | Category Description |
| Image | nvarchar(255) | Image Path |
| IsActive | bit | Active Status |
| CreatedAt | datetime | Creation Date |

---

# Entity

```csharp
Category
{
    Id
    CategoryCode
    Name
    Description
    Image
    IsActive
    CreatedAt
}
```

---

# Folder Structure

```
Modules
│
└── Category
    │
    ├── Controllers
    │      CategoryController.cs
    │
    ├── Services
    │      ICategoryService.cs
    │      CategoryService.cs
    │
    ├── Repositories
    │      ICategoryRepository.cs
    │      CategoryRepository.cs
    │
    ├── DTOs
    │      CreateCategoryDto.cs
    │      UpdateCategoryDto.cs
    │      CategoryDto.cs
    │
    ├── ViewModels
    │      CategoryViewModel.cs
    │
    ├── Validators
    │
    ├── Views
    │      Create.cshtml
    │      Edit.cshtml
    │      Index.cshtml
    │
    └── Images
           Categories
```

---

# Layered Architecture

```
Controller
      │
      ▼
Service Layer
      │
      ▼
Repository Layer
      │
      ▼
DbContext
      │
      ▼
SQL Server
```

---

# Implementation Roadmap

## Step 1

Database Table

- Categories

---

## Step 2

Create Entity

```
Category.cs
```

---

## Step 3

Entity Configuration

```
CategoryConfiguration.cs
```

Configure

- Required fields
- Max Length
- Unique Code
- Default Values

---

## Step 4

Migration

```
Add-Migration AddCategoryModule

Update-Database
```

---

## Step 5

DTOs

Create

```
CreateCategoryDto
```

Update

```
UpdateCategoryDto
```

Read

```
CategoryDto
```

---

## Step 6

Repository Layer

Interface

```
ICategoryRepository
```

Methods

```
Add()

Update()

Delete()

GetAll()

GetById()

Search()

Exists()

Save()
```

---

## Step 7

Service Layer

Business Logic

- Generate Category Code
- Validate Duplicate Category
- Upload Image
- Delete Image
- Search
- Update

---

## Step 8

Controller

Actions

```
Index()

Create()

Create(Category)

Edit(id)

Edit(Category)

Delete(id)

Search()

Details(id)
```

---

## Step 9

Views

```
Index

Create

Edit

Details
```

---

# Category Code Generation

Automatically generate

Example

```
CAT0001

CAT0002

CAT0003
```

Rule

```
Prefix

CAT

+

4 Digit Number
```

---

# Validation Rules

## Category Name

Required

Maximum

100 Characters

No duplicate names

---

## Category Code

Generated Automatically

Unique

Read Only

---

## Description

Optional

Maximum

500 Characters

---

## Image

Optional

Maximum

2 MB

Allowed Types

```
jpg

jpeg

png

webp
```

---

# Business Rules

✔ Category Name must be unique

✔ Category Code must be unique

✔ Deleted category should not break existing products

✔ Inactive category cannot be selected while creating products

✔ Every product belongs to one category

---

# Search Flow

```
Search Text
      │
      ▼
Controller
      │
      ▼
Service
      │
      ▼
Repository
      │
      ▼
SQL Query
      │
      ▼
Filtered Categories
```

---

# Image Upload Flow

```
Select Image
      │
      ▼
Validate Size
      │
      ▼
Validate Extension
      │
      ▼
Save File
      │
      ▼
Store File Path
      │
      ▼
Save Database
```

---

# Exception Handling

Duplicate Category

```
Category already exists.
```

Invalid Image

```
Only jpg, jpeg, png and webp are allowed.
```

Large Image

```
Maximum image size is 2 MB.
```

Category Not Found

```
Category does not exist.
```

---

# Deliverables

- Category CRUD
- Category Image Upload
- Category Search
- Duplicate Validation
- Image Validation
- Soft Delete Support
- Layered Architecture
- Repository Pattern
- Clean UI
- Responsive Pages

---

# Future Enhancements

- Parent Category
- Child Category
- Unlimited Category Levels
- Drag & Drop Sorting
- Category Slug
- SEO Metadata
- Featured Categories
- Category Icons
- Bulk Import
- Bulk Export
- Category Analytics

---

# Completion Checklist

- Database Table
- Entity
- Entity Configuration
- Migration
- DTOs
- Repository
- Service
- Controller
- CRUD Views
- Image Upload
- Search
- Validation
- Exception Handling
- Testing
- Documentation

---