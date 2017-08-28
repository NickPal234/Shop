using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;

namespace TestWebApl.BLL.Services
{
  public  class CartServices
    {
        private List<CartView> lineCollection = new List<CartView>();

        public void AddItem(BookView bookAdd, int quantity)
        {
            CartView line = lineCollection
                .Where(g => g.book.Id == bookAdd.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartView
                {
                   book = bookAdd,
                    count = quantity
                });
            }
            else
            {
                line.count += quantity;
            }
        }

        public void RemoveLine(BookView book)
        {
            lineCollection.RemoveAll(l => l.book.Id == book.Id);
        }

        public double ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.book.Price * e.count);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartView> Lines
        {
            get { return lineCollection; }
        }
    }

    }

