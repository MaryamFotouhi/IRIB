using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.UserTokens.GetByRefreshToken
{
    public class GetUserTokenByRefreshTokenQuery : IQuery<UserTokenDto?>
    {
        public string HashRefreshToken { get; private set; }

        public GetUserTokenByRefreshTokenQuery(string hashRefreshToken)
        {
            HashRefreshToken = hashRefreshToken;
        }
    }
}

