using Veri_Yapilari_CS.Sozluk;

namespace Veri_Yapilari_CS.Graph
{
    public class GraphVertex<T>
    {
        public T Key { get; private set; }
        public Sozluk<GraphVertex<T>, float> InEdges { get; private set; } = new Sozluk<GraphVertex<T>, float>();
        public Sozluk<GraphVertex<T>, float> OutEdges { get; private set; } = new Sozluk<GraphVertex<T>, float>();

        public GraphVertex(T key)
        {
            Key = key;
        }
    }
}
