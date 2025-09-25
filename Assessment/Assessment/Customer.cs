using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class Customer
    {
        #region Private Fields

        private readonly int m_number_of_clothing_items = 0;

        #endregion

        #region Public Fields

        public int ClothingItems
        {
            get { return m_number_of_clothing_items; }

        }

        #endregion

        #region Constructors
        public Customer()
        {
            m_number_of_clothing_items = new Random().Next(1, 7);
        }

        public Customer(int initial_number_of_clothing_items)
        {
            // The number of itmes the customer will try on
            if (initial_number_of_clothing_items == 0)
            {
                // The store allows customers to bring 1-6 items into a dressing room
                m_number_of_clothing_items = new Random().Next(1, 7);
            }
            else if (initial_number_of_clothing_items > 20)
            {
                throw new ArgumentException(message: "Customers may not bring more than 20 items into a dressing room.");
            }

            m_number_of_clothing_items = initial_number_of_clothing_items;
        }

        #endregion

    }
}
