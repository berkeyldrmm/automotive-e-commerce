using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Otomativ_e_ticaret.Controllers
{
	public class IletisimController : Controller
	{
		private readonly IMesajService mesajManager;

		public IletisimController(IMesajService mesajManager)
		{
			this.mesajManager = mesajManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Mesaj mesaj)
		{
			mesaj.MesajZamani = DateTime.Now;
			MesajValidator mesajValidator = new MesajValidator();
			ValidationResult validationResult = mesajValidator.Validate(mesaj);

			if(validationResult.IsValid) 
			{
				Console.WriteLine(ModelState);
				mesajManager.TEkle(mesaj);
				ViewBag.mesaj = "Form gönderildi.";
			}
			else
			{
				foreach (var error in validationResult.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
				}
				Console.WriteLine(ModelState);
				ViewBag.mesaj = "Form gönderilmedi";
			}


			return View();
		}
	}
}
