using System;


public class Stack : ICloneable {
    private object[] items;

    public int Count { get; private set; }

    public Stack(int length = 0) {
        items = new object[length == 0 ? 10 : length];
    }

    public void Push(object item) {
        grow();

        items[Count] = item;

        Count++;
    }

    public object Peek() {
        if (Count == 0)
            throw new InvalidOperationException("No items on stack.");

        return items[Count - 1];
    }

    public object Pop() {
        if (Count == 0)
            throw new InvalidOperationException("No items on stack.");

        object item = items[Count - 1];
        items[Count - 1] = default(object);
        Count--;

        return item;
    }

    public void Clear() {
        items = new object[10];
        Count = 0;
    }

    private void grow() {
        // Überprüfen, ob noch Platz
        if (items.Length >= Count + 1)
            return;

        // Array-Kapazität verdoppeln
        int newLength = items.Length * 2;

        Array.Resize(ref items, newLength);
    }



    public static void TestStack() {
        twoEmptyStacksWithSameCapacityShouldBeEqual();
        twoEmptyStacksWithDifferentCapacitiesShouldNotEqual();
        stackIsEqualToSelf();
        stacksWithEqualElementsShouldBeEqual();
        cloningShouldResultInEqualStacks();
        cloningAndChangingAStackShouldNotBeEqual();
    }

    private static void twoEmptyStacksWithSameCapacityShouldBeEqual() {
        Stack stack1 = new Stack(5);
        Stack stack2 = new Stack(5);
        Console.WriteLine(stack1 == stack2);
    }

    private static void twoEmptyStacksWithDifferentCapacitiesShouldNotEqual() {
        Stack stack1 = new Stack(1);
        Stack stack2 = new Stack(2);
        Console.WriteLine(stack1 == stack2);
    }

    private static void stackIsEqualToSelf() {
        Stack stack1 = new Stack(1);
        Console.WriteLine(stack1 == stack1);
    }

    private static void stacksWithEqualElementsShouldBeEqual() {
        Stack stack1 = new Stack(1);
        stack1.Push("ZbW");
        Stack stack2 = new Stack(1);
        stack2.Push("ZbW");
        Console.WriteLine(stack1 == stack2);
    }

    private static void cloningShouldResultInEqualStacks() {
        Stack stack1 = new Stack(2);
        stack1.Push("Hello");
        stack1.Push("ZbW");
        Stack stack2 = (Stack)stack1.Clone();
        Console.WriteLine(stack1 == stack2);
    }

    private static void cloningAndChangingAStackShouldNotBeEqual() {
        Stack stack1 = new Stack(2);
        Stack stack2 = (Stack)stack1.Clone();
        stack1.Push("Hello");
        Console.WriteLine(stack1 != stack2);
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }
}
