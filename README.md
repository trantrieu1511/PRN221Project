# Project C# WPF Quản lý nhân sự

* Các actor và usecases của hệ thống: 
- Admin: 
+ Quản lý account. 
+ Bảo trì hệ thống.
- Manager: 
+ Quản lý employee báo cáo đến mình (*xem ở trường report_to). 
+ Giao task cho employee.
- Employee:
+ Xem các tasks được giao. 
+ Check thông báo. (deadline)

+ ------------------Giao việc--------------------

- A Lư làm dashboard, quản lý account
- A Phúc làm CRUD employee (Quản lý bảng profile).
- Khánh làm task (có check deadline, notify cho nhân viên)
- Triệu làm payroll

* Note: Project mình cũng sẽ sử dụng dependency injection và 
cách tổ chức source code theo repository pattern như assignment1 nhé.
