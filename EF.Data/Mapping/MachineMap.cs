using EF.Core.Data;
using System.Data.Entity.ModelConfiguration;

namespace EF.Data.Mapping
{
    public class MachineMap : EntityTypeConfiguration<Machine>
    {
        public MachineMap()
        {
            HasKey(t => t.MachineNo);
            Property(t => t.MachineNo).HasColumnName("MACHINE_NO");
            Property(t => t.MachineName).HasColumnName("MACHINE_NAME");
            Property(t => t.OperationNo).HasColumnName("OPERATION_NO");
            Property(t => t.JitCellNo).HasColumnName("JIT_CELL_NO");
            ToTable("EIS_MACHINE", "EIS");
        }
    }
}