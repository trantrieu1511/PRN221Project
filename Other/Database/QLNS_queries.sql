use PRN221_Project_QLNS

select * from department
select * from [profile]
select * from [profileDetail]
select * from [experience]
select * from [familyInfo]
select * from job
select * from [profile] where report_to = 1
select * from account where profile_id = 1
select * from attendance
select * from account
select * from project
select * from client
select * from schedule
select * from [shift]


--search schedule
select schedule.profile_id, shift_name from schedule join [profile] on schedule.profile_id = [profile].profile_id 
where first_name + last_name like '%m%' order by [profile].profile_id asc

select * from [profile] p, account a where
p.profile_id = a.profile_id


--insert job
insert into job(job_title) values('Web Designer')
insert into job(job_title) values('Web Developer')
insert into job(job_title) values('UI/UX Developer')
insert into job(job_title) values('Software Tester')
insert into job(job_title) values('Software Engineer')
insert into job(job_title) values('Android Developer')
insert into job(job_title) values('Ios Developer')

--insert department
insert into department(department_name) values('IT Management')
insert into department([department_name]) values('Web Development')

--get Generated ProfileID
select top 1 profile_id from [profile]
order by id desc

select * from schedule
-- schedule
insert into schedule values(3,'shift1')
delete from schedule

--insert admin
insert into [Profile](first_name,last_name,email,phone_number,hire_date,job_id,department_id)
values ('mr', 'admin', 'admin@mail.com', '0123456789', '14/07/2022', 1, 1)

--insert manager
insert into [Profile](first_name,last_name,email,phone_number,hire_date,job_id,department_id)
values ('Trieu', 'Tran', 'trantrieu@gmail.com', '0123456789', '14/07/2022', 1, 1)
insert into [Profile](first_name,last_name,email,phone_number,hire_date,job_id,department_id)
values ('mr', 'a', 'MRA@gmail.com', '0246813579', '12/07/2022', 1, 1)


--insert staff
insert into [Profile](first_name,last_name,email,phone_number,hire_date,job_id,department_id,report_to)
values ('MR', 'ASDFG', 'MRASDFG@gmail.com', '01234xxxxx', GETDATE(), 1, 1, 1)

insert into [Profile](first_name,last_name,email,phone_number,hire_date,job_id,department_id,report_to)
values ('Christiano', 'Ronaldo', 'christianoronaldo@gmail.com', '123456789', GETDATE(), 3, 2, 1)

insert into [Profile](first_name,last_name,email,phone_number,hire_date,job_id,department_id,report_to)
values ('MR', 'ASDFG', 'MRASDFG@gmail.com', '01234xxxxx', GETDATE(), 1, 1, 1)

insert into [Profile](first_name,last_name,email,phone_number,hire_date,job_id,department_id,report_to)
values ('mr', 'delete', 'mrdelete@gmail.com', 'mrdelete', GETDATE(), 1, 1, 1)

insert into [Profile](first_name,last_name,email,phone_number,hire_date,job_id,department_id,report_to)
values ('mr', 'delete', 'mrdelete@gmail.com', 'mrdelete', GETDATE(), 1, 1, 1)

-- select account
select * from account

--delete acc
delete from account where profile_id = 2

-- insert account
insert into account(profile_id,username,password,isadmin,ismanager) values ('b', 'b', 0,0)
insert into account(profile_id,username,password,isadmin,ismanager) values ('a', 'a', 0,0)
insert into account(profile_id,username,password,isadmin,ismanager) values ('mrdel', 'mrdel', 0,0)
insert into account(profile_id,username,password,isadmin,ismanager) values (2, 'trantrieu123', '12345678', 0,1)
insert into account(profile_id,username,password,isadmin,ismanager) values (1,'admin', '123', 1,0)


--update acc
update account
set
profile_id = 3 where profile_id = 1

--remove staff
select * from [Profile] where profile_id = 6
select * from [Profile] where ReportsTo = 1



-- Select all Staff of a manager
		select p.profile_id, p.first_name, p.last_name, p.email, p.phone_number, 
		p.hire_date, j.job_title, d.department_name, p.salary, p.report_to,
		a.username, a.[password], a.isadmin
		from [profile] p, department d, job j, account a
		where p.job_id = j.job_id and p.department_id = d.department_id and p.profile_id = a.profile_id
		and report_to = 1

