using Abp.Specifications;

namespace bootcamp_store_backend.Infrastucture.Specs
{
    public interface ISpecificationParser<T>
    {
        Specification<T> ParseSpecification(string filter);
    }
}
