README FILE FOR THE ?name? SOLUTION 

CONTENTS
WHAT TOOLS ARE NEEDED
HOW TO BUILD THE SOLUTION
HOW TO ADD A NEW PROJECT
HOW TO DEBUG THE SERVICE
HOW TO UNIT TEST
FILES IN THE _SOLUTIONFILES FOLDER


WHAT TOOLS ARE NEEDED
See ?


HOW TO BUILD THE SOLUTION

1) Install all the necessary tools (see WHAT TOOLS ARE NEEDED)

2) If you do not yet have the database set up, or if it has changed
   - Get the latest database scripts from source control (?folderPath?)
   - In SQL Management Studio
     - Create a database (name it ?defaultDBName? or whatever you want)
     - Run each database script on that database in the indicated order

2) A) In Visual Studio (VS), open the ?SlnName?.sln solution through source control, getting the latest

   B) In Windows Explorer, write-enable the ?SlnName? folder recursively (because of the EDMX update and T4 generation)
      As a standard, all of our checked-in App.Config files use the following:
      - connectionstring values of: data source-.\SQLExpress and Initial catalog=?defaultDBName?
      - a ReportsRoot appSetting of REPLACE_REPORTS_ROOT
      If your database is different, or if you are running the Reports module, build and run Tools\?SlnName?.SetAppConfigGUI

   C) If the database has just been created or has changed
      - If you have added new tables to the database, you need to add them to the SharePoint list (ultimately Tools\SPM.Tools\ExistingTables.xml)
      - In VS, open Tools\?SlnName?.Tools\?EDMXNamespaceAndFileName?.edmx
        - Some people simply select all of the tables and delete them, but sometimes they have problems doing that
          Others do not delete all and add new tables and refresh existing ones, but sometimes they have problems, too
        - Right-click in the designer, and select Update Model from Database
          - Select your database
            - Uncheck the checkbox to Save entity connection settings in App.config as: ?SlnName?Entities
            - Click Next
          - Check the Tables, but not the Views or Stored Procedures unless you know what you are doing
          - Check Pluralize or singularize generated object names
          - Check Include foreign key columns in the model
          - Click Finish

   D) Click Transform all Templates in the Solution Explorer toolbar

   E) Build > Rebuild Solution

   F) Right-click on the ?SlnName?.Server.WindowsServiceSetup project in the Solution Explorer, and 
      - Select Build
      - Select Install (if you need to debug, see below)

   G) You can now run and modify ?SlnName?.Client.WPF, and if it works and builds with zero errors and zero warnings, you can check it in


HOW TO ADD A NEW PROJECT
- Decide which folder (Client, Server, etc.) the project belongs in
- In VS:
-- File > New > Project
--- Solution: Add to solution
--- Location: Browse to the folder you decided on above
--- Name: Name it like the other projects you see in that folder
--- Click OK
The following is when we put all binaries in the same folder hierarchy component (?SlnName?\bin\{Debug|Release}\Component)
-- Select another project in that same folder
-- Project > Properties > Build
--- Copy the Output path
-- Select your new project in that same folder
-- Project > Properties > Build
--- Paste into the Output path
--- Assuming you are using the Debug config, switch to Release
--- Paste into the Output path again, and change "Debug" to "Release"
--- Switch back to Debug, and check the XML documentation file checkbox (this guarantees you provide the minimal documentation)
--- Build, ensuring you have zero errors and zero warnings
    

HOW TO DEBUG THE SERVICE
After you have a successful build:
- Select the solution in the Solution Explorer
  - Project > Properties > Startup Project, select Multiple Startup Projects, and click OK
- Put a breakpoint anywhere you want in the server, such as ?SlnNamem?.Server.Services.ClientService.RegisterClient()
- If the ?SlnNamem? Windows Service is running in Computer Management (compmgmt.msc), stop it
- Select the ?SlnNamem?.Server.WindowsService, right-click, and Debug > Start new instance ...
- Now run the client
Some people have experienced problems with this and run two instances of VS, one for the client and one for the server


HOW TO UNIT TEST
Right-click on the Test project you desire and select Run Tests


FILES IN THE _SOLUTIONFILES FOLDER

The files in this folder are not compiled and are used by multiple projects in this solution.

_BestPractices.cs helps us to remember what some of our coding standards are and makes it easy to copy the desired statements

_Template.cs can easily be copied when we create a new class so that we can have all of the regions (if you want, you can add
    it to your VS snippets or templates, but this is the official version and might change)
