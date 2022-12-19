using System.Collections.Generic;

namespace DynamicCRUD.Data
{
    public class RequestObject
    {
        public string TableName { get; set; }
        public List<string> SelectProperties { get; set; }
        public SelectType SelectType { get; set; }
    }
    public enum SelectType
    {
        Single,
        List
    }
}
