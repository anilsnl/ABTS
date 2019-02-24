﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABTS.API.Models;
using ABTS.BLL.Abstract;
using ABTS.Entities.Concerete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABTS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager _productManager)
        {
            this._productManager = _productManager;
        }
        /// <summary>
        /// Get products related to given conditions.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductList([FromBody]ProductListModel model)
        {
            List<Products> response = await _productManager.GetProductList(columnName: model.columnName, page: model.page, pageSize: model.pageSize, isDesc: model.isDesc).ToListAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var response = await _productManager.GetAsync(a => a.ProductId == id);
            if (response==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

    }
}