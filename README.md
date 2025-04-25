# 🧪 Test Task

## ⚙️ Prepare

1. 📎 Attach the `EmployeeService\App_Data\Test.mdf` file to your local **SQL Server** instance using SQL Server Management Studio (SSMS):
    - Right-click on `Databases` → `Attach...`
    - Locate and select `Test.mdf`
    - Confirm and finish attaching

> 💡 Make sure SQL Server has access permissions to the folder containing `Test.mdf`.

**OR**

1. **Create the `Employee` table** in your SQL Server database:

   Run the following SQL script to create the `Employee` table:

   ```sql
   CREATE TABLE Employee(
	     ID INT PRIMARY KEY IDENTITY,
	     Name VARCHAR(50) NOT NULL,
	     ManagerID INT NULL DEFAULT NULL,
	     Enable BIT DEFAULT 1,
	     CONSTRAINT FK_Manager FOREIGN KEY (ManagerID) REFERENCES Employee(ID)
   );

2. 🛠 **Update the connection string** in `Web.config`:
   - Open the `Web.config` file in the root of your WCF project.
   - Find the `<connectionStrings>` section and update the connection string to match your SQL Server configuration.

   **Example:**
   ```xml
   <connectionStrings>
       <add name="Default" 
            connectionString="" 
            providerName="System.Data.EntityClient" />
   </connectionStrings>
---

## 🚀 Run

1. Start the **EmployeeService** project (WCF Service)
    - Build and run the solution
    - Ensure the service is hosted and accessible (default: `http://localhost:64014`)

---

## 🔗 Endpoints

### 📘 Get Employee by ID


#### Endpoint:
GET http://localhost:64014/EmployeeService.svc/GetEmployeeById?id={id}

#### Description:
- Returns employee details in JSON format
- If the employee is not found or is disabled, an appropriate response is returned (e.g., 404)

#### Example `curl` Request:
```bash
curl -X GET "http://localhost:64014/EmployeeService.svc/GetEmployeeById?id=1" ^
     -H "Accept: application/json"
```
Replace 1 with the desired employee ID.

### 🔧 Enable or Disable Employee
#### Endpoint:

PUT http://localhost:64014/EmployeeService.svc/EnableEmployee?id=1

#### Description:
- Enables or disables an employee based on the provided enable flag.

- enable = 1 will enable the employee.

- enable = 0 will disable the employee.

#### Example `curl` Request to Enable Employee:
```bash
curl -X PUT "http://localhost:64014/EmployeeService.svc/EnableEmployee?id=1" ^
-H "Content-Type: application/json" ^
-d "{\"enable\":1}"
```
#### Example `curl` Request to Disable Employee:
```bash
curl -X PUT "http://localhost:64014/EmployeeService.svc/EnableEmployee?id=1" ^
-H "Content-Type: application/json" ^
-d "{\"enable\":0}"
```
Replace 1 with the desired employee ID and set enable to either 1 (enable) or 0 (disable).