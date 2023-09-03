namespace Veri_Yapilari_CS.BagliListe
{
    public class BagliListeNode<T>
    {
        public T Value { get; set; }
        public BagliListeNode<T> Prev {  get; set; }
        public BagliListeNode<T> Next { get; set; }

        public BagliListeNode(T value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }
}
