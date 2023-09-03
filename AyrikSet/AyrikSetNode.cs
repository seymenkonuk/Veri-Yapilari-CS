namespace Veri_Yapilari_CS.AyrikSet
{
    public class AyrikSetNode<T>
    {
        public T Value {  get; set; }
        public AyrikSetNode<T> Parent { get; set; }
        public AyrikSetNode(T value)
        {
            Value = value;
        }
    }
}
