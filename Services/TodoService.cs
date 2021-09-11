using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TodoList
{
    public class TodoItem
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public bool Checked { get; set; }
    }

    public interface ITodoService
    {
        event Action OnChanged;
        IEnumerable<TodoItem> GetTodos();
        void AddTodo(TodoItem item);
        void RemoveTodo(TodoItem item);
        void ToggleTodo(TodoItem item);
        int GetCompletedItemsCount();
        void RemoveAllChecked();
    }

    public class TodoService : ITodoService
    {
        public event Action OnChanged;

        private List<TodoItem> Items;
        public static int ItemsCompleted = 0;

        public TodoService()
        {
            Items = new List<TodoItem>();
            Items.Add(new TodoItem { Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            Items.Add(new TodoItem { Name = "Ut vel gravida nisi, vel laoreet elit. Praesent vel pulvinar justo, vel sodales augue. Fusce sodales elit vel arcu blandit, at malesuada leo lobortis." });
            Items.Add(new TodoItem { Name = "Sed aliquam ligula ac finibus commodo" });
            Items.Add(new TodoItem { Name = "Cras interdum arcu a nisl tristique blandit." });
            Items.Add(new TodoItem { Name = "Ut tincidunt nunc nisl, non varius felis hendrerit ac. Nullam lacinia lorem ac orci ornare, non facilisis sapien scelerisque. Duis mi erat, tincidunt sed libero vel, laoreet cursus arcu. Curabitur ac hendrerit tortor, ut iaculis tortor. " });
            Items.Add(new TodoItem { Name = "Vestibulum quam mauris, ultricies eget ante sit amet, fringilla imperdiet nibh." });
            Items.Add(new TodoItem { Name = "Donec ac mauris faucibus." });
            Items.Add(new TodoItem { Name = "Fusce tempus dignissim justo vel blandit." });
            Items.Add(new TodoItem { Name = "Morbi laoreet magna orci." });
            Items.Add(new TodoItem { Name = "Cras interdum arcu." });
        }

        private void DispatchOnChanged()
        {
            OnChanged?.Invoke();
        }

        public void AddTodo(TodoItem item)
        {
            Items.Add(item);
            DispatchOnChanged();
        }

        public IEnumerable<TodoItem> GetTodos()
        {
            return Items;
        }

        public void RemoveTodo(TodoItem item)
        {
            Items.Remove(item);
            DispatchOnChanged();
        }

        public void ToggleTodo(TodoItem item)
        {
            item.Checked = !item.Checked;

            if (Items.Contains(item))
            {
                ItemsCompleted += item.Checked ? 1 : -1;
                DispatchOnChanged();
            }
        }

        public int GetCompletedItemsCount()
        {
            return ItemsCompleted;
        }

        public void RemoveAllChecked()
        {
            var toRemove = Items.Where(x => x.Checked).ToArray();
            foreach (var item in toRemove)
                Items.Remove(item);

            DispatchOnChanged();
        }
    }
}
