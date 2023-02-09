# Visma Task
### Prerequisites
* Microsoft Visual Studio with support for the newest stable version of .NET (currently .NET6).
* Microsoft SQL Server.
* Preparation - Create a database in your MSSQL server called VismaDb.
### Launch
* Standard - Open the Visma.sln solution select Visma launch profile in Visual Studio and launch the project.

# Decisions made / Performace considerations
### Linq2db 
* Using Linq2db lightweight ORM instead of Entity framework  for more performant DB operations 

### Common
* All bussiness and persistance layer logic moved to a Common class library, so that the solution is not tied to the implementing project (Could make a Winforms/MVC or any other type of app, not only API if needed)

# API Usage
### /Employee/GetAll
* Get request
* Example request : ``` /Employee/GetAll ```
* Example response :
```
[
  {
    "firstName": "AA",
    "lastName": "BB",
    "birthdate": "1998-02-09T09:28:58.107",
    "employmentDate": "2009-03-09T09:28:58.107",
    "bossId": null,
    "address": "string",
    "salary": 0,
    "role": 0,
    "id": "a919be4c-2d63-408d-bfe9-ac1890ff64d9"
  },
  {
    "firstName": "ART",
    "lastName": "RAT",
    "birthdate": "1998-02-09T09:34:30.939",
    "employmentDate": "2023-02-09T09:34:30.939",
    "bossId": null,
    "address": "string",
    "salary": 0,
    "role": 1,
    "id": "82116e12-1c18-4aa6-864f-dece7d6b659e"
  }
]
```
* When no employees are found :
```
[]
```
### /Employee/GetById
* Takes in the employee id in URL
* Example request : ```/Employee/GetById?id=2973909A-D578-4027-9107-0E8D8BE1A0FB```
* Get request
* Example response :
```
{
  "firstName": "AA",
  "lastName": "BB",
  "birthdate": "1998-02-09T09:28:58.107",
  "employmentDate": "2009-03-09T09:28:58.107",
  "bossId": null,
  "address": "string",
  "salary": 0,
  "role": 0,
  "id": "2973909a-d578-4027-9107-0e8d8be1a0fb"
}
```
### /Employee/FindByBossId
* Takes in a list the boss id in URL
* Example request : ```/Employee/FindByBossId?id=3FA85F64-5717-4562-B3FC-2C963F66AFA6```
* Get request
* Example response :
```
[
  {
    "firstName": "Broman",
    "lastName": "MrBro",
    "birthdate": "2023-02-09T09:19:56.738",
    "employmentDate": "2023-02-09T09:19:56.738",
    "bossId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "address": "string",
    "salary": 0,
    "role": 1,
    "id": "527e6976-d58a-4451-a294-4742ff210088"
  },
  {
    "firstName": "TTT",
    "lastName": "RRR",
    "birthdate": "1998-02-09T09:38:09.3",
    "employmentDate": "2023-02-09T09:38:09.3",
    "bossId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "address": "string",
    "salary": 0,
    "role": 1,
    "id": "f7033b5c-cfb0-4939-b418-61186e3241fe"
  }
]
```
* When no employees are found :
```
[]
```
### /Employee/GetEmployeeCountAndAverageSalaryByRole
* Takes in a role
* Roles : 0 = CEO, 1 = Other, 2 = Test
* Example request : ```/Employee/GetEmployeeCountAndAverageSalaryByRole?role=1```
* Get request
* Example response :
```
{
  "role": 1,
  "count": 4,
  "salaryAverage": 375
}
```
### /Employee/Add
* Example request : ```/Employee/Add```
* Post request
* Attention, Employee is validated against these rules :
🔲 All properties, except for Boss are required
🔲 Only the CEO role has no boss
🔲 There can be only 1 employee with CEO role
🔲 FirstName and LastName cannot be longer than 50 characters
🔲 FirstName !=LastName
🔲 Employee must be at least 18 years old and not older than 70 years
🔲 EmploymentDate cannot be earlier than 2000-01-01
🔲 EmploymentDate cannot be a future date
🔲 Current salary must be non-negative
* Example request body :
```
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "firstName": "string",
  "lastName": "string",
  "birthdate": "2023-02-09T10:49:06.048Z",
  "employmentDate": "2023-02-09T10:49:06.048Z",
  "bossId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "address": "string",
  "salary": 0,
  "role": 0
}
```
* Example response :
* Employee added successfully
```
"5a0f63e1-17ba-4a3d-888a-3ed8fe84da8c"
```
* Employee was not added successfully
```
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-e4e4dd19c25d0d6e38cdd3d11b11466e-c00655456054a0f6-00",
  "errors": {
    "BossId": [
      "Employee with role CEO cannot have a boss id assigned."
    ],
    "Birthdate": [
      "Employee must be at least 18 years old and not older than 70 years."
    ],
    "FirstName": [
      "Employee's first name cannot be equal to his last name."
    ]
  }
}
```
### /Employee/Update
* Example request : ```/Employee/Update```
* Put request
* Attention, Employee is validated against these rules :
🔲 All properties, except for Boss are required
🔲 Only the CEO role has no boss
🔲 There can be only 1 employee with CEO role
🔲 FirstName and LastName cannot be longer than 50 characters
🔲 FirstName !=LastName
🔲 Employee must be at least 18 years old and not older than 70 years
🔲 EmploymentDate cannot be earlier than 2000-01-01
🔲 EmploymentDate cannot be a future date
🔲 Current salary must be non-negative
* Example request body :
```
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "firstName": "string",
  "lastName": "string",
  "birthdate": "2023-02-09T10:49:06.048Z",
  "employmentDate": "2023-02-09T10:49:06.048Z",
  "bossId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "address": "string",
  "salary": 0,
  "role": 0
}
```
* Example response :
* Employee updated successfully
```
1
```
* Employee was not added successfully
```
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-e4e4dd19c25d0d6e38cdd3d11b11466e-c00655456054a0f6-00",
  "errors": {
    "BossId": [
      "Employee with role CEO cannot have a boss id assigned."
    ],
    "Birthdate": [
      "Employee must be at least 18 years old and not older than 70 years."
    ],
    "FirstName": [
      "Employee's first name cannot be equal to his last name."
    ]
  }
}
```
* Employee was not found
```
0
```
### /Employee/UpdateSalary
* Takes in an id and salary in URL
* Example request : ```/Employee/UpdateSalary?id=3FA85F64-5717-4562-B3FC-2C963F66AFA6&salary=9899```
* Get request
* Updated successfully :
```
1
```
* Updated unsucessfully (No employee found):
```
0
```
* Updated unsucessfully (Salary wrong (less than 0)):
```
-1
```
### /Employee/Delete
* Takes in guid in the URL
* Example request : ```/Employee/Delete?id=5a0f63e1-17ba-4a3d-888a-3ed8fe84da8c```
* Delete request
* Example response :
* Employee removed succesfully
```
1
```
* Employee was not removed successfully (usually when Employee was never entered)
```
-1
```







