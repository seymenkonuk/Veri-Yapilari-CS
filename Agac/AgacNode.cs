using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veri_Yapilari_CS.Liste;

namespace Veri_Yapilari_CS.Agac
{
    internal class AgacNode<T>
    {
        public T Value { get; set; }
        public readonly Liste<AgacNode<T>> Children = new Liste<AgacNode<T>>();
        public AgacNode(T value)
        {
            Value = value;
        }
    }
}
