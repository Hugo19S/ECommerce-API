using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.CustomErrors;

public static class DomainErrors
{
    // Not Found Message
    public static Error NotFound(string entity, Guid entityId) =>
        Error.NotFound($"{entity}.NotFound", $"{entity} with id {entityId} not found.");

    // Conflict Message
    public static Error Conflict(string entity) =>
        Error.Conflict($"{entity}.Conflict", $"There's already a {entity} with the same name!");

    // Order Error
    public static Error Generic(string entity, string item) =>
        Error.NotFound($"This {entity} don't have {item}");

    public static Error CategoryTypeConflict() =>
        Error.Conflict("Name.Conflict", "There's already a category of the same name on this type!");

    // Operation Errors
    public static Error JSonPatchNotFound() =>
        Error.NotFound("JSonPatch.NotFound", $"JSonPatch should not be empty!");
    
    public static Error OperationUnauthorized() =>
        Error.Unauthorized("Operation.Unauthorized", $"Moving and copying operations are not allowed!");

    public static Error OperationPathUnauthorized() =>
        Error.Unauthorized("Operation.Unauthorized", $"This operation is not allowed in this path!");   
}
