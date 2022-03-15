using System.ComponentModel.DataAnnotations;

namespace testApp.Code
{
    public class Product
    {

        [Key]
        public int id { get; set; }

        public string productname { get; set; }



    }


}
