

using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IActiveDirectoryAuthService
    {
        AuthToken Login(Credentials credentials);

    }
}
