using System;
using System.Collections.Generic;
using core.Domain;

namespace core.Repository
{
    public interface IColor
    {
        bool AddColor(MColor Color); 
        bool UpdateColor(MColor Color);
        bool DeleteColor(int id);
        List<MColor> ShowColorProduct();
        
    }
}