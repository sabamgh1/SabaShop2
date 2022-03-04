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
    public class RCategory : ICategory
    {
        private readonly IMapper iMap;
        private readonly SabaShopContext context;
        public RCategory(SabaShopContext Context, IMapper IMap)
        {
            context = Context;
            iMap = IMap;
        }
        public bool AddCategory(MCategory mcategory)
        {
            Category s = new Category()
            {
                Name = mcategory.Name,
                Status = mcategory.Status,
                ParentId = mcategory.ParentId
            };
            context.categories.Add(s);
            context.SaveChanges();
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var select = context.categories.SingleOrDefault(u => u.Id == id);
            if (select != null)
            {
                context.categories.Remove(select);
                context.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }

        public List<MCategory> ShowActiveStatus()
        {
            var select=context.categories.Where(c=>c.Status=="1").ToList();
            if (select!=null)
            {
                List<MCategory> category= new List<MCategory>();
                foreach (var item in select)
                {
                    MCategory c=new MCategory()
                    {
                        Name=item.Name,
                        ParentId=item.ParentId
                    };
                    category.Add(c);
                }
                return category;
            }
            else
            {
                return null;
            }
        }

        
        public List<MCategory> ShowChildCategory(int id)
        {
            var select=context.categories.Where(c=>c.ParentId==id && c.Status=="1").ToList();
            if (select!=null)
            {
                List<MCategory> category= new List<MCategory>();
                foreach (var item in select)
                {
                    MCategory c=new MCategory()
                    {
                        Name=item.Name,
                        ParentId=item.ParentId
                    };
                    category.Add(c);
                }
                return category;
            }
            else
            {
                return null;
            }
        }

        public List<MCategory> ShowDeActiveStatus()
        {
            var select=context.categories.Where(c=>c.Status=="0").ToList();
            if (select!=null)
            {
                List<MCategory> category= new List<MCategory>();
                foreach (var item in select)
                {
                    MCategory c=new MCategory()
                    {
                        Name=item.Name,
                        ParentId=item.ParentId
                    };
                    category.Add(c);
                }
                return category;
            }
            else
            {
                return null;
            }
        }

        public MCategory ShowParentCategory(int id)
        {
           var select=context.categories.SingleOrDefault(c=>c.Id==id).ParentId;
            
            var parent = context.categories.SingleOrDefault(p=>p.Id==select);
            MCategory c=new MCategory();
            c.Name=parent.Name;
            c.ParentId=parent.ParentId;
            return c;
        
        }

        public bool UpdateCategory(MCategory category)
        {
            var Select = context.categories.SingleOrDefault(c=>c.Id==category.Id);
            if (Select!=null)
            {
                Select.Name=category.Name;
                Select.ParentId=category.ParentId;
                Select.Status=category.Status;
                
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
