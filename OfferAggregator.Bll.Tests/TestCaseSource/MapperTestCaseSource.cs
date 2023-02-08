﻿using OfferAggregator.Bll.Models;
using OfferAggregator.Dal.Models;
using System.Collections;

namespace OfferAggregator.Bll.Tests.TestCaseSource
{
    public class MapperTestCaseSource
    {
        public static IEnumerable MapProductsDtosToProductModelsTestCaseSource()
        {
            ProductsDto productsDto1 = new ProductsDto
            {
                Id = 1,
                Name = "one",
                IsDeleted = false,
                GroupId = 1
            };
            ProductsDto productsDto2 = new ProductsDto
            {
                Id = 2,
                Name = "two",
                IsDeleted = false,
                GroupId = 2
            };
            List<ProductsDto> baseProductsDto = new List<ProductsDto> { productsDto1, productsDto2 };

            ProductModel productModel1 = new ProductModel
            {
                Id = 1,
                Name = "one",
                IsDeleted = false,
                GroupId = 1
            };
            ProductModel productModel2 = new ProductModel
            {
                Id = 2,
                Name = "two",
                IsDeleted = false,
                GroupId = 2
            };
            List<ProductModel> expectedProductModel = new List<ProductModel> { productModel1, productModel2 };

            yield return new object[] { baseProductsDto, expectedProductModel };


            baseProductsDto = new List<ProductsDto>();

            expectedProductModel = new List<ProductModel>();

            yield return new object[] { baseProductsDto, expectedProductModel };


            ProductsDto productsDto10 = new ProductsDto();
            ProductsDto productsDto20 = new ProductsDto
            {
                Id = 20,
                Name = "two2",
                IsDeleted = true,
                GroupId = 20
            };
            baseProductsDto = new List<ProductsDto> { productsDto10, productsDto20 };

            ProductModel productModel10 = new ProductModel();
            ProductModel productModel20 = new ProductModel
            {
                Id = 20,
                Name = "two2",
                IsDeleted = true,
                GroupId = 20
            };
            expectedProductModel = new List<ProductModel> { productModel10, productModel20 };

            yield return new object[] { baseProductsDto, expectedProductModel };
        }

        public static IEnumerable MapProductModelToProductsDtoTestCaseSource()
        {
            ProductModel baseProductModel = new ProductModel
            {
                Id = 10,
                Name = "ten",
                IsDeleted = false,
                GroupId = 12
            };
            ProductsDto expectedProductsDto = new ProductsDto
            {
                Id = 10,
                Name = "ten",
                IsDeleted = false,
                GroupId = 12
            };

            yield return new object[] { baseProductModel , expectedProductsDto };
        }
    }
}