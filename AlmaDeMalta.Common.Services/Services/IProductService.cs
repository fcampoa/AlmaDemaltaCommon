using AlmaDeMalta.Common.Contracts.Attributes;
using AlmaDeMalta.Common.Contracts.Contracts;

namespace AlmaDeMalta.Common.Services.Services;
    [ServiceClass(targetClass: typeof(ProductService), strategy: StrategyEnum.Scoped)]
    public interface IProductService: IBaseService<Product>
    {

    }
