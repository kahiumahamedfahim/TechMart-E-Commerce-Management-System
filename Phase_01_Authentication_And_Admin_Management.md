# TechMart E-Commerce Management System

# Phase 01: Authentication & Admin Management

---

# Objective

Build the security foundation of the application and establish a secure Role-Based Access Control (RBAC) system.

This phase ensures that only authenticated and authorized users can access the system.

---

# Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* Cookie Authentication
* Claims-Based Authorization
* Repository Pattern
* Service Layer
* Razor Views
* jQuery AJAX
* SweetAlert2
* Bootstrap 5

---

# Database Tables

## Users

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

---

## EmailVerificationCodes

* Id
* UserId
* VerificationCode
* ExpiryTime
* IsUsed

---

## PasswordResetCodes

* Id
* UserId
* ResetCode
* ExpiryTime
* IsUsed

---

# Completed Features

## Authentication

* ✅ Register
* ✅ Login
* ✅ Logout
* ✅ Cookie Authentication
* ✅ Claims Creation
* ✅ Password Hashing
* ✅ Role Based Authorization

---

## Email Verification

* ✅ Generate OTP
* ✅ Send Verification Email
* ✅ Verify Email
* ✅ Resend OTP
* ✅ Prevent Login Before Verification

---

## Password Management

* ✅ Forgot Password
* ✅ Send Reset Code
* ✅ Verify Reset Code
* ✅ Reset Password

---

## Profile Management

* ✅ View Profile
* ✅ Edit Profile
* ✅ Upload Profile Image

---

## Admin Management

### Create Admin

* SuperAdmin can create Admin accounts.
* Admin UserId generated automatically.
* Admin receives Email Verification OTP.

---

### Admin List

* Display all admins.
* Show User ID.
* Show Name.
* Show Email.
* Show Verification Status.
* Show Active Status.
* Show Created Date.

---

### Search

* Live Search using AJAX.
* Search by:

  * User ID
  * Name
  * Email

---

### Enable / Disable Admin

* SuperAdmin can Disable Admin.
* SuperAdmin can Enable Admin.
* Disabled Admin cannot login.
* SweetAlert confirmation before status change.
* AJAX status update.

---

# Security Features

## Cookie Authentication

Stores authenticated user session securely.

---

## Claims

Authenticated users receive:

* NameIdentifier
* Name
* Email
* Role
* UserId

---

## Authorization

Role-based authorization implemented using:

```csharp
[Authorize(Roles = "SuperAdmin")]
```

---

## Password Security

* ASP.NET Core Password Hasher
* Passwords are never stored as plain text.

---

## Anti Forgery

All POST requests protected using:

* ValidateAntiForgeryToken
* AntiForgeryToken

---

# User Roles

## SuperAdmin

Permissions

* Register First Account
* Login
* Manage Own Profile
* Create Admin
* View Admin List
* Search Admin
* Enable Admin
* Disable Admin

---

## Admin

Permissions

* Login
* Logout
* Manage Own Profile
* Change Password

Restrictions

* Cannot create another Admin.
* Cannot manage other Admin accounts.

---

# Authentication Workflow

```text
Register
      ↓
Generate OTP
      ↓
Send Email
      ↓
Verify Email
      ↓
Login
      ↓
Dashboard
```

---

# Forgot Password Workflow

```text
Forgot Password
        ↓
Generate Reset Code
        ↓
Send Email
        ↓
Verify Reset Code
        ↓
Reset Password
        ↓
Login
```

---

# Admin Management Workflow

```text
SuperAdmin Login
        ↓
Dashboard
        ↓
Create Admin
        ↓
Email Verification
        ↓
Admin Login
        ↓
Admin Profile
```

---

# Layered Architecture

```text
Presentation Layer

↓

Controller Layer

↓

Service Layer

↓

Repository Layer

↓

Entity Framework Core

↓

SQL Server
```

---

# Design Patterns Used

* Repository Pattern
* Generic Repository
* Service Layer
* Dependency Injection
* Role-Based Authorization
* Cookie Authentication
* AJAX
* SweetAlert2

---

# Learning Outcomes

After completing Phase 01, the project includes:

* Secure Authentication System
* Email Verification
* Password Recovery
* Role-Based Authorization
* Profile Management
* Admin Management
* AJAX Search
* SweetAlert Integration
* Clean Layered Architecture
* Generic Repository Implementation

---

# Future Improvements

* Access Denied Page
* Dashboard Statistics
* Activity Logs
* Audit Trail
* Two-Factor Authentication (2FA)
* Remember Me
* Login History

---

# Phase Status

| Module                 | Status      |
| ---------------------- | ----------- |
| Authentication         | ✅ Completed |
| Email Verification     | ✅ Completed |
| Password Management    | ✅ Completed |
| Profile Management     | ✅ Completed |
| Admin Management       | ✅ Completed |
| AJAX Search            | ✅ Completed |
| Enable / Disable Admin | ✅ Completed |
| Authorization          | ✅ Completed |

---

# Next Phase

## Phase 02: Category Management

Planned Features

* Create Category
* Edit Category
* Enable / Disable Category
* Search Category
* Category List
* AJAX Search
* Validation
* Image Upload (Optional)

---

**Phase 01 Status:** ✅ Completed

**Version:** v1.0

**Project:** TechMart E-Commerce Management System
V