-- Select all profile
	select p.profile_id, p.first_name, p.last_name, p.email, p.phone_number, 
	p.hire_date, j.job_title, d.department_name, p.salary, p.report_to,
	a.username, a.[password], a.isadmin
	from [profile] p, department d, job j, account a
	where p.job_id = j.job_id and p.department_id = d.department_id and p.profile_id = a.profile_id
	
	select p.*
	from [profile] p, department d, job j, account a
	where p.job_id = j.job_id and p.department_id = d.department_id and p.profile_id = a.profile_id
	and a.profile_id = p.profile_id
	

	select j.* from job j, [profile] p where j.job_id = p.job_id and p.report_to is not null
	select d.* from department d, [profile] p where d.department_id = p.department_id and p.report_to = 1
 
-- update
update [Profile] set profile_id = 'ABABA', first_name = 'a', last_name = 'b', email = 'ab@gmail.com', phone_number = '0321656489', hire_date = GETDATE(), job_id = 2,
salary = 0, ReportsTo = 1, department_id = 2, username = 'ab', [password] = 'ab', img = '' where profile_id = 'ab'

update [Profile]
set 
--first_name = 'a', 
--last_name = 'b', 
--email = 'ab@gmail.com', 
--phone_number = '0321656489', 
hire_date = '03/07/2022'
--department_id = 1,
--job_id = 1,
--salary = 0, 
--report_to = 1
where profile_id = 1

--search by name
select * from [profile]
where report_to = 1
and first_name + last_name like '%r%'
--search by id
select * from [profile]
where report_to = 1
and profile_id like '%m%'
--search by job
select * from [profile]
where report_to = 1
and job_id = '3'
-- filter staff
--search with job
select * from [profile] where profile_id like '%m%' and job_id = 1	and first_name + last_name like '%a%' and report_to is not null
--search without job
select * from [profile] where profile_id like '%m%' and first_name + last_name like '%a%' and report_to is not null

--select client
select * from client cl join project pj 
on cl.client_id = pj.client_id

select id, client_id, first_name, last_name, email, phone_number, client.company_id, company.company_name from client join
company on client.company_id = company.company_id 
order by client.client_id asc


-- filter client
--search with company name
select * from [client] where client_id like '%%' and company_id = ''
--search without company name
select * from [client] where client_id like '%%' and first_name + last_name like '%%'


-- select all info of a staff profile
select * from [profile] p, profileDetail pd, familyInfo f, experience e, account a
where p.profile_id = pd.profile_id and p.profile_id = f.profile_id and
p.profile_id = e.profile_id and p.profile_id = a.profile_id

select p.profile_id, p.first_name, p.last_name, p.email, p.phone_number, p.hire_date, p.job_id,
p.department_id, p.salary, p.report_to, a.username, a.[password], a.isadmin, a.ismanager
from [profile] p, [account] a 
where p.profile_id = a.profile_id 
and p.report_to = 1


-- client
select client_id, first_name, last_name, email,
phone_number, company_id, company_name from client join 
company on client.company = company.company_id

select * from client
insert into client 
values(1, 'mr', 'client2', 'mrclient2@mail.com', '0123456789','C-Company')

delete from client where client_id = '1'

insert into client 
values('1', 'mr', 'client', 'mrclient@mail.com', '0123456789','C-Company')
select * from project

-- edit client
select * from client
update [client]
set
--first_name = 'mra',
--last_name = 'mra',
--email = 'mra',
--phone_number = '0123456789',
company_id = 4
where client_id = 'CL004'

--insert company
select * from [company]
insert into [company](company_name) values('Global Technology')
insert into [company](company_name) values('Delta Infotech')
insert into [company](company_name) values('Carlson Tech')
insert into [company](company_name) values('Cream Inc')
insert into [company](company_name) values('International Software')
insert into [company](company_name) values('Mercury Software Inc')
insert into [company](company_name) values('Mustang Technologies')
insert into [company](company_name) values('Wellware Company')

--edit company
update [company] set company_name = 'C Company' where company_id = 3

