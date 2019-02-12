namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Producto")]
    public partial class Producto
    {
        public int ProductoID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductoCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int CategoriaID { get; set; }

        [Required]
        public int MarcaID { get; set; }

        [Required]
        public int UnidadMedidaID { get; set; }

        [Required]
        public decimal PrecioMayor { get; set; }

        [Required]
        public decimal PrecioMenor { get; set; }

        [Required]
        public decimal StockActual { get; set; }

        [Required]
        public decimal StockMinimo { get; set; }

        public bool Estado { get; set; }

        public Guid UsuarioCreador { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Guid? UsuarioModificador { get; set; }

        public DateTime? FechaModificacion { get; set; }

        //Configuraremos en el global asax para evitar recursividad al aplicar json
        public virtual Categoria Categoria { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
