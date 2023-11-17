using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCSharp.Object
{
    public class Product
    {
        public Guid Product_ID { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public string Product_Description { get; set;} = string.Empty;
        public string Product_Category {  get; set; } = string.Empty;
        public string Product_Version {  get; set; } = string.Empty;
        public string Product_Type {  get; set; } = string.Empty;
        public float Product_Price {  get; set; } = 0;
    }
}
