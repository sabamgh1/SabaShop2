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
    public class RColor : IColor
    {
        private readonly IMapper iMap;
        private readonly SabaShopContext context;
        public RColor(SabaShopContext Context, IMapper IMap)
        {
            context = Context;
            iMap = IMap;
        }

        public bool AddColor(MColor Color)
        {
            var c= iMap.Map<Color>(Color);
            context.colors.Add(c);
            context.SaveChanges();
            return true;
        }


        public bool DeleteColor(int id)
        {
            var select = context.colors.SingleOrDefault(u => u.Id == id);
            if (select != null)
            {
                context.colors.Remove(select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

       
        public List<MColor> ShowColorProduct()
        {
            var select = context.colors.ToList();
            if (select != null)
            {
                List<MColor> Color = new List<MColor>();
                foreach (var item in select)
                {
                    MColor c = new MColor()
                    {
                        Id=item.Id,
                        color = item.color,
                        IdProduct=item.IdProduct
                    };
                    Color.Add(c);
                }
                return Color;
            }
            else
            {
                return null;
            }
        }


        public bool UpdateColor(MColor color)
        {
           var Select = context.colors.SingleOrDefault(c=>c.Id==color.Id);
            if (Select!=null)
            {
                
                Select.color = color.color;
                Select.IdProduct=color.IdProduct;
                
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