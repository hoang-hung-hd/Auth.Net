using System.Collections.Generic;
using App.Models;

namespace App.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id=1, Name="Nokia", Price=123},
                new ProductModel() {Id=2, Name="Samsung", Price=222},
                new ProductModel() {Id=3, Name="Redmi", Price=321},
                new ProductModel() {Id=4, Name="PoCo", Price=324},
                new ProductModel() {Id=5, Name="Xiaomi", Price=456}
            });
        }

    }
}