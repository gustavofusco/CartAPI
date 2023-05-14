namespace CartAPI.Services.CupomService
{
    public class CupomService : ICupomService
    {
        private readonly DataContext _context;
        public CupomService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Cupom>> GetAll()
        {
            var cupons = await _context.Cupons.ToListAsync();
            return cupons;
        }

        public async Task<Cupom> ApplyCupom(string cod, int idUser)
        {
            var cupom = await _context.Cupons.FirstOrDefaultAsync(c => c.Codigo == cod.ToUpper());

            if (cupom == null)
                return null;

            var cart = _context.Cart.FirstOrDefault(ct => ct.UserId == idUser);
            
            if (cart == null)
                return null;

            cart.Cupom = cupom;
            _context.Cart.Update(cart);
            await _context.SaveChangesAsync();

            return cupom;
        }
    }
}
