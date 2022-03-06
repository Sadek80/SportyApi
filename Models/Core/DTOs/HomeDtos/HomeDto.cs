using SportyApi.Models.Core.DTOs.ProductDtos;
using SportyApi.Models.Core.DTOs.TrainingProgramsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models.Core.DTOs.HomeDtos
{
    public class HomeDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<TrainingProgramDto> TrainingPrograms { get; set; }
    }
}
