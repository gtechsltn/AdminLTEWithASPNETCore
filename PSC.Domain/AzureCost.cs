﻿using PSC.Domain.CommonTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Domain
{
    /// <summary>
    /// Class AzureCost.
    /// </summary>
    [Table("AzureCosts")]
    public class AzureCost
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        public long ResourceId { get; set; }
        /// <summary>
        /// Gets or sets the azure resource.
        /// </summary>
        /// <value>The azure resource.</value>
        [ForeignKey("ResourceId")]
        public AzureResource AzureResource { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>The location identifier.</value>
        public long LocationId { get; set; }
        /// <summary>
        /// Gets or sets the azure location.
        /// </summary>
        /// <value>The azure location.</value>
        [ForeignKey("LocationId")]
        public AzureLocation AzureLocation { get; set; }

        /// <summary>
        /// Gets or sets the resource group identifier.
        /// </summary>
        /// <value>The resource group identifier.</value>
        public long ResourceGroupId { get; set; }
        /// <summary>
        /// Gets or sets the azure resource group.
        /// </summary>
        /// <value>The azure resource group.</value>
        [ForeignKey("ResourceGroupId")]
        public AzureResourceGroup AzureResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        public long CategoryId { get; set; }
        /// <summary>
        /// Gets or sets the azure category.
        /// </summary>
        /// <value>The azure category.</value>
        [ForeignKey("CategoryId")]
        public AzureCategory AzureCategory { get; set; }

        /// <summary>
        /// Gets or sets the subcategory identifier.
        /// </summary>
        /// <value>The subcategory identifier.</value>
        public long SubcategoryId { get; set; }
        /// <summary>
        /// Gets or sets the azure subcategory.
        /// </summary>
        /// <value>The azure subcategory.</value>
        [ForeignKey("SubcategoryId")]
        public AzureSubcategory AzureSubcategory { get; set; }

        public long? AzureCostImportId { get; set; }
        [ForeignKey("AzureCostImportId")]
        public AzureCostImport AzureCostImport { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public decimal Cost { get; set; }
    }
}
