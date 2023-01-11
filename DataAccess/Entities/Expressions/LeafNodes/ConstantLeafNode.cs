using Model.Enums;

namespace DataAccess.Entities.Expressions.LeafNodes
{
    public class ConstantLeafNode : LeafNode
    {
        public FdbaDataType ConstantType { get; set; }

        public string Value { get; set; }
    }
}
