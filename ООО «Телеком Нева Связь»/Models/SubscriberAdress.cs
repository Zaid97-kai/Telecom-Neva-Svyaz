//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ООО__Телеком_Нева_Связь_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubscriberAdress
    {
        public int Id { get; set; }
        public Nullable<int> SubscriberId { get; set; }
        public string Prefix_code { get; set; }
        public string Raion { get; set; }
        public string Prefix { get; set; }
        public string House { get; set; }
    
        public virtual Subscribers Subscribers { get; set; }
    }
}
