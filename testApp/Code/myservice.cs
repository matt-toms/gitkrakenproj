using System.Linq;

namespace testApp.Code
{

    public class myservice : imyservice
    {


        private readonly IRepository<Product> _productRepository;


        public myservice(IRepository<Product> productRepository)
        {

            _productRepository = productRepository;

        }

        public int getProductID()
        {
           return 1234443;
        }



        public Product GetProducts()
        {
            var t = _productRepository.GetTable(3);
            return t;

        }



        public string myname() {

            return "Matt";
        }
    }


    public interface imyservice
    {


        public string myname();

        public int getProductID();


        public Product GetProducts();

    }


   
}
