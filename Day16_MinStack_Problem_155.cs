/*
 * Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
 * 
 * Implement the MinStack class:
 * 
 * MinStack() initializes the stack object.
 * void push(int val) pushes the element val onto the stack.
 * void pop() removes the element on the top of the stack.
 * int top() gets the top element of the stack.
 * int getMin() retrieves the minimum element in the stack.
 * You must implement a solution with O(1) time complexity for each function.
 * 
 *  
 * 
 * Example 1:
 * 
 * Input
 * ["MinStack","push","push","push","getMin","pop","top","getMin"]
 * [[],[-2],[0],[-3],[],[],[],[]]
 * 
 * Output
 * [null,null,null,null,-3,null,0,-2]
 * 
 * Explanation
 * MinStack minStack = new MinStack();
 * minStack.push(-2);
 * minStack.push(0);
 * minStack.push(-3);
 * minStack.getMin(); // return -3
 * minStack.pop();
 * minStack.top();    // return 0
 * minStack.getMin(); // return -2
 *  
 * 
 * Constraints:
 * 
 * -231 <= val <= 231 - 1
 * Methods pop, top and getMin operations will always be called on non-empty stacks.
 * At most 3 * 104 calls will be made to push, pop, top, and getMin.
 * 
*/

public class MinStack
{
    public Stack stack;
    public Stack minStack;
    public MinStack()
    {
        stack = new Stack();
        minStack = new Stack();
    }

    public void Push(int val)
    {
        if (minStack.Count > 0)
        {
            if (Convert.ToInt32(minStack.Peek()) >= val)
            {
                minStack.Push(val);
            }
        }
        else
        {
            minStack.Push(val);
        }

        stack.Push(val);
    }

    public void Pop()
    {
        int val = Convert.ToInt32(stack.Pop());

        if (minStack.Count > 0 && Convert.ToInt32(minStack.Peek()) == val)
        {
            minStack.Pop();
        }
    }

    public int Top()
    {
        return Convert.ToInt32(stack.Peek());
    }

    public int GetMin()
    {
        return Convert.ToInt32(minStack.Peek());
    }
}


/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
