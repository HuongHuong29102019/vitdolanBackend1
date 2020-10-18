using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;


namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemBusiness _itemBusiness;
        private string _path;
        public ItemController(IItemBusiness itemBusiness, IConfiguration configuration)
        {
            _itemBusiness = itemBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [AllowAnonymous]
        [Route("delete-item")]
        [HttpPost]
        public IActionResult DeleteItem([FromBody] Dictionary<string, object> formData)
        {
            string item_id = "";
            if (formData.Keys.Contains("item_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_id"]))) { item_id = Convert.ToString(formData["item_id"]); }
            _itemBusiness.Delete(item_id);
            return Ok();
        }
        [Route("update-item")]
        [HttpPost]
        public ItemModel UpdateItem([FromBody] ItemModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }
        [Route("create-item")]
        [HttpPost]
        public ItemModel CreateItem([FromBody] ItemModel model)
        {
            model.item_id = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ItemModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
        [Route("get-same-item")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDataSameItem()
        {
            return _itemBusiness.GetDataSameItem();
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string item_group_id = "";
                if (formData.Keys.Contains("item_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_group_id"]))) { item_group_id = Convert.ToString(formData["item_group_id"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, item_group_id);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        [Route("searchadmin")]
        [HttpPost]
        public ResponseModel SearchItemName([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string item_name = "";
                if (formData.Keys.Contains("item_name") && !string.IsNullOrEmpty(Convert.ToString(formData["item_name"]))) { item_name = Convert.ToString(formData["item_name"]); }
                long total = 0;
                var data = _itemBusiness.SearchItemName(page, pageSize, out total, item_name);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

    }
}
