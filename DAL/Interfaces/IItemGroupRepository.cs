using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IItemGroupRepository
    {
        List<ItemGroupModel> GetData();
        ItemGroupModel GetDatabyID(string id);
        bool Create(ItemGroupModel model);
        bool Update(ItemGroupModel model);
        bool Delete(string id);
        List<ItemGroupModel> Search(int pageIndex, int pageSize, out long total, string item_group_name);
    }
}
