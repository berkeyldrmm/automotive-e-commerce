using EntityLayer.Concrete;

namespace Otomativ_e_ticaret.Controllers
{
    public static class GorselOlustur
    {
        public static async void gorselOlustur(Urun urun, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var randomName = String.Format($"{Guid.NewGuid()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            urun.GorselUrl = "images/" + randomName;
        }
    }
}
