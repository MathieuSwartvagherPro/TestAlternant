using S_InterModels.IRepository;
using S_InterModels.Models.Optimus;

namespace S_InterModels.Repository
{
    internal class Usr :
    {
        private readonly OptimusContext _OptimusContext;

        public Usr(OptimusContext optimusContext)
        {
            _OptimusContext = optimusContext;
        }

        //AIDE : await _OptimusContext.nomTable.ToListAsync();
    }
}