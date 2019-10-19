using System.Collections.Generic;

namespace GOL.AcessoDados.Models
{
    public class PASSAGEIRO_AIRPLANE
    {
        public int ID { get; set; }
        public int ID_AIRPLANE { get; set; }
        public int ID_PASSAGEIRO { get; set; }

        public virtual PASSAGEIRO PASSAGEIRO { get; set; }
        public virtual AIRPLANE AIRPLANE { get; set; }

    }
}
