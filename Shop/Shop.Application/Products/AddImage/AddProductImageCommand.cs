﻿using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommand:IBaseCommand
    {
        public AddProductImageCommand(long productId, IFormFile imageFile, int sequence)
        {
            ProductId = productId;
            ImageFile = imageFile;
            Sequence = sequence;
        }

        public long ProductId { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public int Sequence { get; private set; }
    }
}