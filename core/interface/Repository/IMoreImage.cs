using System;
using System.Collections.Generic;
using core.Domain;

namespace core.Repository
{
    public interface IMoreImage
    {
        bool AddMoreImage(MMoreImage MoreImage); 
        bool UpdateMoreImage(MMoreImage MoreImage);
        bool DeleteMoreImage(int id);
        List<MMoreImage> ShowMoreImage();
        
    }
}