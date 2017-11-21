namespace CameraBazaar.Web.Infrastructure.Extensions
{
    using Data.Models;

    public static class EnumExtensions
    {
        public static string ToDisplayName(this LightMetering lightMetering)
        {
            if (lightMetering == LightMetering.CenterWeighted)
            {
                return "CenterWeighted";
            }

            return lightMetering.ToString();
        }
    }
}
