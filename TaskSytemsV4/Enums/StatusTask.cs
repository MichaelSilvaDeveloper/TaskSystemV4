using System.ComponentModel;

namespace TaskSytemsV4.Enums
{
    public enum StatusTask
    {
        [Description("Pendente")]
        Pending = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluído")]
        Concluded = 3
    }
}
