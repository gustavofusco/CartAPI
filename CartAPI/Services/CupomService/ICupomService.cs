namespace CartAPI.Services.CupomService
{
    public interface ICupomService
    {
        Task<List<Cupom>> GetAll();
        Task<Cupom> ApplyCupom(string cod, int idUser);
    }
}
