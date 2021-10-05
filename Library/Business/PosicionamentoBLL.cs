﻿using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class PosicionamentoBLL
    {
        public List<Posicionamento> GetAll()
        {
            PosicionamentoDAL pDAL = new PosicionamentoDAL();
            return pDAL.GetAll();
        }
    }
}
