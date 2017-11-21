namespace CameraBazaar.Services
{
    using CameraBazaar.Data.Models;

    public interface ICameraService
    {
        void Create(
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxIso,
            bool isFullFrame,
            string videoResolution,
            LightMetering lightMetering,
            string description,
            string imageUrl,
            string userId);
    }
}
