# Project C# WPF Quản lý nhân sự

* Các actor và usecases của hệ thống: 
- Admin: 
+ Quản lý account. 
+ Bảo trì hệ thống.
- Manager: 
+ Quản lý employee báo cáo đến mình (*xem ở trường report_to, 
thường manager không có thông tin ở trường report_to). 
+ Giao task cho employee.
- Employee:
+ Xem các tasks được giao. 
+ Check thông báo deadline (Do thầy yêu cầu làm.
Deadline được config báo trước cho employee một 
vài ngày, tuần, tháng, ...v.v)

+ ------------------Giao việc--------------------

- A Lư làm dashboard, quản lý account (Quản lý bảng account).
- A Phúc làm CRUD employee (Quản lý bảng profile).
- Khánh làm giao manager giao task cho employee, employee
check task và cũng như thông báo deadline của mình.
- Triệu làm quản lý lương (Quản lý bảng payroll)

* Note: Project mình cũng sẽ sử dụng dependency injection và 
cách tổ chức source code theo repository pattern như assignment1.
Ae có gì bất cứ điều gì thắc mắc về project của mình thì cứ hỏi lên 
nhóm nhé.
