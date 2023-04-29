using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using DTOLayer.DTOs.Siparis;
using EntityLayer.Concrete;
using Otomativ_e_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
	public class EfSiparis : GenericRepository<Siparis>, ISiparisDal
	{
		
	}
}
