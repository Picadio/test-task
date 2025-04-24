WITH EmployeesCTE AS
(
     SELECT ID,
            Name,
            ManagerID
     FROM Employee WHERE ID = @id

     UNION ALL

     SELECT Employee.ID,
            Employee.Name,
            Employee.ManagerID
     FROM Employee
     INNER JOIN EmployeesCTE AS cte ON Employee.ManagerID = cte.ID
)
SELECT * FROM EmployeesCTE;