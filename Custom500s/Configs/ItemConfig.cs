using Custom500s;
using System.Collections.Generic;
using System.ComponentModel;


namespace Custom500s.Configs
{
    public class ItemConfig
    {

        [Description("The list of Custom 500s")]
        public List<SCP330> SCP330s { get; private set; } = new List<SCP330>()
        {
            new SCP330() {Type = ItemType.SCP500},
        };
    }
}
