namespace ClimbEdge.Common.Constants
{
    public static class Constants
    {
        public const string DefaultDateFormat = "yyyy-MM-dd";
        public const string DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string DefaultTimeZone = "UTC-5";
        public const string DefaultTimeFormat = "HH:mm:ss";
        public const string DefaultDateTimeFormatWithZone = "yyyy-MM-dd HH:mm:ss zzz"; // Incluye zona horaria
        public const string DefaultDateTimeOffsetFormat = "yyyy-MM-ddTHH:mm:ss.fffK"; // Formato de DateTimeOffset
        public const int CachingExpiration = 1800; // Tiempo de expiración para caché en segundos (30 minutos)

        // Otros constantes comunes
        public const int MaxPageSize = 100;
        public const int DefaultPageSize = 20;
        public const int RecentlyDaysThreshold = 30; // Días para considerar un registro como reciente
        public const string DefaultCurrency = "USD";
        public const string DefaultLanguage = "es-LA"; // Español de América Latina
        public const string DefaultCountry = "EC"; // Estados Unidos
        public const string DefaultApiVersion = "0.1";
        public static IReadOnlyList<string> AllowedApiVersions => new[] { "0.1" };

        public const string ApiName = "ClimbEdge API";
        public const string ApiDescription = "API for ClimbEdge application providing various endpoints for climbing-related data and operations.";
    }
}