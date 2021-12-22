using Business.Abstract;

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Concrete.Constants;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
        
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public IResult Add(Article article)
        {
            _articleDal.Add(article);
            
            return new SuccesResult(Messages.ArticleAdded);
            
        }

        public IResult Delete(Article article)
        {
            _articleDal.Delete(article);
            return new SuccesResult(Messages.ArticleDeleted);
        }

        public IDataResult<Article> GetById(int articleId)
        {
            return new SuccesDataResult<Article>(_articleDal.Get(a => a.Id == articleId));
        }

        public IDataResult<List<Article>> GetList()
        {
            return new SuccesDataResult<List<Article>>(_articleDal.GetList().ToList()) ;
        }

        public IDataResult<List<Article>> GetListByCategory(int categoryId)
        {
            return new SuccesDataResult<List<Article>>( _articleDal.GetList(a => a.CategoryId == categoryId).ToList());
        }

        public IResult Update(Article article)
        {
            _articleDal.Update(article);
            return new SuccesResult(Messages.ArticleUpdated);
        }
    }
}
