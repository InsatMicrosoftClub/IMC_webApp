using DAL.RepositoryUoW;
using Entities.Models;
using IMC_webApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC_webApp.BuisnessLogic
{
    class SubjectService
    {
        public void addSubject(Subject model)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.getRepository<Subject, int>().Add(model);
                unitOfWork.Save();
            }
        }

        public List<Subject> getAllSubjects()
        {
            IList<Subject> Subjects;
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                Subjects = unitOfWork.getRepository<Subject, int>().GetAll();
            }
            return (List<Subject>)Subjects;
        }
        

        public void Delete(Subject model)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.getRepository<Subject, int>().Delete(model);
                unitOfWork.Save();
            }
        }
        public void Update(Subject model)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.getRepository<Subject, int>().Update(model);
                unitOfWork.Save();
            }
        }
    }
}
