using System;
using System.Collections.Generic;
using core.Domain;

namespace core.Repository
{
    public interface ICategory
    {
        bool AddCategory(MCategory category); 
        bool UpdateCategory(MCategory category);
        bool DeleteCategory(int id);
        List<MCategory> ShowChildCategory(int id);
        MCategory ShowParentCategory(int id);
        List<MCategory> ShowActiveStatus();
        List<MCategory> ShowDeActiveStatus();
    }
}