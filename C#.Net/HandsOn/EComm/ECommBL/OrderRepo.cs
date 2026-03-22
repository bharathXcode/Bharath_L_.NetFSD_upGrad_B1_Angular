namespace ECommBL
{
    public class OrderRepo
    {
        public string MakeOrdre(string orderId, int productId)
        {
            try
            {
                if (orderId == null)
                {
                    throw new ArgumentNullException("Order Id Should not be null");
                }
                if (productId <= 0)
                {
                    throw new ArgumentException("Product Id should not be -ve or 0");
                }
                else
                    return "Order Sucessfull";
            }
            catch (ArgumentNullException ex)
            {
                throw;
                //Console.WriteLine(ex.Message);
            }
        }
    }
}
