using Business.Interfaces;
using Entity.Entities;
using Infrastructure.Interfaces;
using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IBaseRepository<Product> repository) : base(unitOfWork, repository)
        {
        }
    }
}
