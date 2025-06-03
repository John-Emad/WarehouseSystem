# 📦 Warehouse Management System

A simple and functional Windows Forms application for managing warehouse operations, built using **C#**, **WinForms**, and **Entity Framework (EF Core)** with **SQL Server** as the backend database.

## 🚀 Features

This system is designed to help businesses manage inventory, track suppliers and customers, and handle warehouse transactions efficiently.

### 🔧 Management Modules
- **Customer Management**: Add and edit customer records.
- **Supplier Management**: Add and edit supplier details.
- **Item Management**: Define and update warehouse items.
- **Warehouse Management**: Register and modify warehouse details.

### 🧾 Voucher Transactions
Create and manage various transaction types before final submission:
- **Receipt Vouchers**: Record incoming items from suppliers.
- **Issue Vouchers**: Track outgoing items to customers.
- **Transfer Vouchers**: Move items between warehouses.

All voucher types support **editing prior to submission**.

### 📊 Reporting System
View detailed operational insights through the following reports:
- **Warehouse Inventory Report**: See all items in a warehouse with quantity and transfer history.
- **Expiration Date Report**: Identify items close to their expiration dates.
- **Item Aging Report**: View how long items have been in stock.
- **Item Per Warehouse(s) Report**: Display item quantities and movement across selected warehouses.
- **Item Transfers Report**: Track item movements between warehouses.

### 🖥️ UI & Navigation
- Clean and intuitive user interface for easy interaction.
- Centralized **main form** with **menu-based and button-based navigation** to all modules and reports.

### 🛠️ Technology Stack
- **.NET Windows Forms (WinForms)**
- **Entity Framework Core (EF Core)**
- **Microsoft SQL Server**

## 💡 Getting Started

1. Clone the repository.
2. Configure your connection string in `appsettings.json` or directly within the DbContext if required.
3. Build and run the solution in Visual Studio.

## 📂 Project Structure
- `Forms/` – Contains form logic for each module (Customers, Suppliers, Vouchers, Reports, etc.)
- `Domain/` – Entity models, DTOs, Enums and Interfaces
- `Data/` – EF Context managment and Repositories

> For any questions or suggestions, feel free to open an issue or contact the repository maintainer.
