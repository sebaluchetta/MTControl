using MTControl.DAO;


namespace MTControl.Services.Interface
{
    public interface IResultService
    {
        
        void CreateResults ( List<Result> results );
        List<Result> GetAllResults ( );
        void DeleteResults (  );
    }
}
