using EF.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace EF.Data
{
    public class CustomRepository
    {
        private readonly EfContext _context;

        public CustomRepository(EfContext context)
        {
            _context = context;
        }

        public Machine GetMachineByMachineNo(string machineNo)
        {
            var q = string.Format(@"SELECT MACHINE_NO MachineNo, MACHINE_NAME MachineName, OPERATION_NO OperationNo, JIT_CELL_NO JitCellNo FROM EIS_MACHINE WHERE MACHINE_NO = '{0}'", machineNo);
            return _context.Database.SqlQuery<Machine>(q).SingleOrDefault();
        }
    }
}