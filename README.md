# DbUp.PlanFileScriptProvider

Plugin for [DbUp](https://github.com/dbup/dbup) to allow for plan file configuration.

The motivation for using a plan file with a database migration runner comes from [Sqitch](https://github.com/sqitchers/sqitch). I created this repository because there didn't appear to be anything similar for DbUp.

The plan file is a basic yaml file that lists one or more changes in order of execution. Previously the order execution was entirely based on the alphabetic order of the script file names. This led to naming conventions like `001_dosomething.sql`, which can become quite messy.

An example plan file is as follows:
```yaml
scripts:
   - path: /scripts/CreateSchema.sql
     timestamp: 2019-04-11
     author: Joe Bloggs
     description: Creates the 'Test' schema.
   - path: /scripts/CreateServiceAccountLogin.sql
     timestamp: 2019-04-11
     author: Joe Bloggs
     description: Creates the 'Test' sevice account login.
   - path: /scripts/CreateBaselineObjects.sql
     timestamp: 2019-04-12
     author: John Doe
     description: Creates the baseline objects (e.g. tables, views, functions, stored-procs, etc).
```

To configure DbUp to use the plan file, you can do something like the following:
```csharp
var migration =
   DeployChanges.To
      .SqlDatabase(connection)
      .WithTransaction()
      .WithVariables(variables)
      .WithPan("/etc/database-migration/plan.yml")
      .JournalToSqlTable("Test", "Version")
      .LogScriptOutput()
      .LogToConsole()
      .Build();
```

To install from nuget;
```bash
Install-Package DbUp.PlanFileScriptProvider
```
