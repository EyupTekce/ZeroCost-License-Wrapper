# ZeroCost-License-Wrapper
A zero-cost, serverless HWID license manager and executable wrapper powered by Google Sheets and Google Apps Script.

# 🛡️ Zero-Cost HWID License Wrapper

A lightweight, zero-cost license management tool designed for indie developers. This tool wraps any executable (`.exe`) with a custom licensing screen and validates Hardware IDs (HWID) using Google Sheets as a free, serverless database.

## 🚀 Features

* **Zero Server Cost:** Utilizes Google Sheets & Google Apps Script instead of a paid dedicated database.
* **HWID Locking:** Automatically binds the provided license key to the user's physical machine/hardware.
* **Expiration Management:** Supports time-limited licenses (e.g., 30 days, 1 year).
* **Seamless Integration:** Wraps any existing `.exe` application without requiring code changes to the original source code.

## 🧠 Architecture & Workflow

The system consists of three main components working together:

1.  **The Wrapper (C#):** The tool generates a new executable that acts as a gatekeeper. When launched, it reads the machine's HWID.
2.  **The API (Google Apps Script):** The desktop app sends an HTTP POST request to a deployed Apps Script Web App.
3.  **The Database (Google Sheets):** The script checks the spreadsheet to verify if the entered key is valid, unassigned, or already bound to the current HWID. If the validation passes, the original application is extracted and executed in the background.

## 🛠️ Prerequisites

* Windows OS
* .NET Framework / .NET Core (depending on your build)
* A Google Account (to host the Sheet and Apps Script)

## ⚙️ Setup & Installation

1. Create a new Google Sheet with the following columns: `Key`, `Status`, `HWID`, `Date`, `Duration`.
2. Open **Extensions > Apps Script** in your Google Sheet and paste the provided JavaScript backend code.
3. Deploy the script as a **Web App** (accessible to anyone) and copy the `Deployment ID`.
4. Run the **License Creator** desktop application.
5. Select the `.exe` you want to protect, enter your Google Sheets details, paste the `Deployment ID`, and generate your wrapped application!

## ⚠️ Disclaimer & Future Roadmap

*This project was developed as a Minimum Viable Product (MVP) to demonstrate system integration between desktop applications and cloud services.* It is a great, cost-effective solution for indie projects and small user bases. However, for enterprise-level security, migrating to a dedicated database (like PostgreSQL) and a secured backend is recommended, as C# wrappers can potentially be reverse-engineered by advanced users.

**Developed by [Senin Adın/Kullanıcı Adın]**
