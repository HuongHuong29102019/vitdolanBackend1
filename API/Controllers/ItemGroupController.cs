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
    public class ItemGroupController : ControllerBase
    {
        private IItemGroupBusiness _itemGroupBusiness;
        private string _path;
        public ItemGroupController(IItemGroupBusiness itemGroupBusiness, IConfiguration configuration)
        {
            _itemGroupBusiness = itemGroupBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        //vd
        [Route("get-menu")]
        [HttpGet]
        public IEnumerable<ItemGroupModel> GetAllMenu()
        {
            return _itemGroupBusiness.GetData();
        }

        [AllowAnonymous]
        [Route("delete-itemgroup")]
        [HttpPost]
        public IActionResult DeleteItemGroup([FromBody] Dictionary<string, object> formData)
        {
            string item_group_id = "";
            if (formData.Keys.Contains("item_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_group_id"]))) { item_group_id = Convert.ToString(formData["item_group_id"]); }
            _itemGroupBusiness.Delete(item_group_id);
            return Ok();
        }

        [Route("create-itemgroup")]
        [HttpPost]
        public ItemGroupModel CreateItemGroup([FromBody] ItemGroupModel model)
        {
            model.item_group_id = Guid.NewGuid().ToString();
            _itemGroupBusiness.Create(model);
            return model;
        }

        [Route("update-itemgroup")]
        [HttpPost]
        public ItemGroupModel UpdateItemGroup([FromBody] ItemGroupModel model)
        {
            _itemGroupBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ItemGroupModel GetDatabyID(string id)
        {
            return _itemGroupBusiness.GetDatabyID(id);
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
                string item_group_name = "";
                if (formData.Keys.Contains("item_group_name") && !string.IsNullOrEmpty(Convert.ToString(formData["item_group_name"]))) { item_group_name = Convert.ToString(formData["item_group_name"]); }
                long total = 0;
                var data = _itemGroupBusiness.Search(page, pageSize, out total, item_group_name);
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
