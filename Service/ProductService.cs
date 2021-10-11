using System.Collections.Generic;
using App.Models;

namespace App.Services{
    public class ProductService : List<ProductModel> {

        public ProductService(){
            this.AddRange(new ProductModel[]{
                new ProductModel() {Id = 1, Name = "Iphone X", Price = 1000},
                new ProductModel() {Id = 2, Name = "Iphone X", Price = 1000},
                new ProductModel() {Id = 3, Name = "Iphone X", Price = 1000},
                new ProductModel() {Id = 4, Name = "Iphone X", Price = 1000},
        });
        }
        
    }
}