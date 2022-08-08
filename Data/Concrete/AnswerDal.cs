using Data.Abstract;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class AnswerDal : AdoRepository<AnswerEntities>, IAnswerDal { }
}
