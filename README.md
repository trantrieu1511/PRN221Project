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
+ Check deadline (Quá deadline employee sẽ không giao được việc (trừ khi manager mở rộng thêm),
Manager set up thông báo deadline cho employee, trước x ngày/ tháng/ năm để employee biết hoàn thành
kịp công việc của họ.)

+ -------------------------------------- Giao việc -----------------------------------------

- A Lư làm dashboard của cả manager và employee, quản lý account (Quản lý bảng account).
- A Phúc làm manager quản lý thông tin employee báo cáo đến mình 
(CRUD profile báo cáo đến mình).
- Khánh làm manager giao task cho employee, employee
check task. Check deadline.
- Triệu làm quản lý lương (Quản lý bảng payroll)

* Note: 
- Project mình sẽ sử dụng dependency injection và SignalR. Ae có gì bất cứ điều gì
thắc mắc về project của mình thì cứ hỏi lên nhóm nhé.
