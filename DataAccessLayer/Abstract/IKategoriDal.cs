﻿using DataAccessLayer.Abstraact;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IKategoriDal : IGenericDal<Kategori>
    {
        public Kategori GetKategoriByKod(string KategoriKod);
    }
}
