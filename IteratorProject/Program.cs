
DataStack stack = new DataStack();
for (int i = 0; i < 5; i++) stack.Push(i);
DataStack stack2 = new DataStack(stack);
Console.WriteLine(stack==stack2);
stack2.Push(10);
Console.WriteLine(stack==stack2);
class DataStack
{
    private int[] items= new int[10];
    private int length;
    public DataStack() => length = -1;
    public DataStack(DataStack myStack)
    {
        this.items = myStack.items;
        this.length = myStack.length;
    }
    public int[] Items { get => items; }
    public int Length { get => length; }
    public void Push(int value) =>items[++length] = value;
    public int Pop() =>items[length--];
    public static bool operator ==(DataStack left, DataStack right)
    {
        StackIterator it1=new StackIterator(left);
        StackIterator it2=new StackIterator(right);
        while (it1.IsEnd() || it2.IsEnd())
        {
            if (it1.Get() != it2.Get()) break;
            it1++;
            it2++;
        }
        return !it1.IsEnd()&&!it2.IsEnd();
    }
    public static bool operator !=(DataStack left, DataStack right)
    {
        return !(left == right);
    }
}

class StackIterator
{
    private DataStack stack;
    private int index;
    public StackIterator(DataStack myStack)
    {
        this.stack = myStack;
        this.index = 0;
    }
    public static StackIterator operator ++(StackIterator s)
    {
        s.index++;
        return s;
    }
    public int Get()
    {
        if(index<stack.Length) return stack.Items[index];
        return 0;
    }
    public bool IsEnd() => index != stack.Length + 1;
}
