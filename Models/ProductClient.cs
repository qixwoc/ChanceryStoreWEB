using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChanceryStoreMVC.Models
{
    public class ProductClient
    {
        private int id;
        private string name;
        private double price;
        private int amount;
        private int barcode;
        private bool outdate;
        private byte[] image;
        private int providerId;

        [Key]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;

            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;

            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;

            }
        }

        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;

            }
        }

        public int Barcode
        {
            get { return barcode; }
            set
            {
                barcode = value;

            }
        }

        public bool Outdate
        {
            get { return outdate; }
            set
            {
                outdate = value;

            }
        }

        public byte[] Image
        {
            get { return image; }
            set
            {
                image = value;           
            }
        }

        public int ProviderId
        {
            get { return providerId; }
            set
            {
                providerId = value;
            }
        }

    }
}