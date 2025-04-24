using API_PDS.Model;
using API_PDS.ViewModel;

namespace API_PDS.Services
{
    public class CondominioService
    {
        private readonly CondoSocialContext _context;
        private readonly UtilizadorService _utilizadorService;

        public CondominioService(CondoSocialContext context, UtilizadorService utilizadorService)
        {
            _context = context;
            _utilizadorService = utilizadorService;
        }

        /// <summary>
        /// Adiciona um novo condominio à DB
        /// </summary>
        /// <param name="condominio"></param>
        public void AdicionarCondominio(Condominio condominio, NovoCondominioViewModel uvm)
        {
            _context.Condominios.Add(condominio);
            _context.SaveChanges();
            uvm.CondominioId = condominio.Id;
            _utilizadorService.AdicionarUtilizador(uvm);
        }

        /// <summary>
        /// Verifica se um determinado cod. postal já existe
        /// </summary>
        /// <param name="cp"></param>
        /// <returns></returns>
        public bool existeCP(string cp)
        {
            return _context.CodigoPostal.Any(con => con.CP == cp);
        }

        /// <summary>
        /// Adiciona o CP à DB
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="localidade"></param>
        public void AdicionarCP(string cp, string localidade) {
            CodigoPostal codigoPostal = new CodigoPostal(cp, localidade);
            _context.CodigoPostal.Add(codigoPostal);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtem um condominio com determinado Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Condominio ObtemCondominioId(int id)
        {
            return _context.Condominios.FirstOrDefault(c => c.Id == id);
        }


        public List<Condominio> ObtemTodosCondominios()
        {
            return _context.Condominios.ToList();
        }
    }
}
