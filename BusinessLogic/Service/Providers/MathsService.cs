using BusinessLogic.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MathService : IMathService
    {
        private decimal ans = 0;
        public decimal Add(decimal num1, decimal num2)
        {   
            try
            {
              ans = num1 + num2;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return ans;
        }

        public decimal Divide(decimal num1, decimal num2)
        {
            try
            {
                ans = num1 / num2;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ans;
        }

        public decimal Multiply(decimal num1, decimal num2)
        {
            try
            {
                ans = num1 * num2;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ans;
        }

        public decimal Subtract(decimal num1, decimal num2)
        {
            try
            {
                ans = num1 - num2;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ans;
        }
    }
}
