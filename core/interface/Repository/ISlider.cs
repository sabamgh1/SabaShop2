using System;
using System.Collections.Generic;
using core.Domain;

namespace core.Repository
{
    public interface ISlider
    {
        bool AddSlider(MSlider Slider); 
        bool UpdateSlider(MSlider Slider);
        bool DeleteSlider(int id);
        List<MSlider> ShowActiveImageSlider();
        List<MProduct> ShowProductSlider(int IdSlider);
        
    }
}