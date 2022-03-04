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
    public class RSlider : ISlider
    {
        private readonly IMapper iMap;
        private readonly SabaShopContext context;
        public RSlider(SabaShopContext Context, IMapper IMap)
        {
            context = Context;
            iMap = IMap;
        }
        public bool AddSlider(MSlider Slider)
        {
            var c = iMap.Map<Slider>(Slider);
            context.Sliders.Add(c);
            context.SaveChanges();
            return true;
        }

        public bool DeleteSlider(int id)
        {
            var select = context.Sliders.SingleOrDefault(u => u.Id == id);
            if (select != null)
            {
                context.Sliders.Remove(select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MProduct> ShowProductSlider(int IdSlider)
        {
            var select = context.Sliders.SingleOrDefault(s => s.Id == IdSlider).NameSlider;
            if (select != null)
            {
                var n = context.Sliders.Where(s => s.NameSlider == select && s.Status== true).ToList();
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

        public List<MSlider> ShowActiveImageSlider()
        {
            var select = context.Sliders.Where(s => s.Status == true).ToList();
            if (select != null)
            {
                List<MSlider> Slider = new List<MSlider>();
                foreach (var item in select)
                {
                    MSlider c = new MSlider()
                    {
                        Id = item.Id,
                        ImageSlider = item.ImageSlider
                    };
                    Slider.Add(c);
                }
                return Slider;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateSlider(MSlider Slider)
        {
            var Select = context.Sliders.SingleOrDefault(c=>c.Id==Slider.Id);
            if (Select!=null)
            {
                Select.NameSlider = Slider.NameSlider;
                Select.ImageSlider=Slider.ImageSlider;
                Select.Status=Slider.Status;
                Select.IdProduct=Slider.IdProduct;
                
                
                context.Update(Select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}