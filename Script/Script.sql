--Package Name
--1) Npgsql


-- Use Session Code
-- builder.Services.AddSession(
--     Object =>{
--         Object.IdleTimeout = TimeSpan.FromMinutes(30);
--         Object.Cookie.HttpOnly = true;
--         Object.Cookie.IsEssential = true;
--     }
-- );

-- Create Employee Table
Create table t_ems_employee(
	c_empId serial,
	c_empName varchar(100),
	c_empEmail varchar(100) UNIQUE,
	c_empPwd varchar(100),
	c_empImage varchar(100),
	CONSTRAINT pk_empId PRIMARY KEY (c_empId)
)

-- INSERT Employee Table
INSERT INTO t_ems_employee (c_empName, c_empEmail, c_empPwd, c_empImage) 
VALUES 
('John Doe', 'john.doe@example.com', 'password123', 'john.jpg'),
('Jane Smith', 'jane.smith@example.com', 'securepass', 'jane.png')
RETURNING *;

SELECT * FROM t_ems_employee;


SELECT * FROM t_ems_employee WHERE c_empId = 1;


SELECT * FROM t_ems_employee WHERE c_empEmail = 'john.doe@example.com';


UPDATE t_ems_employee 
SET c_empName = 'Johnathan Doe', c_empPwd = 'newpassword456', c_empImage = 'john_updated.jpg' 
WHERE c_empId = 1
RETURNING *;


DELETE FROM t_ems_employee WHERE c_empId = 2
RETURNING *;
