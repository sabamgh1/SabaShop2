using System;
using System.Collections.Generic;
using AutoMapper;
using core.Domain;
using core.Repository;
using infrastructure.Data.Context;
using infrastructure.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository
{
    public class RBaner : IBaner
    {
        private readonly IMapper iMap;
        private readonly SabaShopContext context;
        public RBaner(SabaShopContext Context, IMapper IMap)
        {
            context = Context;
            iMap = IMap;
        }

        public bool AddBaner(MBaner Baner)
        {
            
            var c = iMap.Map<Baner>(Baner);
            context.Baners.Add(c);
            context.SaveChanges();
            return true;
        }

        public bool UpdateBaner(MBaner Baner)
        {
            var Select = context.Baners.SingleOrDefault(c=>c.Id==Baner.Id);
            if (Select!=null)
            {
                Select.NameBaner = Baner.NameBaner;
                Select.ImageBaner=Baner.ImageBaner;
                Select.Status=Baner.Status;
                Select.IdProduct=Baner.IdProduct;
                
                
                context.Update(Select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBaner(int id)
        {
            var select = context.Baners.SingleOrDefault(u => u.Id == id);
            if (select != null)
            {
                context.Baners.Remove(select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MBaner> ShowActiveImageBaner()
        {
            var select = context.Baners.Where(s => s.Status == true).ToList();
            if (select != null)
            {
                List<MBaner> Baner = new List<MBaner>();
                foreach (var item in select)
                {
                    MBaner c = new MBaner()
                    {
                        Id = item.Id,
                        ImageBaner = item.ImageBaner
                    };
                    Baner.Add(c);
                }
                return Baner;
                 }
            else
            {
                return null;
            }
        }

        public List<MProduct> ShowProductBaner(int IdBaner)
        {
            var select = context.Baners.SingleOrDefault(s => s.Id == IdBaner).NameBaner;
            if (select != null)
            {
                var n = context.Baners.Where(s => s.NameBaner == select && s.Status== true).ToList();
                List<int> IdP = new List<int>();
                foreach (var item in n)
                {
                    var s = item.IdProduct;
                    IdP.Add(s);
                }

                List<MProduct> product = new List<MProduct>();
                foreach (var item in IdP)
                {
                    var p =context.Products.SingleOrDefault(s => s.Id == item);
                    var MP=iMap.Map<MProduct>(p);
                    
                    product.Add(MP);
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