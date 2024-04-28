using System.Text.Json;

namespace SLinkUser.Host.Common
{
    public struct SLinkUserConst
    {
        public const string HttpClientName = "SLinkUser.Api";
        public const string ApiUrl = "http://localhost:32768";
        public static readonly JsonSerializerOptions ApiJsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }
}
