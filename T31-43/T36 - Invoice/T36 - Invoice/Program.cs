using System;
using System.Collections.Generic;

namespace Invoice
{
    class InvoiceItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public double Total
        {
            get { return Price * Quantity; }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}e {2} pieces {3}e total", Name, Price, Quantity, Total);
        }
    }

    class Invoice
    {
        public string Customer { get; set; }
        public List<InvoiceItem> Items { get; set; }

        public int ItemsCount
        {
            get { return Items.Count; }
        }

        public int ItemsTogether
        {
            get
            {
                int count = 0;
                foreach (var item in Items)
                {
                    count += item.Quantity;
                }
                return count;
            }
        }

        public double CountTotal()
        {
            double total = 0;
            foreach (var item in Items)
            {
                total += item.Total;
            }
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var invoice = new Invoice();
            invoice.Customer = "Kirsi Kernel";
            invoice.Items = new List<InvoiceItem>();
            invoice.Items.Add(new InvoiceItem { Name = "Milk", Price = 1.75, Quantity = 1 });
            invoice.Items.Add(new InvoiceItem { Name = "Beer", Price = 5.25, Quantity = 48 });
            invoice.Items.Add(new InvoiceItem { Name = "Butter", Price = 2.50, Quantity = 2 });

            Console.WriteLine(PrintInvoice(invoice));

            Console.ReadLine(); // wait for user input
        }

        private static string PrintInvoice(Invoice invoice)
        {
            string output = String.Format("Customer {0}'s invoice:\n", invoice.Customer);
            output += "=================================\n";
            foreach (var item in invoice.Items)
            {
                output += item.ToString() + "\n";
            }
            output += "=================================\n";
            output += String.Format("Total: {0} pieces {1} euros", invoice.ItemsTogether, invoice.CountTotal());
            return output;
        }
    }
}