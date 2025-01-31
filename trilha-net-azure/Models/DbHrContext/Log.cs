using System.ComponentModel.DataAnnotations;

namespace trilha_net_azure.Models.DbHrContext
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string Action { get; set; }
        public string MyProperty { get; set; }
        public DateTimeOffset Timestamp { get; set; }

    }
}
