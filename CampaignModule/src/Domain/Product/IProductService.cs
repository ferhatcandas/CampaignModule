﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Product
{
    public interface IProductService
    {
        void AddProduct(string productCode, double price, int stock);
        ProductDto GetProduct(string productCode);
        ProductDto DecraseProductStock(string productCode,int count);

    }
}