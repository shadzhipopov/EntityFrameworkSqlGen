using System;

namespace Model.Enums
{
    public enum RelationType
    {
        OneToZeroOrOne,
        OneToMany,
        ManyToMany
    }

    public static class RelationTypeExtensions
    {
        public static RelationType GetRelationTypeFromRelationEnds(RelationEnd principalEnd, RelationEnd dependentEnd)
        {
            if(principalEnd == RelationEnd.One && dependentEnd == RelationEnd.One)
            {
                return RelationType.OneToZeroOrOne;
                throw new NotSupportedException("One to one relations are not supported!");
            }

            if (principalEnd == RelationEnd.One && dependentEnd == RelationEnd.ZeroOrOne)
            {
                return RelationType.OneToZeroOrOne;
            }
            if((principalEnd == RelationEnd.One || principalEnd == RelationEnd.ZeroOrOne) &&
                dependentEnd == RelationEnd.Many)
            {
                return RelationType.OneToMany;
            }
            return RelationType.ManyToMany;
        }
    }
}
