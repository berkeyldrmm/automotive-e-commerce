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
			ViewBag.title = "İletişim";
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
				mesajManager.TEkle(mesaj);
				ViewBag.mesaj = "Form gönderildi.";
			}
			else
			{
				foreach (var error in validationResult.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
				}
				ViewBag.mesaj = "Form gönderilmedi";
			}

			return View();
		}
	}
}
