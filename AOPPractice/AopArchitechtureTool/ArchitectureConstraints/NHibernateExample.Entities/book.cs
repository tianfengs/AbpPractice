using System;
namespace NHibernateExample.Entities
{
    public class Book
    {
        public virtual Guid Id { get; set; }
        //测试NhEntityAttribute的时候取消注释
        //public string Name { get; set; }//这个不小心忘记了virtual
        public virtual string Publisher { get; set; }
        public virtual decimal Price { get; set; }
    }
}
