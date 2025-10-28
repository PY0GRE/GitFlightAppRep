using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Helpers
{
    public static class ImageHelper
    {
        public static async Task<byte[]?> CapturePhotoAsync()
        {

            FileResult? photo = await MediaPicker.CapturePhotoAsync();
            /*
             * Inversion de control 
            if (  photo != null )
            {
                using var stream = await photo.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
            }
            return null;
            */
            if ( photo == null )
                return null;

            using var stream = await photo.OpenReadAsync();
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }

        /// <summary>
        /// Convierte un arreglo de bytes a ImageSource para mostrar en la interfaz
        /// </summary>
        /// <param name="bytesArray"></param>
        /// <returns></returns>
        public static ImageSource? ToImageSource(byte[]? bytesArray)
        {
            /*
            if ( bytesArray != null && bytesArray.Length > 0)
            {
                return ImageSource.FromStream(() => new MemoryStream(bytesArray));
            }
            return null;
            */

            //if ( bytesArray == null || bytesArray.Length == 0 )
            //return null;

            if ( bytesArray == null ) return null;

            return ImageSource.FromStream(() => new MemoryStream(bytesArray));
        }

        public static async Task<string?> SaveImageLocaclyAsync(FileResult fileResult)
        {
            if ( fileResult == null )
                return null;

            var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileResult.FileName)}";
            var newFilePath = Path.Combine(FileSystem.AppDataDirectory, newFileName);
            using var sourceStream = await fileResult.OpenReadAsync();
            using var destinationStream = File.OpenWrite(newFilePath);
            await sourceStream.CopyToAsync(destinationStream);
            return newFilePath;
        } 
    }
}
