using ClientBase.ViewModel.Base;
using Shared.Core.Entities;
using Shared.Core.Entities.Base;

namespace ClientBase.ViewModel
{
  public class ProductViewModel : ProductBaseViewModel<ProductBase>
  {
    public ProductViewModel(ProductBase product) : base(product)
    {
    }

    public ProductViewModel()
    {
      Entity = new Product();
    }
  }
}