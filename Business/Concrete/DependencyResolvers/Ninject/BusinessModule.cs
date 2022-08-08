using Business.Abstract;
using Business.Concrete.Answer;
using Business.Concrete.Subject;
using Data.Abstract;
using Data.Concrete;
using Ninject;
using Ninject.Modules;

namespace Business.Concrete.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISubjectService>().To<SubjectManager>().InSingletonScope().WithConstructorArgument(new SubjectDal());

            Bind<ISubjectDal>().To<SubjectDal>();

            Bind<IAnswerService>().To<AnswerManager>().InSingletonScope().WithConstructorArgument(new AnswerDal());
            Bind<IAnswerDal>().To<AnswerDal>();

        }
    }
}
