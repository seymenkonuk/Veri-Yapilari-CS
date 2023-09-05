using Veri_Yapilari_CS.Liste;

namespace Veri_Yapilari_CS.Agac
{
    public class AgacNode<T>
    {
        public T Value { get; set; }
        public readonly Liste<AgacNode<T>> Children = new Liste<AgacNode<T>>();
        public AgacNode(T value)
        {
            Value = value;
        }
    }
}
