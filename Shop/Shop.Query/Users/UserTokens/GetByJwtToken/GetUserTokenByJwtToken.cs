using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.UserTokens.GetByJwtToken
{
    public class GetUserTokenByJwtTokenQuery : IQuery<UserTokenDto?>
    {
        public string HashJwtToken { get; private set; }

        public GetUserTokenByJwtTokenQuery(string hashJwtToken)
        {
            HashJwtToken = hashJwtToken;
        }
    }
}

