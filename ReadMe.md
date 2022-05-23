## Controller : 
    -Là một lớp kế thừa từ lớp Controller 
    - Action trong controller là một phương thức public 
    - Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult 
    - Các dịch vụ inject vào controller qua hàm tạo

## View : 
    - Là file có đuôi .cshtml 
    - View cho action lưu tại Views/{controller}/{action}/{id?} 
    - Có thể thêm thư mục lưu trữ View (trong file startup.cs có intro)

## Truyền dữ liệu qua View : 
    - Qua Model 
    - Qua ViewData 
    - Qua ViewBag 
    - Qua TemData

## Areas
    - Là tên dùng để routing
    -Là cấu trúc thư mục chứa M.V.C
    -Thiết lập Area cho controller bằng [Area("AreaName)]
    - Tạo cấu trúc thư mục

## Các thuộc tính thiết lập Area :
    + asp-area : Thiết lập Area
    + asp-action : Thiết lập Action
    + asp-controller : Thiết lập controller
    + asp-route : thiết lập tham số của route
    + asp-

## Logger :
    - Có thể thêm 2 cấu hình sau vào file appsettings.json ( mục Logging) để đọc log ứng dụng : 
    "Microsoft.EntityFrameworkCore.Query" : "Information", 
    "Microsoft.EntityFrameworkCore.Database.Command": "Information"