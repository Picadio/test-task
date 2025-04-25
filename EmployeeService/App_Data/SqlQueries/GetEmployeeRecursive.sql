WITH EmployeesCTE AS
(
     SELECT ID,
            Name,
            ManagerID,
            Enable
     FROM Employee WHERE ID = @id AND Enable = 1

     UNION ALL

     SELECT Employee.ID,
            Employee.Name,
            Employee.ManagerID,
            Employee.Enable
     FROM Employee
     INNER JOIN EmployeesCTE AS cte ON Employee.ManagerID = cte.ID AND Employee.Enable = 1
)
SELECT * FROM EmployeesCTE;