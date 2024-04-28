namespace SLinkUser.Domain
{
    public struct ErrorCode
    {
        public const string InternalServerError = "Internal Server Error";
        public const string BadRequest = "Bad Request";
        public const string NotFound = "NotFound";
        public const string AnErrorOccured = "An error server occured.";
    }

    public struct StatusErrorCode
    {
        public const int InternalServerError = 500;
        public const int BadRequest = 400;
        public const int NotFound = 404;
    }
}
