using API.Accounts.Entities;

namespace API.Accounts.Interfaces;

public interface ITokenService
{
    string CrateToken(AppUser user);

}
