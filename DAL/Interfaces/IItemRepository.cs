using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IItemRepository
    {
        bool Create(ItemModel model);
        ItemModel GetDatabyID(string id);
        List<ItemModel> GetDataAll();
        List<ItemModel> GetDataSameItem();
        List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
        bool Update(ItemModel model);
        bool Delete(string id);
        List<ItemModel> SearchItemName(int pageIndex, int pageSize, out long total, string item_name);
    }
}
