namespace CameraBazaar.Services.Implementations
{
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }
        public void Create(CameraMake make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed,
            MinISO minISO, int maxIso, bool isFullFrame, string videoResolution, LightMetering lightMetering, string description, string imageUrl,
            string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
