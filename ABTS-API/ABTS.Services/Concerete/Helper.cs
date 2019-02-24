﻿using ABTS.Entities.Abstract;
using ABTS.Entities.Concerete;
using Nest;
using System;
using System.Collections.Generic;

namespace ABTS.ElasticSearchService.Concerete
{
    public class Helper
    {
        private readonly ElasticClient _elasticClient;
        public Helper(string connectionSettings)
        {
            _elasticClient = new ElasticClient(new ConnectionSettings(new Uri(connectionSettings)));
        }
        public Helper()
        {
            var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"));
            _elasticClient = new ElasticClient(connectionSettings);
        }
        public bool CreateIndexProduct(string indexName)
        {
            var createIndexDescriptor = new CreateIndexDescriptor(indexName)
                .Mappings(ms => ms
                .Map<Products>(m => m
                .AutoMap()
                .Properties(ps => ps
                .Completion(c => c
                .Name(p => p.ProductName)
                .Name(p => p.ProductId)
                .Name(t => t.CategoryId)
                .Name(t => t.SupplierId))))
             );
            ICreateIndexResponse createIndexResponse = _elasticClient.CreateIndex(createIndexDescriptor);
            return createIndexResponse.IsValid;
        }
        public bool CreateIndexCategories(string indexName)
        {
            var createIndexDescriptor = new CreateIndexDescriptor(indexName)
                .Mappings(ms => ms
                .Map<Categories>(m => m
                .AutoMap()
                .Properties(ps => ps
                .Completion(c => c
                .Name(p => p.CategoryName)
                .Name(p => p.CategoryId)
                )))
             );
            ICreateIndexResponse createIndexResponse = _elasticClient.CreateIndex(createIndexDescriptor);
            return createIndexResponse.IsValid;
        }
        public bool CreateIndexSuppliers(string indexName)
        {
            var createIndexDescriptor = new CreateIndexDescriptor(indexName)
                .Mappings(ms => ms
                .Map<Suppliers>(m => m
                .AutoMap()
                .Properties(ps => ps
                .Completion(c => c
                .Name(p => p.CompanyName)
                .Name(p => p.SupplierId)
                .Name(t => t.City))))
             );
            ICreateIndexResponse createIndexResponse = _elasticClient.CreateIndex(createIndexDescriptor);
            return createIndexResponse.IsValid;
        }
        public bool AddMany(string indexName, IEnumerable<IEntity> products) =>
             _elasticClient.IndexMany(products, indexName).IsValid;
        public bool IndexExists(string indexName)
        {
            bool isExists = _elasticClient.IndexExists(indexName.ToLowerInvariant()).Exists;
            return isExists;
        }
    }
}
