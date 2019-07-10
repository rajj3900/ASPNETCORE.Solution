//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(Store.Data.StoreEntities),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets2e703c1b64fda5d6940527a9b6bfaca91a00039184ef0e948ea2a2c796a347f8))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework 6 Power Tools", "0.9.2.0")]
    internal sealed class ViewsForBaseEntitySets2e703c1b64fda5d6940527a9b6bfaca91a00039184ef0e948ea2a2c796a347f8 : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "2e703c1b64fda5d6940527a9b6bfaca91a00039184ef0e948ea2a2c796a347f8"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "StoreModelStoreContainer.Country")
            {
                return GetView0();
            }

            if (extentName == "StoreModelStoreContainer.Store")
            {
                return GetView1();
            }

            if (extentName == "StoreEntities.Countries")
            {
                return GetView2();
            }

            if (extentName == "StoreEntities.Stores")
            {
                return GetView3();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for StoreModelStoreContainer.Country.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Country
        [StoreModel.Store.Country](T1.Country_Id, T1.Country_Code, T1.Country_Name, T1.Country_CreatedUser, T1.Country_CreatedDate)
    FROM (
        SELECT 
            T.Id AS Country_Id, 
            T.Code AS Country_Code, 
            T.Name AS Country_Name, 
            T.CreatedUser AS Country_CreatedUser, 
            T.CreatedDate AS Country_CreatedDate, 
            True AS _from0
        FROM StoreEntities.Countries AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for StoreModelStoreContainer.Store.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Store
        [StoreModel.Store.Store](T1.Store_Id, T1.Store_StoreCode, T1.Store_StoreName, T1.Store_CountryId, T1.Store_CreatedUser, T1.Store_CreatedDate)
    FROM (
        SELECT 
            T.Id AS Store_Id, 
            T.StoreCode AS Store_StoreCode, 
            T.StoreName AS Store_StoreName, 
            T.CountryId AS Store_CountryId, 
            T.CreatedUser AS Store_CreatedUser, 
            T.CreatedDate AS Store_CreatedDate, 
            True AS _from0
        FROM StoreEntities.Stores AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for StoreEntities.Countries.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView2()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Countries
        [StoreModel.Country](T1.Country_Id, T1.Country_Code, T1.Country_Name, T1.Country_CreatedUser, T1.Country_CreatedDate)
    FROM (
        SELECT 
            T.Id AS Country_Id, 
            T.Code AS Country_Code, 
            T.Name AS Country_Name, 
            T.CreatedUser AS Country_CreatedUser, 
            T.CreatedDate AS Country_CreatedDate, 
            True AS _from0
        FROM StoreModelStoreContainer.Country AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for StoreEntities.Stores.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView3()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Stores
        [StoreModel.Store](T1.Store_Id, T1.Store_StoreCode, T1.Store_StoreName, T1.Store_CountryId, T1.Store_CreatedUser, T1.Store_CreatedDate)
    FROM (
        SELECT 
            T.Id AS Store_Id, 
            T.StoreCode AS Store_StoreCode, 
            T.StoreName AS Store_StoreName, 
            T.CountryId AS Store_CountryId, 
            T.CreatedUser AS Store_CreatedUser, 
            T.CreatedDate AS Store_CreatedDate, 
            True AS _from0
        FROM StoreModelStoreContainer.Store AS T
    ) AS T1");
        }
    }
}
