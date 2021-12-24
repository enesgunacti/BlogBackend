using Business.Abstract;
using Business.Concrete.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccesResult(Messages.CommentAdded);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccesResult(Messages.CommentDeleted);
        }

        public IDataResult<List<Comment>> GetById(int articleId)
        {
            return new SuccesDataResult<List<Comment>> (_commentDal.GetList(c => c.ArticleId == articleId).ToList());
        }

        public IDataResult<List<Comment>> GetList()
        {
            return new SuccesDataResult<List<Comment>>(_commentDal.GetList().ToList());
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccesResult(Messages.CommentUpdated);
        }
    }
}
