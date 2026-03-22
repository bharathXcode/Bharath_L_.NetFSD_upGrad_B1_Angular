using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnGenericCollections
{
    interface IProductRepository
    {
        void Add(Product product);
        void Delete(int  id);
        Product Get(int id); //return product details with Id
        List<Product> GetAll(); //return all products
        void Edit(int id, double price);
    }
    internal class ProductRepository : IProductRepository
    {
        public List<Product> products = null;
        public ProductRepository()
        {
            products = new List<Product>() { new Product() { Id = 1, Name = "Mouse", Price = 400, Description = "Electronic gadget" } };
        }
        public void Add(Product product)
        {
            products.Add(product); //add product to the list
        }

        public void Delete(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if(products[i].Id == id)
                {
                    products.RemoveAt(i);//remove item using index
                    break;
                }
            }
        }

        public void Edit(int id, double price)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    products[i].Price = price;//update price of the product
                    break;
                }
            }
        }

        public Product Get(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                   return products[i];
                }
            }
            return null;
        }

        public List<Product> GetAll()
        {
            return products;//return all the products
        }
    }
    class Test_Repo
    {
        static void Main()
        {
            try
            {
                ProductRepository _repository = new ProductRepository();
                do
                {
                    Console.WriteLine("1.Add Product");
                    Console.WriteLine("2.View Products");
                    Console.WriteLine("3.View Product By Id");
                    Console.WriteLine("4.Edit Product");
                    Console.WriteLine("5.Delete Product");
                    Console.WriteLine("6.Exist App");
                    Console.WriteLine("Enter Choice");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {
                                //Add Product
                                Product product = new Product();
                                product.Id = new Random().Next(1, 100);
                                Console.WriteLine("Enter Product name");
                                product.Name = Console.ReadLine();
                                Console.WriteLine("Enter Price");
                                product.Price = double.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Descrption");
                                product.Description = Console.ReadLine();
                                _repository.Add(product);
                            }
                            break;
                        case 2:
                            {
                                foreach (var item in _repository.GetAll())
                                {
                                    Console.WriteLine(item); //Invoke Tosring() default
                                }
                            }
                            break;
                        case 3:
                            {
                                //get product by id
                                Console.WriteLine("Enter Id");
                                int id = int.Parse(Console.ReadLine());
                                var product = _repository.Get(id);
                                if (product != null)
                                {
                                    Console.WriteLine(product);
                                }
                                else
                                    Console.WriteLine("Invalid Product id");
                            }
                            break;
                        case 4:
                            {
                                Console.WriteLine("Enter Id");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter New Price");
                                double price = double.Parse(Console.ReadLine());
                                _repository.Edit(id, price);
                            }
                            break;
                        case 5:
                            {
                                Console.WriteLine("Enter Id");
                                int id = int.Parse(Console.ReadLine());
                                _repository.Delete(id);
                            }
                            break;
                        case 6:
                            {
                                Environment.Exit(0); //exit app
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                            }
                            break;
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
              
            }
        }
    }
}
