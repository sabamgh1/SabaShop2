using System;
using System.Collections.Generic;
using AutoMapper;
using core.Domain;
using core.Repository;
using infrastructure.Data.Context;
using infrastructure.Data.Entities;
using System.Linq;

namespace infrastructure.Repository
{
    public class RProduct : IProduct
    {
        private readonly IMapper iMap;
        private readonly SabaShopContext context;
        public RProduct(SabaShopContext Context, IMapper IMap)
        {
            context = Context;
            iMap = IMap;
        }

        public bool AddProduct(MProduct Product)
        {
            Product p = new Product()
            {
                Name = Product.Name,
                price = Product.price,
                Count = Product.Count,
                discription = Product.discription,
                MainImage = Product.MainImage,
                Status = Product.Status,
                IdColor = Product.IdColor,
                IdSize = Product.IdSize,
                IdCategory = Product.IdCategory,
                discount = Product.discount,
                Type = Product.Type
            };
            context.Products.Add(p);
            context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var select = context.Products.SingleOrDefault(u => u.Id == id);
            if (select != null)
            {
                context.Products.Remove(select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MProduct> ShowActiveStatusProduct()
        {
            var select = context.Products.Where(c => c.Status == true).ToList();
            if (select != null)
            {
                List<MProduct> product = new List<MProduct>();
                foreach (var item in select)
                {
                    MProduct p = new MProduct()
                    {
                        Name = item.Name,
                        price = item.price,
                        Count = item.Count,
                        discription = item.discription,
                        MainImage = item.MainImage,
                        Status = item.Status,
                        IdColor = item.IdColor,
                        IdSize = item.IdSize,
                        IdCategory = item.IdCategory,
                        discount = item.discount,
                        Type = item.Type
                    };
                    product.Add(p);
                }
                return product;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateProduct(MProduct Product)
        {
            var Select = context.Products.SingleOrDefault(c => c.Id == Product.Id);
            if (Select != null)
            {
                Select.Name = Product.Name;
                Select.price = Product.price;
                Select.Count = Product.Count;
                Select.discription = Product.discription;
                Select.MainImage = Product.MainImage;
                Select.Status = Product.Status;
                Select.IdColor = Product.IdColor;
                Select.IdSize = Product.IdSize;
                Select.IdCategory = Product.IdCategory;
                Select.discount = Product.discount;
                Select.Type = Product.Type;

                context.Update(Select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public MProduct DetailsProduct(int IdProduct)
        {
            var select = context.Products.SingleOrDefault(c => c.Id == IdProduct);
            if (select != null)
            {
                var c = iMap.Map<MProduct>(select);
                return c;
            }
            else
            {
                return null;
            }
        }
        public List<MProduct> ShowProductCategory(int IdCategory)
        {
            var select = context.Products.Where(c => c.IdCategory == IdCategory && c.Status == true).ToList();
            if (select != null)
            {
                List<MProduct> product = new List<MProduct>();
                foreach (var item in select)
                {
                    MProduct c = new MProduct()
                    {
                        Name = item.Name,
                        price = item.price,
                        Count = item.Count,
                        discription = item.discription,
                        MainImage = item.MainImage,
                        Status = item.Status,
                        IdColor = item.IdColor,
                        IdSize = item.IdSize,
                        IdCategory = item.IdCategory,
                        discount = item.discount,
                        Type = item.Type
                    };
                    product.Add(c);
                }
                return product;
            }
            else
            {
                return null;
            }
        }
        public List<MProduct> ShowProductType(string Type)
        {
            var select = context.Products.Where(c => c.Type == Type).ToList();
            if (select != null)
            {
                List<MProduct> product = new List<MProduct>();
                foreach (var item in select)
                {

                    MProduct c = new MProduct()
                    {
                        Name = item.Name,
                        price = item.price,
                        Count = item.Count,
                        discription = item.discription,
                        MainImage = item.MainImage,
                        Status = item.Status,
                        IdColor = item.IdColor,
                        IdSize = item.IdSize,
                        IdCategory = item.IdCategory,
                        discount = item.discount,
                        Type = item.Type
                    };
                    product.Add(c);
                }
                return product;
            }
            else
            {
                return null;
            }
        }


    }
}