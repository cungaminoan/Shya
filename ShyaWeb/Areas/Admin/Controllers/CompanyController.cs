using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shya.DataAccess;
using Shya.DataAccess.Data;
using Shya.DataAccess.Repository.IRepository;
using Shya.Models;
using Shya.Utility;

namespace ShyaWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class CompanyController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CompanyController(IUnitOfWork db)
		{
			_unitOfWork = db;
		}
		public IActionResult Index()
		{
			List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
			return View(objCompanyList);
		}
		public IActionResult Upsert(int? id)
		{
			if (id == null || id == 0)
			{
				return View(new Company());
			}
			else
			{
				Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
				return View(companyObj);
			}
		}

		[HttpPost]
		public IActionResult Upsert(Company CompanyObj)
		{
			if (ModelState.IsValid)
			{
				
				if (CompanyObj.Id == 0)
				{

					_unitOfWork.Company.Add(CompanyObj);
				}
				else
				{
					_unitOfWork.Company.Update(CompanyObj);
				}
				_unitOfWork.Save();
				TempData["success"] = "Company was created successfully";
				return RedirectToAction("Index");
			}
			else
			{
				return View(CompanyObj);
			}
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
			return Json(new { data = objCompanyList });
		}

		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var companyToBeDelete = _unitOfWork.Company.Get(u=>u.Id == id);
			if(companyToBeDelete == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}
			_unitOfWork.Company.Remove(companyToBeDelete);
			_unitOfWork.Save();
			return Json(new { success = true, message= "Delete Successfully" });

		}
		#endregion
	}
}
