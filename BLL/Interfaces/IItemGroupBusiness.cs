using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IItemGroupBusiness
    {
        List<ItemGroupModel> GetData();
        ItemGroupModel GetDatabyID(string id);
        bool Create(ItemGroupModel model);
        bool Update(ItemGroupModel model);
        bool Delete(string id);
        List<ItemGroupModel> Search(int pageIndex, int pageSize, out long total, string item_group_name);
    }
}
