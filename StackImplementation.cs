public class Stack
{
    static readonly int MAX = 1000;
    int[] stack = new int[MAX];

    int top;
    public Stack()
    {
        top = -1;
    }
    public void push(int data)
    {
        if(top >=MAX)
        {

        }
        else
        {
            stack[++top] = data;
        }
    }

    public int pop()
    {
        if(top <0)
        {
            return 0;
        }
        else
        {

            int value = stack[top--];
            int index = Array.IndexOf(stack, value);
            stack[index] = 0;
            return value;
        }
    }

    public int peek()
    {
        return stack[top];
    }
}

public class Solution
{
    static void Main(string[] args)
    {
        Stack stack = new Stack();

        stack.push(10);
        stack.push(20);
        stack.push(30);

        int top = stack.peek();

        int popped = stack.pop();

        top = stack.peek();
    }
} 
