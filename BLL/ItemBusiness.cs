using DAL;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ItemBusiness : IItemBusiness
    {
        private IItemRepository _res;
        private string Secret;
        public ItemBusiness(IItemRepository ItemGroupRes, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = ItemGroupRes;
        }
        public bool Create(ItemModel model)
        {
            return _res.Create(model);
        }
        public ItemModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ItemModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<ItemModel> GetDataSameItem()
        {
            return _res.GetDataSameItem();
        }
        public List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id)
        {
            return _res.Search(pageIndex, pageSize, out total, item_group_id);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(ItemModel model)
        {
            return _res.Update(model);
        }
        public List<ItemModel> SearchItemName(int pageIndex, int pageSize, out long total, string item_name)
        {
            return _res.SearchItemName(pageIndex, pageSize, out total, item_name);
        }
    }

}
