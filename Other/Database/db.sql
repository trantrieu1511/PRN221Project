--CREATE DATABASE PRN221_QLNS
USE PRN221_QLNS
--DROP DATABASE PRN221_QLNS

CREATE TABLE [job] (
	job_id INT IDENTITY(1,1) PRIMARY KEY,
	job_title VARCHAR (35) NOT NULL,
	min_salary DECIMAL (8, 2) DEFAULT NULL,
	max_salary DECIMAL (8, 2) DEFAULT NULL
);

--drop table [department]
CREATE TABLE [department] (
	department_id INT IDENTITY(1,1) PRIMARY KEY,
	department_name VARCHAR (30) NOT NULL,
);

--drop table [profile]
CREATE TABLE [profile] (
	profile_id INT identity primary key,
	first_name VARCHAR (20) NOT NULL,
	last_name VARCHAR (20) NOT NULL,
	email VARCHAR (100) NOT NULL,
	phone_number VARCHAR (20) NULL,
	hire_date VARCHAR (20) NOT NULL,
	job_id INT NULL,
	department_id INT NULL,
	report_to int NULL,
	annual_leave INT DEFAULT 12 NOT NULL,
	FOREIGN KEY (job_id) REFERENCES job (job_id),
	FOREIGN KEY (department_id) REFERENCES department (department_id),
	FOREIGN KEY (report_to) REFERENCES [profile] (profile_id)
);

CREATE TABLE [account] (
    profile_id int,
	username VARCHAR(20) NOT NULL,
	password VARCHAR(20) NOT NULL, 
	isadmin BIT NOT NULL,
	ismanager BIT NOT NULL,
	status BIT DEFAULT 1 NOT NULL,
	FOREIGN KEY (profile_id) REFERENCES [profile] (profile_id)
);

--drop table salary
CREATE TABLE [salary] (
	payslip_number INT IDENTITY(1,1) PRIMARY KEY,
    profile_id int,
	basic_salary DECIMAL (8, 2) NOT NULL,
	DA DECIMAL (8, 2) DEFAULT NULL,
	HRA DECIMAL (8, 2) DEFAULT NULL,
	conveyance DECIMAL (8, 2) DEFAULT NULL,
	allowance DECIMAL (8, 2) DEFAULT NULL,
	medical_allowance DECIMAL (8, 2) DEFAULT NULL,
	TDS DECIMAL (8, 2) DEFAULT NULL,
	ESI DECIMAL (8, 2) DEFAULT NULL,
	PF DECIMAL (8, 2) DEFAULT NULL,
	leave DECIMAL (8, 2) DEFAULT NULL,
	loan DECIMAL (8, 2) DEFAULT NULL,
	professional_tax DECIMAL (8, 2) DEFAULT NULL,
	create_date varchar(20) NOT NULL
	FOREIGN KEY (profile_id) REFERENCES [profile] (profile_id)
);

CREATE TABLE [company] (
    company_id INT IDENTITY(1,1) PRIMARY KEY,
	company_name VARCHAR (25) NOT NULL,
);


--drop table [company]
CREATE TABLE [myCompany] (
    company_id INT IDENTITY(1,1) PRIMARY KEY,
	company_name VARCHAR (25) NOT NULL,
	profile_id int NOT NULL,
	company_address VARCHAR (50) NOT NULL,
	company_country VARCHAR (20) NOT NULL,
	company_province VARCHAR (20) NOT NULL,
	company_city VARCHAR (20) NOT NULL,
	postal_code INT NOT NULL,
	company_email VARCHAR (50) NOT NULL,
	company_pnumber INT NOT NULL,
	fax INT NOT NULL,
	website_url VARCHAR (50) NOT NULL,
	FOREIGN KEY (profile_id) REFERENCES [profile] (profile_id)
	);

--drop table client
CREATE TABLE [client] (
	client_id INT IDENTITY primary key,
	first_name VARCHAR (20) DEFAULT NULL,
	last_name VARCHAR (25) NOT NULL,
	email VARCHAR (100) NOT NULL,
	phone_number VARCHAR (20) DEFAULT NULL,
	company_id INT NOT NULL,
	FOREIGN KEY (company_id) REFERENCES [company] (company_id)
);

CREATE TABLE [attendance] (
    shift_id INT IDENTITY(1,1) PRIMARY KEY,
	date VARCHAR(30) NOT NULL,
    time_in VARCHAR(30) NOT NULL,
	time_out VARCHAR(30) NOT NULL,
	production_time VARCHAR(30) NOT NULL,
	employee_id int,
	note VARCHAR(45),
);

CREATE TABLE [shift](
    name VARCHAR(255) PRIMARY KEY NOT NULL,
	start_time VARCHAR(20) NOT NULL,
	end_time VARCHAR(20) NOT NULL,
);

CREATE TABLE [schedule](
    profile_id int,
	shift_name VARCHAR(255),
	FOREIGN KEY (profile_id) REFERENCES [profile] (profile_id)
);

--drop table project
CREATE TABLE [project] (
   title VARCHAR (35) PRIMARY KEY,
   client_id int,
   period VARCHAR(50),
   rate DECIMAL(8,2),
   manager_id int,
   description VARCHAR(255),
   status INT,
   FOREIGN KEY (client_id) REFERENCES [client] (client_id),
   FOREIGN KEY (manager_id) REFERENCES [profile] (profile_id),
);

-- drop table task
CREATE TABLE [task] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(35),
	priority INT,
	deadline VARCHAR(20),
	status int,
	assigned int,
	project VARCHAR(35),
	FOREIGN KEY (assigned) REFERENCES [profile] (profile_id),
	FOREIGN KEY (project) REFERENCES [project] (title),
);