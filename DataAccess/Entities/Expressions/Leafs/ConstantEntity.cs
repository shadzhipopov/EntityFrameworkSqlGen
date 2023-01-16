using Model.Enums;

namespace DataAccess.EntityFramework.Entities.Expressions.Leafs
{
    public class ConstantEntity : LeafEntity
    {
        public FdbaDataType ConstantType { get; set; }

        public string Value { get; set; }
    }
}
