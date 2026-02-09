using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test basic priorities.
    // Expected Result: The highest priority item should be dequeued first and the lowest priority item should be dequeued last
    //                  no matter the order they were enqueued.
    // Defect(s) Found: The item wasn't being dequeued.
    public void TestPriorityQueue_DifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 2);
        priorityQueue.Enqueue("High", 9);
        priorityQueue.Enqueue("Medium", 6);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result:  Dequeue should follow FIFO for items with same priority.
    // Defect(s) Found: Code was using >= instead of > 
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 8);
        priorityQueue.Enqueue("Second", 8);
        priorityQueue.Enqueue("Third", 8);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

   
    [TestMethod]
    // Scenario: Enqueue and dequeue with a single item
    // Expected Result: The single item is dequeued successfully
    // Defect(s) Found: Passes. No defects found. 
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyOne", 5);

        Assert.AreEqual("OnlyOne", priorityQueue.Dequeue());
    }

        [TestMethod]
    // Scenario: Enqueue and dequeue with a single item when priority is zero
    // Expected Result: The single item is dequeued successfully
    // Defect(s) Found: Passes. No defects found.
    public void TestPriorityQueue_SingleZero()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Zero", 0);

        Assert.AreEqual("Zero", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Can dequeue as expected when priorities match FIFO order.
    // Expected Result: dequeues as expected when priorities match FIFO order.
    // Defect(s) Found: Wasn't dequeuing.
    public void TestPriorityQueue_MatchingFIFOAndPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Five", 5);
        priorityQueue.Enqueue("Four", 4);
        priorityQueue.Enqueue("Three", 3);
        priorityQueue.Enqueue("Two", 2);
        priorityQueue.Enqueue("One", 1);

        Assert.AreEqual("Five", priorityQueue.Dequeue());
        Assert.AreEqual("Four", priorityQueue.Dequeue());
        Assert.AreEqual("Three", priorityQueue.Dequeue());
        Assert.AreEqual("Two", priorityQueue.Dequeue());
        Assert.AreEqual("One", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue with a priority of zero in the mix. 
    // Expected Result: The item of priority zero is dequeued successfully
    // Defect(s) Found: Wasn't dequeuing.
    public void TestPriorityQueue_CanHandlePriorityZero()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Two", 2);
        priorityQueue.Enqueue("One", 1);
        priorityQueue.Enqueue("Zero", 0);

        Assert.AreEqual("Two", priorityQueue.Dequeue());
        Assert.AreEqual("One", priorityQueue.Dequeue());
        Assert.AreEqual("Zero", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple priorities with some duplicates
    // Expected Result: Dequeue in correct priority order with FIFO for same priorities
    // Defect(s) Found: Uses >= instead of >. 
    public void TestPriorityQueue_ComplexMix()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 7);
        priorityQueue.Enqueue("E", 5);

        Assert.AreEqual("D", priorityQueue.Dequeue());  // Priority 7
        Assert.AreEqual("B", priorityQueue.Dequeue());  // Priority 5, first
        Assert.AreEqual("E", priorityQueue.Dequeue());  // Priority 5, second
        Assert.AreEqual("A", priorityQueue.Dequeue());  // Priority 3, first
        Assert.AreEqual("C", priorityQueue.Dequeue());  // Priority 3, second
    }
}
