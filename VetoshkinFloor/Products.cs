//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VetoshkinFloor
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            this.PartnerProduct = new HashSet<PartnerProduct>();
            this.ProductCount = new HashSet<ProductCount>();
            this.Materials = new HashSet<Materials>();
        }
    
        public string ProductArticle { get; set; }
        public int ProductType { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> StandardNumber { get; set; }
        public string ProductDescription { get; set; }
        public double ProductHeight { get; set; }
        public int MeasurementUnit { get; set; }
        public byte[] ProductImage { get; set; }
        public Nullable<double> ProductLength { get; set; }
        public Nullable<double> ProductWidth { get; set; }
        public Nullable<double> WeightWithoutPackaging { get; set; }
        public Nullable<double> WeightWithPackaging { get; set; }
        public byte[] QualityCertificate { get; set; }
        public Nullable<int> ManfacturingTime { get; set; }
        public Nullable<int> WorkshopNumber { get; set; }
        public Nullable<int> WorkersProductionNumber { get; set; }
    
        public virtual MeasurementUnits MeasurementUnits { get; set; }
        public virtual PartnerMinCostHistory PartnerMinCostHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartnerProduct> PartnerProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCount> ProductCount { get; set; }
        public virtual ProductType ProductType1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materials> Materials { get; set; }
    }
}