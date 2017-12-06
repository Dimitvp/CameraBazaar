namespace CameraBazaar.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }
        public void Create(
            CameraMake make, 
            string model, 
            decimal price, 
            int quantity, 
            int minShutterSpeed, 
            int maxShutterSpeed,
            MinISO minISO, 
            int maxISO, 
            bool isFullFrame, 
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description, 
            string imageUrl,
            string userId)
        {
            var camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MaxISO = maxISO,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }

        public bool Edit(
            int id,
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description,
            string imageUrl,
            string userId)
        {
            var camera = this.db
                .Cameras
                .FirstOrDefault(c => c.Id == id && c.UserId == userId);

            if (camera == null)
            {
                return false;
            }

            camera.Make = make;
            //Update everything else

            this.db.SaveChanges();

            return true;
        }

        public bool Exists(int id, string userId)
            => this.db.Cameras.Any(c => c.Id == id && c.UserId == userId);
    }
}
