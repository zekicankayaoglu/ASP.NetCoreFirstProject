using System.ComponentModel.DataAnnotations;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        //[Required]
        //[DataType (DataType.EmailAddress)]
        public string Email { get; set; }
        //[Required]
        public string City { get; set; }
        //[Required]
        public string Address { get; set; }
        
        public int Age { get; set; }
    }
}
