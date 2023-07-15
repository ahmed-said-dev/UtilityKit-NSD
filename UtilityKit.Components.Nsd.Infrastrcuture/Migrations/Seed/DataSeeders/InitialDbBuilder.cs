using UtilityKit.Components.Nsd.Infrastrcuture;

namespace UtilityKit.Components.Nsd.Infrastrcuture.Migrations.Seed.DataSeeders
{
    public class InitialDbBuilder
    {
        private readonly NsdDbContext  _context;

        public InitialDbBuilder(NsdDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //new UserCreator(_context).Create();
          
            _context.SaveChanges();
        }
    }
}
