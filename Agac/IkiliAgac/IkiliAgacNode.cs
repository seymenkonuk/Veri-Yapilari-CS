namespace Veri_Yapilari_CS.Agac.IkiliAgac
{
    public class IkiliAgacNode<T>
    {
        public T Value { get; set; }
        public IkiliAgacNode<T> Left { get; set; }
        public IkiliAgacNode<T> Right { get; set; }

        public IkiliAgacNode(T value)
        {
            Value = value;
        }
    }
}
