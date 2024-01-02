namespace TicTacToe.Patterns.Composite
{
    public class CompositeCell : IComponent
    {
        private List<IComponent> components = new List<IComponent>();

        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void Display(int indentationLevel)
        {
            foreach (var component in components)
            {
                component.Display(indentationLevel + 1);
            }
        }

        public string GetValue()
        {

            return string.Join(", ", components.Select(c => c.GetValue()));
        }
    }
}
