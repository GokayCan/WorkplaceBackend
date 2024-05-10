using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Authentication;
using Business.Repositories.EmailParameterRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Repositories.EmailParameterRepository;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.UserOperationClaimRepository;
using Business.Repositories.CompanyRepository;
using DataAccess.Repositories.CompanyRepository;
using Business.Repositories.CompanyResponsibleRepository;
using DataAccess.Repositories.CompanyResponsibleRepository;
using Business.Repositories.CompanyStaffRepository;
using DataAccess.Repositories.CompanyStaffRepository;
using Business.Repositories.CompanyStudentRepository;
using DataAccess.Repositories.CompanyStudentRepository;
using Business.Repositories.DepartmentRepository;
using DataAccess.Repositories.DepartmentRepository;
using Business.Repositories.FacultyRepository;
using DataAccess.Repositories.FacultyRepository;
using Business.Repositories.InterestRepository;
using DataAccess.Repositories.InterestRepository;
using Business.Repositories.LanguageRepository;
using DataAccess.Repositories.LanguageRepository;
using Business.Repositories.ProgrammingRepository;
using DataAccess.Repositories.ProgrammingRepository;
using Business.Repositories.StaffRepository;
using DataAccess.Repositories.StaffRepository;
using Business.Repositories.StudentRepository;
using DataAccess.Repositories.StudentRepository;
using Business.Repositories.StudentInterestRepository;
using DataAccess.Repositories.StudentInterestRepository;
using Business.Repositories.StudentLanguageRepository;
using DataAccess.Repositories.StudentLanguageRepository;
using Business.Repositories.StudentProgrammingRepository;
using DataAccess.Repositories.StudentProgrammingRepository;
using DataAccess.Repositories.UserRepository;
using Business.Repositories.SectorRepository;
using DataAccess.Repositories.SectorRepository;
using Business.Repositories.LessonRepository;
using DataAccess.Repositories.LessonRepository;
using Business.Repositories.StudentLessonRepository;
using DataAccess.Repositories.StudentLessonRepository;
using Business.Repositories.SemesterRepository;
using DataAccess.Repositories.SemesterRepository;
using Business.Utilities.ExcelReader;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            builder.RegisterType<EfEmailParameterDal>().As<IEmailParameterDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<CompanyResponsibleManager>().As<ICompanyResponsibleService>().SingleInstance();
            builder.RegisterType<EfCompanyResponsibleDal>().As<ICompanyResponsibleDal>().SingleInstance();

            builder.RegisterType<CompanyStaffManager>().As<ICompanyStaffService>().SingleInstance();
            builder.RegisterType<EfCompanyStaffDal>().As<ICompanyStaffDal>().SingleInstance();

            builder.RegisterType<CompanyStudentManager>().As<ICompanyStudentService>().SingleInstance();
            builder.RegisterType<EfCompanyStudentDal>().As<ICompanyStudentDal>().SingleInstance();

            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().SingleInstance();

            builder.RegisterType<FacultyManager>().As<IFacultyService>().SingleInstance();
            builder.RegisterType<EfFacultyDal>().As<IFacultyDal>().SingleInstance();

            builder.RegisterType<InterestManager>().As<IInterestService>().SingleInstance();
            builder.RegisterType<EfInterestDal>().As<IInterestDal>().SingleInstance();

            builder.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();

            builder.RegisterType<ProgrammingManager>().As<IProgrammingService>().SingleInstance();
            builder.RegisterType<EfProgrammingDal>().As<IProgrammingDal>().SingleInstance();

            builder.RegisterType<StaffManager>().As<IStaffService>().SingleInstance();
            builder.RegisterType<EfStaffDal>().As<IStaffDal>().SingleInstance();

            builder.RegisterType<StudentManager>().As<IStudentService>().SingleInstance();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>().SingleInstance();

            builder.RegisterType<StudentInterestManager>().As<IStudentInterestService>().SingleInstance();
            builder.RegisterType<EfStudentInterestDal>().As<IStudentInterestDal>().SingleInstance();

            builder.RegisterType<StudentLanguageManager>().As<IStudentLanguageService>().SingleInstance();
            builder.RegisterType<EfStudentLanguageDal>().As<IStudentLanguageDal>().SingleInstance();

            builder.RegisterType<StudentProgrammingManager>().As<IStudentProgrammingService>().SingleInstance();
            builder.RegisterType<EfStudentProgrammingDal>().As<IStudentProgrammingDal>().SingleInstance();

            
            builder.RegisterType<ExcelManager>().As<IExcelService>().SingleInstance();

            builder.RegisterType<SectorManager>().As<ISectorService>().SingleInstance();
            builder.RegisterType<EfSectorDal>().As<ISectorDal>().SingleInstance();

            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().SingleInstance();

            builder.RegisterType<StudentLessonManager>().As<IStudentLessonService>().SingleInstance();
            builder.RegisterType<EfStudentLessonDal>().As<IStudentLessonDal>().SingleInstance();

            builder.RegisterType<SemesterManager>().As<ISemesterService>().SingleInstance();
            builder.RegisterType<EfSemesterDal>().As<ISemesterDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
