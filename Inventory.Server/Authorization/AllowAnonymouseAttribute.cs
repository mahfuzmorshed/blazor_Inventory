namespace Inventory.Server.Authorization;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{ } 