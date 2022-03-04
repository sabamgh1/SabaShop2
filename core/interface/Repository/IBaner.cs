using System;
using System.Collections.Generic;
using core.Domain;

namespace core.Repository
{
    public interface IBaner
    {
        bool AddBaner(MBaner Baner); 
        bool UpdateBaner(MBaner Baner);
        bool DeleteBaner(int id);
        List<MBaner> ShowActiveImageBaner();
        List<MProduct> ShowProductBaner(int IdBaner);
        
    }
}