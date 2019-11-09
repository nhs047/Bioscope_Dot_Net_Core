***Note: You must be in solution directory to perform these action

1. To add new database migrations, run the following syntax of command,
    dotnet ef migrations add MigrationName --project .\Bioscope.Data --startup-project .\Bioscope.App
2. To remove last migrations, run the following syntax command,
    dotnet ef migrations remove --project .\Bioscope.Data --startup-project .\Bioscope.App
3. To update database, run the following command of syntax,
    dotnet ef database update --project .\Bioscope.Data --startup-project .\Bioscope.App