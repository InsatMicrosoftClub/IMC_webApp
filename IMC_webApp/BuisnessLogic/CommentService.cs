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
    public class CommentService
    {
        public void addComment(Comment model)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.getRepository<Comment, int>().Add(model);
                unitOfWork.Save();
            }
        }

        public List<Comment> getAllComments()
        {
            IList<Comment> Comments;
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                Comments = unitOfWork.getRepository<Comment, int>().GetAll();
            }
            return (List<Comment>)Comments;
        }
        public List<Comment> getCommentsByMember(string MemberID)
        {
            List<Comment> Comments;
            IEnumerable<Comment> query;
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                Comments = (List<Comment>)unitOfWork.getRepository<Comment, int>().GetAll();
                query = from c in Comments where c.User.Id == MemberID select c;

            }
            return (List<Comment>)query;
        }

        public void Delete(Comment model)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.getRepository<Comment, int>().Delete(model);
                unitOfWork.Save();
            }
        }
        public void Update(Comment model)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.getRepository<Comment, int>().Update(model);
                unitOfWork.Save();
            }
        }
    }
}