--select all profile with salary
select * from account
select p.*, s.basic_salary, s.DA, s.HRA, s.conveyance, s.allowance, s.medical_allowance,
s.TDS, s.ESI, s.PF, s.leave, s.loan, s.professional_tax, ((basic_salary+DA+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary,
s.create_date
from [profile] p full outer join [account] a 
on p.profile_id = a.profile_id 
full outer join [salary] s
on p.profile_id = s.profile_id
where a.isadmin != 1

--select salary
select * from salary

select s.*, ((basic_salary+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary from salary s
where profile_id = 1

select s.*, ((basic_salary+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary from salary s 
where profile_id = 1

--add salary
select * from [profile]
insert into salary 
values(5, 100000, 100, 0, 0, 0, 100, 20, 0, 0, 10, 0, 10, '01/07/2022')
select * from salary
--edit salary
update salary
set
basic_salary = 3000,
DA = 15,
HRA = 20,
conveyance = 50,
allowance = 25,
medical_allowance = 35,
TDS = 100,
ESI = 10,
PF = 2,
leave = 5,
loan = 16,
professional_tax = 30
--create_date = '02/07/2022'
where profile_id = 'SSSSS'

--delete salary
delete from salary where profile_id = 4 and basic_salary = 250

select * from account

--filter salary
-- search with ename erole from to
select p.*, s.basic_salary, s.DA, s.HRA, s.conveyance, s.allowance, s.medical_allowance,
s.TDS, s.ESI, s.PF, s.leave, s.loan, s.professional_tax, ((basic_salary+DA+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary,
s.create_date
from [profile] p full outer join [account] a 
on p.profile_id = a.profile_id 
full outer join [salary] s
on p.profile_id = s.profile_id
where a.isadmin = 0
and a.ismanager = 'true'
and p.first_name + p.last_name like '%t%'
and s.create_date BETWEEN '02/07/2022' and '05/07/2022'

-- search with date created (from)
select p.*, s.basic_salary, s.DA, s.HRA, s.conveyance, s.allowance, s.medical_allowance,
s.TDS, s.ESI, s.PF, s.leave, s.loan, s.professional_tax, ((basic_salary+DA+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary,
s.create_date
from [profile] p full outer join [account] a 
on p.profile_id = a.profile_id 
full outer join [salary] s
on p.profile_id = s.profile_id
where a.isadmin = 0
--and a.ismanager = 'false'
--and p.first_name + p.last_name like '%true%'
--and s.create_date >= '02/07/2022'

-- search with date created only
select p.*, s.basic_salary, s.DA, s.HRA, s.conveyance, s.allowance, s.medical_allowance,
s.TDS, s.ESI, s.PF, s.leave, s.loan, s.professional_tax, ((basic_salary+DA+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary,
s.create_date
from [profile] p full outer join [account] a 
on p.profile_id = a.profile_id 
full outer join [salary] s
on p.profile_id = s.profile_id
where a.isadmin = 0
and p.first_name + p.last_name like '%%'
and s.create_date BETWEEN '02/07/2022' and '05/07/2022'

--search without create-date
select p.*, s.basic_salary, s.DA, s.HRA, s.conveyance, s.allowance, s.medical_allowance,
s.TDS, s.ESI, s.PF, s.leave, s.loan, s.professional_tax, ((basic_salary+DA+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary,
s.create_date
from [profile] p full outer join [account] a 
on p.profile_id = a.profile_id 
full outer join [salary] s
on p.profile_id = s.profile_id
where a.isadmin = 0
and a.ismanager = 1
and p.first_name + p.last_name like '%t%'


--search without ename and create date
select p.*, s.basic_salary, s.DA, s.HRA, s.conveyance, s.allowance, s.medical_allowance,
s.TDS, s.ESI, s.PF, s.leave, s.loan, s.professional_tax, ((basic_salary+DA+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary,
s.create_date
from [profile] p full outer join [account] a 
on p.profile_id = a.profile_id 
full outer join [salary] s
on p.profile_id = s.profile_id
where a.isadmin != 1
and a.ismanager = 'false'

--query for choose staff option in add Salary
select p.profile_id, p.first_name, p.last_name, s.basic_salary
from [profile] p full outer join [account] a 
on p.profile_id = a.profile_id 
full outer join [salary] s
on p.profile_id = s.profile_id
where a.isadmin = 0 
and s.basic_salary is null

--get Staff net Salary only
select ((basic_salary+DA+HRA+conveyance+allowance+medical_allowance)-(TDS+ESI+PF+leave+loan+professional_tax)) as net_salary
from [profile] p full outer join [account] a 
on p.profile_id = a.profile_id 
full outer join [salary] s
on p.profile_id = s.profile_id
where a.isadmin != 1
and report_to = 1
order by p.profile_id asc

--project
select * from project

--account management
SELECT profile.*, account.* FROM [account], [profile] WHERE account.profile_id = profile.profile_id and report_to is NULL
