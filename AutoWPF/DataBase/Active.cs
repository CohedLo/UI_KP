//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoWPF.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Active
    {
        public double ID { get; set; }
        public Nullable<double> ID_мероприятия { get; set; }
        public string Активность { get; set; }
        public Nullable<double> День { get; set; }
        public Nullable<System.DateTime> Время_начала { get; set; }
        public Nullable<double> Модератор { get; set; }
        public Nullable<double> Жюри_1 { get; set; }
        public Nullable<double> Жюри_2 { get; set; }
        public Nullable<double> Жюри_3 { get; set; }
        public Nullable<double> Жюри_4 { get; set; }
        public Nullable<double> Жюри_5 { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Folk Folk { get; set; }
        public virtual Folk Folk1 { get; set; }
        public virtual Folk Folk2 { get; set; }
        public virtual Folk Folk3 { get; set; }
        public virtual Folk Folk4 { get; set; }
        public virtual Folk Folk5 { get; set; }
    }
}
