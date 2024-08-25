﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC_CoffeeShopSystem.BaseURL;
using WebAPI_CoffeeShop.Models.ModelView;
using System.Web.Razor.Tokenizer.Symbols;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class ProductsCall
    {
        ProductsCall() { }
        private static ProductsCall instance = null;
        public static ProductsCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductsCall();
                }
                return instance;
            }
        }
        public List<ProductView> getProducts()
        {
            List<ProductView> prodInfo = new List<ProductView>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource getProducts using HttpClient
                HttpResponseMessage Res = client.GetAsync(productUrl.getProducts).GetAwaiter().GetResult();
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    //Deserializing the response recieved from web api and storing into the product list
                    prodInfo = JsonConvert.DeserializeObject<List<ProductView>>(prodResponse);
                }
                //returning the product list to view
                return prodInfo;
            }
        }
        public ProductView GetDetailsProduct(int? idProd)
        {
            ProductView prodInfo = new ProductView();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync(productUrl.getDetailsProduct + "?idProd=" + idProd).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<ProductView>(prodResponse);
                }
                return prodInfo;
            }
        }

        public List<ProductView> SearchProductsByKeyWord(string keyword)
        {
            List<ProductView> prodInfo = new List<ProductView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(productUrl.SearchProductsByKeyWord + "?keyword=" + keyword).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<ProductView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public List<ProductView> SearchProductsByCategory(string lsIdCategory)
        {
            List<ProductView> prodInfo = new List<ProductView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(productUrl.SearchProductsByCategory + "?lsIdCategory=" + lsIdCategory).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<ProductView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public List<ProductView> SearchProductsByPrice(int typePrice)
        {
            List<ProductView> prodInfo = new List<ProductView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(productUrl.SearchProductsByPrice + "?typePrice=" + typePrice).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<ProductView>>(prodResponse);
                }
                return prodInfo;
            }
        }

    }
}