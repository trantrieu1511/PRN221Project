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

- A Lư làm dashboard, quản lý account (Quản lý bảng account).
- A Phúc làm CRUD employee (Quản lý bảng profile).
- Khánh làm manager giao task cho employee, employee
check task. Check deadline.
- Triệu làm quản lý lương (Quản lý bảng payroll)

* Note: 
- Project mình cũng sẽ sử dụng dependency injection và 
cách tổ chức source code theo repository pattern như assignment1.
Ae có gì bất cứ điều gì thắc mắc về project của mình thì cứ hỏi lên 
nhóm nhé.
- Giao diện mọi người chủ động tìm được ở trên mạng thì dùng nếu không
tự làm ra cũng được (Giao diện WPF em thấy tìm hơi khó).
