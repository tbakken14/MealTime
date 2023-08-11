# _MealTime_

#### By _**Thomas Bakken, Elijah Cartwright**_

#### _A web application for meal planning._

## Technologies Used

* _.NET_
* _C#_
* _MySQL_
* _Entity Framework Core_

## Description

_A website to track recipes and create meal plans and shopping lists._

## Setup/Installation Requirements

* _Install .NET SDK 6_
* _Install MySQL Server_
* _Clone the repository_
* _In the bash command line:_
  * _Navigate to the top-level directory_
  * _Create `appsettings.json` with: $ touch appsettings.json_
    * _Open the file in a text editor and copy the following line_
      * _\{"ConnectionStrings": \{"DefaultConnection": "Server=localhost;Port=3306;database=\[DB_NAME\];uid=\[USERNAME\];pwd=\[PASSWORD\];"\}\}_
    * _Replace \[DB_NAME\] with a database name_
    * _Replace \[USERNAME\] with your MySQL username_
    * _Replace DB_NAME with your MySQL password_
  * _Enter command: $ dotnet restore MealTime_
  * _Initialize database with: $ dotnet ef database update_
  * _Run application with command: $ dotnet run --project MealTime_


## Known Bugs

## License

_MIT_

Copyright (c) _8/8/2023_ _Thomas Bakken, Elijah Cartwright_