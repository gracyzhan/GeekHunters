1. The example dababase has been put in the folder: App_Data 
2. Change the connectionString in web.configure in web project 
3. change the connectionString in app.configure in unit test project 


 <add name="GracyDemoSkillDbStrings" providerName="System.Data.SQLite.EF6" connectionString="Data Source=C:\DonetDevelopment\InterViewProject\GeekHunter.sqlite;Pooling=True" />
