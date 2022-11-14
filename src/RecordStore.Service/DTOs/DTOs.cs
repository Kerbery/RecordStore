namespace RecordStore.Service.DTOs
{
    public record CreateUserDTO(string UserName, string Email, string Password, IEnumerable<string> Roles);
    public record UpdateUserDTO(Guid Id, string UserName, string Email, string? Password, IEnumerable<UserRoleDTO> Roles);
    public record UserRoleDTO(string Name, bool IsInRole);
}
