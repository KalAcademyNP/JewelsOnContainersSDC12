﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class APIPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}/catalogtypes";
            }
            public static string GetAllBrands(string baseUri)
            {
                return $"{baseUri}/catalogbrands";
            }
            public static string GetAllCatalogItems(string baseUri, int page, int take, 
                int? brand, int? type)
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;
                if (brand.HasValue)
                {
                    filterQs = $"catalogBrandId={brand.Value}";
                }
                if (type.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ? 
                        $"catalogTypeId={brand.Value}" : 
                        $"&catalogTypeId={brand.Value}";
                }

                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUri}/items?pageIndex={page}&pageSize={take}";
                } else
                {
                    preUri = $"{baseUri}/items/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }
                return preUri;
            }
        }
    }
}