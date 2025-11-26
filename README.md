# DVLD

DVLD is a Windows Forms desktop application for managing driving-license related workflows (applications, licenses, drivers, tests, users and related resources). This repository contains the presentation, business and data access layers for the application.

## Key Features

- Manage driving license applications (new, renewals, replacements, detained, international)
- Driver and person management
- Test and appointment scheduling
- User and role management
- Simple layered architecture (Presentation, Business, DataAccess)

## Requirements

- Windows 10/11
- Visual Studio 2017 or newer (recommended) or another IDE that supports .NET Framework WinForms
- .NET Framework 4.7.2 (the presentation project targets `v4.7.2`)
- SQL Server accessible from your machine for the application database

## Quick Start

1. Open the solution: `DVLD.sln` in Visual Studio.
2. Update the database connection string in `DVLD/App.config` (connection string name: `DbConnection`). Example currently included in the file:

```xml
<connectionStrings>
	<add name="DbConnection" connectionString="Server=192.168.8.100,1433;Database=myDVLD;User Id=sa;Password=Password@1234;Encrypt=true;TrustServerCertificate=true;" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

Replace the sample values with your server, database name and credentials. Store production credentials securely and do not commit secrets.

3. Build the solution (`Build > Build Solution`).
4. Set the startup project to the presentation layer project (the Windows Forms project under `DVLD/`), then run (`F5`).

## Project Structure

- `DVLD/` — Presentation layer (Windows Forms UI). Entry point: `Program.cs`, main form: `frmMain.cs`.
- `DVLD_BusinessLayer/` — Business models and application logic (C# classes such as `Person`, `Driver`, `License`, `Test`, etc.).
- `DVLD_DataAccessLayer/` — Data access classes that interact with the database (classes named `DataAccess*.cs`, and a `DatabaseHelper` utility).
- `assets/`, `Resources/`, `Controls/`, `Applications/`, `Licenses/`, `People/`, `Users/` — UI-related resources and forms used by the presentation layer.

## Configuration

- Connection string: edit `DVLD/App.config` to point to your SQL Server instance. The application expects a connection string with the name `DbConnection`.
- Other configuration and settings are available inside the `Properties` folders of the projects.

## Development Notes

- The solution uses a classic 3-layer separation (UI -> Business -> DataAccess). Data access classes are located in `DVLD_DataAccessLayer` and business entities in `DVLD_BusinessLayer`.
- `DVLD_DataAccessLayer/DatabaseHelper.cs` is used for logging errors to the Windows Event Log (`DVLD` source). Additional database setup (tables, schema) is expected to be created externally — check your organization's deployment scripts or the original database backup for schema details.

## Running & Troubleshooting

- If the app fails to connect to the database, check `App.config` and ensure SQL Server allows remote connections and firewall rules permit traffic on the specified port.
- Run Visual Studio as Administrator if you encounter permission issues when creating Event Log sources.

## Contributing

If you intend to contribute, please:

- Open an issue describing the change.
- Create a branch for your work and submit a pull request with tests or manual verification steps.

## License & Contact

This repository does not include a license file. Add a `LICENSE` if you plan to publish or share this project. For questions about this code, contact the repository owner.

---

If you'd like, I can also:

- Add a `LICENSE` (you tell me which one),
- Add a short CONTRIBUTING.md with branch and commit conventions, or
- Create a simple SQL schema template if you can provide the intended database schema or sample data.
