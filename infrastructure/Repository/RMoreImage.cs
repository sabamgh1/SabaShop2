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
    public class RMoreImage : IMoreImage
    {
        private readonly IMapper iMap;
        private readonly SabaShopContext context;
        public RMoreImage(SabaShopContext Context, IMapper IMap)
        {
            context = Context;
            iMap = IMap;
        }


        public bool AddMoreImage(MMoreImage MoreImage)
        {
            var c= iMap.Map<MoreImage>(MoreImage);
            
            context.MoreImages.Add(c);
            context.SaveChanges();
            return true;
        }

        public bool DeleteMoreImage(int id)
        {
             var select = context.MoreImages.SingleOrDefault(u => u.Id == id);
            if (select != null)
            {
                context.MoreImages.Remove(select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MMoreImage> ShowMoreImage()
        {
             var select = context.MoreImages.ToList();
            if (select != null)
            {
                List<MMoreImage> moreImage = new List<MMoreImage>();
                foreach (var item in select)
                {
                    MMoreImage c = new MMoreImage()
                    {
                        Id=item.Id,
                        moreImage = item.moreImage,
                        IdProduct=item.IdProduct
                    };
                    moreImage.Add(c);
                }
                return moreImage;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateMoreImage(MMoreImage MoreImage)
        {
             var Select = context.MoreImages.SingleOrDefault(c=>c.Id==MoreImage.Id);
            if (Select!=null)
            {
                
                Select.moreImage = MoreImage.moreImage;
                Select.IdProduct=MoreImage.IdProduct;
                
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