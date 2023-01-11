using DataAccess.Entities.Metadata;
using System.Runtime.Serialization;

namespace DataAccess.Entities.Security.Permissions.Business
{
    [DataContract(IsReference = true)]
    public abstract class BusinessObjectPermission : Permission
    {
        [DataMember]
        public Guid ObjectId { get; set; }

        [DataMember]
        public BusinessObject Object { get; set; }
    }
}
