using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Core
{
    [XmlInclude(typeof(Grass))]
    [XmlInclude(typeof(Grass_2))]
    [XmlInclude(typeof(Herbivorous_1))]
    [DataContract]
    [KnownType(typeof(Grass))]
    [KnownType(typeof(Grass_2))]
    [KnownType(typeof(Herbivorous_1))]
    public abstract class ContentBase
    {
        [DataMember]
        public int PosX;
        [DataMember]
        public int PosY;
        [DataMember]
        public char Icon { get; set; }

        public ContentBase()
        {

        }

       // [DataMember]
       // [XmlElement]
        public virtual IBehavior Behavior { get; }

        public ContentBase(int x, int y, char ico)
        {
            PosX = x;
            PosY = y;
            Icon = ico;
        }

        public static implicit operator bool(ContentBase content)
        {
            return content != null;
        }
    }
}
