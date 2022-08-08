using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService
{
    public static class SubjectCache
    {
        private ISubjectService _subjectService = new SubjectManager(new SubjectDal());
    }
}
