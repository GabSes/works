using System.Collections;
using TicTacToe.Patterns.Template;

namespace TicTacToe.Patterns.Iterator
{
    public class MessagesCollection : IteratorAggregate
    {
        List<Message> _collection = new List<Message>();
        
        public List<Message> getItems()
        {
            return this._collection;
        }

        public void AddItem(Message item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new SimpleIterator(this);
        }
    }
}
