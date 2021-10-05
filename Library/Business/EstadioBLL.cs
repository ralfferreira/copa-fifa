using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class EstadioBLL
    {
        EstadioDAL dao = new EstadioDAL();

        public bool Insert(Estadio e)
        {
            bool salvou = false;
            dao.Insert(e);

            if(e.Id > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Estadio> GetAll()
        {            
            return dao.GetAll();
        }

        public Estadio GetById(int id)
        {            
            return dao.GetById(id);
        }

        public bool Update(Estadio e)
        {
            bool atualizou = false;
            
            if(e.Id == 0)
            {
                throw new Exception("Selecione um estádio para atualizar.");
            }

            if(dao.Update(e) == 0)
            {
                atualizou = true;
            }
            return atualizou;
        }

        public bool Delete(int id)
        {
            bool deletou = false;

            if(dao.Delete(id) == 0)
            {
                deletou = true;
            }
            return deletou;
        }
    }
}
