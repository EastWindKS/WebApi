namespace WebAPI.Models.Filters;

public enum SearchOptionEnum
{
    Equal = 1,
    NotEqual,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual,
    GreaterThanLessThan,
    GreaterThanOrEqualLessThanOrEqual,
    GreaterThanOrEqualLessThan,
    GreaterThanLessThanOrEqual,
    Contains,
    NotContains,
    True,
    False,
    Container,
    Route,
    RoutePoint,
    IsNull,
    NotNull,
    CollectionFilled,
    CollectionEmpty
}