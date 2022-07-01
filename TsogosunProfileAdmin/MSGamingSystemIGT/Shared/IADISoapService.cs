using System;

namespace tsogosun.com.MSGamingSystemIGT.Shared
{
    public interface IADISoapService
    {
        string GetResponse(string ipAddress, string requestBody);
    }
}
