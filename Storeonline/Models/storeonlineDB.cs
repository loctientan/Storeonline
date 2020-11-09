using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Storeonline.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [DisplayName("Nhà sản xuất")]
        [Required(ErrorMessage ="Vui lòng nhập tên Nhà sản xuất")]
        public string Name { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }

        [DisplayName("Mã nhân viên")]
        public int ParentID { get; set; }

        [DisplayName("Thời gian tạo")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Được tạo bởi")]
        public string CreateBy { get; set; }

        [DisplayName("Thời gian sửa")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Được sửa bởi")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Hiển thị tại trang chủ")]
        public bool ShowOnHome { get; set; }

        public virtual ICollection<Product> product { get; set; }
        
        [NotMapped]
        public List<ProductCategory> productcategories { get; set; }

    }

    public class Product 
    {
       [Key]
       public int ProductID { get; set;}

       [DisplayName("Mã sản phẩm")]
       [Required(ErrorMessage ="Vui lòng nhập")]
       public string ProductCode { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string ProductName { get; set; }

        [DisplayName("Mô tả sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Description { get; set; }

        [DisplayName("Mã sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string ProductImage { get; set; }

        public Product()
        {
            ProductImage = "";
        }

        [DisplayName("Giá sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public int Price { get; set; }

        [DisplayName("Giá khuyến mãi")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public int PromotionPrice { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public int Quantity { get; set; }

        [DisplayName("Nhà sản xuất")]
        [ForeignKey ("ProductCategory")] public int? CategoryID { get; set; }
        public ProductCategory ProductCategory{ get; set; }


        [DisplayName("Chi tiết sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Detail { get; set; }

        [DisplayName("Thời hạn bảo hành")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public int Warranty { get; set; }

        [DisplayName("Thời gian tạo")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Được tạo bởi")]
        public string CreateBy { get; set; }

        [DisplayName("Thời gian sửa")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Được sửa bởi")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Top Hot")]
        public DateTime TopHot { get; set; }

        [DisplayName("Lượt xem")]
        public int ViewCounts {get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual ICollection<Invoice> invoice { get; set; }

        public virtual ICollection<InvoiceDetails> detailsinvoice { get; set; }

        public ProductCategory productcategory { get; set; }

        public virtual ICollection<Cart> cart { get; set; }


    }

    public class User
    {
        [Key]
        public int UserID { get; set; }

        [DisplayName("Mã người dùng")]
        public string UserCode { get; set; }

        [DisplayName("Họ và Tên đệm")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string LastName { get; set; }

        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string FirstName { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Address { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Email { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        [Compare("Password", ErrorMessage = "Password và Confirm Password phải giống nhau")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Có phải là nhân viên")]
        public Boolean IsStaff { get; set; }

        [DisplayName("Chức vụ")]
        //[Required(ErrorMessage = "Vui lòng nhập")]
        public string Position { get; set; }

        [ForeignKey("Role")] public int? IdRole { get; set; }
        
        [NotMapped]
        public string LoginError { get; set; }

        public Role role { get; set; }

        public virtual ICollection<Cart> cart { get; set; }
    }

    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [DisplayName("Quyền truy cập")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string RoleName { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Details { get; set; }

        public virtual ICollection<User> user { get; set; }
    }

    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [ForeignKey("User")] public int? UserID { get; set; }
        [ForeignKey("Dienthoai")] public int? ProductID { get; set; }

        [DisplayName("Ngày mua")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public DateTime DateOfPurchase { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public int Quantity { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }

    public class Invoice
    {
        [Key]

        public int InvoiceID { get; set; }

        [DisplayName("Mã đơn hàng")]
        public string InvoiceCode { get; set; }

        [DisplayName("Ngày đặt")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        public string Email { get; set; }

        [DisplayName("Họ và tên đệm")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        public string LastName { get; set; }

        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        public string FirstName { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        public string Phone { get; set; }

        [DisplayName("Địa chỉ giao hàng")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        public string Address { get; set; }


        [DisplayName("Ghi chú")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        public string ghichu { get; set; }

        [DisplayName("Hình thức thanh toán")]
        [Required(ErrorMessage = "Vui lòng chọn")]
        public int Payment { get; set; }

        public int UserID { get; set; }

        [DisplayName("Mã khách hàng")]
        public string UserCode { get; set; }

        public virtual ICollection<InvoiceDetails> invoicedetails { get; set; }


    }

    public class InvoiceDetails
    {
        [Key]
        public int InvoiceDetailsID { get; set; }

        [DisplayName("Mã đơn hàng")]
        [ForeignKey("Invoice")] public int? InvoiceID { get; set; }

        [ForeignKey("Product")] public int? ProductID { get; set; }

        [DisplayName("Tên điện thoại")]
        public string ProductName { get; set; }

        [DisplayName("Mã Khách hàng")]
        public string UserCode { get; set; }

        [DisplayName("Giá bán")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public int Price { get; set; }

        [DisplayName("Giá khuyến mãi")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public int PromotionPrice { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        public Invoice invoice { get; set; }
        public Product product { get; set; }
    }

    public class NewsCategory
    {
        [Key]
        public int NewsCategoryID { get; set; }

        [DisplayName("Chuyên mục")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        public string Name { get; set; }

        [DisplayName("Mã Chuyên mục")]
        public int NCCode { get; set; }

        [DisplayName("Mô tả Chuyên mục")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        public string Description { get; set; }

        [DisplayName("Thời gian tạo")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Được tạo bởi")]
        public string CreateBy { get; set; }

        [DisplayName("Thời gian sửa")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Được sửa bởi")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Hiển thị trên trang chủ")]
        public bool TopHot { get; set; }

        public virtual ICollection<News> news { get; set; }

        [NotMapped]
        public List<NewsCategory> newscategories { get; set; }

    }

    public class News
    {
        [Key]
        public int NewsID { get; set; }

        [DisplayName("Tiêu đề")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Title { get; set; }

        [DisplayName("Tiêu đề phụ")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string MetaTitle { get; set; }

        [DisplayName("Mô tả bản tin")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Description { get; set; }

        [DisplayName("Hình ảnh")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string NewsImage { get; set; }

        public int? NewsCategoryID { get; set; }

        [DisplayName("Chi tiết bản tin")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Details { get; set; }

        [DisplayName("Thời gian tạo")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Được tạo bởi")]
        public string CreateBy { get; set; }

        [DisplayName("Thời gian sửa")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Được sửa bởi")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Hiển thị trên trang chủ")]
        public bool TopHot { get; set; }

        [DisplayName("Lượt xem")]
        public int ViewCount { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public NewsCategory newscategory { get; set; }

    }

    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string FirstName { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Address { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Email { get; set; }

        [DisplayName("Nội dung Feedback")]
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Content { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Thời gian tạo")]
        public DateTime CreateDate { get; set; }
    }
}
