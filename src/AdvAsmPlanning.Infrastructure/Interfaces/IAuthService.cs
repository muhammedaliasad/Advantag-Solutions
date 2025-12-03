namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IAuthService
{
    string GenerateToken(long userId, IEnumerable<string> roles);
}
