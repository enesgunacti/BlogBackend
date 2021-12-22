using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        IDataResult<Article> GetById(int articleId);
        IDataResult<List<Article>> GetList();
        IDataResult<List<Article>> GetListByCategory(int categoryId);
        IResult Add(Article article);
        IResult Delete(Article article);
        IResult Update(Article article);


    }
}
