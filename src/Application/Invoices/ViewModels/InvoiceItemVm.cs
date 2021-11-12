﻿namespace Application.Invoices.ViewModels
{
    public class InvoiceItemVm
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }

        public double Amount
        {
            get { return Quantity * Rate; }
        }
    }
}