using System;
using System.Collections.Generic;

namespace Model
{
  public class ItemModel
  {
    public string item_id { get; set; }
    public string item_group_id { get; set; }
    public string item_name { get; set; }
    public string item_image { get; set; }
    public decimal? item_price { get; set; }
    public string item_color { get; set; }
    public string item_material { get; set; }
    public string item_width { get; set; }
    public string item_height { get; set; }
    public string item_depth { get; set; }
  }
}
