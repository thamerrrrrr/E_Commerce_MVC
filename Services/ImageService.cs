namespace E_Commerce_MVC.Services
{
    public class ImageService
    {
        private string _ImageFolderPath;
        public ImageService()
        {
            _ImageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
        }
        public string UploadImage(IFormFile image)
        {
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filepath = Path.Combine(_ImageFolderPath, filename);
            using (var stream = System.IO.File.Create(filepath))
            {
                image.CopyTo(stream);
            }
            return filename;
        }
        public bool DeleteImage(string filename) { 
         var filepath = Path.Combine(_ImageFolderPath, filename);
        
            if (File.Exists(filepath))
            {
               
                File.Delete(filepath);
                return true;
            }
            return false;
        }
    }
}
