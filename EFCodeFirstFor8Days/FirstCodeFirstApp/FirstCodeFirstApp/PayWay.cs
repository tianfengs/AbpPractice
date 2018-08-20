using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCodeFirstApp
{
    [Table("PayWay")]
    public class PayWay
    {
        public int Id { get; set; }
        [MaxLength(8,ErrorMessage = "支付方式的名称长度不能大于8")]
        public string Name { get; set; }

        public int DonatorId { get; set; }
    }
}
